;******************************************************
; Título del proyecto
;
; Fecha: Poner aquí la fecha
; Autor: Poner aquí el autor
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

;******************************************************
;No olvides configurar al inicio los puertos que utilizarás
;También debes configurar si habrá o no pull ups en las entradas
;Para las salidas deberás indicar cuál es la salida inicial
;Los registros que vayas a utilizar inicializalos si es necesario
;******************************************************

Reset:
;Primero inicializamos el stack pointer...
ldi r16, high(RAMEND)
out SPH, r16
ldi r16, low(RAMEND)
out SPL, r16 

//interrupciones
sei
ldi R16, 0b0000_0010	;flanco de bajada
out MCUCR, R16
ldi R16, 0b1110_0000	;clear flags
out GIFR, R16
ldi R16, 0b0100_0000	;uso de interrumpción 0
out GICR, R16	

//leds
ldi R16, $FF			;salidas
out DDRA, R16 
ldi R16, 0				;apagados al inicio
out PORTA, R16

//botón
ldi R16, 0				;entradas
out DDRD, R16
ldi R16, $FF			;pullups
out PORTD, R16

ciclo:
	ldi R16, 0b0000_1000
	ldi R16, 0b0010_0010
	ldi R16, 0b0100_1001
	ldi R16, 0b0101_0101
	ldi R16, 0b0101_1101
	ldi R16, 0b0111_0111
	ldi R16, 0b0111_1111
	rjmp ciclo


RETARDO:	
	; ============================= 
	;    delay loop generator 
	;     100000 cycles:
	; ----------------------------- 
	; delaying 99990 cycles:
			  ldi  R17, $A5
	WGLOOP0:  ldi  R18, $C9
	WGLOOP1:  dec  R18
			  brne WGLOOP1
			  dec  R17
			  brne WGLOOP0
	; ----------------------------- 
	; delaying 9 cycles:
			  ldi  R17, $03
	WGLOOP2:  dec  R17
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
	out PORTA,R16
	rcall RETARDO
		botoncito: sbis PIND, 2
				rjmp botoncito
	rcall RETARDO
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



