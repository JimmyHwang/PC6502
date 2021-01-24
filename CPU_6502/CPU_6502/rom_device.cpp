#include "main.h"

VOID ROM_DEVICE_CLASS::Write8(UINTN Address, UINT8 Data) {
}

VOID ROM_DEVICE_CLASS::Write16(UINTN Address, UINT16 Data) {
}

VOID ROM_DEVICE_CLASS::Write32(UINTN Address, UINT32 Data) {
}

ROM_DEVICE_CLASS::ROM_DEVICE_CLASS(int size):BASE_DEVICE_CLASS() {
  //
  // BASE_DEVICE_CLASS() -> ROM_DEVICE_CLASS()
  //
  UINT8 *buffer = (UINT8 *)malloc(size);
  if (buffer) {
    this->Buffer = buffer;
    this->Size = size;
  }
}

ROM_DEVICE_CLASS::~ROM_DEVICE_CLASS() {
  //
  // ROM_DEVICE_CLASS-> BASE_DEVICE_CLASS()
  //
}

DNA_STATUS ROM_DEVICE_CLASS::LoadImage(UINT8 *buffer, int size) {
  DNA_STATUS Status;

  if ((UINTN)size <= this->Size) {
    memcpy(this->Buffer, buffer, size);
    Status = DNA_SUCCESS;
  } else {
    Status = DNA_INVALID_PARAMETER;
  }

  return Status;
}
