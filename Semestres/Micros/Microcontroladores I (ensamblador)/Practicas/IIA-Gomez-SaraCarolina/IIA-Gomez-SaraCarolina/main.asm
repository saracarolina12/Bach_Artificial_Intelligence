/*
OCR0		TIEMPO ALTO				ÁNGULO				
86				0.000696			0					
87				0.000704			20
88				0.000712			40
89				0.000720			60		
90				0.000728			80
91				0.000736			100					
95				0.000768			180    
*/

;******************************************************
; Examen Final
;
; Fecha: 30/11/2021
; Autor: Sara Carolina Gómez Delgado
;******************************************************

.include "m16adef.inc"     
   
;******************************************************
;Registros (aquí pueden definirse)
;.def temporal=r19

;Palabras claves (aquí pueden definirse)
;.equ LCD_DAT=DDRC
;.equ ESA = DDRA
;.equ ESA = DDRB
;.equ ESA = DDRC
;.equ ESA = DDRD
.equ DDR_TEC = DDRA	
.equ PORT_TEC = PORTA 
.equ PIN_TEC = PINA
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
//salidas 2,1,0
res:
	//TECLADO 
	ldi R16, 0b0000_0111				;salidas(a7,a6,a5), las demás entradas
	out DDR_TEC, R16					
	ldi R16, $FF
	out PORT_TEC, R16
	//DISPLAY C
	ldi R16, $FF						;salidas
	out DDRC, R16						
	ldi R16, 0						;encendidos
	out PORTC, R16	
	//DISPLAY D
	ldi R16, $FF						;salidas
	out DDRD, R16						
	ldi R16, 0						;encendidos
	out PORTD, R16
	//SERVO
	ldi R16, $FF						;salidas
	out DDRB, R16
	ldi R16, $FF						;encendido al inicio
	out PORTB, R16
	ldi R16, 0							;inicializo en 0
	out TCNT0, R16
	ldi R16, 86							;(segs=0.001) 0=0°
	out OCR0, R16
	ldi R16, 0b0110_1011				;prescaler = 64
	out TCCR0, R16
	clr R23								//CONTADOR

TECLADO: //ciclo
	ldi R16, 0xFF
	out PORT_TEC, R16				;5v:Salidas // pullups:entradas
	cbi PORT_TEC, 0					;A4=0 (pin 4 con 0)
	nop								;pierde un ciclo de reloj
	nop								;pierde otro ciclo de reloj

	//3,6,9,#  --------------------------------------------------------- A0
	sbis PIN_TEC,3					;si tiene un 1 se brinca la línea
	rjmp TRES
	sbis PIN_TEC,4
	rjmp SEIS
	sbis PIN_TEC,5
	rjmp NUEVE
	sbis PIN_TEC,6
	rjmp GATO
	sbi PORT_TEC, 0					;A4=1 --5v
	cbi PORT_TEC, 1					;A5=0 --0v
	nop
	nop

	//2,5,8,0   ---------------------------------------------------------A1
	sbis PIN_TEC,3					;tiene un 1 se brinca la línea
	rjmp DOS
	sbis PIN_TEC,4
	rjmp CINCO
	sbis PIN_TEC,5
	rjmp OCHO
	sbis PIN_TEC,6
	rjmp CERO
	sbi PORT_TEC, 1					;A5=1 --5v
	cbi PORT_TEC, 2					;A6=0 --0v
	nop
	nop

	//1,4,7,*   ---------------------------------------------------------A2
	sbis PIN_TEC,3					;tiene un 1 se brinca la línea
	rjmp UNO
	sbis PIN_TEC,4
	rjmp CUATRO
	sbis PIN_TEC,5
	rjmp SIETE
	sbis PIN_TEC,6
	rjmp AST

rjmp TECLADO  //regresa al ciclo


UNO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_UNO:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 3				;A0 porque entró el UNO en A0
	RJMP TRABA_UNO
	rcall RETARDO50m
	;código al soltar 
	ldi R16, 8
	ldi R26, 1						;valor real
	rcall PRINT
rjmp TECLADO

DOS:	
	;código al presionar
	rcall RETARDO50m
	TRABA_DOS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 3				;A0 porque entró el UNO en A0
	RJMP TRABA_DOS
	rcall RETARDO50m
	;código al soltar
	ldi R16, 4
	ldi R26, 2
	rcall PRINT
rjmp TECLADO

TRES:	
	;código al presionar
	rcall RETARDO50m
	TRABA_TRES:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 3				;A0 porque entró el UNO en A0
	RJMP TRABA_TRES
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b0000_1100
	ldi R26, 3
	rcall PRINT
rjmp TECLADO

CUATRO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_CUATRO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 4				;A0 porque entró el UNO en A0
	RJMP TRABA_CUATRO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b0000_0010
	ldi R26, 4
	rcall PRINT
rjmp TECLADO

CINCO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_CINCO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 4				;A0 porque entró el UNO en A0
	RJMP TRABA_CINCO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b0000_1010
	ldi R26, 5
	rcall PRINT
rjmp TECLADO

SEIS:	
	;código al presionar
	rcall RETARDO50m
	TRABA_SEIS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 4				;A0 porque entró el UNO en A0
	RJMP TRABA_SEIS
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b0000_0110
	ldi R26, 6
	rcall PRINT
rjmp TECLADO

SIETE:	
	;código al presionar
	rcall RETARDO50m
	TRABA_SIETE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 5				;A0 porque entró el UNO en A0
	RJMP TRABA_SIETE
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b0000_1110
	ldi R26, 7
	rcall PRINT
rjmp TECLADO

OCHO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_OCHO:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 5				;A0 porque entró el UNO en A0
	RJMP TRABA_OCHO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 1
	ldi R26, 8
	rcall PRINT
rjmp TECLADO

NUEVE:	
	;código al presionar
	rcall RETARDO50m
	TRABA_NUEVE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 5				;A0 porque entró el UNO en A0
	RJMP TRABA_NUEVE
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b0000_1001
	ldi R26, 9
	rcall PRINT
rjmp TECLADO

AST:	
	;código al presionar
	rcall RETARDO50m
	TRABA_AST:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 6			;A0 porque entró el UNO en A0
	RJMP TRABA_AST
	rcall RETARDO50m
	;código al soltar
	cpi R23, 2				//sólo si es el segundo número, se va a revisar el rango en que se encuentra
	breq RANGOS
	regresarangos:
rjmp TECLADO

RANGOS:
	//convertir número a número real [R17,R16]
		ldi R19, 10				//por ejemplo 7*10 = 70 para tomar el valor real y no sólo un 7
		//primer dígito
		mul R25, R19			//convertir en decena
		add R0, R26
		mov R25, R0
		
		//RANGOS
		cpi R25,0				//resultado
		brsh checkcero					// >= 0
		fincero:
		cpi R25, 10
		brsh checkveinte
		finveinte:
		cpi R25, 30
		brsh checkcuarenta
		fincuarenta:
		cpi R25, 50
		brsh checksesenta
		finsesenta:
		cpi R25, 70
		brsh checkochenta
		finochenta:
		cpi R25, 90
		brsh checkcien
		fincien:
	rjmp regresarangos

checkcero:
	cpi R25, 10
	brlo G_CERO					//<9
	fingcero:
	rjmp fincero
checkveinte:
	cpi R25, 30
	brlo G_VEINTE
	fingveinte:
	rjmp finveinte
checkcuarenta:
	cpi R25, 50
	brlo G_CUARENTA
	fingcuarenta:
	rjmp fincuarenta
checksesenta:
	cpi R25, 70
	brlo G_SESENTA
	fingsesenta:
	rjmp finsesenta
checkochenta:
	cpi R25, 90
	brlo G_OCHENTA
	fingochenta:
	rjmp finochenta
checkcien:
	cpi R25, 100
	brlo G_CIEN
	fingcien:
	rjmp fincien
CERO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_CERO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 6			;A0 porque entró el UNO en A0
	RJMP TRABA_CERO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0
	ldi R26, 0
	rcall PRINT
rjmp TECLADO

GATO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_GATO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 6			;A0 porque entró el UNO en A0
	RJMP TRABA_GATO
	rcall RETARDO50m
	;código al soltar
	rjmp res					;reset
rjmp TECLADO

PRINT:
	inc R23
	cpi R23, 1
	breq PRIMER
	fin_primer:
	cpi R23, 2
	breq SEGUNDO
	fin_segundo:
	ret

PRIMER:
	out PORTC, R16					//lo saco a las unidades 
	mov R17, R16					//respaldo ese primer número
	mov R25, R26
	rjmp fin_primer

SEGUNDO:
	out PORTC, R16					//saco el nuevo número
	out PORTD, R17					//saco el respaldo
	rjmp fin_segundo

G_CERO:
	ldi R16, 86						
	out OCR0, R16
	ldi R16, 0b0110_1011				
	out TCCR0, R16
	rjmp fingcero

G_VEINTE:
	ldi R16, 87						
	out OCR0, R16
	ldi R16, 0b0110_1011				
	out TCCR0, R16
	rjmp fingveinte

G_CUARENTA:
	ldi R16, 88						
	out OCR0, R16
	ldi R16, 0b0110_1011				
	out TCCR0, R16
	rjmp fingcuarenta

G_SESENTA:
	ldi R16, 89						
	out OCR0, R16
	ldi R16, 0b0110_1011				
	out TCCR0, R16
	rjmp fingsesenta

G_OCHENTA:
	ldi R16, 90					
	out OCR0, R16
	ldi R16, 0b0110_1011				
	out TCCR0, R16
	rjmp fingochenta

G_CIEN:
	ldi R16, 91						
	out OCR0, R16
	ldi R16, 0b0110_1011				
	out TCCR0, R16
	rjmp fingcien

RETARDO50m:						//400,000 ciclos - 8MHz
	; ============================= 
	;    delay loop generator 
	;     400000 cycles:
	; ----------------------------- 
	; delaying 399999 cycles:
			  ldi  R31, $97
	WGLOOP0:  ldi  R30, $06
	WGLOOP1:  ldi  R29, $92
	WGLOOP2:  dec  R29
			  brne WGLOOP2
			  dec  R30
			  brne WGLOOP1
			  dec  R31
			  brne WGLOOP0
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