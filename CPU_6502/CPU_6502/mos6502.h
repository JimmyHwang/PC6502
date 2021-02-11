//============================================================================
// Name        : mos6502 
// Author      : Gianluca Ghettini
// Version     : 1.0
// Copyright   : 
// Description : A MOS 6502 CPU emulator written in C++
//============================================================================
#ifndef __MOS6502_H__
#define __MOS6502_H__

#include <iostream>
#include <stdint.h>
#include <list>
using namespace std;

#define NEGATIVE  0x80
#define OVERFLOW_ 0x40
#define CONSTANT  0x20
#define BREAK     0x10
#define DECIMAL   0x08
#define INTERRUPT 0x04
#define ZERO      0x02
#define CARRY     0x01

#define SET_NEGATIVE(x) (x ? (status |= NEGATIVE) : (status &= (~NEGATIVE)) )
#define SET_OVERFLOW(x) (x ? (status |= OVERFLOW_) : (status &= (~OVERFLOW_)) )
#define SET_CONSTANT(x) (x ? (status |= CONSTANT) : (status &= (~CONSTANT)) )
#define SET_BREAK(x) (x ? (status |= BREAK) : (status &= (~BREAK)) )
#define SET_DECIMAL(x) (x ? (status |= DECIMAL) : (status &= (~DECIMAL)) )
#define SET_INTERRUPT(x) (x ? (status |= INTERRUPT) : (status &= (~INTERRUPT)) )
#define SET_ZERO(x) (x ? (status |= ZERO) : (status &= (~ZERO)) )
#define SET_CARRY(x) (x ? (status |= CARRY) : (status &= (~CARRY)) )

#define IF_NEGATIVE() ((status & NEGATIVE) ? true : false)
#define IF_OVERFLOW() ((status & OVERFLOW_) ? true : false)
#define IF_CONSTANT() ((status & CONSTANT) ? true : false)
#define IF_BREAK() ((status & BREAK) ? true : false)
#define IF_DECIMAL() ((status & DECIMAL) ? true : false)
#define IF_INTERRUPT() ((status & INTERRUPT) ? true : false)
#define IF_ZERO() ((status & ZERO) ? true : false)
#define IF_CARRY() ((status & CARRY) ? true : false)

// IRQ, reset, NMI vectors
#define irqVectorH 0xFFFF
#define irqVectorL 0xFFFE
#define rstVectorH 0xFFFD
#define rstVectorL 0xFFFC
#define nmiVectorH 0xFFFB
#define nmiVectorL 0xFFFA

class BREAK_POINT {
public:
  uint16_t Address;
  uint8_t Data;
  uint8_t Access;       // Execution, MemRead, MemWrite
  uint8_t Register;     // A, X, Y
  uint8_t Compare;      // =, >, <
};

class mos6502
{
private:
	
	// consumed clock cycles 
	uint32_t cycles;
	
	typedef void (mos6502::*CodeExec)(uint16_t);
	typedef uint16_t (mos6502::*AddrExec)();

	typedef struct tagInstr
	{
		AddrExec addr;
		CodeExec code;
	} Instr;
	
	Instr InstrTable[256];
	
	void Exec(Instr i);
	
	bool illegalOpcode;
	
	// addressing modes
	uint16_t Addr_ACC(); // ACCUMULATOR
	uint16_t Addr_IMM(); // IMMEDIATE
	uint16_t Addr_ABS(); // ABSOLUTE
	uint16_t Addr_ZER(); // ZERO PAGE
	uint16_t Addr_ZEX(); // INDEXED-X ZERO PAGE
	uint16_t Addr_ZEY(); // INDEXED-Y ZERO PAGE
	uint16_t Addr_ABX(); // INDEXED-X ABSOLUTE
	uint16_t Addr_ABY(); // INDEXED-Y ABSOLUTE
	uint16_t Addr_IMP(); // IMPLIED
	uint16_t Addr_REL(); // RELATIVE
	uint16_t Addr_INX(); // INDEXED-X INDIRECT
	uint16_t Addr_INY(); // INDEXED-Y INDIRECT
	uint16_t Addr_ABI(); // ABSOLUTE INDIRECT
	
	// opcodes (grouped as per datasheet)
	void Op_ADC(uint16_t src);
	void Op_AND(uint16_t src);
	void Op_ASL(uint16_t src); 	void Op_ASL_ACC(uint16_t src);
	void Op_BCC(uint16_t src);
	void Op_BCS(uint16_t src);
	
	void Op_BEQ(uint16_t src);
	void Op_BIT(uint16_t src);
	void Op_BMI(uint16_t src);
	void Op_BNE(uint16_t src);
	void Op_BPL(uint16_t src);
	
	void Op_BRK(uint16_t src);
	void Op_BVC(uint16_t src);
	void Op_BVS(uint16_t src);
	void Op_CLC(uint16_t src);
	void Op_CLD(uint16_t src);
	
	void Op_CLI(uint16_t src);
	void Op_CLV(uint16_t src);
	void Op_CMP(uint16_t src);
	void Op_CPX(uint16_t src);
	void Op_CPY(uint16_t src);
	
	void Op_DEC(uint16_t src);
	void Op_DEX(uint16_t src);
	void Op_DEY(uint16_t src);
	void Op_EOR(uint16_t src);
	void Op_INC(uint16_t src);
	
	void Op_INX(uint16_t src);
	void Op_INY(uint16_t src);
	void Op_JMP(uint16_t src);
	void Op_JSR(uint16_t src);
	void Op_LDA(uint16_t src);
	
	void Op_LDX(uint16_t src);
	void Op_LDY(uint16_t src);
	void Op_LSR(uint16_t src); 	void Op_LSR_ACC(uint16_t src);
	void Op_NOP(uint16_t src);
	void Op_ORA(uint16_t src);
	
	void Op_PHA(uint16_t src);
	void Op_PHP(uint16_t src);
	void Op_PLA(uint16_t src);
	void Op_PLP(uint16_t src);
	void Op_ROL(uint16_t src); 	void Op_ROL_ACC(uint16_t src);
	
	void Op_ROR(uint16_t src);	void Op_ROR_ACC(uint16_t src);
	void Op_RTI(uint16_t src);
	void Op_RTS(uint16_t src);
	void Op_SBC(uint16_t src);
	void Op_SEC(uint16_t src);
	void Op_SED(uint16_t src);
	
	void Op_SEI(uint16_t src);
	void Op_STA(uint16_t src);
	void Op_STX(uint16_t src);
	void Op_STY(uint16_t src);
	void Op_TAX(uint16_t src);
	
	void Op_TAY(uint16_t src);
	void Op_TSX(uint16_t src);
	void Op_TXA(uint16_t src);
	void Op_TXS(uint16_t src);
	void Op_TYA(uint16_t src);
	
	void Op_ILLEGAL(uint16_t src);
		
	// stack operations
	inline void StackPush(uint8_t byte);
	inline uint8_t StackPop();

  // Break-Point
  bool BP_IsExecutionHit(uint16_t pc);
  bool BP_DataCompare(BREAK_POINT *bp, uint8_t data);

public:
  // registers
  uint8_t A; // accumulator
  uint8_t X; // X-index
  uint8_t Y; // Y-index

  // stack pointer
  uint8_t sp;

  // program counter
  uint16_t pc;

  // status register
  uint8_t status;

  // Break-Point
  uint8_t BreakPointBitmap[0x2000];
  list<BREAK_POINT> BreakPoints;
  bool BP_IsMemoryHit(uint16_t addr, uint8_t data, bool write);
  int IgnoreBPs;
  bool bp_flag;

  mos6502();
  void NMI();
  void IRQ();
  void Reset();
  int Run(uint32_t n);
  virtual void Write(uint16_t ip, uint8_t data);
  virtual uint8_t Read(uint16_t ip);
  void InitBreakPointSystem();
};

#endif