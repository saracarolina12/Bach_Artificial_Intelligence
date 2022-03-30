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

//TECLADO
ldi R16, 0xF0 ;es lo mismo que declararlo como 0b1111_0000
out DDR_TEC, R16 ;configuré el puerto A del teclado SALIDAS:ENTRADAS

//BUZZER Y LED
ldi R16, $FF					;configuro puerto D como SALIDA
out DDRD, R16	
ldi R16, 0b1111_1110			;D7 = led prendido, D0 alarma apagada
out PORTD, R16

//R16 = lectura teclado
//R17 = contador
//R18 = flag
//R19 = primer número para detener alarma(2)
//R20 = segundo número para detener alarma(3)
//R21 = almacenar RESULTADO [2,3]

ldi R18, 0						;DECLARO flag para ver si el usario ya se equivocó
ldi R17, 0						;DECLARO contador para ver cuántos números van presionados

TECLADO: //ciclo
	;ldi R16, 0b1110_1111			;para ahorrarme el "cbi PORT_TEC, 4"
	ldi R16, 0xFF
	out PORT_TEC, R16				;5v:Salidas // pullups:entradas
	cbi PORT_TEC, 4					;A4=0 (pin 4 con 0)
	nop								;pierde un ciclo de reloj
	nop								;pierde otro ciclo de reloj
	
	//1,4,7,*  ---------------------------------------------------------
	sbis PIN_TEC,0					;si tiene un 1 se brinca la línea
	rjmp UNO						; + en proteus
	sbis PIN_TEC,1					
	rjmp CUATRO						; - en proteus
	sbis PIN_TEC,2
	rjmp SIETE						; x en proteus
	sbis PIN_TEC,3
	rjmp AST						; / en proteus

	sbi PORT_TEC, 4					;A4=1 --5v
	cbi PORT_TEC, 5					;A5=0 --0v
	nop
	nop


	//2,5,8,0   ---------------------------------------------------------
	sbis PIN_TEC,0					;tiene un 1 se brinca la línea
	rjmp DOS						; = en proteus
	sbis PIN_TEC,1
	rjmp CINCO						; 3 en proteus
	sbis PIN_TEC,2
	rjmp OCHO						; 6 en proteus
	sbis PIN_TEC,3
	rjmp CERO						; 9 en proteus


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
	ldi R16, 0b0000_0001
	cpi R22, 0b0000_0001		;revisar si estoy en ESCÁNDALO, buscando los dos números [2,3]
	BREQ tomove1					;si sí, voy a MOVER	
	rcall ESCUCHA
	cpi R23, 0b0000_0001		;revisar si estoy en ABRE, buscando apretar un sólo número para cerrar con candado
	BREQ abrir					;si sí, voy a abrir //¡¡¡¡COPIAR ESTO A LOS DEMÁS NÚMEROS!!!			
	;código al presionar
	rcall RETARDO50m
	TRABA_UNO	:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entró el UNO en A0
	RJMP TRABA_UNO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
abrir:
	rjmp siabre
tomove1:
	ldi R19, 0b0000_0001		;carga al primer numero [2,3] un uno
	rcall MOVER

DOS:
	ldi R16, 0b0000_0010
	cpi R22, 0b0000_0001		;revisar si estoy en ESCÁNDALO, buscando los dos números [2,3]
	BREQ tomove2					;si sí, voy a MOVER	
	rcall ESCUCHA
	cpi R23, 0b0000_0001
	BREQ abrir
	;código al presionar
	rcall RETARDO50m
	TRABA_DOS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entró el UNO en A0
	RJMP TRABA_DOS
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
tomove2:
	ldi R19, 0b0000_0010
	rcall MOVER

TRES:
	ldi R16, 0b0000_0011			
	cpi R22, 0b0000_0001		;revisar si estoy en ESCÁNDALO, buscando los dos números [2,3]
	BREQ tomove3					;si sí, voy a MOVER	
	rcall ESCUCHA
	cpi R23, 0b0000_0001
	BREQ abrir
	;código al presionar
	rcall RETARDO50m
	TRABA_TRES:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 0				;A0 porque entró el UNO en A0
	RJMP TRABA_TRES
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
tomove3:
	ldi R19, 0b0000_0011
	rcall MOVER			

CUATRO:	
	ldi R16, 0b0000_0100
	cpi R22, 0b0000_0001		;revisar si estoy en ESCÁNDALO, buscando los dos números [2,3]
	BREQ tomove4					;si sí, voy a MOVER	
	rcall ESCUCHA
	cpi R23, 0b0000_0001
	BREQ abrir
	;código al presionar
	rcall RETARDO50m
	TRABA_CUATRO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_CUATRO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
tomove4:
	ldi R19, 0b0000_0100
	rcall MOVER


CINCO:	
	ldi R16, 0b0000_0101
	cpi R22, 0b0000_0001			;revisar si estoy en ESCÁNDALO, buscando los dos números [2,3]
	BREQ tomove5					;si sí, voy a MOVER	
	rcall ESCUCHA
	cpi R23, 0b0000_0001
	BREQ abrir
	;código al presionar
	rcall RETARDO50m
	TRABA_CINCO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_CINCO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
tomove5:
	ldi R19, 0b0000_0101
	rcall MOVER

SEIS:
	ldi R16, 0b0000_0110
	cpi R22, 0b0000_0001			;revisar si estoy en ESCÁNDALO, buscando los dos números [2,3]
	BREQ tomove6					;si sí, voy a MOVER	
	rcall ESCUCHA
	cpi R23, 0b0000_0001
	BREQ abrir
	;código al presionar
	rcall RETARDO50m
	TRABA_SEIS:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 1				;A0 porque entró el UNO en A0
	RJMP TRABA_SEIS
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
tomove6:
	ldi R19, 0b0000_0110
	rcall MOVER

SIETE:	
	ldi R16, 0b0000_0111	
	cpi R22, 0b0000_0001			;revisar si estoy en ESCÁNDALO, buscando los dos números [2,3]
	BREQ tomove7					;si sí, voy a MOVER	
	rcall ESCUCHA
	cpi R23, 0b0000_0001
	BREQ abrir2
	;código al presionar
	rcall RETARDO50m
	TRABA_SIETE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_SIETE
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
tomove7:
	ldi R19, 0b0000_0111	
	rcall MOVER
abrir2:
	rjmp siabre

OCHO:	
	ldi R16, 0b0000_1000
	cpi R22, 0b0000_0001			;revisar si estoy en ESCÁNDALO, buscando los dos números [2,3]
	BREQ tomove8					;si sí, voy a MOVER	
	rcall ESCUCHA
	cpi R23, 0b0000_0001
	BREQ abrir2
	;código al presionar
	rcall RETARDO50m
	TRABA_OCHO:						;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_OCHO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
tomove8:
	ldi R19, 0b0000_1000
	rcall MOVER

NUEVE:	
	ldi R16, 0b0000_1001	
	cpi R22, 0b0000_0001			;revisar si estoy en ESCÁNDALO, buscando los dos números [2,3]
	BREQ tomove9					;si sí, voy a MOVER	
	cpi R23, 0b0000_0001
	BREQ abrir2
	rcall ESCUCHA
	;código al presionar
	rcall RETARDO50m
	TRABA_NUEVE:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2				;A0 porque entró el UNO en A0
	RJMP TRABA_NUEVE
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
tomove9:
	ldi R19, 0b0000_1001
	rcall MOVER

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
		sbis PIN_TEC, 1			;A0 porque entró el UNO en A0
	RJMP TRABA_B
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

C:	
	;código al presionar
	rcall RETARDO50m
	TRABA_C:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 2			;A0 porque entró el UNO en A0
	RJMP TRABA_C
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

D:	
	;código al presionar
	rcall RETARDO50m
	TRABA_D:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entró el UNO en A0
	RJMP TRABA_D
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

AST:	
	;código al presionar
	rcall RETARDO50m
	TRABA_AST:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entró el UNO en A0
	RJMP TRABA_AST
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

CERO:	
	ldi R16, 0 
	cpi R22, 0b0000_0001		;revisar si estoy en ESCÁNDALO, buscando los dos números [2,3]
	BREQ tomove0				;si sí, voy a MOVER
	cpi R23, 0b0000_0001		;revisar si estoy en ABRE, buscando apretar un sólo número para cerrar con candado
	BREQ siabre					;si sí....
	rcall ESCUCHA
	;código al presionar
	rcall RETARDO50m
	TRABA_CERO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entró el UNO en A0
	RJMP TRABA_CERO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO
tomove0:
	ldi R19, 0 
	rcall MOVER

GATO:	
	;código al presionar
	rcall RETARDO50m
	TRABA_GATO:					;mientras tenga 0 se cicla
		sbis PIN_TEC, 3			;A0 porque entró el UNO en A0
	RJMP TRABA_GATO
	rcall RETARDO50m
	;código al soltar
rjmp TECLADO

/*FIN DE LAS TECLAS*/

MOVER:
	or R20,R19					;para poder juntar ambos números en un registro
	mov R21,R20					;almacena el número anterior con el actual para verificar el [2,3] 
	mov R20,R19					;temporal que al final se almacena en R21
	swap R20
	rjmp siescandalo			;regresa a ESCÁNDALO

ESCUCHA:
	inc R17

	cpi R17, 1					;si el contador es 1 
	BREQ CONT1

	cpi R17, 2
	BREQ CONT2

	cpi R17, 3
	BREQ CONT3

	cpi R17, 4
	BREQ CONT4
	ret

CONT1:
	cpi R16, 0b0000_0001
	BRNE FLAGON					;si no es 1 el primer dígito
	ret

CONT2:
	cpi R16,  0b0000_0101
	BRNE FLAGON					;si no es 5 el segundo dígito
	ret

CONT3:
	cpi R16,  0b0000_0111
	BRNE FLAGON					;si no es 7 el tercer dígito
	ret

CONT4:
	cpi R16,  0b0000_1001		
	BRNE ESCANDALO 				;si no es 9 el cuarto dígito, está mal aunque los anteriores estén bien
	cpi R18, 0b0000_0000		;si la bandera está inactiva, significa que fue correcta la clave, entonces, abre
	BREQ ABRE
	rjmp ESCANDALO				;else: directo a ESCANDALO

//LEVANTAR BANDERA (ESTÁ MAL LA CLAVE)
FLAGON:
	ldi R18, 0b0000_0001
	ret

ESCANDALO: //PENDIENTE: RESETEAR CONTADOR
	ldi R22, 0b0000_0001		;flag que indica que estoy en escándalo
	ldi R16, 0b1111_0001		;D7 = led encendido, D0 alarma encendida 
	out PORTD, R16				;activar buzzer
	rjmp TECLADO				;leer últimos dos números MOVER
	siescandalo:
		cpi R21, $23				;si SÍ es 2,3
		BREQ APAGAR_ALARMA
		rjmp TECLADO			;regreso a escuchar botones

APAGAR_ALARMA:
	ldi R16, 0b1111_0000	;SILENCIO BRUNO! (apago alarma, enciendo led[cierro con llave])
	out PORTD, R16
	ldi R17, 0				;reseteo contador

ABRE:
	ldi R23, 0b0000_0001		;para saber que estoy en ABRE
	ldi R16, 0b0111_0000		;D7 = led apagado, D0 alarma apagada
	out PORTD, R16
	rjmp TECLADO//leer número
	siabre:
		ldi R16, 0b1111_0000	;D7 = led encendido, D0 alarma apagada
		out PORTD, R16
		ldi R23, 0b0000_0000	;reseteo el flag de ABRE para que no se cicle
	rjmp TECLADO
	

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

