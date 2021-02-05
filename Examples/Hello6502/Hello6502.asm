        ORG     $E000
NumBits:
        db      $77,$24,$5D,$6D,$2E,$6B,$7B,$25,$7F,$6F

Startup:
        LDX     #0
LoopX:  
        LDA     NumBits
        LDA     NumBits,X        
        STA     $C000
        INX
        CPX     #10
        bne     LoopX
        LDA     #$AA
        STA     $C001
        jmp     Startup

NMI:
        jmp     NMI
  
IRQ:
        jmp     IRQ
  
        ORG     $fffa   ; System vectors
        DW      &NMI,&Startup,&IRQ


