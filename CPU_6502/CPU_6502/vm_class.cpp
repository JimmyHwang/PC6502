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
  record->Address = Ip;
  record->Data = Data;
  wp = (wp + 1) & MEMORY_ACCESS_MASK;
  This->MemoryAccessIndex = wp;
  if (This->MemoryAccessIndex < MEMORY_ACCESS_MAX) {
    This->MemoryAccessCount++;
  }

#ifdef DEBUG_ADDRESSS_DECODER
  DebugOut(L"R8,0x%lX=0x%08X", Ip, Data);
  //printf("R8,0x%lX=0x%08X", Ip, Data);
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
  //printf("W8,0x%lX=0x%08X", Ip, Data);
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
  record->Address = Ip;
  record->Data = Data;
  wp = (wp + 1) & MEMORY_ACCESS_MASK;
  This->MemoryAccessIndex = wp;
  if (This->MemoryAccessIndex < MEMORY_ACCESS_MAX) {
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

  jst = {};
  jstr = message;
  auto j = json::parse(jstr);
  string target = j["Target"];
  if (target == "XIO") {
    status = this->FindDevice("XIO", &dev);
    jst = dev->Talk(j);
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
  DNA_STATUS status;
  BASE_DEVICE_CLASS *dev;
  int i;

  status = DNA_NOT_FOUND;
  for (i = 0; i < MAX_DEVICE_COUNT; i++) {
    if (this->DeviceList[i] != NULL) {
      dev = this->DeviceList[i];
      if (dev->Type == Type) {
        *Device = dev;
        status = DNA_SUCCESS;
        break;
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

//
// flag.0 (count.24)   
//    Run with Step Over
//
DNA_STATUS VM_CLASS::Run(int count) {
  DNA_STATUS Status;
  int flag;

  flag = (count >> 24);
  count &= 0xFFFFFF;

  if (flag & 1) {
    UINT16 pc;
    UINT16 target_pc;
    UINT8 opcode;
    pc = CPU->pc;
    opcode = this->ShadowMemory[pc];
    if (opcode == 0x20) {     // is JSR instruction
      target_pc = pc + 3;
      do {
        this->CpuControl->Run(this->CpuControl, 1);
      } while (CPU->pc != target_pc);
    } else {
      this->CpuControl->Run(this->CpuControl, 1);
    }
  } else {
    this->CpuControl->Run(this->CpuControl, count);
  }
  Status = DNA_SUCCESS;

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
