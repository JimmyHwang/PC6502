#include "main.h"

PLATFORM_CLASS *gPlatform = NULL;

//-----------------------------------------------------------------------------
// DLL Functions
//-----------------------------------------------------------------------------
int InitializeVM() {
  DNA_STATUS Status;

  gPlatform = new PLATFORM_CLASS();
  if (gPlatform != NULL) {
    Status = DNA_SUCCESS;
  } else {
    Status = DNA_OUT_OF_RESOURCES;
  }

  return Status;
}

int filesize(FILE *fp) {
  int size;
  fseek(fp, 0L, SEEK_END);
  size = ftell(fp);
  fseek(fp, 0L, SEEK_SET);
  return size;
}

int LoadBIOS(const char *filename) {    // Get filename from C# "func(string filename)"
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
    Status = gPlatform->LoadBIOS(buffer, fsize);
  } else {
    printf("%s: [%s] not found", __FUNCTION__, filename);
    Status = DNA_NOT_FOUND;
  }

  return Status;
}

//-----------------------------------------------------------------------------
// Memory Functions
//-----------------------------------------------------------------------------
int main() {
  PLATFORM_CLASS *Platform = new PLATFORM_CLASS();
  LoadBIOS("Startup.bin");

  return 0;
}