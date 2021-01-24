#include "main.h"

RAM_DEVICE_CLASS::RAM_DEVICE_CLASS(int size):BASE_DEVICE_CLASS() {
  //
  // BASE_DEVICE_CLASS() -> RAM_DEVICE_CLASS()
  //  
  UINT8 *buffer = (UINT8 *)malloc(size);
  if (buffer) {
    this->Buffer = buffer;
    this->Size = size;
  }
}

RAM_DEVICE_CLASS::~RAM_DEVICE_CLASS() {
  //
  // RAM_DEVICE_CLASS() -> BASE_DEVICE_CLASS()
  //
}
