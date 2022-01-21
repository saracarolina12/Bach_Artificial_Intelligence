;******************************************************
; Teclado Matricial 
;
; Fecha: 05/10/2021
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

.equ DDR_D = DDRD
.equ PORT_D = PORTD
.equ PIN_D = PIND
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
ldi r17, high(RAMEND)
out SPH, r17
ldi r17, low(RAMEND)
out SPL, r17 

;******************************************************
;No olvides configurar al inicio los puertos que utilizarás
;También debes configurar si habrá o no pull ups en las entradas
;Para las salidas deberás indicar cuál es la salida inicial
;Los registros que vayas a utilizar inicializalos si es necesario
;******************************************************

//TECLADO
ldi R17, 0xF0						;es lo mismo que declararlo como 0b1111_0000
out DDR_TEC, R17					;configuré el puerto del teclado SALIDAS:ENTRADAS

//DISPLAYS
ldi R17, 0xFF						;DDRD: 0b_1111_1111 = salidas por ser leds 
out DDR_D, R17
ldi R17, 0xFF						;PORTD: 0b_1111_1111 = encendidos de inicio
out PORT_D, R17

//iniciar con 0 display
ldi R17,0; R17 = 0
out PORTD, R17 ;Mostrar 0 en display

TECLADO: //ciclo
	;ldi R17, 0b1110_1111			;para ahorrarme el "cbi PORT_TEC, 4"
	ldi R17, 0xFF
	out PORT_TEC, R17				;5v:Salidas // pullups:entradas
	cbi PORT_TEC, 4					;A4=0 (pin 4 con 0)
	nop								;pierde un ciclo de reloj
	nop								;pierde otro ciclo de reloj
	

	//1,4,7,*  ---------------------------------------------------------
	sbis PIN_TEC,0					;si tiene un 1 se brinca la línea
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
	sbis PIN_TEC,0					;tiene un 1 se brinca la línea
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
	sbis PIN_TEC,0					;tiene un 1 se brinca la línea
	rjmp TRES
	sbis PIN_TEC,1
	rjmp SEIS
	sbis PIN_TEC,2
	rjmp NUEVE
	sbis PIN_TEC,3
	rjmp GATO

	sbi PORT_TEC, 6					;A5=1 --5v
	cbi PORT_TEC, 7					;A6=0 --0v
	nop
	nop
	   
	//A,B,C,D   ---------------------------------------------------------
	sbis PIN_TEC,0					;tiene un 1 se brinca la línea
	rjmp A
	sbis PIN_TEC,1
	rjmp B
	sbis PIN_TEC,2
	rjmp C
	sbis PIN_TEC,3
	rjmp D

rjmp TECLADO  //regresa al ciclo


UNO:
	ldi R17, 0b1000_0000
	rcall MOVER 
	;código al presionar
	rcall RETARDO50m
	TRABA_UNO:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entró el UNO en A0
	RJMP TRABA_UNO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

DOS:	
	ldi R17, 0b0100_0000
	rcall MOVER 
	;código al presionar
	rcall RETARDO50m
	TRABA_DOS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entró el UNO en A0
	RJMP TRABA_DOS
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

TRES:	
	ldi R17, 0b1100_0000
	rcall MOVER 
	;código al presionar
	rcall RETARDO50m
	TRABA_TRES:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entró el UNO en A0
	RJMP TRABA_TRES
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

CUATRO:	
	ldi R17, 0b0010_0000
	rcall MOVER 
	;código al presionar
	rcall RETARDO50m
	TRABA_CUATRO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_CUATRO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

CINCO:		
	ldi R17, 0b1010_0000
	rcall MOVER 
	;código al presionar
	rcall RETARDO50m
	TRABA_CINCO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_CINCO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

SEIS:		
	ldi R17, 0b0110_0000
	rcall MOVER 
	;código al presionar
	rcall RETARDO50m
	TRABA_SEIS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_SEIS
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

SIETE:
	ldi R17, 0b_1110_0000	
	rcall MOVER 
	;código al presionar
	rcall RETARDO50m
	TRABA_SIETE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_SIETE
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

OCHO:	
	ldi R17, 0b0001_0000
	rcall MOVER 
	;código al presionar
	rcall RETARDO50m
	TRABA_OCHO:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_OCHO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

NUEVE:
	ldi R17, 0b1001_0000	
	rcall MOVER 
	;código al presionar
	rcall RETARDO50m
	TRABA_NUEVE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_NUEVE
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO


A:	
	//out PORTD, R17
	;código al presionar
	rcall RETARDO50m
	TRABA_A:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 0			;A0 porque entró el UNO en A0
	RJMP TRABA_A
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

B:	
	//out PORTD, R17
	;código al presionar
	rcall RETARDO50m
	TRABA_B:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 1			;A0 porque entró el UNO en A0
	RJMP TRABA_B
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

C:	
	//out PORTD, R17
	;código al presionar
	rcall RETARDO50m
	TRABA_C:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2			;A0 porque entró el UNO en A0
	RJMP TRABA_C
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

D:	
	//out PORTD, R17
	;código al presionar
	rcall RETARDO50m
	TRABA_D:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entró el UNO en A0
	RJMP TRABA_D
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

AST:
	//out PORTD, R17
	;código al presionar
	rcall RETARDO50m
	TRABA_AST:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entró el UNO en A0
	RJMP TRABA_AST
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO


CERO:	
	ldi R17, 0 
	rcall MOVER 
	;código al presionar
	rcall RETARDO50m
	TRABA_CERO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entró el UNO en A0
	RJMP TRABA_CERO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO


GATO:	
	//out PORTD, R17
	;código al presionar
	rcall RETARDO50m
	TRABA_GATO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entró el UNO en A0
	RJMP TRABA_GATO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

MOVER:
	or R18,R17
	out PORTD, R18
	mov R18,R17
	swap R18
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

