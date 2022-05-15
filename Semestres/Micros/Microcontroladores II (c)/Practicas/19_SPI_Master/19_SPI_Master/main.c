/*
 * main.c
 *
 * Created: 5/5/2022 12:46:33 PM
 *  Author: scago
 */

#define F_CPU 1000000
#define isClear(r, i) (!(r & (1 << i)))
#define isSet(r, i) (r & (1 << i))

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <stdint.h>
#include <stdlib.h>
#include <stdio.h>
// #include <cstdlib>
#include <time.h>

#define DDRLCD DDRD
#define PORTLCD PORTD
#define PINLCD PIND
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
void LCD_wr_string(volatile const char *s);
void LCD_wr_lines(volatile const char *a, volatile const char *b);

volatile uint8_t s[16], s2[16];


void LCD_wr_string(volatile const char *s){
	char c;
	while((c=*s++)){
		LCD_wr_char(c);
	}
}

void LCD_wr_lines(volatile const char *a, volatile const char *b){
	LCD_wr_instruction(LCD_Cmd_Clear);
	LCD_wr_instruction(0b10000000);
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

void LCD_wr_char(volatile uint8_t data){
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


void SPI_INIT_MASTER(){
	DDRB = (1<<MOSI_BIT) | (1<<7); // MOSI 5  SCK 7  MISO 6 
	SPCR = (1 << SPE) | (1 << MSTR) | (1<< SPR1) | (1<< SPR0); // Enable, Master, 128 Fosc
	DDRA = 0XFF;
	PORTA = 0XFF;
}

uint8_t SPI_TRANSMIT(uint8_t i, uint8_t data){
	PORTA = ~(1<<i);
	SPDR = data;
	while( !( SPSR &  (1<<SPIF)) ); //trabo hasta que termine de transmitir
	PORTA |= (1<<i);
	return SPDR;
}


int main(void)
{
	LCD_init();
	SPI_INIT_MASTER();
	
	DDRC = 0;
	PORTC = 0xFF;
	sprintf(s,  "SPI");
	sprintf(s2, "Bidireccional");
	LCD_wr_lines(s,s2);
	uint8_t data, slave, idx, pot;
    while(1)
    {
        if( isClear(PINC, 0) ){
			_delay_ms(50);
			while( isClear(PINC, 0) ){}
			slave = 6; pot = 1;idx = 0;
			_delay_ms(50);
		}else if( isClear(PINC, 2) ){
			_delay_ms(50);
			while( isClear(PINC, 2) ){}
			slave = 6; pot = 2;idx = 7;
			_delay_ms(50);
		}else if( isClear(PINC, 4) ){
			_delay_ms(50);
			while( isClear(PINC, 4) ){}
			slave = 7; pot = 1;idx = 0;
			_delay_ms(50);
		}else if( isClear(PINC, 6) ){
			_delay_ms(50);
			while( isClear(PINC, 6) ){}
			slave = 7; pot = 2;idx = 7;
			_delay_ms(50);
		}else continue;
		uint8_t dataf;
		dataf = SPI_TRANSMIT(slave, idx);
		_delay_ms(200);
		sprintf(s,  "%d",data);
		data = SPI_TRANSMIT(slave, idx);
		sprintf(s,  "#%d    Slave: %d",pot,slave);
		sprintf(s2, "%d.%d v", data/10, data%10);
		LCD_wr_lines(s,s2);
    }
}
