#ifndef __XIO_DEVICE_H__
#define __XIO_DEVICE_H__

#include "typedef.h"
#include "base_device.h"
#include "xio_device.h"

class XIO_DEVICE_CLASS: public BASE_DEVICE_CLASS {
  private:
    UINT8 Regs[0x10];

  public:
    XIO_DEVICE_CLASS(UINT16 Size);
    ~XIO_DEVICE_CLASS();

    UINT8 Read8(UINTN Address) override;
    UINT16 Read16(UINTN Address) override;
    UINT32 Read32(UINTN Address) override;
    VOID Write8(UINTN Address, UINT8 Data) override;
    VOID Write16(UINTN Address, UINT16 Data) override;
    VOID Write32(UINTN Address, UINT32 Data) override;    
    json Talk(json Message) override;
};

#endif