#include "main.h"

//#define DEBUG_ADDRESSS_DECODER

//-----------------------------------------------------------------------------
// Memory Hook for CPU
//-----------------------------------------------------------------------------
UINT8
MemoryRead8(
  MEMORY_CONTROL_PROTOCOL *Protocol,
  UINTN Ip
) {
  UINT8 Data;
  int Index;
  VM_CLASS *This;
  BASE_DEVICE_CLASS *Device;

  This = _CR(Protocol, VM_CLASS, MemoryControl);
  Index = (Ip >> ADDRESS_MASK_BITS) & ADDRESS_INDEX_MASK;
  Device = This->DeviceMappingTable[Index];
  Data = Device->Read8(Ip);
  //
  // Update ShadowMemory for Disassembly
  //
  if (This->ShadowMemory) {
    This->ShadowMemory[Ip] = Data;
  }
  //
  // Record memory action
  //
  int wp = This->MemoryAccessIndex;
  MEMORY_ACCESS *record = &This->MemoryAccessHistory[wp];
  record->Mode = MEMORY_ACCESS_READ;
  record->Address = (UINT16)Ip;
  record->Data = Data;
  wp = (wp + 1) & MEMORY_ACCESS_MASK;
  This->MemoryAccessIndex = wp;
  if (This->MemoryAccessCount < MEMORY_ACCESS_MAX) {
    This->MemoryAccessCount++;
  }

#ifdef DEBUG_ADDRESSS_DECODER
  DebugOut(L"R8,0x%lX=0x%08X", Ip, Data);
#endif  
  return Data;
}

VOID
MemoryWrite8(
  MEMORY_CONTROL_PROTOCOL *Protocol,
  UINTN Ip,
  UINT8 Data
) {
  int Index;
  VM_CLASS *This;
  BASE_DEVICE_CLASS *Device;

#ifdef DEBUG_ADDRESSS_DECODER  
  DebugOut(L"W8,0x%lX=0x%08X", Ip, Data);
#endif  
  This = _CR(Protocol, VM_CLASS, MemoryControl);
  Index = (Ip >> ADDRESS_MASK_BITS) & ADDRESS_INDEX_MASK;
  Device = This->DeviceMappingTable[Index];
  //
  // Update ShadowMemory for Disassembly
  //
  if (Device->ReadOnly == false) {
    if (This->ShadowMemory) {
      This->ShadowMemory[Ip] = Data;
    }
    Device->Write8(Ip, Data);
  }
  //
  // Record memory action
  //
  int wp = This->MemoryAccessIndex;
  MEMORY_ACCESS *record = &This->MemoryAccessHistory[wp];
  record->Mode = MEMORY_ACCESS_WRITE;
  record->Address = (UINT16)Ip;
  record->Data = Data;
  wp = (wp + 1) & MEMORY_ACCESS_MASK;
  This->MemoryAccessIndex = wp;
  if (This->MemoryAccessCount < MEMORY_ACCESS_MAX) {
    This->MemoryAccessCount++;
  }
}

UINT16
MemoryRead16(
  MEMORY_CONTROL_PROTOCOL *Protocol,
  UINTN Ip
  ) 
{
  assert(false);
  return 0;
}

VOID
MemoryWrite16(
  MEMORY_CONTROL_PROTOCOL *Protocol,
  UINTN Ip,
  UINT16 Data
  )
{
  assert(false);
}

UINT32
MemoryRead32(
  MEMORY_CONTROL_PROTOCOL *Protocol,
  UINTN Ip
  ) 
{
  assert(false);
  return 0;
}

VOID
MemoryWrite32(
  MEMORY_CONTROL_PROTOCOL *Protocol,
  UINTN Ip,
  UINT32 Data
  ) 
{
  assert(false);
}

char *VM_CLASS::Talk(char *message) {
  string jstr;
  BASE_DEVICE_CLASS *dev;
  DNA_STATUS status;
  json jst;
  string target;
  string command;

  jst = {};
  jstr = message;
  auto j = json::parse(jstr);
  target = j["Target"];
  if (target == "XIO") {
    status = this->FindDevice("XIO", &dev);
    jst = dev->Talk(j);
  } else if (target == "CPU") {
    jst = this->CPU->Talk(j);
  } else if (target == "VM") {
    command = j["Command"];
    if (command == "Reload") {
      jst = this->Reload();
    } else {
      jst["Status"] = "Failed";
      jst["Message"] = "Command not found";
    }    
  } else {
    jst["Status"] = "Failed";
    jst["Message"] = "Target not found";
  }

  return ExportJsonString(jst);
}

//-----------------------------------------------------------------------------
// Private Functions
//-----------------------------------------------------------------------------
void VM_CLASS::AddDevice(BASE_DEVICE_CLASS *Device, UINTN Address, UINTN Size) {
  int i;
  UINTN addr;

  Device->VM = this;
  Device->Base = Address;
  //
  // Add to device list for manager device resources
  //
  for (i = 0; i < MAX_DEVICE_COUNT; i++) {
    if (this->DeviceList[i] == NULL) {
      this->DeviceList[i] = Device;
      break;
    }
  }

  //
  // Add Device to Mapping Table
  //
  for (i = 0; i < 16; i++) {
    addr = i << ADDRESS_MASK_BITS;
    if (addr >= Address && addr <= Address + Size) {
      this->DeviceMappingTable[i] = Device;
    }
  }
}

//-----------------------------------------------------------------------------
// Public Functions
//-----------------------------------------------------------------------------
DNA_STATUS VM_CLASS::AddDeviceROM(UINT16 base, UINT16 size, UINT8 *buffer) {
  DNA_STATUS Status;
  ROM_DEVICE_CLASS *ROM;

  ROM = new ROM_DEVICE_CLASS(size);
  ROM->LoadImage(buffer, size);
  this->AddDevice(ROM, base, size);
  if (this->ShadowMemory) {
    memcpy(this->ShadowMemory + base, buffer, size);
  }
  Status = DNA_SUCCESS;

  return Status;
}

DNA_STATUS VM_CLASS::AddDeviceROM(UINT16 base, UINT16 size, string filename) {
  DNA_STATUS Status;
  ROM_DEVICE_CLASS *ROM;

  ROM = new ROM_DEVICE_CLASS(size);
  ROM->LoadFile(filename);
  this->AddDevice(ROM, base, size);
  if (this->ShadowMemory) {
    memcpy(this->ShadowMemory + base, ROM->Buffer, size);
  }
  Status = DNA_SUCCESS;

  return Status;
}

DNA_STATUS VM_CLASS::AddDeviceRAM(UINT16 base, UINT16 size) {
  DNA_STATUS Status;
  RAM_DEVICE_CLASS *RAM;

  RAM = new RAM_DEVICE_CLASS(size);
  this->AddDevice(RAM, base, size);
  Status = DNA_SUCCESS;

  return Status;
}

DNA_STATUS VM_CLASS::AddDeviceXIO(UINT16 base, UINT16 size) {
  DNA_STATUS Status;
  XIO_DEVICE_CLASS *XIO;

  XIO = new XIO_DEVICE_CLASS(size);
  this->AddDevice(XIO, base, size);
  Status = DNA_SUCCESS;

  return Status;
}
DNA_STATUS VM_CLASS::FindDevice(string Type, BASE_DEVICE_CLASS **Device) {
  return FindDevice(Type, Device, 0);
}

DNA_STATUS VM_CLASS::FindDevice(string Type, BASE_DEVICE_CLASS **Device, int Index) {
  DNA_STATUS status;
  BASE_DEVICE_CLASS *dev;
  int i;

  status = DNA_NOT_FOUND;
  for (i = 0; i < MAX_DEVICE_COUNT; i++) {
    if (this->DeviceList[i] != NULL) {
      dev = this->DeviceList[i];
      if (dev->Type == Type) {
        if (Index == 0) {
          *Device = dev;
          status = DNA_SUCCESS;
          break;
        } else {
          Index--;
        }
      }
    }
  }

  return status;
}

DNA_STATUS VM_CLASS::Reset() {
  DNA_STATUS Status;

  //
  // Clear Memory History
  //
  this->MemoryAccessIndex = 0;
  this->MemoryAccessCount = 0;
  //
  // Reset Processor
  //
  this->CpuControl->Reset(this->CpuControl);
  Status = DNA_SUCCESS;

  return Status;
}

DNA_STATUS VM_CLASS::Reload() {
  DNA_STATUS Status;
  DNA_STATUS Result;
  int i;
  BASE_DEVICE_CLASS *Device;
  ROM_DEVICE_CLASS *ROM;

  Result = DNA_NOT_FOUND;
  for (i = 0; i < 16; i++) {
    Status = this->FindDevice("ROM", &Device, i);
    if (Status == DNA_SUCCESS) {
      Result = DNA_SUCCESS;
      ROM = (ROM_DEVICE_CLASS *)Device;
      Status = ROM->Reload();
      if (Status == DNA_SUCCESS) {
        if (this->ShadowMemory) {
          memcpy(this->ShadowMemory + ROM->Base, ROM->Buffer, ROM->Size);
        }
      } else {
        Result = Status;
        break;
      }
    }

    return Result;
  }
    
  //
  // Clear Memory History
  //
  this->MemoryAccessIndex = 0;
  this->MemoryAccessCount = 0;
  //
  // Reset Processor
  //
  this->CpuControl->Reset(this->CpuControl);
  Status = DNA_SUCCESS;

  return Status;
}

//
// flag.0 (count.24)   
//    Run with Step Over
//
DNA_STATUS VM_CLASS::Run(int count) {
  DNA_STATUS Status;
  int flag;

  flag = count & 0xFF000000;
  count &= 0xFFFFFF;

  Status = DNA_SUCCESS;
  if (flag & VM_STEP_OVER_FLAG) {
    UINT16 pc;
    UINT16 target_pc;
    UINT8 opcode;
    pc = CPU->pc;
    opcode = this->ShadowMemory[pc];
    if (opcode == 0x20) {               // is JSR instruction
      target_pc = pc + 3;
      do {
        Status = this->CpuControl->Run(this->CpuControl, 1);
        if (Status == DNA_BREAK_POINT) {
          break;
        }
      } while (CPU->pc != target_pc);
    } else {
      Status = this->CpuControl->Run(this->CpuControl, 1);
    }
  } else if (flag & VM_THREAD_FLAG) {
    ThreadRunningFlag = true;
    if (flag & VM_THREAD_COUNT_FLAG) {
      ThreadContinueFlag = true;
    } else if (count == 0) {
      ThreadContinueFlag = true;
      count = 0x1000;
    } else {
      ThreadContinueFlag = false;
    }
    do {
      Status = this->CpuControl->Run(this->CpuControl, count);
      if (Status == DNA_BREAK_POINT) {
        break;
      }
    } while (ThreadContinueFlag);
    ThreadRunningFlag = false;
  } else {
    Status = this->CpuControl->Run(this->CpuControl, count);
  }

  return Status;
}

DNA_STATUS VM_CLASS::Halt() {
  DNA_STATUS Status;

  if (ThreadRunningFlag) {
    Status = this->CpuControl->Halt (this->CpuControl);  
  } else {
    Status = DNA_NOT_FOUND;
  }

  return Status;
}

//-----------------------------------------------------------------------------
// Constructor & Destructor
//-----------------------------------------------------------------------------
VM_CLASS::VM_CLASS() {
  int i;
  NULL_DEVICE_CLASS *NUL;

  this->CPU = new CLASS_MOS6502();
  this->CpuControl = &this->CPU->CpuControl;
  this->CPU->MemoryControl = &this->MemoryControl;
  this->MemoryControl.Read8 = MemoryRead8;
  this->MemoryControl.Write8 = MemoryWrite8;
  this->MemoryControl.Read16 = MemoryRead16;
  this->MemoryControl.Write16 = MemoryWrite16;
  this->MemoryControl.Read32 = MemoryRead32;
  this->MemoryControl.Write32 = MemoryWrite32;
  
  //
  // Initialize Shadow Memory
  //
  this->ShadowMemory = (UINT8 *)malloc(0x10000);

  //
  // Initialize Device List
  //
  for (i = 0; i < MAX_DEVICE_COUNT; i++) {
    this->DeviceList[i] = NULL;
  }

  //
  // Initialize Mapping Table
  //
  NUL = new NULL_DEVICE_CLASS();
  this->AddDevice (NUL, 0x0000, 0x10000);
}

VM_CLASS::~VM_CLASS() {
  int i;
  BASE_DEVICE_CLASS *device;

  //
  // Free Shadow Memory
  //
  free (this->ShadowMemory);

  //
  // Free Device
  //
  for (i = 0; i < MAX_DEVICE_COUNT; i++) {
    device = this->DeviceList[i];
    if (device != NULL) {
      delete device;
      this->DeviceList[i] = NULL;
    }
  }
}
