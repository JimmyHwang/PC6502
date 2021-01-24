#include "main.h"

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
  Log.Verbose("R8,0x%lX=0x%08X", Ip, Data);
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
  Log.Verbose("W8,0x%lX=0x%08X", Ip, Data);
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
) {
  UINT16 Data;
  int Index;
  PLATFORM_CLASS *This;
  BASE_DEVICE_CLASS *Device;

  This = _CR(Protocol, PLATFORM_CLASS, MemoryControl);
  Index = (Ip >> ADDRESS_MASK_BITS) & ADDRESS_INDEX_MASK;
  Device = This->DeviceMappingTable[Index];
  Data = Device->Read8(Ip);

#if DEBUG_ADDRESSS_DECODER  
  Log.Verbose("R16,0x%lX=0x%08X", Ip, Data);
#endif  
  return Data;
}

VOID
MemoryWrite16(
  MEMORY_CONTROL_PROTOCOL *Protocol,
  UINTN Ip,
  UINT16 Data
) {
  int Index;
  PLATFORM_CLASS *This;
  BASE_DEVICE_CLASS *Device;

#if DEBUG_ADDRESSS_DECODER  
  Log.Verbose("W16,0x%lX=0x%08X", Ip, Data);
#endif  
  This = _CR(Protocol, PLATFORM_CLASS, MemoryControl);
  Index = (Ip >> ADDRESS_MASK_BITS) & ADDRESS_INDEX_MASK;
  Device = This->DeviceMappingTable[Index];
  Device->Write16(Ip, Data);
}

UINT32
MemoryRead32(
  MEMORY_CONTROL_PROTOCOL *Protocol,
  UINTN Ip
  ) 
{
  return 0;
}

VOID
MemoryWrite32(
  MEMORY_CONTROL_PROTOCOL *Protocol,
  UINTN Ip,
  UINT32 Data
  ) 
{
}
//
// Protocol Defination
//
void PLATFORM_CLASS::AddDeivce(BASE_DEVICE_CLASS *Device, UINTN Address, UINTN Size) {
  int i;
  UINTN addr;

  for (i = 0; i < 16; i++) {
    addr = i << ADDRESS_MASK_BITS;
    if (addr >= Address && addr <= Address + Size) {
      this->DeviceMappingTable[i] = Device;
    }
  }
}
//
// Class Constructor
//
PLATFORM_CLASS::PLATFORM_CLASS() {
  int i;

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
  // Initialize Device Mapping Table
  //
  for (i = 0; i < 16; i++) {
    DeviceMappingTable[i] = 0;
  }
  //
  // Initialize device and add to mapping table
  //
  ROM_DEVICE_CLASS *ROM = new ROM_DEVICE_CLASS();
  this->AddDeivce(ROM, 0xE000, 0x2000);
  XIO_DEVICE_CLASS *XIO = new XIO_DEVICE_CLASS();
  this->AddDeivce(XIO, 0xC000, 0x2000);
  RAM_DEVICE_CLASS *RAM = new RAM_DEVICE_CLASS();
  this->AddDeivce(RAM, 0x0000, 0x2000);


}

DNA_STATUS PLATFORM_CLASS::LoadBIOS(const char *filename) {
  DNA_STATUS Status;

  Status = ROM->LoadImage(filename);

  return Status;
}

PLATFORM_CLASS::~PLATFORM_CLASS() {
}
