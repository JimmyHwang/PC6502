; RAM           $0000 - $1FFF
; XIO           $C000 - $DFFF
; ROM           $E000 - $FFFF
Running         equ     $FD
Minute          equ     $FE
Second          equ     $FF
XIO_Base        equ     $C000           ; XIO Base
XIO_LED         equ     XIO_Base+0      ; 7-Segment LED x 4
XIO_Button      equ     XIO_Base+8      ; Read         
                                        ;   bit 0: Second button flag (0x01)
                                        ;   bit 1: Minute button flag (0x02)
                                        ;   bit 2: Start button flag  (0x04)
                                        ;   bit 3: Reset button flag  (0x08)
                                        ;   bit 4: Mode button flag   (0x10)
                                        ; Write
                                        ;   bit 0: 1 to clear Second button flag (0x01)
                                        ;   bit 1: 1 to clear Minute button flag (0x02)
                                        ;   bit 2: 1 to clear Start button flag  (0x04)
                                        ;   bit 3: 1 to clear Reset button flag  (0x08)
                                        ;   bit 4: 1 to clear Mode button flag   (0x10)
        org     $E000
Startup
        sti                             ; Disable IRQ
        cld                             ; Select binary mode
        ldx     #$ff
        txs                             ; initialize stack pointer
        lda     #0
        sta     Minute
        sta     Second
        sta     Running
LoopX
        jsr     PrintTime
        lda     XIO_Button              ; check start button
        and     #4
        bne     LoopX_Start             ; goto LoopX_Start if start button pressed
        lda     XIO_Button              ; check reset button
        and     #8
        bne     LoopX_Reset             ; goto LoopX_Reset if reset button pressed
LoopX1
        lda     Running                 ; Run timer if Running flag be set
        cmp     #1
        bne     LoopX1_End
        php
        sed                             ; Decimal flag = 1
        lda     Second                  ; minute:second = minute:second + 1
        clc
        adc     #1
        sta     Second
        cmp     #$60
        bne     LoopX1_End              ; goto LoopX1e if Second != 60
        lda     #0                      ; Second = 0
        sta     Second        
        clc
        lda     Minute                  ; Minute += 1
        adc     #1
        sta     Minute  
        cmp     #$60                    ; goto LoopX1e if Minute != 60
        bne     LoopX1_End
        lda     #0                      ; Minute = 0
        sta     Minute        
LoopX1_End
        plp
        jmp     LoopX
LoopX_Start
        lda     Running                 ; Running = Running ^ 1
        eor     #1
        sta     Running
        lda     #4                      ; clear start button bit
        sta     XIO_Button              
        jmp     LoopX1
LoopX_Reset        
        lda     #0                      ; clear Minute & Second
        sta     Second
        sta     Minute
        sta     Running                 ; stop timer
        lda     #8                      ; clear reset button bit
        sta     XIO_Button              
        jmp     LoopX1
;
; Input X       Display Number
;       Y       Display Position
; Kill  A
;       
Print1  lda     LEDFont,x
        sta     XIO_LED,y
        rts
;
; Input A       Display Number
;       Y       Display start position, the Y will move to next position after print
; Kill  A,X
;       
Print2H pha
        and     #$F
        tax
        jsr     Print1
        iny
        pla
        lsr     a
        lsr     a
        lsr     a
        lsr     a
        tax
        jsr     Print1
        iny
        rts
;
; Input Minute, Second      Display Minute & Second to LED
; Kill  A,X,Y
;       
PrintTime       
        ldy     #0
        lda     Second
        jsr     Print2H
        lda     Minute
        jsr     Print2H
        rts
        
LEDFont db      $77,$24,$5D,$6D,$2E,$6B,$7B,$25,$7F,$6F

NMI
        jmp     NMI
  
IRQ
        jmp     IRQ
  
        org     $FFFA  ; System vectors
        dw      NMI
        dw      Startup
        dw      IRQ
