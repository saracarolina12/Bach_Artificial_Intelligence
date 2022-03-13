;******************************************************
; Cambio de intensidad de LED
;
; Fecha: 18/11/2021
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

;******************************************************
;No olvides configurar al inicio los puertos que utilizarás
;También debes configurar si habrá o no pull ups en las entradas
;Para las salidas deberás indicar cuál es la salida inicial
;Los registros que vayas a utilizar inicializalos si es necesario
;******************************************************
/*
	leds:
		B3: principal
		B2: máximo
		B1: mínimo
	botones:
		A0: aumenta
		A1: disminuye
*/
;LEDS
ldi R16, $FF									;salida
out DDRB, R16
ldi R16, 0b0000_1010							;encendido  B3,B1
out PORTB, R16	
;BOTONES
ldi R16, 0										;entrada
out DDRA, R16
ldi R16, $FF									;pullups
out PORTA, R16
;TIMER0
ldi R16, 0										;inicializo en 0
out TCNT0, R16
ldi R16, 0b0110_1011
out TCCR0, R16
clr R19											;intensidad
ldi R20, 5									
out OCR0, R19
BOTONES:	
	sbis PINA, 0							
		rcall AUMENTA
	sbis PINA, 1
		rcall DISMINUYE	
rjmp BOTONES

AUMENTA:
	//presionar
	rcall RETARDO
	traba: sbis PINA,0
		rjmp traba
	rcall RETARDO
	//soltar
	cpi R19, 250									;si es el máximo (250 porque como va de 10 en 10, no puede llegar al 255)
	breq INTENSIDADMAX
	cpi R19, 255									;si excede, ya no suma
	breq yamax	
	add R19, R20
	out OCR0, R19
	cbi PORTB, 1
	yamax:
	ret

DISMINUYE:
	//presionar
	rcall RETARDO
	trabadis: sbis PINA,0
		rjmp trabadis
	rcall RETARDO
	//soltar
	cpi R19, 0
	breq INTENSIDADMIN	
	subi R19, 5
	out OCR0, R19
	cbi PORTB, 2
	yamin:
	ret

INTENSIDADMAX:
	sbi PORTB, 2
	rjmp yamax

INTENSIDADMIN:
	sbi PORTB, 1
	rjmp yamin

RETARDO:
	; ============================= 
	;    delay loop generator 
	;     100000 cycles:
	; ----------------------------- 
	; delaying 99990 cycles:
			  ldi  R31, $A5
	WGLOOP0:  ldi  R30, $C9
	WGLOOP1:  dec  R30
			  brne WGLOOP1
			  dec  R31
			  brne WGLOOP0
	; ----------------------------- 
	; delaying 9 cycles:
			  ldi  R31, $03
	WGLOOP2:  dec  R31
			  brne WGLOOP2
	; ----------------------------- 
	; delaying 1 cycle:
			  nop
	; ============================= 
	ret

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
