#pragma once
#ifndef __PLATFORM_CLASS_H__
#define __PLATFORM_CLASS_H__

#include "typedef.h"
#include "dna_status.h"

#define ADDRESS_MASK_BITS   12
#define ADDRESS_INDEX_MASK  0xF
#define MAX_DEVICE_COUNT    16

class PLATFORM_CLASS {
private:
  void AddDevice(BASE_DEVICE_CLASS *Device, UINTN Address, UINTN Size);

public:
  CLASS_MOS6502 *CPU;
  CPU_CONTROL_PROTOCOL *CpuControl;
  MEMORY_CONTROL_PROTOCOL MemoryControl;
  BASE_DEVICE_CLASS *DeviceList[16];
  int DeviceCount;
  BASE_DEVICE_CLASS *DeviceMappingTable[16];

  PLATFORM_CLASS();
  ~PLATFORM_CLASS();

  DNA_STATUS AddDeviceROM(UINT16 base, UINT16 size, UINT8 *buffer);
  DNA_STATUS AddDeviceRAM(UINT16 base, UINT16 size);
  DNA_STATUS AddDeviceXIO(UINT16 base, UINT16 size);
  DNA_STATUS Reset();
  DNA_STATUS Run(int count);
};

#endif

