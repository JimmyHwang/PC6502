#include "main.h"

VOID ROM_DEVICE_CLASS::Write8(UINTN Address, UINT8 Data) {
}

VOID ROM_DEVICE_CLASS::Write16(UINTN Address, UINT16 Data) {
}

VOID ROM_DEVICE_CLASS::Write32(UINTN Address, UINT32 Data) {
}

ROM_DEVICE_CLASS::ROM_DEVICE_CLASS(UINT16 Size):BASE_DEVICE_CLASS("ROM", Size) {
  UINT8 *buffer;
  //
  // Set ReadOnly flag
  //
  this->ReadOnly = true;
  //
  // BASE_DEVICE_CLASS() -> ROM_DEVICE_CLASS()
  //
  buffer = (UINT8 *)malloc(Size);
  if (buffer) {
    this->Buffer = buffer;
    this->Size = Size;
  }
}

ROM_DEVICE_CLASS::~ROM_DEVICE_CLASS() {
  //
  // ROM_DEVICE_CLASS-> BASE_DEVICE_CLASS()
  //
}

DNA_STATUS ROM_DEVICE_CLASS::LoadImage(UINT8 *buffer, UINT16 size) {
  DNA_STATUS Status;

  if ((UINTN)size <= this->Size) {
    memcpy(this->Buffer, buffer, size);
    Status = DNA_SUCCESS;
  } else {
    Status = DNA_INVALID_PARAMETER;
  }

  return Status;
}

DNA_STATUS ROM_DEVICE_CLASS::LoadFile(string filename) {
  DNA_STATUS Status;
  FILE *fp;
  int fsize;
  UINT8 *buffer;
  size_t ret;

  fp = fopen(filename.c_str(), "rb");
  if (fp) {
    this->Filename = filename;
    fsize = filesize(fp);
    buffer = (UINT8 *)malloc(fsize);      // 動態配置記憶體給Array
    ret = fread(buffer, 1, fsize, fp);    // fread回傳讀取的byte數
    fclose(fp);
    this->LoadImage(buffer, fsize);
    Status = DNA_SUCCESS;
  } else {
    Status = DNA_INVALID_PARAMETER;
  }

  return Status;
}

DNA_STATUS ROM_DEVICE_CLASS::Reload() {
  return this->LoadFile(this->Filename);
}