;******************************************************
; Display al revés
;
; Fecha: 20/12/2021
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

/*En las salidas rota la tierra*/
//TECLADO A
ldi R16, 0b1010_1010				;7-5-3-1:salidas // 6-4-2-0:entradas
out DDR_TEC, R16					;configuré el puerto del teclado ENTRADAS:SALIDAS
ldi R16, 0b1111_1111				;pullups : salida inicial 1
out PORT_TEC, R16

//DISPLAY B
ldi R16, $FF						;salida, led
out DDRB, R16
ldi R16, 0							;inicia en 0
out PORTB, R16


TECLADO: //ciclo	
	ldi R16, 0b1111_1111			;pullups : salida inicial 1
	out PORT_TEC, R16

	cbi PORT_TEC, 1						;para empezar a rotar la tierra (en las salidas)
	nop
	nop

	sbis PIN_TEC, 0
	rjmp D
	sbis PIN_TEC, 2
	rjmp GATO
	sbis PIN_TEC, 4
	rjmp CERO
	sbis PIN_TEC, 6
	rjmp AST

	sbi PORT_TEC, 1
	cbi PORT_TEC, 3
	nop
	nop

	sbis PIN_TEC, 0
	rjmp C
	sbis PIN_TEC, 2
	rjmp TRES
	sbis PIN_TEC, 4
	rjmp DOS
	sbis PIN_TEC, 6
	rjmp UNO

	sbi PORT_TEC, 3
	cbi PORT_TEC, 5
	nop
	nop

	sbis PIN_TEC, 0
	rjmp B
	sbis PIN_TEC, 2
	rjmp SEIS
	sbis PIN_TEC, 4
	rjmp CINCO
	sbis PIN_TEC, 6
	rjmp CUATRO

	sbi PORT_TEC, 5
	cbi PORT_TEC, 7
	nop
	nop

	sbis PIN_TEC, 0
	rjmp A
	sbis PIN_TEC, 2
	rjmp NUEVE
	sbis PIN_TEC, 4
	rjmp OCHO
	sbis PIN_TEC, 6
	rjmp SIETE

rjmp TECLADO  //regresa al ciclo


UNO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_UNO:						
		sbis PIN_TEC, 6				;el pin debe ser el que corresponda a la "entrada" del micro->pin
	RJMP TRABA_UNO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b1000_0000
	rcall PRINT
rjmp TECLADO

DOS:	
	;código al presionar
	rcall RETARDO50m
	TRABA_DOS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 4				;A0 porque entró el UNO en A0
	RJMP TRABA_DOS
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b0100_0000
	rcall PRINT
rjmp TECLADO

TRES:	
	;código al presionar
	rcall RETARDO50m
	TRABA_TRES:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_TRES
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b1100_0000
	rcall PRINT
rjmp TECLADO

CUATRO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_CUATRO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 6				;A0 porque entró el UNO en A0
	RJMP TRABA_CUATRO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b0010_0000
	rcall PRINT
rjmp TECLADO

CINCO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_CINCO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 4 			;A0 porque entró el UNO en A0
	RJMP TRABA_CINCO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b1010_0000
	rcall PRINT
rjmp TECLADO

SEIS:	
	;código al presionar
	rcall RETARDO50m
	TRABA_SEIS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_SEIS
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b0110_0000
	rcall PRINT
rjmp TECLADO

SIETE:	
	;código al presionar
	rcall RETARDO50m
	TRABA_SIETE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 6				;A0 porque entró el UNO en A0
	RJMP TRABA_SIETE
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b1110_0000
	rcall PRINT
rjmp TECLADO

OCHO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_OCHO:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 4				;A0 porque entró el UNO en A0
	RJMP TRABA_OCHO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b0001_0000
	rcall PRINT
rjmp TECLADO

NUEVE:	
	;código al presionar
	rcall RETARDO50m
	TRABA_NUEVE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_NUEVE
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0b1001_0000
	rcall PRINT
rjmp TECLADO

A:	
	;código al presionar
	rcall RETARDO50m
	TRABA_A:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 0			;A0 porque entró el UNO en A0
	RJMP TRABA_A
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

B:	
	;código al presionar
	rcall RETARDO50m
	TRABA_B:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 0			;A0 porque entró el UNO en A0
	RJMP TRABA_B
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

C:	
	;código al presionar
	rcall RETARDO50m
	TRABA_C:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 0			;A0 porque entró el UNO en A0
	RJMP TRABA_C
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

D:	
	;código al presionar
	rcall RETARDO50m
	TRABA_D:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 0  		;A0 porque entró el UNO en A0
	RJMP TRABA_D
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

AST:	
	;código al presionar
	rcall RETARDO50m
	TRABA_AST:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 6			;A0 porque entró el UNO en A0
	RJMP TRABA_AST
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

CERO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_CERO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 4			;A0 porque entró el UNO en A0
	RJMP TRABA_CERO
	rcall RETARDO50m
	;código al soltar
	clr R16
	rcall PRINT
rjmp TECLADO

GATO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_GATO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2			;A0 porque entró el UNO en A0
	RJMP TRABA_GATO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

PRINT:
	swap R16
	out PORTB, R16
	clr R16
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

