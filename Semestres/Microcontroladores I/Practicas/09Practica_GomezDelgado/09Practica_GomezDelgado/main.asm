;******************************************************
; Cronómetro
;
; Fecha: 09/11/2021
; Autor: Sara Carolina Gómez Delgado
;******************************************************

.include "m16adef.inc"     
   
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
sei

;******************************************************
;No olvides configurar al inicio los puertos que utilizarás
;También debes configurar si habrá o no pull ups en las entradas
;Para las salidas deberás indicar cuál es la salida inicial
;Los registros que vayas a utilizar inicializalos si es necesario
;******************************************************
/*
		R17 = contador de 1 segundo
		R18 = [x][segundos]
		R19 = [mins][x]
*/
res:
	//BOTONES-A
	ldi R16, 0													
	out DDRA, R16
	ldi R16, $FF												
	out PORTA, R16
	//MINUTOS-C
	ldi R16, $FF												
	out DDRC, R16
	ldi R16, 0
	out PORTC, R16
	//MINUTOS-D
	ldi R16, $FF												
	out DDRD, R16
	ldi R16, 0
	out PORTD, R16


	ldi R16, 0											;lleva la cuenta cada N ciclos
	out TCNT0, R16
	ldi R16, 155										;0.01 segundos
	out OCR0, R16	
	ldi R16, 0b0000_0011								;0000_00xx [comp][overf] 1=limpia, 0=activa
	out TIFR, R16
	ldi R16, 0b0000_0010								;0000_00xx [comp][overf] 1=usar, 0=no_usar
	out TIMSK, R16
	;ldi R16, 0b0000_1100 todavía no se pone
	;out TCCR0, R16

	BOTONES:
			sbis PINA, 0								;INICIO
			rcall INICIO
			sbis PINA, 7								;LIMPIAR
			rjmp res
		rjmp BOTONES


INICIO:
	ldi R16, 0b0000_1100
	out TCCR0, R16										;enciendo el TIMER0_COMP
	rcall RETARDO
	traba: sbis pinA, 0									;¿el A0 sigue presionado?
		   rjmp traba									;sí
	rcall RETARDO										;no
	rjmp BOTONES
	

RETARDO:
	; ============================= 
	;    delay loop generator 
	;     100000 cycles:
	; ----------------------------- 
	; delaying 99990 cycles:
			  ldi  R29, $A5
	WGLOOP0:  ldi  R30, $C9
	WGLOOP1:  dec  R30
			  brne WGLOOP1
			  dec  R29
			  brne WGLOOP0
	; ----------------------------- 
	; delaying 9 cycles:
			  ldi  R29, $03
	WGLOOP2:  dec  R29
			  brne WGLOOP2
	; ----------------------------- 
	; delaying 1 cycle:
			  nop
	; ============================= 
	RET

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
	ldi R16, SREG								;respaldo SREG
	push R16									;respaldo SREG
	inc R17										;contador 1 seg
	cpi R17, 100				
	rjmp ES_100									;si sí es 100	
	regresa:
		pop R16										;si no, regresa
		out SREG, R16																				
reti
SPM_RDY: 
reti ; Store Program Memory Ready Handler


ES_100:
	inc R18
	cpi R18, 59
	rjmp ES_59
	//help

ES_59:
	ldi R18, 0
	inc R19										;aumento minutos
	out PORTC, R19								;saco minutos
	ldi R17, 0
	rjmp regresa

	



