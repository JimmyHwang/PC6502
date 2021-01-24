#pragma once
#ifndef __MAIN_H__
#define __MAIN_H__

#include "typedef.h"
#include "dna_status.h"

#include "mos6502.h"
#include "mos6502class.h"
#include "cpu_control_protocol.h"
#include "memory_control_protocol.h"

#include "rom_device.h"
#include "ram_device.h"
#include "xio_device.h"

#include "platform_class.h"

//-----------------------------------------------------------------------------
// Export DLL Functions
//-----------------------------------------------------------------------------
extern "C"
{
  // YourCallback is now a function that takes in 2 ints and returns void
  //typedef void(__stdcall * YourCallback)(int, int);
  //__declspec(dllexport) void __stdcall TakesInCallbackAndDoesStuff(YourCallback yourCallback);

  __declspec(dllexport) int __stdcall InitializeVM();
  __declspec(dllexport) int __stdcall LoadBIOS(const char *filename);
}
#endif