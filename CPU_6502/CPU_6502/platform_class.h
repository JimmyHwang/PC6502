#pragma once
#ifndef __PLATFORM_CLASS_H__
#define __PLATFORM_CLASS_H__

#include "typedef.h"
#include "dna_status.h"

#define ADDRESS_MASK_BITS   12
#define ADDRESS_INDEX_MASK  0xF

class PLATFORM_CLASS {
private:

public:
  CLASS_MOS6502 *CPU;
  CPU_CONTROL_PROTOCOL *CpuControl;
  MEMORY_CONTROL_PROTOCOL MemoryControl;
  BASE_DEVICE_CLASS *DeviceMappingTable[16];

  ROM_DEVICE_CLASS *ROM;
  RAM_DEVICE_CLASS *RAM;
  XIO_DEVICE_CLASS *XIO;

  PLATFORM_CLASS();
  ~PLATFORM_CLASS();

  void AddDeivce(BASE_DEVICE_CLASS *Device, UINTN Address, UINTN Size);
  DNA_STATUS LoadBIOS(const char *filename);
};

#endif

