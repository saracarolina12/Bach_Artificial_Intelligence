/*
 * 16_Voltimetro_COMS.c
 *
 * Created: 07/04/2022 02:33:05 p. m.
 * Author : scago
 */ 


/*TEMPLATE*/

#define F_CPU 1000000

//Teclado
#define PINT PINA
#define PORTT PORTA
#define DDRT DDRA

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <stdint.h>
#include <stdlib.h>
#include <stdio.h>
//#include <cstdlib>//random

#define isClear(r, i) (!(r & (1 << i)))
#define isSet(r, i) (r & (1 << i))
#define mZERO(who) memset(who, 0, sizeof(who));
#define mONE(who) memset(who, 1, sizeof(who));
#define mNEG(who) memset(who, -1, sizeof(who));
#define delay(t) _delay_ms(t)

//LCD
#define DDRLCD DDRC
#define PORTLCD PORTC
#define PINLCD PINC
#define RS 4
#define RW 5
#define E 6
#define BF 3
#define LCD_Cmd_Clear      0b00000001	// replace all characters with ASCII 'space'
#define LCD_Cmd_Home       0b00000010  // return cursor to first position on first line
//#define LCD_Cmd_Mode     0b000001 ID  S
#define LCD_Cmd_ModeDnS	   0b00000110 //sin shift cursor a la derecha
#define LCD_Cmd_ModeInS	   0b00000100 //sin shift cursor a la izquierda
#define LCD_Cmd_ModeIcS	   0b00000111 //con shift desplazamiento a la izquierda
#define LCD_Cmd_ModeDcS	   0b00000101 //con shift desplazamiento a la derecha
//#define LCD_Cmd_OnOff    0b00001 D C B
#define LCD_Cmd_Off		   0b00001000
#define LCD_Cmd_OnsCsB	   0b00001100
#define LCD_Cmd_OncCsB     0b00001110
#define LCD_Cmd_OncCcB     0b00001111
//#define LCD_Cmd_Shift    0b0001 SC  RL 00
//#define LCD_Cmd_Function 0b001 DL  N  F  00
#define LCD_Cmd_Func2Lin   0b00101000
#define LCD_Cmd_Func1LinCh 0b00100000
#define LCD_Cmd_Func1LinG  0b00100100
//#define LCD_Cmd_DDRAM    0b1xxxxxxx


/* INIT VARIABLES  */
uint8_t tecla;
uint8_t seed = 0;
char uno[17],dos[17];
uint8_t adcRange=204.5; //adc 10 bits
//uint8_t adcRange=50; //adc 8 bits

//uint8_t keyb[4][4] =
//{
	//{0x7, 0x8, 0x9, 0xA},
	//{0x4, 0x5, 0x6, 0xB},
	//{0x1, 0x2, 0x3, 0xC},
	//{0xE, 0x0, 0xF, 0xD}
//};
uint8_t keyb[4][3] =
{
//{0x1, 0x2, 0x3, 0xA},
//{0x4, 0x5, 0x6, 0xB},
//{0x7, 0x8, 0x9, 0xC},
//{0xE, 0x0, 0xF, 0xD}
};


/*  FUNCTIONS  */
void RTR(uint8_t pin){
	_delay_ms(50);
	while(isClear(PINT,pin));
	_delay_ms(50);
}

uint8_t pressed(void){
	while(1){
		seed++;
		PORTT = ~(1<<0);				//1111_1110 rota tierra
		asm("nop");
		asm("nop");
		//DCBA
		if(isClear(PINT,4)){		//+,D
			RTR(4);
			return(keyb[3][3]);
		}
		if(isClear(PINT,5)){		//-,C
			RTR(5);
			return(keyb[2][3]);
		}
		if(isClear(PINT,6)){		//x,B
			RTR(6);
			return(keyb[1][3]);
		}
		if(isClear(PINT,7)){		// entre, A
			RTR(7);
			return(keyb[0][3]);
		}
		PORTT = ~(1<<1);
		asm("nop");
		asm("nop");
		//3,6,9,#(F)
		if(isClear(PINT,4)){		//A
			RTR(4);
			return(keyb[3][2]);
		}
		if(isClear(PINT,5)){		//B
			RTR(5);
			return(keyb[2][2]);
		}
		if(isClear(PINT,6)){		//C
			RTR(6);
			return(keyb[1][2]);
		}
		if(isClear(PINT,7)){		//D
			RTR(7);
			return(keyb[0][2]);
		}
		PORTT = ~(1<<2);
		asm("nop");
		asm("nop");
		//2,5,8,0
		if(isClear(PINT,4)){		//A
			RTR(4);
			return(keyb[3][1]);
		}
		if(isClear(PINT,5)){		//B
			RTR(5);
			return(keyb[2][1]);
		}
		if(isClear(PINT,6)){		//C
			RTR(6);
			return(keyb[1][1]);
		}
		if(isClear(PINT,7)){		//D
			RTR(7);
			return(keyb[0][1]);
		}
		PORTT = ~(1<<3);
		asm("nop");
		asm("nop");
		//1,4,7,*(E)
		if(isClear(PINT,4)){		//A
			RTR(4);
			return(keyb[3][0]);
		}
		if(isClear(PINT,5)){		//B
			RTR(5);
			return(keyb[2][0]);
		}
		if(isClear(PINT,6)){		//C
			RTR(6);
			return(keyb[1][0]);
		}
		if(isClear(PINT,7)){		//D
			RTR(7);
			return(keyb[0][0]);
		}

	}
}


#define PORTADC PORTA
#define PINADC PINA
#define DDRADC DDRA
void ADC_init(){
	ADMUX = 0b01100010;
	SFIOR = 0;
	ADCSRA = 0b10011100;
	DDRA = 0;
	PORTA = 0; //ADC does not need pull up
	ADCSRA|=(1<<ADSC);
}

 ISR(ADC_vect){ //entra aquí solito después de la interrupción
        //uint16_t rej = ADC; //10 bits
		float res = ADCH; //8 bits
		//dtostrf(a, 1, 3, v); //Float to string
        dtostrf(res/51, 1,3, uno);
		LCD_wr_string(uno);
		LCD_wr_instruction(LCD_Cmd_Clear);
		UDR = res;
		delay(50);
        ADCSRA|=(1 << ADSC);//inicia una nueva conversión
    }

void write_EEPROM(uint16_t dir, uint8_t dato){
	while(isSet(EECR, EEWE)){}//traba mientras escribe
	EEAR = dir;
	EEDR = dato;
	cli();
	EECR |= (1<<EEMWE);
	EECR |= (1<<EEWE); //pone uno en EEMWE
	sei();
}

uint8_t read_EEPROM(uint16_t dir){
	while(isSet(EECR, EEWE)){}
	EEAR = dir;
	EECR |= (1<<EERE);
	return EEDR;
}

void LCD_wr_lineOne(volatile uint8_t *a){
	LCD_wr_instruction(LCD_Cmd_Clear);
	LCD_wr_instruction(LCD_Cmd_Home);
	LCD_wr_string(a);
}
void LCD_wr_lineTwo(volatile uint8_t *b){
	LCD_wr_instruction(0b11000000);
	LCD_wr_string(b);
}
void LCD_wr_lines(uint8_t *a, uint8_t *b){
	LCD_wr_instruction(LCD_Cmd_Clear);
	LCD_wr_instruction(LCD_Cmd_Home);
	LCD_wr_string(a);
	LCD_wr_instruction(0b11000000);
	LCD_wr_string(b);
}
void LCD_wr_string(volatile uint8_t *s){
	uint8_t c;
	while((c=*s++)){
		LCD_wr_char(c);
	}
}
void LCD_init(void){
	DDRLCD=(15<<0)|(1<<RS)|(1<<RW)|(1<<E); //DDRLCD=DDRLCD|(0B01111111)
	_delay_ms(15);
	LCD_wr_inst_ini(0b00000011);
	_delay_ms(5);
	LCD_wr_inst_ini(0b00000011);
	_delay_us(100);
	LCD_wr_inst_ini(0b00000011);
	_delay_us(100);
	LCD_wr_inst_ini(0b00000010);
	_delay_us(100);
	LCD_wr_instruction(LCD_Cmd_Func2Lin); //4 Bits, n?mero de l?neas y tipo de letra
	LCD_wr_instruction(LCD_Cmd_Off); //apaga el display
	LCD_wr_instruction(LCD_Cmd_Clear); //limpia el display
	LCD_wr_instruction(LCD_Cmd_ModeDnS); //Entry mode set ID S
	LCD_wr_instruction(LCD_Cmd_OnsCsB); //Enciende el display
}

void LCD_wr_char(uint8_t data){
	//saco la parte m?s significativa del dato
	PORTLCD=data>>4; //Saco el dato y le digo que escribir? un dato
	saca_uno(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
	//saco la parte menos significativa del dato
	PORTLCD=data&0b00001111; //Saco el dato y le digo que escribir? un dato
	saca_uno(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
	saca_cero(&PORTLCD,RS);
	LCD_wait_flag();
	
}

void LCD_wr_inst_ini(uint8_t instruccion){
	PORTLCD=instruccion; //Saco el dato y le digo que escribir? un dato
	saca_cero(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
}

void LCD_wr_instruction(uint8_t instruccion){
	//saco la parte m?s significativa de la instrucci?n
	PORTLCD=instruccion>>4; //Saco el dato y le digo que escribir? un dato
	saca_cero(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
	//saco la parte menos significativa de la instrucci?n
	PORTLCD=instruccion&0b00001111; //Saco el dato y le digo que escribir? un dato
	saca_cero(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
	LCD_wait_flag();
}


void LCD_wait_flag(void){
	//	_delay_ms(100);
	DDRLCD&=0b11110000; //Para poner el pin BF como entrada para leer la bandera lo dem?s salida
	saca_cero(&PORTLCD,RS);// Instrucci?n
	saca_uno(&PORTLCD,RW); // Leer
	while(1){
		saca_uno(&PORTLCD,E); //pregunto por el primer nibble
		_delay_ms(10);
		saca_cero(&PORTLCD,E);
		if(isSet(PINLCD,BF)) {break;} //uno_en_bit para proteus, 0 para la vida real
		_delay_us(10);
		saca_uno(&PORTLCD,E); //pregunto por el segundo nibble
		_delay_ms(10);
		saca_cero(&PORTLCD,E);
	}
	saca_uno(&PORTLCD,E); //pregunto por el segundo nibble
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
	//entonces cuando tenga cero puede continuar con esto...
	saca_cero(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	DDRLCD|=(15<<0)|(1<<RS)|(1<<RW)|(1<<E);
}


void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT){ // al usarla, no olvidar el &
	*LUGAR=*LUGAR|(1<<BIT);
}

void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT){// al usarla, no olvidar el &
	*LUGAR=*LUGAR&~(1<<BIT);
}

#define BAUD 4800
#define MYUBRR F_CPU/16/BAUD-1
void USART_Init(uint16_t UBRR){
	DDRD |= 0b00000010; //Pin 1: TX; Pin0: RX
	UBRRH = (uint8_t)(UBRR >> 8); //UBRRH:UBRRL
	UBRRL = (uint8_t)(UBRR); //UBRRH:UBRRL
	UCSRB = (1<<RXEN) | (1<<TXEN) | (1<<RXCIE);
		/*
			RXCIE. 1: Interruption when data received; 0: No interruption
			TXCIE. 1: Interruption when finished transmission (not usually needed); 0: No interruption
			UDRIE. 1: Interruption When ready to transmit; 0: No interruption
			RXEN. 1: Habilita recepcion; 0: Deshabilita recepcion
			TXEN. 1: Habilita transmision; 0: Deshabilita transmision
			UCSZ2. To enable 9 bits of transmission
			RXB8, TXB8. 9th bit of UDR. Write or read before UDR
		*/
	
	UCSRC = (1<<URSEL) | (0<<USBS) | (3<<UCSZ0);
		/* Set frame format: 8 data, 2 stop bit */
		/*
			URSEL. Set as 1 always
			UMSEL. 1: Síncrono; 0: Asíncrono (usamos 0)
			Parity
				UPM1: 1, UPM0: 0 Par
				UPM1: 1, UPM1: 1 Impar
			USBS. 0: 1 stop bit; 1: 2 stop bits
			Number of bits
				UCSZ1	UCSZ0
				0		0		5 bits
				0		1		6 bits
				1		0		7 bits
				1		1		8 bits	
				1		1		8 bits //Enable UCSZ2
		*/
	/*
		Other registers
			UDR Contains the data to send and just received. It is used in other functions
				There's a ninth bit in another register
			It resets immediately after accesing to it
			
			UCSRA Has information and other stuff, not completely needed
	*/
}
void USART_Transmit(uint8_t data) { 
	while (!(UCSRA & (1<<UDRE)));
	UDR = data;
}
volatile uint8_t data = 0;
ISR(USART_RXC_vect){ //Cuando se recibe el dato, entra aqui
	data = UDR;
	if(data=='a'){ //comparar para transmitir
		//código
	}
		
}
void Keyboard_init(){
	DDRT = 0b00001111;									//7->4: entradas,3->0: salidas(rotar tierra)
	PORTT = 0b11111111;
}

int main(void)
{
	sei();
	LCD_init();
	USART_Init(MYUBRR);
	ADC_init();
	while (1);
	
}