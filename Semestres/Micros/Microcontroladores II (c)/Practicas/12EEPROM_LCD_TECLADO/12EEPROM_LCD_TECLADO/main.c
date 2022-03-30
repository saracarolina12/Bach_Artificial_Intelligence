/*
 * 12EEPROM_LCD_TECLADO.c
 *
 * Created: 16/03/2022 01:47:46 p. m.
 * Author : scago
 */ 


/*TEMPLATE*/

//LCD
#define F_CPU 1000000
#define PINT PIND
#define PORTT PORTD
#define DDRT DDRD
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
void LCD_wr_lineTwo(uint8_t b);
void write_EEPROM(uint16_t dir, uint8_t dato);
uint8_t read_EEPROM(uint16_t dir);

//uint8_t keyb[4][4] =
//{
//{0x7, 0x8, 0x9, 0xA},
//{0x4, 0x5, 0x6, 0xB},
//{0x1, 0x2, 0x3, 0xC},
//{0xE, 0x0, 0xF, 0xD}
//};
uint8_t keyb[4][4] =
{
	{0x1, 0x2, 0x3, 0xA},
	{0x4, 0x5, 0x6, 0xB},
	{0x7, 0x8, 0x9, 0xC},
	{0xE, 0x0, 0xF, 0xD}
};

void RTR(uint8_t pin){
	_delay_ms(50);
	while(isClear(PINT,pin));
	_delay_ms(50);
}


uint8_t pressed(void){
	while(1){
		PORTT = ~(1<<0);				//1111_1110 rota tierra
		asm("nop");
		asm("nop");
		//DCBA
		if(isClear(PINT,4)){		//1
			RTR(4);
			
			return(keyb[0][0]);
		}
		if(isClear(PINT,5)){		//8
			RTR(5);
			return(keyb[0][1]);
		}
		if(isClear(PINT,6)){		//9
			RTR(6);
			return(keyb[0][2]);
		}
		if(isClear(PINT,7)){		// entre, A
			RTR(7);
			return(keyb[0][3]);
		}
		PORTT = ~(1<<1);
		asm("nop");
		asm("nop");
		
		//3,6,9,#(F)
		if(isClear(PINT,4)){		//4
			RTR(4);
			return(keyb[1][0]);
		}
		if(isClear(PINT,5)){		//B
			RTR(5);
			return(keyb[1][1]);
		}
		if(isClear(PINT,6)){		//C
			RTR(6);
			return(keyb[1][2]);
		}
		if(isClear(PINT,7)){		//D
			RTR(7);
			return(keyb[1][3]);
		}
		PORTT = ~(1<<2);
		asm("nop");
		asm("nop");
		
		//2,5,8,0
		if(isClear(PINT,4)){		//A
			RTR(4);
			return(keyb[2][0]);
		}
		if(isClear(PINT,5)){		//B
			RTR(5);
			return(keyb[2][1]);
		}
		if(isClear(PINT,6)){		//C
			RTR(6);
			return(keyb[2][2]);
		}
		if(isClear(PINT,7)){		//D
			RTR(7);
			return(keyb[2][3]);
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
			return(keyb[3][1]);
		}
		if(isClear(PINT,6)){		//C
			RTR(6);
			return(keyb[3][2]);
		}
		if(isClear(PINT,7)){		//D
			RTR(7);
			return(keyb[3][3]);
		}

	}
}

char lin1[17], lin2[17], clear[11];
volatile uint8_t pos = 0x88, c = 1, uno, dos, tres, cuatro;
int main(void)
{
	LCD_init();
	//teclado
	DDRT = 0b00001111;					//7->4: entradas,3->0: salidas(rotar tierra)
	PORTT = 0b11111111;
	//pruebas
	DDRA = 0;
	
	uno = read_EEPROM(0);
	dos = read_EEPROM(1);
	tres = read_EEPROM(2);
	cuatro = read_EEPROM(3);
	sprintf(lin1, "%d %d %d %d", uno, dos, tres, cuatro);
	LCD_wr_instruction(0x89);
	LCD_wr_string(lin1);
	
	while (1){
		uint8_t tecla = pressed();
		if(tecla < 10){ //bloqueo los que no son números
			LCD_wr_lineTwo(tecla);
		}
		
	}
	
}

void LCD_wr_lineTwo( uint8_t b){
	cuatro = tres;
	tres = dos;
	dos = uno;
	uno = b;
	sprintf(lin1, "%d %d %d %d", uno, dos, tres, cuatro);
	LCD_wr_instruction(0x89);
	LCD_wr_string(lin1);
	//for(uint8_t i=0; i<11; i++){
		sprintf(clear, " ");
		LCD_wr_instruction(0x8A);
		LCD_wr_string(clear);
		//pos++;
	//}
	write_EEPROM(0, uno);
	write_EEPROM(1, dos);
	write_EEPROM(2, tres);
	write_EEPROM(3, cuatro);
	pos = 0x87;
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


