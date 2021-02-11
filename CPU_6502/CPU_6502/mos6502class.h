#ifndef __CLASS_MOS6502_H__
#define __CLASS_MOS6502_H__

class CLASS_MOS6502;
class CHROMOSOME;

#include "mos6502.h"
#include "cpu_control_protocol.h"
#include "memory_control_protocol.h"
#include "nlohmann/json.hpp"
using json = nlohmann::json;

class CLASS_MOS6502: public mos6502 {
private:
  void ClearBPs();
  void AddBP(json item);
  void UpdateBpBitmap(UINT16 Address, bool State);

public:	
  CLASS_MOS6502();
  CPU_CONTROL_PROTOCOL CpuControl;
  MEMORY_CONTROL_PROTOCOL *MemoryControl;  

  void Write(uint16_t ip, uint8_t data) override;
  uint8_t Read(uint16_t ip) override;
  json Talk(json message);
};

#endif