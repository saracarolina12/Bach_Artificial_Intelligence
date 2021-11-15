;******************************************************
; Teclado Notas Musicales
;
; Fecha: 11/11/2021
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

//BOCINA
ldi R16, $FF				;salida
out DDRB, R16
ldi R16, 0					;apagada al inicio
out PORTB, R16
JINGLEBELLS:
	ldi R20, 0
	ldi R19, 0
	//1
	rcall D4_n
	rcall B4_n
	rcall A4_n
	rcall G4_n
	//2
	rcall D4_n
	rcall D4_p
	rcall mini
	rcall D4_c
	rcall D4_c
	rcall mini
	//3
	rcall D4_n
	rcall B4_n
	rcall A4_n
	rcall G4_n
	//4
	rcall E4_r
	rcall mini
	//5
	rcall E4_n
	rcall C5_n
	rcall B4_n
	rcall A4_n
	//6
	rcall Fsos4_r
	//7
	rcall D5_n
	rcall D5_n
	rcall C5_n
	rcall A4_n
	//8
	rcall B4_r
	rcall negra
rjmp JINGLEBELLS

//redondas
D4_r:
	ldi R16, 212			;Excel Timer0 C:\Users\scago\Documents\GitHub\IA_School\Semestres\Microcontroladores I 
	rcall sonar
	rcall redonda				
	rcall callar
	ret	
E4_r:
	ldi R16, 187 
	rcall sonar
	rcall redonda
	rcall callar
	ret
Fsos4_r:
	ldi R16, 162
	rcall sonar
	rcall redonda
	rcall callar
	ret
B4_r:
	ldi R16, 124
	rcall sonar 
	rcall redonda
	rcall callar
	ret
//negras
D4_n:
	ldi R16, 212			
	rcall sonar
	rcall negra				
	rcall callar
	ret		
E4_n:
	ldi R16, 187 
	rcall sonar
	rcall negra
	rcall callar
	ret
G4_n:
	ldi R16, 155
	rcall sonar
	rcall negra
	rcall callar
	ret
A4_n:
	ldi R16, 137
	rcall sonar
	rcall negra
	rcall callar
	ret
B4_n:
	ldi R16, 124
	rcall sonar 
	rcall negra
	rcall callar
	ret
C5_n:
	ldi R16, 118 
	rcall sonar 
	rcall negra
	rcall callar
	ret
D5_n:
	ldi R16, 105
	ldi R19, 1
	rcall sonar 
	rcall negra
	rcall callar
	ret
//corcheas
D4_c:
	ldi R16, 212			
	rcall sonar
	rcall corchea
	rcall callar			
	ret	
//puntillo
D4_p:
	ldi R16, 212			
	rcall sonar
	rcall blanca_punt
	rcall callar
	ret
E4_p:
	ldi R16, 187 
	rcall sonar
	rcall blanca_punt
	rcall callar
	ret

sonar:
	out OCR0, R16
	ldi R16, 0b0001_1011	;ctc 10, prescaler 64 = 011
	out TCCR0, R16
	inc R20
	ret

callar:
	ldi R16, 0
	out TCCR0, R16			//se apaga
	cbi PORTB, 3			;evita zumbido de "silencio"
	ldi R16, 0
	ret

//tiempos
mini:
	; ============================= 
	;    delay loop generator 
	;     100000 cycles:
	; ----------------------------- 
	; delaying 99990 cycles:
			  ldi  R31, $A5
	min0:  ldi  R30, $C9
	min1:  dec  R30
			  brne min1
			  dec  R31
			  brne min0
	; ----------------------------- 
	; delaying 9 cycles:
			  ldi  R31, $03
	min2:  dec  R31
			  brne min2
	; ----------------------------- 
	; delaying 1 cycle:
			  nop
	; ============================= 
ret

redonda: //2 segundos		
	; ============================= 
	;    delay loop generator 
	;     12000000 cycles:
	; ----------------------------- 
	; delaying 11999976 cycles:
			  ldi  R31, $3E
	red0:  ldi  R30, $FD
	red1:  ldi  R29, $FE
	red2:  dec  R29
			  brne red2
			  dec  R30
			  brne red1
			  dec  R31
			  brne red0
	; ----------------------------- 
	; delaying 24 cycles:
			  ldi  R31, $08
	red3:  dec  R31
			  brne red3
	; =============================  
	ret
blanca: // 1 segundo
	; ============================= 
	;    delay loop generator 
	;     8000000 cycles:
	; ----------------------------- 
	; delaying 7999992 cycles:
			  ldi  R31, $48
	bl0:  ldi  R30, $BC
	bl1:  ldi  R29, $C4
	bl2:  dec  R29
			  brne bl2
			  dec  R30
			  brne bl1
			  dec  R31
			  brne bl0
	; ----------------------------- 
	; delaying 6 cycles:
			  ldi  R31, $02
	bl3:  dec  R31
			  brne bl3
	; ----------------------------- 
	; delaying 2 cycles:
			  nop
			  nop
	; ============================= 
	ret
blanca_punt: //1.5 segundos
	; ============================= 
	;    delay loop generator 
	;     8000000 cycles:
	; ----------------------------- 
	; delaying 7999992 cycles:
			  ldi  R31, $48
	WGLOOP0:  ldi  R30, $BC
	WGLOOP1:  ldi  R29, $C4
	WGLOOP2:  dec  R29
			  brne WGLOOP2
			  dec  R30
			  brne WGLOOP1
			  dec  R31
			  brne WGLOOP0
	; ----------------------------- 
	; delaying 6 cycles:
			  ldi  R31, $02
	WGLOOP3:  dec  R31
			  brne WGLOOP3
	; ----------------------------- 
	; delaying 2 cycles:
			  nop
			  nop
	; ============================= 
	ret
negra: //0.5 segundos
	; ============================= 
	;    delay loop generator 
	;     4000000 cycles:
	; ----------------------------- 
	; delaying 3999996 cycles:
			  ldi  R31, $24
	n0:  ldi  R30, $BC
	n1:  ldi  R29, $C4
	n2:  dec  R29
			  brne n2
			  dec  R30
			  brne n1
			  dec  R31
			  brne n0
	; ----------------------------- 
	; delaying 3 cycles:
			  ldi  R31, $01
	n3:  dec  R31
			  brne n3
	; ----------------------------- 
	; delaying 1 cycle:
			  nop
	; ============================= 
	ret	
corchea: //0.25 segundos
	; ============================= 
	;    delay loop generator 
	;     2000000 cycles:
	; ----------------------------- 
	; delaying 1999998 cycles:
			  ldi  R31, $12
	cor0:  ldi  R30, $BC
	cor1:  ldi  R29, $C4
	cor2:  dec  R29
			  brne cor2
			  dec  R30
			  brne cor1
			  dec  R31
			  brne cor0
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



