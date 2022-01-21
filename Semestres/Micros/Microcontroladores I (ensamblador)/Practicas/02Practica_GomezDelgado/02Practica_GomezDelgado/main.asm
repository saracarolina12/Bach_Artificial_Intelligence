;******************************************************
; Convertidor BCD a 7 segmentos
;
; Fecha: Poner aquí la fecha
; Autor: Sara Carolina Gómez Delgado
;******************************************************

.include "m16def.inc"     
   
;******************************************************
;Registros (aquí pueden definirse)
;.def temporal=r19

;Palabras claves (aquí pueden definirse)
;.equ LCD_DAT=DDRC
;******************************************************

.org 0x0000
;Comienza el vector de interrupciones.
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
; Termina el vector de interrupciones.

;******************************************************
;Aquí comenzará el programa
;******************************************************
Reset:
;Primero inicializamos el stack pointer...
ldi r16, high(RAMEND)
out SPH, r16
ldi r16, low(RAMEND)
out SPL, r16 


;******************************************************
;No olvides configurar al inicio los puertos que utilizarás
;También debes configurar si habrá o no pull ups en las entradas
;Para las salidas deberás indicar cuál es la salida inicial
;Los registros que vayas a utilizar inicializalos si es necesario
;******************************************************


//DIPSWITCH
ldi R16, 0b0000_00000 ;DDRA
out DDRA, R16 
ldi R16, 0b1111_1111 ;PORTA
out PORTA, R16

//LEDS
ldi R16, 0b1111_1111 ; DDRC
out DDRC, R16
ldi R16, 0b0000_0000 ; PORTC
out PORTC, R16

;Repetir esto 
REGRESA: 
	in R16, PINA

	ldi r17, $f0
	eor r16, r17

	cpi R16, 0
	BREQ cero ;Si es 0, hago lo del cero

	cpi R16, 1
	BREQ uno ;Si es 1, hago lo del uno


	cpi R16, 2
	BREQ dos ;Si es 2, hago lo del dos

	cpi R16, 3
	BREQ tres ;Si es 3, hago lo del tres

	cpi R16, 4
	BREQ cuatro ;Si es 4, hago lo del cuatro

	cpi R16, 5
	BREQ cinco ;Si es 5, hago lo del cinco

	cpi R16, 6
	BREQ seis ;Si es 6, hago lo del seis

	cpi R16, 7
	BREQ siete ;Si es 7, hago lo del siete

	cpi R16, 8
	BREQ ocho ;Si es 8, hago lo del ocho

	cpi R16, 9
	BREQ nueve ;Si es 9, hago lo del nueve

	;else
	ldi R16, 0b0000_0000
	out PORTC, R16
	RJMP REGRESA

RJMP REGRESA

cero:
	ldi R16, 0b0011_1111
	out PORTC, R16
	RJMP REGRESA
uno:
	ldi R16, 0b0000_0110
	out PORTC, R16
	RJMP REGRESA
dos:
	ldi R16, 0b0101_1011
	out PORTC, R16
	RJMP REGRESA
tres:
	ldi R16, 0b0100_1111
	out PORTC, R16
	RJMP REGRESA
cuatro:
	ldi R16, 0b0110_0110
	out PORTC, R16
	RJMP REGRESA
cinco:
	ldi R16, 0b0110_1101
	out PORTC, R16
	RJMP REGRESA
seis:
	ldi R16, 0b0111_1101
	out PORTC, R16
	RJMP REGRESA
siete:
	ldi R16, 0b0000_0111
	out PORTC, R16
	RJMP REGRESA
ocho:
	ldi R16, 0b0111_1111
	out PORTC, R16
	RJMP REGRESA
nueve:
	ldi R16, 0b0110_1111
	out PORTC, R16
	RJMP REGRESA

;******************************************************
;Aquí están las rutinas para el manejo de las interrupciones concretas
;******************************************************
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

