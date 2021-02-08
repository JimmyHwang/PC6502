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
  //printf("<CLASS_MOS6502::reset()=0x%lX>", (char*)This - (char*)0);  
  This->Reset();  
}

VOID
MOS6502_Run (
  CPU_CONTROL_PROTOCOL *Protocol,
  UINTN Count
  ) 
{
  CLASS_MOS6502 *This;
  
  This = _CR(Protocol, CLASS_MOS6502, CpuControl);
  //printf("<CLASS_MOS6502::reset()=0x%lX>", (char*)This - (char*)0);  
  This->Run((int)Count);  
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
  UINT8 Data;
  
  Data = this->MemoryControl->Read8(this->MemoryControl, (UINTN)ip);
  
  return Data;
}

void CLASS_MOS6502::Write(uint16_t ip, uint8_t data) {
  this->MemoryControl->Write8(this->MemoryControl, (UINTN)ip, (UINT8)data);
}

//-----------------------------------------------------------------------------
// Break Point
//-----------------------------------------------------------------------------
void CLASS_MOS6502::ClearBPs() {
  std::list<BREAK_POINT>::iterator bp;
  UINT16 addr;
  UINT16 index;
  UINT8 mask;

  for (bp = this->BreakPoints.begin(); bp != this->BreakPoints.end(); ++bp) {
    addr = bp->Address;
    index = addr >> 3;
    mask = 0xFF ^ (1 << (addr & 3));
    this->BreakPointBitmap[index] &= mask;
  }    
  this->BreakPoints.clear();
}

void CLASS_MOS6502::AddBP(UINT16 Address) {
  BREAK_POINT bp;
  bp.Address = Address;
  this->BreakPoints.push_back(bp);  
}

//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
json CLASS_MOS6502::Talk(json args) {
  json result;
  string command;
  json items;

  command = args["Command"];
  if (command == "UpdateBPs") {
    this->ClearBPs();
    items = args["Items"];
    for (auto& el : items.items()) {
      json item = el.value();
      int type = item["Type"];
      UINT16 addr = item["Address"];
      this->AddBP(addr);
    }
  }

  return result;
}

//-----------------------------------------------------------------------------
// Class Constructor
//-----------------------------------------------------------------------------
CLASS_MOS6502::CLASS_MOS6502():mos6502() {
  //printf("<CLASS_MOS6502::CLASS_MOS6502()=0x%lX>", (char*)this - (char*)0);
  this->CpuControl.Run = MOS6502_Run;
  this->CpuControl.Reset = MOS6502_Reset;
  this->CpuControl.IRQ = MOS6502_IRQ;
  this->CpuControl.NMI = MOS6502_NMI;
  //
  // Clear BreakPoint bitmap
  //
  int i;
  for (i = 0; i < 0x2000; i++) {
    this->BreakPointBitmap[i] = 0;
  }
}
