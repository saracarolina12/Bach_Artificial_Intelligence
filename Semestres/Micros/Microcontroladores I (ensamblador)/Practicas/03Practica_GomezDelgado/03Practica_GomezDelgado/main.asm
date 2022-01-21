;*******************
; Contador
;
; Created: 21/09/2021
; Author : Sara Carolina Gómez Delgado
;*******************

.include "m16adef.inc"     
   
;*******************
;Registros (aquí pueden definirse)
;.def temporal=r19

;Palabras claves (aquí pueden definirse)
;.equ LCD_DAT=DDRC
;********************

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


//BOTÓN
ldi R16, 0b0000_00000 ;DDRA -> Entrada
out DDRA, R16
ldi R16, 0b1111_1111 ;PORTA -> Sí pullups
out PORTA, R16

//DISPLAY
ldi R16, 0b1111_1111 ;DDRD -> Salida
out DDRD, R16 
ldi R16, 0b1111_1111 ;PORTD -> Sí encendido (queremos mostrar 0 desde el inicio)
out PORTD, R16

//iniciar con 0 display
ldi R17,0; R17 = 0
out PORTD, R17 ;Mostrar 0 en display


;Repetir
REGRESA:
	//in R16, PINA;leer constantemente el puerto
	BOTONES:
		sbis PINA, 0 ;0 porque el A0 es el que tiene el botón
		rjmp AUMENTA
	rjmp BOTONES

	AUMENTA:
		inc R17 ;incrementa en 1
		cpi R17, 10 ; ¿Es 10?
		breq RESETEAR_CERO
		fin_reseteo:
			out PORTD, R17

			//retardo inicio
			rcall RETARDO
			presionado: sbis PINA, 0
						rjmp presionado
			rcall RETARDO
			//retardo fin
	rjmp BOTONES


	//resetear a 0
	RESETEAR_CERO:
		ldi R17, 0
		rjmp fin_reseteo



	RETARDO:  //el siguiente código se sacó con el .exe (C:\Users\scago\Documents\GitHub\School\Semestres\Microcontroladores I\Generador_Retardos_AVRdelayloop3)
		//para los retardos hay que tener cuidado en seleccionar los registros en el .exe
		//añadir al .exe los registros NO utilizados
		
		; ============================= 
		;    delay loop generator 
		;     100000 cycles:
		; ----------------------------- 
		; delaying 99990 cycles:
				  ldi  R20, $A5
		WGLOOP0:  ldi  R18, $C9
		WGLOOP1:  dec  R18
				  brne WGLOOP1
				  dec  R20
				  brne WGLOOP0
		; ----------------------------- 
		; delaying 9 cycles:
				  ldi  R20, $03
		WGLOOP2:  dec  R20
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
reti
SPM_RDY: 
reti ; Store Program Memory Ready Handler

