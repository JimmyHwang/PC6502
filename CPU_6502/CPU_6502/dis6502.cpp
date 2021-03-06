#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <stdint.h>
#include <malloc.h>

uint16_t BranchIP(int pc, int8_t offset) {
  int addr;

  addr = (pc+2) + offset;

  return addr;
}

int Disassemble6502(unsigned char *codebuffer, int pc, char *output_buffer) {
  char opstr[256];
  uint8_t *opcodes = &codebuffer[pc];
  int count = 1;

  switch (opcodes[0]) {
  case 0x00: sprintf(opstr, "BRK"); break;
  case 0x01: sprintf(opstr, "ORA ($%02X,X)", opcodes[1]); count = 2; break;
  case 0x05: sprintf(opstr, "ORA $%02X", opcodes[1]); count = 2; break;
  case 0x06: sprintf(opstr, "ASL $%02X", opcodes[1]); count = 2; break;
  case 0x08: sprintf(opstr, "PHP"); break;
  case 0x09: sprintf(opstr, "ORA #$%02X", opcodes[1]); count = 2; break;
  case 0x0a: sprintf(opstr, "ASL A"); break;
  case 0x0d: sprintf(opstr, "ORA $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x0e: sprintf(opstr, "ASL $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x10: sprintf(opstr, "BPL $%02X", BranchIP(pc,opcodes[1])); count = 2; break;
  case 0x11: sprintf(opstr, "ORA ($%02X),Y", opcodes[1]); count = 2; break;
  case 0x15: sprintf(opstr, "ORA $%02X,X", opcodes[1]); count = 2; break;
  case 0x16: sprintf(opstr, "ASL $%02X,X", opcodes[1]); count = 2; break;
  case 0x18: sprintf(opstr, "CLC"); break;
  case 0x19: sprintf(opstr, "ORA $%02X%02X,Y", opcodes[2], opcodes[1]); count = 3; break;
  case 0x1d: sprintf(opstr, "ORA $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x1e: sprintf(opstr, "ASL $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x20: sprintf(opstr, "JSR $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x21: sprintf(opstr, "AND ($%02X,X)", opcodes[1]); count = 2; break;
  case 0x24: sprintf(opstr, "BIT $%02X", opcodes[1]); count = 2; break;
  case 0x25: sprintf(opstr, "AND $%02X", opcodes[1]); count = 2; break;
  case 0x26: sprintf(opstr, "ROL $%02X", opcodes[1]); count = 2; break;
  case 0x28: sprintf(opstr, "PLP"); break;
  case 0x29: sprintf(opstr, "AND #$%02X", opcodes[1]); count = 2; break;
  case 0x2a: sprintf(opstr, "ROL A"); break;
  case 0x2c: sprintf(opstr, "BIT $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x2d: sprintf(opstr, "AND $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x2e: sprintf(opstr, "ROL $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x30: sprintf(opstr, "BMI $%02X", BranchIP(pc,opcodes[1])); count = 2; break;
  case 0x31: sprintf(opstr, "AND ($%02X),Y", opcodes[1]); count = 2; break;
  case 0x35: sprintf(opstr, "AND $%02X,X", opcodes[1]); count = 2; break;
  case 0x36: sprintf(opstr, "ROL $%02X,X", opcodes[1]); count = 2; break;
  case 0x38: sprintf(opstr, "SEC"); break;
  case 0x39: sprintf(opstr, "AND $%02X%02X,Y", opcodes[2], opcodes[1]); count = 3; break;
  case 0x3d: sprintf(opstr, "AND $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x3e: sprintf(opstr, "ROL $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x40: sprintf(opstr, "RTI"); break;
  case 0x41: sprintf(opstr, "EOR ($%02X,X)", opcodes[1]); count = 2; break;
  case 0x45: sprintf(opstr, "EOR $%02X", opcodes[1]); count = 2; break;
  case 0x46: sprintf(opstr, "LSR $%02X", opcodes[1]); count = 2; break;
  case 0x48: sprintf(opstr, "PHA"); break;
  case 0x49: sprintf(opstr, "EOR #$%02X", opcodes[1]); count = 2; break;
  case 0x4a: sprintf(opstr, "LSR A"); break;
  case 0x4c: sprintf(opstr, "JMP $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x4d: sprintf(opstr, "EOR $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x4e: sprintf(opstr, "LSR $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x50: sprintf(opstr, "BVC $%02X", BranchIP(pc,opcodes[1])); count = 2; break;
  case 0x51: sprintf(opstr, "EOR ($%02X),Y", opcodes[1]); count = 2; break;
  case 0x55: sprintf(opstr, "EOR $%02X,X", opcodes[1]); count = 2; break;
  case 0x56: sprintf(opstr, "LSR $%02X,X", opcodes[1]); count = 2; break;
  case 0x58: sprintf(opstr, "CLI"); break;
  case 0x59: sprintf(opstr, "EOR $%02X%02X,Y", opcodes[2], opcodes[1]); count = 3; break;
  case 0x5d: sprintf(opstr, "EOR $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x5e: sprintf(opstr, "LSR $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x60: sprintf(opstr, "RTS"); break;
  case 0x61: sprintf(opstr, "ADC ($%02X,X)", opcodes[1]); count = 2; break;
  case 0x65: sprintf(opstr, "ADC $%02X", opcodes[1]); count = 2; break;
  case 0x66: sprintf(opstr, "ROR $%02X", opcodes[1]); count = 2; break;
  case 0x68: sprintf(opstr, "PLA"); break;
  case 0x69: sprintf(opstr, "ADC #$%02X", opcodes[1]); count = 2; break;
  case 0x6a: sprintf(opstr, "ROR A"); break;
  case 0x6c: sprintf(opstr, "JMP ($%02X%02X)", opcodes[2], opcodes[1]); count = 3; break;
  case 0x6d: sprintf(opstr, "ADC $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x6e: sprintf(opstr, "ROR $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x70: sprintf(opstr, "BVS $%02X", BranchIP(pc,opcodes[1])); count = 2; break;
  case 0x71: sprintf(opstr, "ADC ($%02X),Y", opcodes[1]); count = 2; break;
  case 0x75: sprintf(opstr, "ADC $%02X,X", opcodes[1]); count = 2; break;
  case 0x76: sprintf(opstr, "ROR $%02X,X", opcodes[1]); count = 2; break;
  case 0x78: sprintf(opstr, "SEI"); break;
  case 0x79: sprintf(opstr, "ADC $%02X%02X,Y", opcodes[2], opcodes[1]); count = 3; break;
  case 0x7d: sprintf(opstr, "ADC $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x7e: sprintf(opstr, "ROR $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x81: sprintf(opstr, "STA ($%02X,X)", opcodes[1]); count = 2; break;
  case 0x84: sprintf(opstr, "STY $%02X", opcodes[1]); count = 2; break;
  case 0x85: sprintf(opstr, "STA $%02X", opcodes[1]); count = 2; break;
  case 0x86: sprintf(opstr, "STX $%02X", opcodes[1]); count = 2; break;
  case 0x88: sprintf(opstr, "DEY"); break;
  case 0x8a: sprintf(opstr, "TXA"); break;
  case 0x8c: sprintf(opstr, "STY $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x8d: sprintf(opstr, "STA $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x8e: sprintf(opstr, "STX $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0x90: sprintf(opstr, "BCC $%02X", BranchIP(pc,opcodes[1])); count = 2; break;
  case 0x91: sprintf(opstr, "STA ($%02X),Y", opcodes[1]); count = 2; break;
  case 0x94: sprintf(opstr, "STY $%02X,X", opcodes[1]); count = 2; break;
  case 0x95: sprintf(opstr, "STA $%02X,X", opcodes[1]); count = 2; break;
  case 0x96: sprintf(opstr, "STX $%02X,Y", opcodes[1]); count = 2; break;
  case 0x98: sprintf(opstr, "TYA"); break;
  case 0x99: sprintf(opstr, "STA $%02X%02X,Y", opcodes[2], opcodes[1]); count = 3; break;
  case 0x9a: sprintf(opstr, "TXS"); break;
  case 0x9d: sprintf(opstr, "STA $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xa0: sprintf(opstr, "LDY #$%02X", opcodes[1]); count = 2; break;
  case 0xa1: sprintf(opstr, "LDA ($%02X,X)", opcodes[1]); count = 2; break;
  case 0xa2: sprintf(opstr, "LDX #$%02X", opcodes[1]); count = 2; break;
  case 0xa4: sprintf(opstr, "LDY $%02X", opcodes[1]); count = 2; break;
  case 0xa5: sprintf(opstr, "LDA $%02X", opcodes[1]); count = 2; break;
  case 0xa6: sprintf(opstr, "LDX $%02X", opcodes[1]); count = 2; break;
  case 0xa8: sprintf(opstr, "TAY"); break;
  case 0xa9: sprintf(opstr, "LDA #$%02X", opcodes[1]); count = 2; break;
  case 0xaa: sprintf(opstr, "TAX"); break;
  case 0xac: sprintf(opstr, "LDY $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xad: sprintf(opstr, "LDA $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xae: sprintf(opstr, "LDX $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xb0: sprintf(opstr, "BCS $%02X", BranchIP(pc,opcodes[1])); count = 2; break;
  case 0xb1: sprintf(opstr, "LDA ($%02X),Y", opcodes[1]); count = 2; break;
  case 0xb4: sprintf(opstr, "LDY $%02X,X", opcodes[1]); count = 2; break;
  case 0xb5: sprintf(opstr, "LDA $%02X,X", opcodes[1]); count = 2; break;
  case 0xb6: sprintf(opstr, "LDX $%02X,Y", opcodes[1]); count = 2; break;
  case 0xb8: sprintf(opstr, "CLV"); break;
  case 0xb9: sprintf(opstr, "LDA $%02X%02X,Y", opcodes[2], opcodes[1]); count = 3; break;
  case 0xba: sprintf(opstr, "TSX"); break;
  case 0xbc: sprintf(opstr, "LDY $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xbd: sprintf(opstr, "LDA $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xbe: sprintf(opstr, "LDX $%02X%02X,Y", opcodes[2], opcodes[1]); count = 3; break;
  case 0xc0: sprintf(opstr, "CPY #$%02X", opcodes[1]); count = 2; break;
  case 0xc1: sprintf(opstr, "CMP ($%02X,X)", opcodes[1]); count = 2; break;
  case 0xc4: sprintf(opstr, "CPY $%02X", opcodes[1]); count = 2; break;
  case 0xc5: sprintf(opstr, "CMP $%02X", opcodes[1]); count = 2; break;
  case 0xc6: sprintf(opstr, "DEC $%02X", opcodes[1]); count = 2; break;
  case 0xc8: sprintf(opstr, "INY"); break;
  case 0xc9: sprintf(opstr, "CMP #$%02X", opcodes[1]); count = 2; break;
  case 0xca: sprintf(opstr, "DEX"); break;
  case 0xcc: sprintf(opstr, "CPY $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xcd: sprintf(opstr, "CMP $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xce: sprintf(opstr, "DEC $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xd0: sprintf(opstr, "BNE $%02X", BranchIP(pc,opcodes[1])); count = 2; break;
  case 0xd1: sprintf(opstr, "CMP ($%02X),Y", opcodes[1]); count = 2; break;
  case 0xd5: sprintf(opstr, "CMP $%02X,X", opcodes[1]); count = 2; break;
  case 0xd6: sprintf(opstr, "DEC $%02X,X", opcodes[1]); count = 2; break;
  case 0xd8: sprintf(opstr, "CLD"); break;
  case 0xd9: sprintf(opstr, "CMP $%02X%02X,Y", opcodes[2], opcodes[1]); count = 3; break;
  case 0xdd: sprintf(opstr, "CMP $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xde: sprintf(opstr, "DEC $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xe0: sprintf(opstr, "CPX #$%02X", opcodes[1]); count = 2; break;
  case 0xe1: sprintf(opstr, "SBC ($%02X,X)", opcodes[1]); count = 2; break;
  case 0xe4: sprintf(opstr, "CPX $%02X", opcodes[1]); count = 2; break;
  case 0xe5: sprintf(opstr, "SBC $%02X", opcodes[1]); count = 2; break;
  case 0xe6: sprintf(opstr, "INC $%02X", opcodes[1]); count = 2; break;
  case 0xe8: sprintf(opstr, "INX"); break;
  case 0xe9: sprintf(opstr, "SBC #$%02X", opcodes[1]); count = 2; break;
  case 0xea: sprintf(opstr, "NOP"); break;
  case 0xec: sprintf(opstr, "CPX $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xed: sprintf(opstr, "SBC $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xee: sprintf(opstr, "INC $%02X%02X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xf0: sprintf(opstr, "BEQ $%02X", BranchIP(pc, opcodes[1])); count = 2; break;
  case 0xf1: sprintf(opstr, "SBC ($%02X),Y", opcodes[1]); count = 2; break;
  case 0xf5: sprintf(opstr, "SBC $%02X,X", opcodes[1]); count = 2; break;
  case 0xf6: sprintf(opstr, "INC $%02X,X", opcodes[1]); count = 2; break;
  case 0xf8: sprintf(opstr, "SED"); break;
  case 0xf9: sprintf(opstr, "SBC $%02X%02X,Y", opcodes[2], opcodes[1]); count = 3; break;
  case 0xfd: sprintf(opstr, "SBC $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  case 0xfe: sprintf(opstr, "INC $%02X%02X,X", opcodes[2], opcodes[1]); count = 3; break;
  default:
    sprintf(opstr, ".db $%02X", opcodes[0]); break;
  }
  strcpy(output_buffer, opstr);
  return count;
}

int mainxxx(int argc, char**argv) {
  char output_buffer[16];

  FILE *f = fopen(argv[1], "rb");
  if (f == NULL) {
    printf("error: Couldn't open %s\n", argv[1]);
    exit(1);
  }

  //Get the file size
  fseek(f, 0L, SEEK_END);
  int fsize = ftell(f);
  fseek(f, 0L, SEEK_SET);

  unsigned char *buffer = (unsigned char *)malloc(fsize);
  fread(buffer, fsize, 1, f);
  fclose(f);

  int pc = 0;
  while (pc < fsize) {
    pc += Disassemble6502(buffer, pc, output_buffer);
  }
  return 0;
}
