/*
 * 10HumPHTemp_ADC.c
 *
 * Created: 08/03/2022 03:17:27 p. m.
 * Author : scago
 */ 


/*TEMPLATE*/

//LCD
#define F_CPU 4000000
#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <stdint.h>
#include <stdlib.h>
#include <stdio.h>
//#include <cstdlib>//random

#define isClear(lugar, bit) (!(lugar & (1 << bit)))
#define isSet(lugar, bit) (lugar & (1 << bit))
#define mZERO(who) memset(who, 0, sizeof(who));
#define mONE(who) memset(who, 1, sizeof(who));
#define mNEG(who) memset(who, -1, sizeof(who));
#define delay(t) _delay_ms(t)
//swap and reverse bytes
#define swapB(r) ((r & 0xAA) >> 1 | (r & 0x55) << 1) //aux
#define swapP(r) ((r & 0xCC) >> 2 | (r & 0x33) << 2) //aux
#define swap(r) (r << 4 | r >> 4)                    //swap nibbles
#define reverse(r) swap(swapP(swapB(r)))             //reverses a variable (mirror effect)

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

void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT);
void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT);
void LCD_wr_inst_ini(uint8_t instruccion);
void LCD_wr_char(uint8_t data);
void LCD_wr_instruction(uint8_t instruccion);
void LCD_wait_flag(void);
void LCD_init(void);
void LCD_wr_string(volatile uint8_t *s);
void LCD_wr_lines(uint8_t *a, uint8_t *b);


void RTR(uint8_t pin){
	_delay_ms(50);
	while(isClear(PINA,pin));
	_delay_ms(50);
}

uint16_t lastVal=-1;
uint16_t adcRange=204.5, rej;
int main(void)
{	
	//rojo
	DDRC = 0xFF;
	PORTC = 0;
	//verde-azul
	DDRB = 0xFF;
	PORTB = 0;
	//pruebas
	DDRD = 0;
	
	ADMUX =     0b01000000; //A0 -> Temp
	SFIOR =     0b00000000;
	ADCSRA =    0b10011101; //4 MHz, Fdiv = 32 CON INTERRUPCIONES
	DDRA =      0b00000000;
	PORTA =     0b00000000; //ADC doesnt need pull up
	
	//ADMUX =     0b01000001; //A1 -> Hum
	
	//ADMUX =     0b01000010; //A2 -> PH
	
	sei();
	ADCSRA |= (1<<ADSC); //le digo que inicie
	
	while (1){
		ADMUX =     0b01000000; //A0 -> Temp
		ADMUX =     0b01000001; //A1 -> Hum
		ADMUX =     0b01000010; //A2 -> PH
		ADCSRA |= (1<<ADSC); //le digo que inicie
		//PORTB = 5;
	}
	
}

ISR(ADC_vect){ //entra aquí solito después de la interrupción
	rej = ADC;
	PORTD = ADMUX;
	//delay(1000);
	if(ADMUX == 0x42){
		if(lastVal != rej){ //si cambió el valor
			lastVal = rej; //respaldo
			uint16_t Udec = (float)(rej*10/adcRange); //19 en caso de 1.9
			uint16_t concat =Udec/10; //1.9
			if(concat >= 0 && concat < 1){
				PORTC = 0; //0
				}else if(concat >=1 && concat <2){
				PORTC = 8; //1
				}else if(concat >=2 && concat <3){
				PORTC = 4; //2
				}else if(concat >=3 && concat <4){
				PORTC = 12; //3
				}else if(concat >=4 && concat <5){
				PORTC = 2; //4 leds prendidos
			}
			
		}
	}else{
		PORTB = 3;
	}

	ADCSRA|=(1 << ADSC);//inicia una nueva conversión
	//delay(500);
	PORTB = 0;
}

void LCD_wr_string(volatile uint8_t *s){
	uint8_t c;
	while((c=*s++)){
		LCD_wr_char(c);
	}
}


void LCD_wr_lines(uint8_t *a, uint8_t *b){
	LCD_wr_instruction(LCD_Cmd_Clear);
	LCD_wr_instruction(LCD_Cmd_Home);
	LCD_wr_string(a);
	LCD_wr_instruction(0b11000000);
	LCD_wr_string(b);
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
		if(isSet(PINLCD,BF)) {break;} //uno_en_bit para protues, 0 para la vida real
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




