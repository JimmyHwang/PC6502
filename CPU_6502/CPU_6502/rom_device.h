#ifndef __ROM_DEVICE_H__
#define __ROM_DEVICE_H__

#include "typedef.h"
#include "dna_status.h"
#include "base_device.h"

class ROM_DEVICE_CLASS: public BASE_DEVICE_CLASS {
  private:
  public:
    ROM_DEVICE_CLASS(int size);
    ~ROM_DEVICE_CLASS();
    
    DNA_STATUS LoadImage(UINT8 *buffer, int size);
    
    VOID Write8(UINTN Address, UINT8 Data) override;
    VOID Write16(UINTN Address, UINT16 Data) override;
    VOID Write32(UINTN Address, UINT32 Data) override;    
};

#endif