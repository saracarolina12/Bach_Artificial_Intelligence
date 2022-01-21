;******************************************************
; Examen Parcial 2
;
; Fecha: 19/10/2021
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

//TECLADO Y BOTÓN-A
ldi R16, 0b0001_1110				;ENTRADAS Y SALIDAS PUERTO A ....A0 = botón----> A1,A2,A3,A4 = salida
out DDR_TEC, R16					
ldi R16, $FF						;SÍ pull ups por ser botones, PUERTO A
out PORT_TEC, R16

/*
//DISPLAY ROJO-B
ldi R24, $FF						;SALIDAS PUERTO B
out DDRB, R24	
ldi R24, 0							;apagados al inicio
out PORTB, R24					

//DISPLAY AZUL-C
ldi R18, $FF						;SALIDAS PUERTO B
out DDRC, R16	
ldi R18, 0							;apagados al inicio
out PORTC, R18	

//DISPLAY VERDE-D
ldi R20, $FF						;SALIDAS PUERTO B
out DDRD, R16	
ldi R20, 0							;apagados al inicio
out PORTD, R20	
*/

//DISPLAY ROJO-B
ldi R16, $FF						;SALIDAS PUERTO B
out DDRB, R16	
ldi R16, 0							;apagados al inicio
out PORTB, R16					

//DISPLAY AZUL-C
ldi R16, $FF						;SALIDAS PUERTO B
out DDRC, R16	
ldi R16, 0							;apagados al inicio
out PORTC, R16

//DISPLAY VERDE-D
ldi R16, $FF						;SALIDAS PUERTO B
out DDRD, R16	
ldi R16, 0							;apagados al inicio
out PORTD, R16	

ldi R17, 0							;num B1
ldi R18, 0							;num A2 
ldi R19, 0							;num B2
ldi R22, 0							;CONTADOR 

TECLADO: //ciclo
	sbis PINA,0						;aquí  está el botón
		rcall RST					;hace si está presionado
	;ldi R16, 0b1110_1111			;para ahorrarme el "cbi PORT_TEC, 4"
	ldi R16, 0xFF
	out PORT_TEC, R16				;5v:Salidas // pullups:entradas
	cbi PORT_TEC, 1					;A4=0 (pin 4 con 0)
	nop								;pierde un ciclo de reloj
	nop								;pierde otro ciclo de reloj
	
	//1,4,7,*  ---------------------------------------------------------
	sbis PIN_TEC,1					;si tiene un 1 se brinca la línea
	rjmp UNO
	sbis PIN_TEC,2
	rjmp CUATRO
	sbis PIN_TEC,3
	rjmp SIETE
	sbis PIN_TEC,4
	rjmp AST
	sbi PORT_TEC, 1					;A4=1 --5v
	cbi PORT_TEC, 2					;A5=0 --0v
	nop
	nop

	//2,5,8,0   ---------------------------------------------------------
	sbis PIN_TEC,1					;tiene un 1 se brinca la línea
	rjmp DOS
	sbis PIN_TEC,2
	rjmp CINCO
	sbis PIN_TEC,3
	rjmp OCHO
	sbis PIN_TEC,4
	rjmp CERO
	sbi PORT_TEC, 2					;A5=1 --5v
	cbi PORT_TEC, 3					;A6=0 --0v
	nop
	nop

	//3,6,9,#   ---------------------------------------------------------
	sbis PIN_TEC,1					;tiene un 1 se brinca la línea
	rjmp TRES
	sbis PIN_TEC,2
	rjmp SEIS
	sbis PIN_TEC,3
	rjmp NUEVE
	sbis PIN_TEC,4
	rjmp GATO
	sbi PORT_TEC, 3					;A5=1 --5v
	cbi PORT_TEC, 4					;A6=0 --0v
	nop
	nop

rjmp TECLADO  //regresa al ciclo

UNO:	
	inc R22
	cpi R22, 1
		BREQ uno_esuno
	cpi R22, 2
		BREQ uno_esdos
	cpi R22, 3
		BREQ uno_estres
	cpi R22, 4
		BREQ uno_escuatro
	;código al presionar
	rcall RETARDO50m
	TRABA_UNO	:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entró el UNO en A0
	RJMP TRABA_UNO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
uno_esuno:
	ldi R16, 0b1000_0000
	rcall ESUNO
uno_esdos:
	ldi R17, 0b1000_0000
	rcall ESDOS
uno_estres:
	ldi R18, 0b1000_0000
	rcall ESTRES
uno_escuatro:
	ldi R19, 0b1000_0000
	rcall ESCUATRO

DOS: 
	inc R22
	cpi R22, 1
		BREQ dos_esuno
	cpi R22, 2
		BREQ dos_esdos
	cpi R22, 3
		BREQ dos_estres
	cpi R22, 4
		BREQ dos_escuatro
	;código al presionar
	rcall RETARDO50m
	TRABA_DOS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entró el UNO en A0
	RJMP TRABA_DOS
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
dos_esuno:
	ldi R16, 0b0100_0000
	rcall ESUNO
dos_esdos:
	ldi R17, 0b0100_0000
	rcall ESDOS
dos_estres:
	ldi R18, 0b0100_0000
	rcall ESTRES
dos_escuatro:
	ldi R19, 0b0100_0000
	rcall ESCUATRO

TRES:
	inc R22
	cpi R22, 1
		BREQ tres_esuno
	cpi R22, 2
		BREQ tres_esdos
	cpi R22, 3
		BREQ tres_estres
	cpi R22, 4
		BREQ tres_escuatro
	;código al presionar
	rcall RETARDO50m
	TRABA_TRES:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entró el UNO en A0
	RJMP TRABA_TRES
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
tres_esuno:
	ldi R16, 0b1100_0000
	rcall ESUNO
tres_esdos:
	ldi R17, 0b1100_0000
	rcall ESDOS
tres_estres:
	ldi R18, 0b1100_0000
	rcall ESTRES
tres_escuatro:
	ldi R19, 0b1100_0000
	rcall ESCUATRO

CUATRO:	
	inc R22
	cpi R22, 1
		BREQ cuatro_esuno
	cpi R22, 2
		BREQ  cuatro_esdos
	cpi R22, 3
		BREQ  cuatro_estres
	cpi R22, 4
		BREQ  cuatro_escuatro
	;código al presionar
	rcall RETARDO50m
	TRABA_CUATRO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_CUATRO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
cuatro_esuno:
	ldi R16, 0b0010_0000
	rcall ESUNO
cuatro_esdos:
	ldi R17, 0b0010_0000
	rcall ESDOS
cuatro_estres:
	ldi R18, 0b0010_0000
	rcall ESTRES
cuatro_escuatro:
	ldi R19, 0b0010_0000
	rcall ESCUATRO

CINCO:	
	inc R22
	cpi R22, 1
		BREQ cinco_esuno
	cpi R22, 2
		BREQ cinco_esdos
	cpi R22, 3
		BREQ cinco_estres
	cpi R22, 4
		BREQ cinco_escuatro
	;código al presionar
	rcall RETARDO50m
	TRABA_CINCO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_CINCO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
cinco_esuno:
	ldi R16, 0b1010_0000
	rcall ESUNO
cinco_esdos:
	ldi R17, 0b1010_0000
	rcall ESDOS
cinco_estres:
	ldi R18, 0b1010_0000
	rcall ESTRES
cinco_escuatro:
	ldi R19, 0b1010_0000
	rcall ESCUATRO

ESUNO:
	swap R16					;SWAAAAAP
	ret
ESDOS:							;JUNTO en un sólo registro los dos números	
	or R16, R17					
	//ldi r23, 0b0000_0001		;levanto bandera para que ignore los números
	ret
ESTRES:							;SWAAAAAP
	swap R18
	ret
ESCUATRO:						;JUNTO en un sólo registro los dos números	
	or R18, R19
	ret 

SEIS:	
	inc R22
	cpi R22, 1
		BREQ seis_esuno
	cpi R22, 2
		BREQ seis_esdos
	cpi R22, 3
		BREQ seis_estres
	cpi R22, 4
		BREQ seis_escuatro
	;código al presionar
	rcall RETARDO50m
	TRABA_SEIS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_SEIS
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
 seis_esuno:
	ldi R16,0b0110_0000
	rcall ESUNO
seis_esdos:
	ldi R17,0b0110_0000
	rcall ESDOS
seis_estres:
	ldi R18,0b0110_0000
	rcall ESTRES
seis_escuatro:
	ldi R19,0b0110_0000
	rcall ESCUATRO

SIETE:
	inc R22
	cpi R22, 1
		BREQ siete_esuno
	cpi R22, 2
		BREQ siete_esdos
	cpi R22, 3
		BREQ siete_estres
	cpi R22, 4
		BREQ siete_escuatro
	;código al presionar
	rcall RETARDO50m
	TRABA_SIETE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_SIETE
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
siete_esuno:
	ldi R16, 0b_1110_0000
	rcall ESUNO
siete_esdos:
	ldi R17, 0b_1110_0000
	rcall ESDOS
siete_estres:
	ldi R18, 0b_1110_0000
	rcall ESTRES
siete_escuatro:
	ldi R19, 0b_1110_0000
	rcall ESCUATRO

OCHO:	
	inc R22
	cpi R22, 1
		BREQ ocho_esuno
	cpi R22, 2
		BREQ ocho_esdos
	cpi R22, 3
		BREQ ocho_estres
	cpi R22, 4
		BREQ ocho_escuatro
	;código al presionar
	rcall RETARDO50m
	TRABA_OCHO:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_OCHO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
ocho_esuno:
	ldi R16, 0b0001_0000
	rcall ESUNO
ocho_esdos:
	ldi R17, 0b0001_0000
	rcall ESDOS
ocho_estres:
	ldi R18, 0b0001_0000
	rcall ESTRES
ocho_escuatro:
	ldi R19, 0b0001_0000
	rcall ESCUATRO

NUEVE:	
	inc R22
	cpi R22, 1
		BREQ nueve_esuno
	cpi R22, 2
		BREQ nueve_esdos
	cpi R22, 3
		BREQ nueve_estres
	cpi R22, 4
		BREQ nueve_escuatro
	;código al presionar
	rcall RETARDO50m
	TRABA_NUEVE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_NUEVE
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
nueve_esuno:
	ldi R16, 0b1001_0000
	rcall ESUNO
nueve_esdos:
	ldi R17, 0b1001_0000
	rcall ESDOS
nueve_estres:
	ldi R18, 0b1001_0000
	rcall ESTRES
nueve_escuatro:
	ldi R19, 0b1001_0000
	rcall ESCUATRO

cero_esuno:
	ldi R16, 0
	rcall ESUNO
cero_esdos:
	ldi R17, 0
	rcall ESUNO
cero_estres:
	ldi R18, 0
	rcall ESUNO
cero_escuatro:
	ldi R19, 0
	rcall ESUNO
CERO:	
	inc R22
	cpi R22, 1
		BREQ cero_esuno
	cpi R22, 2
		BREQ cero_esdos
	cpi R22, 3
		BREQ cero_estres
	cpi R22, 4
		BREQ cero_escuatro
	;código al presionar
	rcall RETARDO50m
	TRABA_CERO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entró el UNO en A0
	RJMP TRABA_CERO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

GATO:
	rcall SUMA	
	;código al presionar
	rcall RETARDO50m
	TRABA_GATO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entró el UNO en A0
	RJMP TRABA_GATO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

AST:	
	rcall RESTA
	;código al presionar
	rcall RETARDO50m
	TRABA_AST:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entró el UNO en A0
	RJMP TRABA_AST
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
RST:
	ldi R22, 0
	ret
SUMA:
	adc R16,R18					;ADD with carry 
	out PORTD, R16				;Saca resultado
	rjmp TECLADO

RESTA:
	sbc R16, R18
	out PORTD, R16
	rjmp TECLADO


RETARDO50m:						//400,000 ciclos = 8mhz
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

