﻿#include "main.h"

//-----------------------------------------------------------------------------
// DLL Functions
//-----------------------------------------------------------------------------
void *CreateVM() {
  VM_CLASS *VM;

  VM = new VM_CLASS();

  return VM;
}

int FreeVM(void *vm) {
  DNA_STATUS Status;
  VM_CLASS *VM = (VM_CLASS *)vm;

  delete VM;
  Status = DNA_SUCCESS;

  return Status;
}

int VM_Reset(void *vm) {
  DNA_STATUS Status;
  VM_CLASS *VM = (VM_CLASS *)vm;

  VM->Reset();
  Status = DNA_SUCCESS;
  
  // create an empty structure (null)
  json j;
  j["Command"] = "RESET";
  j["pi"] = 3.141;
  j["happy"] = true;
  string s = j.dump();    // {"happy":true,"pi":3.141}

  //gCallback((char *)s.c_str());

  return Status;
}

typedef struct  {
  VM_CLASS *VM;
  UINT32 Count;
} VM_RUN_ARGS;

DWORD WINAPI VM_RunThread(LPVOID lpParameter) {
  DNA_STATUS Status;
  VM_RUN_ARGS *Args;
  VM_CLASS *VM;
  UINT32 Count;

  Args = (VM_RUN_ARGS *)lpParameter;
  VM = Args->VM;
  Count = Args->Count;
  Status = VM->Run(Count);
  return 0;
}

int VM_Run(void *vm, int count) {
  DNA_STATUS Status = DNA_SUCCESS;
  VM_CLASS *VM = (VM_CLASS *)vm;

  if (count & VM_THREAD_FLAG) {
    VM_RUN_ARGS *Args;
    Args = (VM_RUN_ARGS*)malloc(sizeof(VM_RUN_ARGS));
    Args->VM = VM;
    Args->Count = count;
    VM->Thread = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)VM_RunThread, Args, 0, NULL);
  } else {
    Status = VM->Run(count);
  }

  return Status;
}

int VM_Halt(void *vm) {
  DNA_STATUS Status = DNA_SUCCESS;
  VM_CLASS *VM = (VM_CLASS *)vm;

  if (VM->Thread != NULL) {
    Status = VM->Halt();
    TerminateThread(VM->Thread, 0);
    WaitForSingleObject(VM->Thread, INFINITE);
    CloseHandle(VM->Thread);
    VM->Thread = NULL;
  } else {
    Status = DNA_NOT_FOUND;
  }

  return Status;
}

char *VM_GetRegisters(void *vm) {
  VM_CLASS *VM = (VM_CLASS *)vm;
  string hexcode_buffer;
  json j;

  j["Registers"] = {};
  j["Registers"]["A"] = Hex02(VM->CPU->A);
  j["Registers"]["X"] = Hex02(VM->CPU->X);
  j["Registers"]["Y"] = Hex02(VM->CPU->Y);
  j["Registers"]["Flags"] = Hex02(VM->CPU->status);
  j["Registers"]["PC"] = Hex04(VM->CPU->pc);
  j["Registers"]["SP"] = Hex02(VM->CPU->sp);

  return ExportJsonString(j);
}

char * VM_Disassembly(void *vm, UINT16 address, int lines) {
  VM_CLASS *VM = (VM_CLASS *)vm;
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
  VM_CLASS *VM = (VM_CLASS *)vm;
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

int AddDeviceROM(void *vm, UINT16 Base, UINT16 Size, char *filename) {
  DNA_STATUS Status;
  VM_CLASS *VM = (VM_CLASS *)vm;
  string fn = filename;

  if (VM) {
    Status = VM->AddDeviceROM(Base, Size, fn);
  } else {
    DebugOut(L"%s: VM not found", __FUNCTION__);
    Status = DNA_NOT_FOUND;
  }

  return Status;
}

int AddDeviceRAM(void *vm, UINT16 Base, UINT16 Size) {
  DNA_STATUS Status;
  VM_CLASS *VM = (VM_CLASS *)vm;

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
  VM_CLASS *VM = (VM_CLASS *)vm;

  if (VM) {
    Status = VM->AddDeviceXIO(Base, Size);
  } else {
    DebugOut(L"%s: VM not found", __FUNCTION__);
    Status = DNA_NOT_FOUND;
  }

  return Status;
}

void VM_SetCallback(void *vm, VM_Callback Callback) {
  VM_CLASS *VM = (VM_CLASS *)vm;
  VM->Callback = Callback;
}

char *VM_Talk(void *vm, char *msg) {
  VM_CLASS *VM = (VM_CLASS *)vm;
  return VM->Talk(msg);
}

//-----------------------------------------------------------------------------
// Memory Functions
//-----------------------------------------------------------------------------
int main() {
  VM_CLASS *Platform = new VM_CLASS();
  //LoadBIOS("Startup.bin");

  return 0;
}