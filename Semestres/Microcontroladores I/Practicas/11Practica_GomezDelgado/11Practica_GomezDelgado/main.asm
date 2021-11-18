;******************************************************
; Medidor de periodo
;
; Fecha: 16/11/2021
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
sei
;******************************************************
;No olvides configurar al inicio los puertos que utilizarás
;También debes configurar si habrá o no pull ups en las entradas
;Para las salidas deberás indicar cuál es la salida inicial
;Los registros que vayas a utilizar inicializalos si es necesario
;******************************************************

//SEÑAL - A
ldi R16, 0									;entrada
out DDRA, R16					
ldi R16, $FF								;pullups
out PORTA, R16
//BOTON - B
ldi R16, 0									;entrada
out DDRB, R16
ldi R16, $FF								;pullups
out PORTB, R16
//DISPLAY - C
ldi R16, $FF								;salida
out DDRC, R16
ldi R16, 0								;encendidos
out PORTC, R16

//TIMER 8MHz
ldi R16, 0b0000_0011						;limpia comp, ovrfl
out TIFR, R16
ldi R16, 0 
out TCNT0, R16
ldi R16, 124								;0.001 segs
out OCR0, R16
ldi R16, 0b0000_0010						;por comparación
out TIMSK, R16
;aquí no enciendo el TIMER0


//INTERRUMPCIONES
ldi R16, 0b0000_0010						;int 0, flanco de bajada
out MCUCR, R16
ldi R16, 0b1110_0000						;limpia banderas
out GIFR, R16
ldi R16, 0b0100_0000						;habilito int 0
out GICR, R16

//revisar si está presionado el botón
BOTON:									
	sbis PINB, 0							;¿botón A0 apretado?
	rjmp PRESIONADO
	rjmp BOTON
PRESIONADO:
		rcall RETARDO
		traba_boton: sbis PINB, 0
				rjmp traba_boton
		rcall RETARDO
		ldi R19, 0							;inicializo en 0 el contador por si quiero volver a contar

		traba0: sbis PINA, 0				;por si no presiono en el "flanco de bajada"
				rjmp traba0
		traba1: sbic PINA, 0
				rjmp traba1
		
		ldi R16, 0b0000_1011				;modo:ctc, prescaler:64 ENCIENDO TIMER0
		out TCCR0, R16

		traba0_dos: sbis PINA, 0				
				rjmp traba0_dos
		traba1_dos: sbic PINA, 0
				rjmp traba1_dos

		ldi R16, 0b0000_1000				;modo:ctc, prescaler:64  APAGO TIMER0
		out TCCR0, R16

  rjmp BOTON


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
	inc R19											;Contador

reti
SPM_RDY: 
reti ; Store Program Memory Ready Handler

