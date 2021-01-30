#include "main.h"

PLATFORM_CLASS *gPlatform = NULL;

//-----------------------------------------------------------------------------
// DLL Functions
//-----------------------------------------------------------------------------
void *CreateVM() {
  PLATFORM_CLASS *VM;

  VM = new PLATFORM_CLASS();

  return VM;
}

int FreeVM(void *vm) {
  DNA_STATUS Status;
  PLATFORM_CLASS *VM;

  VM = (PLATFORM_CLASS *)vm;
  delete VM;
  Status = DNA_SUCCESS;

  return Status;
}

int ResetVM(void *vm) {
  DNA_STATUS Status;
  PLATFORM_CLASS *VM;

  VM = (PLATFORM_CLASS *)vm;
  VM->Reset();
  Status = DNA_SUCCESS;

  return Status;
}


int filesize(FILE *fp) {
  int size;
  fseek(fp, 0L, SEEK_END);
  size = ftell(fp);
  fseek(fp, 0L, SEEK_SET);
  return size;
}

int AddDeviceROM(void *vm, UINT16 Base, UINT16 Size, char *filename) {
  DNA_STATUS Status;
  FILE *fp;
  int fsize;
  UINT8 *buffer;
  size_t ret;

  fp = fopen(filename, "rb");
  if (fp) {
    fsize = filesize(fp);
    buffer = (UINT8 *)malloc(fsize);      // 動態配置記憶體給Array
    ret = fread(buffer, 1, fsize, fp);    // fread回傳讀取的byte數
    fclose(fp);
    //
    // Load BIOS image to ROM
    //
    Status = gPlatform->AddDeviceROM(Base, Size, buffer);
    free(buffer);
  } else {
    printf("%s: [%s] not found", __FUNCTION__, filename);
    Status = DNA_NOT_FOUND;
  }

  return Status;
}

int AddDeviceRAM(void *vm, UINT16 Base, UINT16 Size) {
  DNA_STATUS Status;

  Status = gPlatform->AddDeviceRAM(Base, Size);

  return Status;
}

//-----------------------------------------------------------------------------
// Memory Functions
//-----------------------------------------------------------------------------
int main() {
  PLATFORM_CLASS *Platform = new PLATFORM_CLASS();
  //LoadBIOS("Startup.bin");

  return 0;
}