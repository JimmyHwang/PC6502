#include <iostream>
#include <list>
#include <stdint.h>
#include <stdio.h>
#include <string.h>
#include "nlohmann/json.hpp"
using json = nlohmann::json;
using namespace std;

#include "typedef.h"
#include "debug.h"
#include "mos6502class.h"
#include "cpu_control_protocol.h"
#include "common.h"

//
// Protocol Defination
//
VOID
MOS6502_Reset (
  CPU_CONTROL_PROTOCOL *Protocol
  ) 
{
  CLASS_MOS6502 *This;
  
  This = _CR(Protocol, CLASS_MOS6502, CpuControl);
  This->Reset();  
}

int
MOS6502_Run (
  CPU_CONTROL_PROTOCOL *Protocol,
  UINTN Count
  ) 
{
  CLASS_MOS6502 *This;
  
  This = _CR(Protocol, CLASS_MOS6502, CpuControl);
  return This->Run((int)Count);  
}

VOID
MOS6502_IRQ (
  CPU_CONTROL_PROTOCOL *Protocol,
  UINT8 Number
  ) 
{
  CLASS_MOS6502 *This;
  
  This = _CR(Protocol, CLASS_MOS6502, CpuControl);
  This->IRQ();
}

VOID
MOS6502_NMI (
  CPU_CONTROL_PROTOCOL *Protocol
  ) 
{
  CLASS_MOS6502 *This;
  
  This = _CR(Protocol, CLASS_MOS6502, CpuControl);
  This->NMI();
}

//
// Class Method Defination
//
uint8_t CLASS_MOS6502::Read(uint16_t ip) {
  UINT8 data;
  
  data = this->MemoryControl->Read8(this->MemoryControl, (UINTN)ip);
  if (this->BP_IsMemoryHit(ip, data, false)) {
    this->bp_flag = true;
  }

  return data;
}

void CLASS_MOS6502::Write(uint16_t ip, uint8_t data) {
  this->MemoryControl->Write8(this->MemoryControl, (UINTN)ip, (UINT8)data);
  if (this->BP_IsMemoryHit(ip, data, false)) {
    this->bp_flag = true;
  }
}

//-----------------------------------------------------------------------------
// Break Point
//-----------------------------------------------------------------------------
void CLASS_MOS6502::ClearBPs() {
  std::list<BREAK_POINT>::iterator bp;

  for (bp = this->BreakPoints.begin(); bp != this->BreakPoints.end(); ++bp) {
    UpdateBpBitmap(bp->Address, false);
  }    
  this->BreakPoints.clear();
}

void CLASS_MOS6502::UpdateBpBitmap(UINT16 Address, bool State) {
  int index;
  int or_bits;
  int and_bits;

  index = Address >> 3;
  if (State) {
    or_bits = 1 << (Address & 7);
    and_bits = 0xFF;
  } else {
    or_bits = 0;
    and_bits = 0xFF ^ (1 << (Address & 7));
  }
  this->BreakPointBitmap[index] = (this->BreakPointBitmap[index] | or_bits) & and_bits;  
}

void CLASS_MOS6502::AddBP(json item) {
  BREAK_POINT bp;
  bp.Address = item["Address"];
  bp.Data = 0;
  bp.Access = 0;
  bp.Register = 0;
  bp.Compare = 0;
  if (item.contains("Data")) {
    bp.Data = item["Data"];
  }
  if (item.contains("Access")) {
    bp.Access = item["Access"];
  }
  if (item.contains("Register")) {
    bp.Register = item["Register"];
  }
  if (item.contains("Compare")) {
    bp.Compare = item["Compare"];
  }
  this->BreakPoints.push_back(bp);  
  this->UpdateBpBitmap(bp.Address, true);
}

//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
json CLASS_MOS6502::Talk(json args) {
  json result = {};
  string command;
  json items;

  command = args["Command"];
  if (command == "UpdateBPs") {
    this->ClearBPs();
    items = args["Items"];
    for (auto& el : items.items()) {
      json item = el.value();
      this->AddBP(item);
    }
    result["Status"] = "Success";
  } else if (command == "SetIgnoreBPs") {
    IgnoreBPs = args["Count"];
    result["Status"] = "Success";
  } else {
    result["Status"] = "Failed";
    result["Message"] = "Unknow command";
  }

  return result;
}

//-----------------------------------------------------------------------------
// Class Constructor
//-----------------------------------------------------------------------------
CLASS_MOS6502::CLASS_MOS6502():mos6502() {
  this->CpuControl.Run = MOS6502_Run;
  this->CpuControl.Reset = MOS6502_Reset;
  this->CpuControl.IRQ = MOS6502_IRQ;
  this->CpuControl.NMI = MOS6502_NMI;

}
