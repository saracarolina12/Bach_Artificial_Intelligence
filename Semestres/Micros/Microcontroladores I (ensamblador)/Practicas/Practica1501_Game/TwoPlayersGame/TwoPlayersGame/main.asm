;******************************************************
; TwoPlayersGame
;
; Fecha: 03/01/2022
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
sei														;habilita interrupciones

;******************************************************
;No olvides configurar al inicio los puertos que utilizarás
;También debes configurar si habrá o no pull ups en las entradas
;Para las salidas deberás indicar cuál es la salida inicial
;Los registros que vayas a utilizar inicializalos si es necesario
;******************************************************

//DISPLAY A
ldi R16, $FF												;salida
out DDRA, R16
ldi R16, 0													;inicializado en 0
out PORTA, R16

//DETENIDO, PRESIONA, INICIAR C
ldi R16, 0b1000_0010										;c7,c1:leds(salida) // c3: botón(entrada) 
out DDRC, R16	
ldi R16, 0b0000_1010										;c1 encendido, 
out PORTC, R16

//PRESIONÓ ANTES(1,2), JUGADORES(1,2) 
ldi R16, 0b0000_0011
out DDRD, R16
ldi R16, 0b0000_1100
out PORTD, R16

//Interrupciones
ldi R16, 0b1110_0000					
out GIFR, R16
ldi R16, 0b0000_1010						;flanco de bajada (int 0,1)
out MCUCR, R16


INICIAR:
	sbis PINC, 3
		rcall YAINICIO
	rjmp INICIAR

YAINICIO:
		/*ldi R16, 0b1100_0000						;enciendo la interrupción
		out GICR, R16*/

		//correr tiempo aleatorio en múltiplos de 50 ms
		rcall RANDOM

	ret

RANDOM:
	/*ldi R16, 5
	ldi R16, 10
	ldi R16, 15
	ldi R16, 20
	ldi R16, 25
	ldi R16, 30*/
	rjmp RANDOM

;******************************************************
;Aquí están las rutinas para el manejo de las interrupciones concretas
;******************************************************
EXT_INT0: ; IRQ0 Handler ------> jugador 1
	in R16, SREG
	PUSH R16
		ldi R16, 1
		out PORTD, R16
	pop R16
	out SREG, R16
reti
EXT_INT1: ; IRQ1 Handler ------> jugador 2
	in R16, SREG
	PUSH R16
		ldi R16, 2
		out PORTD, R16
	pop R16
	out SREG, R16
reti 
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



