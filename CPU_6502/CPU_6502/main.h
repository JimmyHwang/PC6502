#pragma once
#ifndef __MAIN_H__
#define __MAIN_H__

#include "typedef.h"
#include "nlohmann/json.hpp"
using json = nlohmann::json;

#include "common.h"
#include "dna_status.h"
#include "debug.h"
#include "dis6502.h"

#include "mos6502.h"
#include "mos6502class.h"
#include "cpu_control_protocol.h"
#include "memory_control_protocol.h"

#include "rom_device.h"
#include "ram_device.h"
#include "xio_device.h"
#include "null_device.h"

#include "vm_class.h"

//-----------------------------------------------------------------------------
// Export DLL Functions
//-----------------------------------------------------------------------------
extern "C"
{
  __declspec(dllexport) void * __stdcall CreateVM();
  __declspec(dllexport) int __stdcall FreeVM(void *vm);
  __declspec(dllexport) int __stdcall VM_Reset(void *vm);
  __declspec(dllexport) int __stdcall VM_Run(void *vm, int count);
  __declspec(dllexport) int __stdcall AddDeviceRAM(void *vm, UINT16 Base, UINT16 Size);
  __declspec(dllexport) int __stdcall AddDeviceROM(void *vm, UINT16 Base, UINT16 Size, char *filename);
  __declspec(dllexport) int __stdcall AddDeviceXIO(void *vm, UINT16 Base, UINT16 Size);
  __declspec(dllexport) void __stdcall VM_SetCallback(void *vm, VM_Callback Callback);

  __declspec(dllexport) char * __stdcall VM_Talk(void *vm, char *msg);
  __declspec(dllexport) char * __stdcall VM_GetRegisters(void *vm);  
  __declspec(dllexport) char * __stdcall VM_Disassembly(void *vm, UINT16 base, int lines);
  __declspec(dllexport) char * __stdcall VM_GetMemoryHistory(void *vm);
}
#endif