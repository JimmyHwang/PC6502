#include "main.h"
#include <assert.h>

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
  PLATFORM_CLASS *This;
  BASE_DEVICE_CLASS *Device;

  This = _CR(Protocol, PLATFORM_CLASS, MemoryControl);
  Index = (Ip >> ADDRESS_MASK_BITS) & ADDRESS_INDEX_MASK;
  Device = This->DeviceMappingTable[Index];
  Data = Device->Read8(Ip);

#if DEBUG_ADDRESSS_DECODER  
  printf("R8,0x%lX=0x%08X", Ip, Data);
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
  PLATFORM_CLASS *This;
  BASE_DEVICE_CLASS *Device;

#if DEBUG_ADDRESSS_DECODER  
  printf("W8,0x%lX=0x%08X", Ip, Data);
#endif  
  This = _CR(Protocol, PLATFORM_CLASS, MemoryControl);
  Index = (Ip >> ADDRESS_MASK_BITS) & ADDRESS_INDEX_MASK;
  Device = This->DeviceMappingTable[Index];
  Device->Write8(Ip, Data);
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

//-----------------------------------------------------------------------------
// Private Functions
//-----------------------------------------------------------------------------
void PLATFORM_CLASS::AddDevice(BASE_DEVICE_CLASS *Device, UINTN Address, UINTN Size) {
  int i;
  UINTN addr;

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
DNA_STATUS PLATFORM_CLASS::AddDeviceROM(UINT16 base, UINT16 size, UINT8 *buffer) {
  DNA_STATUS Status;
  ROM_DEVICE_CLASS *ROM = new ROM_DEVICE_CLASS(size);

  ROM->LoadImage(buffer, size);
  this->AddDevice(ROM, base, size);
  Status = DNA_SUCCESS;

  return Status;
}

DNA_STATUS PLATFORM_CLASS::AddDeviceRAM(UINT16 base, UINT16 size) {
  DNA_STATUS Status;
  RAM_DEVICE_CLASS *RAM;

  RAM = new RAM_DEVICE_CLASS(size);
  this->AddDevice(RAM, base, size);
  Status = DNA_SUCCESS;

  return Status;
}

DNA_STATUS PLATFORM_CLASS::AddDeviceXIO(UINT16 base, UINT16 size) {
  DNA_STATUS Status;
  XIO_DEVICE_CLASS *XIO;

  XIO = new XIO_DEVICE_CLASS();
  this->AddDevice(XIO, base, size);
  Status = DNA_SUCCESS;

  return Status;
}

DNA_STATUS PLATFORM_CLASS::Reset() {
  DNA_STATUS Status;

  this->CpuControl->Reset(this->CpuControl);
  Status = DNA_SUCCESS;

  return Status;
}

DNA_STATUS PLATFORM_CLASS::Run(int count) {
  DNA_STATUS Status;

  this->CpuControl->Run(this->CpuControl, count);
  Status = DNA_SUCCESS;

  return Status;
}

//-----------------------------------------------------------------------------
// Constructor & Destructor
//-----------------------------------------------------------------------------
PLATFORM_CLASS::PLATFORM_CLASS() {
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

PLATFORM_CLASS::~PLATFORM_CLASS() {
  int i;
  BASE_DEVICE_CLASS *device;

  for (i = 0; i < MAX_DEVICE_COUNT; i++) {
    device = this->DeviceList[i];
    if (device != NULL) {
      delete device;
      this->DeviceList[i] = NULL;
    }
  }
}
