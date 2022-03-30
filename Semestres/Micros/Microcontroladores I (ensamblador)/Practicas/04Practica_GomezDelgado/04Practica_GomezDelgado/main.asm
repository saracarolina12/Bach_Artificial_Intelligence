;******************************************************
; Contadores Independientes
;
; Fecha: 23/09/2021
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

;******************************************************
;No olvides configurar al inicio los puertos que utilizarás
;También debes configurar si habrá o no pull ups en las entradas
;Para las salidas deberás indicar cuál es la salida inicial
;Los registros que vayas a utilizar inicializalos si es necesario
;******************************************************


//BOTONES
ldi R16, 0b0000_00000 ;DDRA //0 = entrada
out DDRA, R16 
ldi R16, 0b1111_1111 ;PORTA //SÍ pullups
out PORTA, R16

//LEDS
ldi R16, 0b1111_1111 ; DDRC //1 porque son leds (salida [1=salida, 0=entrada])
out DDRC, R16
ldi R16, 0b0000_0000 ; PORTC //0 porque están apagados inicialmente
out PORTC, R16


//inicializar [iiii][iiii]
ldi R17,0; R17 = 0    //izquierdo
ldi R18,0; R18 = 0    //derecho
ldi R19,0; R19 = 0    //registro temporal del lado izquierdo

REPETIR:
	//TODOS LOS BOTONES
	BOTONES:
		//[xxxx][]	
			sbis PINA, 0 ;A[0] primer botón //RESET [rrrr][xxxx] [sbis: hace rjmp si presiona]
			rjmp RESET1

			sbis PINA, 2 ;A[1] segundo botón //INC [x++][xxxx] [sbis: hace rjmp si presiona]
			rjmp AUM1

		//[][xxxx]
			sbis PINA, 4 ;A[0] tercer botón //RESET [xxxx][rrrr] [sbic: hace rjmp si suelta]
			rjmp RESET2

			sbis PINA, 6 ;A[1] cuarto botón //INC [xxxx][x++] [sbic: hace rjmp si suelta]
			rjmp AUM2
		rjmp BOTONES


		//"funciones"
		RESET1:
			//retardo inicio
			rcall RETARDO
				reseteado1: sbis PINA, 0
							rjmp reseteado1
			rcall RETARDO
			//retardo fin
			//resetea en 0
			cbr R17, 0b1111_0000 ;resetea [rrrr][xxxx] //las x las deja como estaban
			clr R19 //limpia el 
			out PORTC, R17 
			rjmp BOTONES

		AUM1:
			//AUMENTA 
			inc R19 ;incrementa en 1 ;aumenta [x++][xxxx] //sólo los 4 bits más significativos
			cpi R19, $10 ; ¿Es 16?
			breq RESETEAR_UNO
			fin_reseteo: 
				//retardo inicio
				rcall RETARDO
				presionado: sbis PINA, 2
							rjmp presionado
				rcall RETARDO
				//retardo fin
				rcall sacar
			rjmp BOTONES
		//----------------------------------
		RESET2:
			//resetea en 0
			cbr R17, 0b0000_1111 ;resetea [xxxx][rrrr] //las x las deja como estaban
			clr R18 //
			out PORTC, R17 
			//retardo inicio
			rcall RETARDO
				reseteado2: sbis PINA, 4
							rjmp reseteado2
			rcall RETARDO
			//retardo fin	
			rjmp BOTONES

		AUM2:
			//AUMENTA 
			inc R18 ;incrementa en 1 ;aumenta [x++][xxxx] //sólo los 4 bits más significativos
			cpi R18, $10 ; ¿Es 16?
			breq RESETEAR_DOS
			fin_reseteo2:
				rcall sacar
				//retardo inicio
				rcall RETARDO
				presionado2: sbis PINA, 6
							rjmp presionado2
				rcall RETARDO
				//retardo fin
			rjmp BOTONES

		 RESETEAR_UNO:
			ldi R17, 0
			ldi R19, 0
			rjmp fin_reseteo
		 RESETEAR_DOS:
			ldi R18, 0
			ldi R17, 0
			rjmp fin_reseteo2

		sacar:
			MOV R17, R19 ; COPIA TEMPORAL
			swap R17
			add R17,R18 ;R17 = R17 + R18 
			out PORTC, R17 //saca el número
		  ret


		RETARDO:
			; ============================= 
			;    delay loop generator 
			;     100000 cycles:
			; ----------------------------- 
			; delaying 99990 cycles:
					  ldi  R20, $A5
			WGLOOP0:  ldi  R21, $C9
			WGLOOP1:  dec  R21
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

