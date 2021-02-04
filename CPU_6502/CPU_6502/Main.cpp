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
  j["Command"] = "RESET";
  j["pi"] = 3.141;
  j["happy"] = true;
  string s = j.dump();    // {"happy":true,"pi":3.141}

  gCallback((char *)s.c_str());

  return Status;
}

string Hex02(UINT8 data) {
  char buffer[8];
  string result = "";

  sprintf(buffer, "%02X", data);
  result = buffer;

  return result;
}

string Hex04(UINT16 data) {
  char buffer[8];
  string result = "";

  sprintf(buffer, "%04X", data);
  result = buffer;

  return result;
}

char *ExportJsonString(json j) {
  int rlen;
  char *result;

  string jstr = j.dump();
  rlen = strlen(jstr.c_str()) + 1;
  result = (char *)malloc(rlen);
  strcpy(result, jstr.c_str());

  return result;
}

int VM_Run(void *vm, int count) {
  DNA_STATUS Status;
  PLATFORM_CLASS *VM = (PLATFORM_CLASS *)vm;

  VM->Run(count);
  Status = DNA_SUCCESS;

  return Status;
}

char * VM_GetRegisters(void *vm) {
  PLATFORM_CLASS *VM = (PLATFORM_CLASS *)vm;
  string hexcode_buffer;
  json j;

  j["Registers"] = {};
  j["Registers"]["A"] = Hex02(VM->CPU->A);
  j["Registers"]["X"] = Hex02(VM->CPU->X);
  j["Registers"]["Y"] = Hex02(VM->CPU->Y);
  j["Registers"]["PC"] = Hex04(VM->CPU->pc);
  j["Registers"]["SP"] = Hex02(VM->CPU->sp);

  return ExportJsonString(j);
}

char * VM_Disassembly(void *vm, UINT16 address, int lines) {
  PLATFORM_CLASS *VM = (PLATFORM_CLASS *)vm;
  char opcode_buffer[64];
  string hexcode_buffer;
  int i;
  json j;
  int pc;
  int opcode_bytes;
  UINT8 value;
  
  j["Lines"] = json::array();
  pc = address;
  for (i = 0; i < lines; i++) {
    opcode_bytes = Disassemble6502(VM->ShadowMemory, pc, opcode_buffer);
    json line = json::object();
    hexcode_buffer = "";
    for (int c = 0; c < opcode_bytes; c++) {
      if (hexcode_buffer != "") {
        hexcode_buffer += " ";
      }
      value = VM->ShadowMemory[pc + c];
      hexcode_buffer += Hex02(value);
    }
    line["Address"] = Hex04(pc);
    line["Opcode"] = hexcode_buffer;
    line["Disassembly"] = opcode_buffer;
    j["Lines"].push_back(line);
    pc += opcode_bytes;
  }  
  
  return ExportJsonString(j);
}

char *VM_GetMemoryHistory(void *vm) {
  PLATFORM_CLASS *VM = (PLATFORM_CLASS *)vm;
  json j;
  int rp;
  int count;
  MEMORY_ACCESS *record;

  j["History"] = json::array();  
  rp = (VM->MemoryAccessIndex - VM->MemoryAccessCount) & MEMORY_ACCESS_MASK;
  count = VM->MemoryAccessCount;
  while (count > 0) {
    json memory_access = json::object();
    record = &VM->MemoryAccessHistory[rp];
    memory_access["Mode"] = record->Mode;
    memory_access["Address"] = record->Address;
    memory_access["Data"] = record->Data;
    j["History"].push_back(memory_access);
    rp = (rp + 1) & MEMORY_ACCESS_MASK;
    count--;
  }
  
  return ExportJsonString(j);
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