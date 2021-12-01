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

//TECLADO + BOTÓN A
RST:
	ldi R16, 0b1110_0000				;salidas(a7,a6,a5), las demás entradas
	out DDR_TEC, R16					;configuré el puerto del teclado 
	ldi R16, $FF
	out PORT_TEC, R16					;SÍ pullups, todos son botones
	//DISPLAY ROJO-B
	ldi R16, $FF						;SALIDAS PUERTO B
	out DDRB, R16	
	ldi R16, 0							;apagados al inicio
	out PORTB, R16					
	//DISPLAY AZUL-C
	ldi R21, $FF						;SALIDAS PUERTO B
	out DDRC, R21	
	ldi R21, 0							;apagados al inicio
	out PORTC, R21
	//DISPLAY VERDE-D
	ldi R23, $FF						;SALIDAS PUERTO B
	out DDRD, R23	
	ldi R23, 0							;apagados al inicio
	out PORTD, R23	

	ldi R20, 0							;inicializo contador en 0
	rjmp TECLADO

TECLADO: //ciclo
	sbis PINA, 0					;¿está siendo apretado el pin 0?
		rjmp RST																//¿por qué usamos rjmp? ¿podemos usar rcall?
	ldi R16, 0xFF
	out PORT_TEC, R16				;5v:Salidas // pullups:entradas
	cbi PORT_TEC, 5					;A4=0 (pin 4 con 0)
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

	sbi PORT_TEC, 5					;A4=1 --5v
	cbi PORT_TEC, 6					;A5=0 --0v
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


	sbi PORT_TEC, 6					;A5=1 --5v
	cbi PORT_TEC, 7					;A6=0 --0v
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

rjmp TECLADO  //regresa al ciclo	

UNO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_UNO	:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_UNO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 1
	rcall SIGUE
rjmp TECLADO

DOS:	
	;código al presionar
	rcall RETARDO50m
	TRABA_DOS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_DOS
	rcall RETARDO50m
	;código al soltar
	ldi R16, 2
	rcall SIGUE
rjmp TECLADO

TRES:	
	;código al presionar
	rcall RETARDO50m
	TRABA_TRES:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_TRES
	rcall RETARDO50m
	;código al soltar
	ldi R16, 3
	rcall SIGUE
rjmp TECLADO

CUATRO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_CUATRO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_CUATRO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 4
	rcall SIGUE
rjmp TECLADO

CINCO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_CINCO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_CINCO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 5
	rcall SIGUE
rjmp TECLADO

SEIS:	
	;código al presionar
	rcall RETARDO50m
	TRABA_SEIS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_SEIS
	rcall RETARDO50m
	;código al soltar
	ldi R16,6
	rcall SIGUE
rjmp TECLADO

SIETE:	
	;código al presionar
	rcall RETARDO50m
	TRABA_SIETE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3				;A0 porque entró el UNO en A0
	RJMP TRABA_SIETE
	rcall RETARDO50m
	;código al soltar
	ldi R16, 7
	rcall SIGUE
rjmp TECLADO

OCHO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_OCHO:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 3				;A0 porque entró el UNO en A0
	RJMP TRABA_OCHO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 8
	rcall SIGUE
rjmp TECLADO

NUEVE:	
	;código al presionar
	rcall RETARDO50m
	TRABA_NUEVE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3				;A0 porque entró el UNO en A0
	RJMP TRABA_NUEVE
	rcall RETARDO50m
	;código al soltar
	ldi R16, 9
	rcall SIGUE
rjmp TECLADO

CERO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_CERO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 4			;A0 porque entró el UNO en A0
	RJMP TRABA_CERO
	rcall RETARDO50m
	;código al soltar
	ldi R16, 0
	rcall SIGUE
rjmp TECLADO

AST:	
	;código al presionar
	rcall RETARDO50m
	TRABA_AST:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 4			;A0 porque entró el UNO en A0
	RJMP TRABA_AST
	rcall RETARDO50m
	;código al soltar
	cpi R20, 2					;si el contador es 2, entonces estamos eligiendo el operador, en este caso suma
	BREQ MAS
rjmp TECLADO

GATO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_GATO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 4			;A0 porque entró el UNO en A0
	RJMP TRABA_GATO
	rcall RETARDO50m
	;código al soltar
	cpi R20, 2					;si el contador es 2, entonces estamos eligiendo el operador, en este caso suma
	BREQ menos
rjmp TECLADO

MAS:
	ldi R25, 0
	inc R20
	rjmp TECLADO

MENOS:
	ldi R25, $0C
	inc R20
	rjmp TECLADO

SIGUE:
	cpi R20, 0					;si es 0, estamos tecleando el primer número [X][]+[][]
	BREQ CONT0
	cpi R20, 1					;si es 1, estamos tecleando el segundo número [][X]+[][]
	BREQ CONT1
	//cpi R20, 2					;si es 2, estamos tecleando el signo (+,-)
	//BREQ CONT2
	cpi R20, 3					;si es 3, estamos tecleando el tercer número [][]+[X][]
	BREQ CONT3
	cpi R20, 4
	BREQ CONT4
	rjmp TECLADO
CONT0:
	mov R21, R16
//	mov R16, R21
//	swap R16
	out PORTC, R16
	inc R20
	rjmp TECLADO
CONT1:
	mov R22, R16
	//mov R16, R21
	swap R16
	or R16, R21
	out PORTC, R16
	inc R20
	rjmp TECLADO
CONT3:
	mov R23, R16
	//mov R16, R23
	//swap R16
	out PORTD, R16
	inc R20
	rjmp TECLADO
CONT4:
	mov R24, R16
	//mov R16, R23
	swap R16
	or R16, R23
	out PORTD, R16
	inc R20
	//antes de mostrar resultado, necesitamos darle el valor real a cada nible:
	ldi R16, 10			;le cargo un 10 para después ver las decenas
	//primer dígito
	mul R21,R16			;por ejemplo: 10 = 1(10) + 0 , donde r16=10 y r21 = 1 //multiplico
	add R0,R22			;R0 es donde se gaurda el resultado de MUL
	mov R21, R0			;copio el resultado a R21
	//segundo dígito
	mul R23, R16
	add R0, R24
	mov R23, R0
	//¿sumo o resto?
	cpi R25, 0			;si es 0, entonces es SUMA, else: RESTA
	BREQ SUMA
	rcall RESTA			;en cualquier otro caso, me voy a RESTA

SUMA:
	add R21, R23		;sumo ambos resultados
	ldi R16, 0			;reseteo el R16
	RJMP DIVIDIR_NIBLES
	
RESTA:
	sub R21, R23		;resto ambos resultados
	ldi R16, 0			;reseteo el R16
	rjmp DIVIDIR_NIBLES

DIVIDIR_NIBLES:
	//subi R26, 10
	cpi R21, 10			;comparo para saber si es menor o igual a 10
	BRSH MODULO			
	rjmp MOSTRAR
MODULO:
	inc R16
	subi R21, 10
	rjmp  DIVIDIR_NIBLES
MOSTRAR:
	swap R21
	or R16, R21
	out PORTB, R16
	rjmp TECLADO


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
