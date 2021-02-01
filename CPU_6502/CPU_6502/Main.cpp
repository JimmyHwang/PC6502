#include "main.h"

using json = nlohmann::json;
VM_Callback gCallback;

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
  PLATFORM_CLASS *VM = (PLATFORM_CLASS *)vm;

  delete VM;
  Status = DNA_SUCCESS;

  return Status;
}

int VM_Reset(void *vm) {
  DNA_STATUS Status;
  PLATFORM_CLASS *VM = (PLATFORM_CLASS *)vm;

  VM->Reset();
  Status = DNA_SUCCESS;
  
  // create an empty structure (null)
  json j;
  j["pi"] = 3.141;
  j["happy"] = true;
  string s = j.dump();    // {"happy":true,"pi":3.141}

  gCallback(1, 2, (char *)s.c_str());

  return Status;
}

int VM_Run(void *vm, int count) {
  DNA_STATUS Status;
  PLATFORM_CLASS *VM = (PLATFORM_CLASS *)vm;

  VM->Run(count);
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
  PLATFORM_CLASS *VM = (PLATFORM_CLASS *)vm;

  if (VM) {
    fp = fopen(filename, "rb");
    if (fp) {
      fsize = filesize(fp);
      buffer = (UINT8 *)malloc(fsize);      // 動態配置記憶體給Array
      ret = fread(buffer, 1, fsize, fp);    // fread回傳讀取的byte數
      fclose(fp);
      //
      // Load BIOS image to ROM
      //
      Status = VM->AddDeviceROM(Base, Size, buffer);
      free(buffer);
    } else {
      DebugOut(L"%s: file [%s] not found", __FUNCTION__, filename);
      Status = DNA_NOT_FOUND;
    }
  } else {
    DebugOut(L"%s: VM not found", __FUNCTION__);
    Status = DNA_NOT_FOUND;
  }

  return Status;
}

int AddDeviceRAM(void *vm, UINT16 Base, UINT16 Size) {
  DNA_STATUS Status;
  PLATFORM_CLASS *VM = (PLATFORM_CLASS *)vm;

  if (VM) {
    Status = VM->AddDeviceRAM(Base, Size);
  } else {
    DebugOut(L"%s: VM not found", __FUNCTION__);
    Status = DNA_NOT_FOUND;
  }

  return Status;
}

int AddDeviceXIO(void *vm, UINT16 Base, UINT16 Size) {
  DNA_STATUS Status;
  PLATFORM_CLASS *VM = (PLATFORM_CLASS *)vm;

  if (VM) {
    Status = VM->AddDeviceXIO(Base, Size);
  } else {
    DebugOut(L"%s: VM not found", __FUNCTION__);
    Status = DNA_NOT_FOUND;
  }

  return Status;
}

void VM_SetCallback(VM_Callback Callback) {
  gCallback = Callback;
}

//-----------------------------------------------------------------------------
// Memory Functions
//-----------------------------------------------------------------------------
int main() {
  PLATFORM_CLASS *Platform = new PLATFORM_CLASS();
  //LoadBIOS("Startup.bin");

  return 0;
}