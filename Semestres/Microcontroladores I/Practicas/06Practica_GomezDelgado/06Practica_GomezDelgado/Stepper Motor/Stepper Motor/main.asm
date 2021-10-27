;
; Stepper Motor.asm
;
; Created: 13/10/2021 11:06:55 p. m.
; Author : lalor
;

.include "m16adef.inc"     
   
;*******************
;Registros (aquí pueden definirse)
;.def temporal=r19

;Palabras claves (aquí pueden definirse)
;.equ LCD_DAT=DDRC
;********************

.org 0x0000
;Comienza el vector de interrupciones...
jmp RESET ; Reset Handler
jmp EXT_INT0 ; IRQ0 Handler
jmp EXT_INT1 ; IRQ1 Handler
jmp TIM2_COMP ; Timer2 Compare Handler
jmp TIM2_OVF ; Timer2 Overflow Handler
jmp TIM1_CAPT ; Timer1 Capture Handler
jmp TIM1_COMPA ; Timer1 CompareA Handler
jmp TIM1_COMPB ; Timer1 CompareB Handler
jmp TIM1_OVF ; Timer1 Overflow Handler
jmp TIM0_OVF ; Timer0 Overflow Handler
jmp SPI_STC ; SPI Transfer Complete Handler
jmp USART_RXC ; USART RX Complete Handler
jmp USART_UDRE ; UDR Empty Handler
jmp USART_TXC ; USART TX Complete Handler
jmp ADC_COMP ; ADC Conversion Complete Handler
jmp EE_RDY ; EEPROM Ready Handler
jmp ANA_COMP ; Analog Comparator Handler
jmp TWSI ; Two-wire Serial Interface Handler
jmp EXT_INT2 ; IRQ2 Handler
jmp TIM0_COMP ; Timer0 Compare Handler
jmp SPM_RDY ; Store Program Memory Ready Handler

;**************
;Inicializar el Stack Pointer
;**************
Reset:
ldi r16, high(RAMEND)
out SPH, r16
ldi r16, low(RAMEND)
out SPL, r16 


;*********************************
;Aquí comienza el programa...
;No olvides configurar al inicio todo lo que utilizarás
;*********************************
//DDRX - I/O
//PORTX: 
//		*entrada: sí pullups? 1=sí, 0=no
//		*salida: encendido? 1=sí, 0=no

//BOTONES
LDI R16, $FC				;1111_1100	ENTRADAS por ser botones
OUT DDRB, R16
LDI R16, $03				;0000_0011	SÍ pullups
OUT PORTB, R16

//MOTOR DE PASOS
LDI R16, $FF				;1111_1111	SALIDAS
OUT DDRA, R16
LDI R16, 0					;0000_0000	apagado de inicio
OUT PORTA, R16

LDI R16, $C0				;1100_0000	?

BOTONES:
	SBIS PINB, 0			;skip if bit #0 is set	
	RCALL RIGHT				;hace esto si el bit 0, es 1
	SBIS PINB, 1			;skip if bit #0 is set
	RCALL LEFT				;hace esto si es bit 1, es 1
RJMP BOTONES

LEFT:
	RCALL RETARDO50M		;rtr
	SBIS PINB, 1			
	RCALL ROTATEL			;hace esto si el bit 1 del puerto b, es 1
	RCALL RETARDO50M		;rtr
	RET

RIGHT:
	RCALL RETARDO50M
	SBIS PINB, 0
	RCALL ROTATER			;hace esto si el bit 0 del puerto b, es 1
	RCALL RETARDO50M
	RET

SEND:
	MOV R17, R16
	SWAP R16
	OR R17, R16
	OUT PORTA, R17
	SWAP R16
	RCALL RETARDO50M
	RET

ROTATEL:
	ROL R16
	RCALL SEND
	RET


ROTATER:
	ROR R16
	RCALL SEND
	RET

RETARDO15M:
; ============================= 
;    delay loop generator 
;     16000 cycles:
; ----------------------------- 
; delaying 15996 cycles:
          ldi  R26, $1F
LOOP0:  ldi  R27, $AB
LOOP1:  dec  R27
          brne LOOP1
          dec  R26
          brne LOOP0
; ----------------------------- 
; delaying 3 cycles:
          ldi  R26, $01
LOOP2:  dec  R26
          brne LOOP2
; ----------------------------- 
; delaying 1 cycle:
          nop
; ============================= 



; ============================= 
RET


RETARDO50m:						//50,000 ciclos: 50ms 1MHz
	; ============================= 
	;    delay loop generator 
	;     10000 cycles:
	; ----------------------------- 
	; delaying 9999 cycles:
			  ldi  R17, $21
	WGLOOP0:  ldi  R18, $64
	WGLOOP1:  dec  R18
			  brne WGLOOP1
			  dec  R17
			  brne WGLOOP0
	; ----------------------------- 
	; delaying 1 cycle:
			  nop
	; ============================= 


;*********************************
;Aquí está el manejo de las interrupciones concretas
;*********************************
EXT_INT0: ; IRQ0 Handler
reti
EXT_INT1: 
reti ; IRQ1 Handler
TIM2_COMP: 
reti ; Timer2 Compare Handler
TIM2_OVF: 
reti ; Timer2 Overflow Handler
TIM1_CAPT: 
reti ; Timer1 Capture Handler
TIM1_COMPA: 
reti ; Timer1 CompareA Handler
TIM1_COMPB: 
reti ; Timer1 CompareB Handler
TIM1_OVF: 
reti ; Timer1 Overflow Handler
TIM0_OVF: 
reti ; Timer0 Overflow Handler
SPI_STC: 
reti ; SPI Transfer Complete Handler
USART_RXC: 
reti ; USART RX Complete Handler
USART_UDRE: 
reti ; UDR Empty Handler
USART_TXC: 
reti ; USART TX Complete Handler
ADC_COMP: 
reti ; ADC Conversion Complete Handler
EE_RDY: 
reti ; EEPROM Ready Handler
ANA_COMP: 
reti ; Analog Comparator Handler
TWSI: 
reti ; Two-wire Serial Interface Handler
EXT_INT2: 
reti ; IRQ2 Handler
TIM0_COMP: 
reti
SPM_RDY: 
reti ; Store Program Memory Ready Handler