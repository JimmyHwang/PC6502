#pragma once
#ifndef __VM_CLASS_H__
#define __VM_CLASS_H__

#include "typedef.h"
#include "dna_status.h"

typedef void(__stdcall *VM_Callback)(char *);

#define ADDRESS_MASK_BITS   12
#define ADDRESS_INDEX_MASK  0xF
#define MAX_DEVICE_COUNT    16
#define MEMORY_ACCESS_MAX   0x20
#define MEMORY_ACCESS_MASK  MEMORY_ACCESS_MAX-1
#define MEMORY_ACCESS_READ  0
#define MEMORY_ACCESS_WRITE 1

#define VM_THREAD_FLAG                  0x80000000
#define VM_THREAD_COUNT_FLAG            0x40000000
#define VM_STEP_OVER_FLAG               0x01000000

typedef struct {
  bool Mode;                    // 0:Read, 1:Write
  UINT16 Address;
  UINT8 Data;
} MEMORY_ACCESS;

class VM_CLASS {
private:
  void AddDevice(BASE_DEVICE_CLASS *Device, UINTN Address, UINTN Size);

public:
  CLASS_MOS6502 *CPU;
  CPU_CONTROL_PROTOCOL *CpuControl;
  MEMORY_CONTROL_PROTOCOL MemoryControl;
  BASE_DEVICE_CLASS *DeviceList[MAX_DEVICE_COUNT];
  int DeviceCount;
  BASE_DEVICE_CLASS *DeviceMappingTable[16];

  //
  // Thread
  //
  HANDLE Thread;
  bool ThreadRunningFlag;
  bool ThreadContinueFlag;

  UINT8 *ShadowMemory;
  MEMORY_ACCESS MemoryAccessHistory[MEMORY_ACCESS_MAX];
  int MemoryAccessIndex = 0;
  int MemoryAccessCount = 0;
  VM_Callback Callback;

  VM_CLASS();
  ~VM_CLASS();

  DNA_STATUS AddDeviceROM(UINT16 Base, UINT16 Size, UINT8 *Buffer);
  DNA_STATUS AddDeviceROM(UINT16 Base, UINT16 Size, string filename);
  DNA_STATUS AddDeviceRAM(UINT16 Base, UINT16 Size);
  DNA_STATUS AddDeviceXIO(UINT16 Base, UINT16 Size);
  DNA_STATUS FindDevice(string Type, BASE_DEVICE_CLASS **Device);
  DNA_STATUS FindDevice(string Type, BASE_DEVICE_CLASS **Device, int Index);
  DNA_STATUS Reload();
  DNA_STATUS Reset();
  DNA_STATUS Run(int count);
  DNA_STATUS Halt();
  char *Talk(char *message);
};
#endif

