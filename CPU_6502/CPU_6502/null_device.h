#ifndef __NULL_DEVICE_H__
#define __NULL_DEVICE_H__

#include "typedef.h"
#include "base_device.h"
#include "null_device.h"

class NULL_DEVICE_CLASS : public BASE_DEVICE_CLASS {
private:

public:
  NULL_DEVICE_CLASS();
  ~NULL_DEVICE_CLASS();

  UINT8 Read8(UINTN Address) override;
  UINT16 Read16(UINTN Address) override;
  UINT32 Read32(UINTN Address) override;
  VOID Write8(UINTN Address, UINT8 Data) override;
  VOID Write16(UINTN Address, UINT16 Data) override;
  VOID Write32(UINTN Address, UINT32 Data) override;
};

#endif