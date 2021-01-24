#ifndef __BASE_DEVICE_H__
#define __BASE_DEVICE_H__

#include "typedef.h"

#define DEVICE_FLAG_PAIR        0x0001        // 0:Single, 1:Pair (Only for BROM, BRAM)

#define SPACE_FLAG_SHARED       0x0001        // 0:Allocated, 1:Shared

class BASE_DEVICE_CLASS {
  private:    
  public:
    UINTN SpaceSize;
    UINTN AddressMask;
    UINT8 *Buffer;
    UINTN Size;
    
    BASE_DEVICE_CLASS();
    ~BASE_DEVICE_CLASS();
    
    virtual UINT8 Read8(UINTN Address);
    virtual UINT16 Read16(UINTN Address);
    virtual UINT32 Read32(UINTN Address);
    virtual VOID Write8(UINTN Address, UINT8 Data);
    virtual VOID Write16(UINTN Address, UINT16 Data);
    virtual VOID Write32(UINTN Address, UINT32 Data);
};

#endif