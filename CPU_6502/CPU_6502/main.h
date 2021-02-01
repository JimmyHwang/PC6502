#pragma once
#ifndef __MAIN_H__
#define __MAIN_H__

#include "typedef.h"
#include "dna_status.h"
#include "debug.h"
#include "nlohmann/json.hpp"

#include "mos6502.h"
#include "mos6502class.h"
#include "cpu_control_protocol.h"
#include "memory_control_protocol.h"

#include "rom_device.h"
#include "ram_device.h"
#include "xio_device.h"
#include "null_device.h"

#include "platform_class.h"

//-----------------------------------------------------------------------------
// Export DLL Functions
//-----------------------------------------------------------------------------
extern "C"
{
  // YourCallback is now a function that takes in 2 ints and returns void
  //typedef void(__stdcall * YourCallback)(int, int);
  //__declspec(dllexport) void __stdcall TakesInCallbackAndDoesStuff(YourCallback yourCallback);
  
  // VM_Callback is now a function that takes in 2 ints and returns void
  typedef void(__stdcall * VM_Callback)(int, int, char *);

  __declspec(dllexport) void * __stdcall CreateVM();
  __declspec(dllexport) int __stdcall FreeVM(void *vm);
  __declspec(dllexport) int __stdcall VM_Reset(void *vm);
  __declspec(dllexport) int __stdcall VM_Run(void *vm, int count);
  __declspec(dllexport) int __stdcall AddDeviceRAM(void *vm, UINT16 Base, UINT16 Size);
  __declspec(dllexport) int __stdcall AddDeviceROM(void *vm, UINT16 Base, UINT16 Size, char *filename);
  __declspec(dllexport) int __stdcall AddDeviceXIO(void *vm, UINT16 Base, UINT16 Size);
  __declspec(dllexport) void __stdcall VM_SetCallback(VM_Callback Callback);
    
  //__declspec(dllexport) int __stdcall LoadBIOS(const char *filename);
}
#endif