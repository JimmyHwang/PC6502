#include "main.h"

VOID ROM_DEVICE_CLASS::Write8(UINTN Address, UINT8 Data) {
}

VOID ROM_DEVICE_CLASS::Write16(UINTN Address, UINT16 Data) {
}

VOID ROM_DEVICE_CLASS::Write32(UINTN Address, UINT32 Data) {
}

ROM_DEVICE_CLASS::ROM_DEVICE_CLASS():BASE_DEVICE_CLASS() {
  //
  // BASE_DEVICE_CLASS() -> ROM_DEVICE_CLASS()
  //
}

ROM_DEVICE_CLASS::~ROM_DEVICE_CLASS() {
  //
  // ROM_DEVICE_CLASS-> BASE_DEVICE_CLASS()
  //
}

DNA_STATUS ROM_DEVICE_CLASS::Create(UINT8 *Buffer, UINTN Size) {
  DNA_STATUS Status;
        
  Status = DNA_SUCCESS;
  
  do {
    this->Buffer = Buffer;
    this->Size = Size;
  } while (FALSE);
  
  return Status;
}
