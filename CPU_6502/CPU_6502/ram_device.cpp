#include "main.h"

RAM_DEVICE_CLASS::RAM_DEVICE_CLASS(UINT16 Size):BASE_DEVICE_CLASS("RAM", Size) {
  //
  // BASE_DEVICE_CLASS() -> RAM_DEVICE_CLASS()
  //  
  UINT8 *buffer = (UINT8 *)malloc(Size);
  if (buffer) {
    this->Buffer = buffer;
    this->Size = Size;
  }
}

RAM_DEVICE_CLASS::~RAM_DEVICE_CLASS() {
  //
  // RAM_DEVICE_CLASS() -> BASE_DEVICE_CLASS()
  //
}
