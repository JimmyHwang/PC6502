#include "main.h"

RAM_DEVICE_CLASS::RAM_DEVICE_CLASS():BASE_DEVICE_CLASS() {
  //
  // BASE_DEVICE_CLASS() -> RAM_DEVICE_CLASS()
  //  
}

RAM_DEVICE_CLASS::~RAM_DEVICE_CLASS() {
  //
  // RAM_DEVICE_CLASS() -> BASE_DEVICE_CLASS()
  //
}

DNA_STATUS RAM_DEVICE_CLASS::Create(UINT8 *Buffer, UINTN Size) {
  DNA_STATUS Status;
  
  Status = DNA_SUCCESS;
  
  do {
    this->Buffer = Buffer;
    this->Size = Size;
  } while (FALSE);
  
  return Status;
}
