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
                                        ;   bit 0: Set to clear Second button flag (0x01)
                                        ;   bit 1: Set to clear Minute button flag (0x02)
                                        ;   bit 2: Set to clear Start button flag  (0x04)
                                        ;   bit 3: Set to clear Reset button flag  (0x08)
                                        ;   bit 4: Set to clear Mode button flag   (0x10)
        org     $E000
Startup
        sti                             ; Disable IRQ
        cld                             ; Select binary mode
        ldx     #$ff
        txs                             ; initialize stack pointer
        lda     #0
        sta     Minute
        sta     Second
LoopX
        jsr     PrintTime
        lda     XIO_Button              ; if click reset button
        and     #8                      
        beq     LoopX1                  ; goto LoopX1 if reset button not press
        lda     #0                      ; clear Minute & Second
        sta     Second
        sta     Minute
        lda     #8                      ; clear reset button bit
        sta     XIO_Button              
LoopX1
        php
        sed                             ; Decimal flag = 1
        lda     Second                  ; minute:second = minute:second + 1
        clc
        adc     #1
        sta     Second
        lda     Minute                  
        adc     #0
        sta     Minute        
        plp
        jmp     LoopX
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
