#ifndef __RAM_DEVICE_H__
#define __RAM_DEVICE_H__

#include "typedef.h"
#include "dna_status.h"
#include "base_device.h"

class RAM_DEVICE_CLASS: public BASE_DEVICE_CLASS {
  private:
  public:
    RAM_DEVICE_CLASS(int size);
    ~RAM_DEVICE_CLASS();
};

#endif