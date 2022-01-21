;******************************************************
; Practica Examen
;
; Fecha: 28/11/2021
; Autor: Sara Carolina G�mez Delgado
;******************************************************

.include "m16adef.inc"     
   
;******************************************************
;Registros (aqu� pueden definirse)
;.def temporal=r19

;Palabras claves (aqu� pueden definirse)
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
;Aqu� comenzar� el programa
;******************************************************
Reset:
;Primero inicializamos el stack pointer...
ldi r16, high(RAMEND)
out SPH, r16
ldi r16, low(RAMEND)
out SPL, r16 


;******************************************************
;No olvides configurar al inicio los puertos que utilizar�s
;Tambi�n debes configurar si habr� o no pull ups en las entradas
;Para las salidas deber�s indicar cu�l es la salida inicial
;Los registros que vayas a utilizar inicializalos si es necesario
;******************************************************

res:
	//TECLADO
	ldi R16, 0b0111_0000			;salidas(a7,a6,a5), las dem�s entradas
	out DDR_TEC, R16					
	ldi R16, $FF
	out PORT_TEC, R16
	//DISPLAY
	ldi R16, $FF					;salidas
	out DDRC, R16						
	ldi R16, 0						;encendidos
	out PORTC, R16
	clr R17							;inicializo R17

TECLADO: //ciclo
	sbis PINA,7						;si presiona reset, se regresa a resetear
		rjmp res
	;ldi R16, 0b1110_1111			;para ahorrarme el "cbi PORT_TEC, 4"
	ldi R16, 0xFF
	out PORT_TEC, R16				;5v:Salidas // pullups:entradas
	cbi PORT_TEC, 4					;A4=0 (pin 4 con 0)
	nop								;pierde un ciclo de reloj
	nop								;pierde otro ciclo de reloj

	//1,4,7,*  ---------------------------------------------------------
	sbis PIN_TEC,0					;si tiene un 1 se brinca la l�nea
	rjmp UNO
	sbis PIN_TEC,1
	rjmp CUATRO
	sbis PIN_TEC,2
	rjmp SIETE
	sbis PIN_TEC,3
	rjmp AST

	sbi PORT_TEC, 4					;A4=1 --5v
	cbi PORT_TEC, 5					;A5=0 --0v
	nop
	nop


	//2,5,8,0   ---------------------------------------------------------
	sbis PIN_TEC,0					;tiene un 1 se brinca la l�nea
	rjmp DOS
	sbis PIN_TEC,1
	rjmp CINCO
	sbis PIN_TEC,2
	rjmp OCHO
	sbis PIN_TEC,3
	rjmp CERO


	sbi PORT_TEC, 5					;A5=1 --5v
	cbi PORT_TEC, 6					;A6=0 --0v
	nop
	nop


	//3,6,9,#   ---------------------------------------------------------
	sbis PIN_TEC,0					;tiene un 1 se brinca la l�nea
	rjmp TRES
	sbis PIN_TEC,1
	rjmp SEIS
	sbis PIN_TEC,2
	rjmp NUEVE
	sbis PIN_TEC,3
	rjmp GATO

rjmp TECLADO  //regresa al ciclo


UNO:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_UNO	:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entr� el UNO en A0
	RJMP TRABA_UNO
	rcall RETARDO50m
	;c�digo al soltar
	ldi R16, 1
	rcall PRINT
rjmp TECLADO

DOS:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_DOS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entr� el UNO en A0
	RJMP TRABA_DOS
	rcall RETARDO50m
	;c�digo al soltar
	ldi R16, 2
	rcall PRINT
rjmp TECLADO

TRES:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_TRES:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entr� el UNO en A0
	RJMP TRABA_TRES
	rcall RETARDO50m
	;c�digo al soltar
	ldi R16, 3
	rcall PRINT
rjmp TECLADO

CUATRO:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_CUATRO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entr� el UNO en A0
	RJMP TRABA_CUATRO
	rcall RETARDO50m
	;c�digo al soltar
	ldi R16, 4
	rcall PRINT
rjmp TECLADO

CINCO:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_CINCO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entr� el UNO en A0
	RJMP TRABA_CINCO
	rcall RETARDO50m
	;c�digo al soltar
	ldi R16, 5
	rcall PRINT
rjmp TECLADO

SEIS:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_SEIS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entr� el UNO en A0
	RJMP TRABA_SEIS
	rcall RETARDO50m
	;c�digo al soltar
	ldi R16, 6
	rcall PRINT
rjmp TECLADO

SIETE:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_SIETE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entr� el UNO en A0
	RJMP TRABA_SIETE
	rcall RETARDO50m
	;c�digo al soltar
	ldi R16, 7
	rcall PRINT
rjmp TECLADO

OCHO:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_OCHO:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entr� el UNO en A0
	RJMP TRABA_OCHO
	rcall RETARDO50m
	;c�digo al soltar
	ldi R16, 8
	rcall PRINT
rjmp TECLADO

NUEVE:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_NUEVE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entr� el UNO en A0
	RJMP TRABA_NUEVE
	rcall RETARDO50m
	;c�digo al soltar
	ldi R16, 9
	rcall PRINT
rjmp TECLADO

AST:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_AST:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entr� el UNO en A0
	RJMP TRABA_AST
	rcall RETARDO50m
	;c�digo al soltar
rjmp TECLADO

CERO:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_CERO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entr� el UNO en A0
	RJMP TRABA_CERO
	rcall RETARDO50m
	;c�digo al soltar
	clr R16
	rcall PRINT
rjmp TECLADO

GATO:	
	;c�digo al presionar
	rcall RETARDO50m
	TRABA_GATO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entr� el UNO en A0
	RJMP TRABA_GATO
	rcall RETARDO50m
	;c�digo al soltar
rjmp TECLADO

PRINT:
	swap R16
	or R16, R17
	out PORTC, R16
	mov R17, R16
	cbr R17, 0b0000_1111
	swap R17
	ret

RETARDO50m:						//50,000 ciclos
	; ============================= 
	;    delay loop generator 
	;     50000 cycles:
	; ----------------------------- 
	; delaying 49995 cycles:
			  ldi  R29, $65
	WGLOOP0:  ldi  R30, $A4
	WGLOOP1:  dec  R30
			  brne WGLOOP1
			  dec  R29
			  brne WGLOOP0
	; ----------------------------- 
	; delaying 3 cycles:
			  ldi  R29, $01
	WGLOOP2:  dec  R29
			  brne WGLOOP2
	; ----------------------------- 
	; delaying 2 cycles:
			  nop
			  nop
	; ============================= 
	ret


/*
RETARDO50m:						//100,000 ciclos
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
*/

/*	
RETARDO50m:						//200,000 ciclos
	; ============================= 
	;    delay loop generator 
	;     200000 cycles:
	; ----------------------------- 
	; delaying 199998 cycles:
			  ldi  R31, $06
	WGLOOP0:  ldi  R30, $37
	WGLOOP1:  ldi  R29, $C9
	WGLOOP2:  dec  R29
			  brne WGLOOP2
			  dec  R30
			  brne WGLOOP1
			  dec  R31
			  brne WGLOOP0
	; ----------------------------- 
	; delaying 2 cycles:
			  nop
			  nop
	; ============================= 
*/

/*
RETARDO50m:						//400,000 ciclos
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
*/





;******************************************************
;Aqu� est�n las rutinas para el manejo de las interrupciones concretas
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

