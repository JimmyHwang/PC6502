#include <iostream>
#include <stdint.h>
#include <stdio.h>
#include <string.h>
using namespace std;

#include "typedef.h"
#include "mos6502class.h"
#include "cpu_control_protocol.h"

//CLASS_MOS6502 *m6502;

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
  
  //printf("<6502_DNA_CPU=0x%lX>", (char*)this->DnaCpu - (char*)0);
  
  //printf("<CLASS_MOS6502::Read>");
  //printf("<6502,CHROMOSOME=0x%lX>", (char*)this->DnaCpu - (char*)0 );
  //Data = this->DnaCpu->Read(ip);
  //printf("<CLASS_MOS6502::Read()=0x%lX>", (char*)this - (char*)0);
  Data = this->MemoryControl->Read8(this->MemoryControl, (UINTN)ip);
  //printf("CLASS_MOS6502::Read=0x%X(0x%X)", ip, Data); 
  
  return Data;
}

void CLASS_MOS6502::Write(uint16_t ip, uint8_t data) {
  //this->DnaCpu->Write(ip, data);
  this->MemoryControl->Write8(this->MemoryControl, (UINTN)ip, (UINT8)data);
}

//
// Class Constructor
//
CLASS_MOS6502::CLASS_MOS6502():mos6502() {
  //printf("<CLASS_MOS6502::CLASS_MOS6502()=0x%lX>", (char*)this - (char*)0);
  this->CpuControl.Run = MOS6502_Run;
  this->CpuControl.Reset = MOS6502_Reset;
  this->CpuControl.IRQ = MOS6502_IRQ;
  this->CpuControl.NMI = MOS6502_NMI;
  //m6502 = this;
}
