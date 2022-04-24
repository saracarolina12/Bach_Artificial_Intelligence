/*
 * DHT_11-pruebas.c
 *
 * Created: 20/04/2022 06:23:10 p. m.
 * Author : scago
 */ 

#define F_CPU 1000000
#include <avr/io.h>
#include <util/delay.h>
#include <stdint.h>
#include <stdlib.h>
#include <stdio.h>

#define DDRLCD DDRC
#define PORTLCD PORTC
#define PINLCD PINC
#define RS 4
#define RW 5
#define E 6
#define BF 3
#define LCD_Cmd_Clear      0b00000001
#define LCD_Cmd_Home       0b00000010
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
#define isClear(r, i) (!(r & (1 << i)))
#define isSet(r, i) (r & (1 << i))

//DHT-11
#define DHT11_PIN 0
#define PIN_SENS PINA
#define PORT_SENS PORTA
#define DDR_SENS DDRA

/**** VARIABLES ****/
uint8_t c=0,I_RH,D_RH,I_Temp,D_Temp,CheckSum;
char uno[17], dos[17];

void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT){
	*LUGAR=*LUGAR|(1<<BIT);
}

void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT){
	*LUGAR=*LUGAR&~(1<<BIT);
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
void LCD_wr_inst_ini(uint8_t instruccion){
	PORTLCD=instruccion; //Saco el dato y le digo que escribir? un dato
	saca_cero(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
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


void Request_HUMTEMP()				/* Microcontroller send start pulse/request */
{
	DDR_SENS |= (1<<DHT11_PIN);
	PORT_SENS |= (1<<DHT11_PIN); /* add this line */
	_delay_ms(100); /* add this line */
	PORT_SENS &= ~(1<<DHT11_PIN); /* set to low pin */
	_delay_ms(20); /* wait for 20ms */
	PORT_SENS |= (1<<DHT11_PIN); /* set to high pin */
}

int Response_HUMTEMP()
{
	DDR_SENS &= ~(1<<DHT11_PIN);
	_delay_us(39);
	if((PIN_SENS & (1<<DHT11_PIN))) //response signal error check!
	return 1;
	_delay_us(80);
	if(!(PIN_SENS & (1<<DHT11_PIN))) //pulled ready output check!
	return 1;
	_delay_us(80);
}

uint8_t Receive_data_HUMTEMP()			/* receive data */
{
	c=0;
	for (int q=0; q<8; q++)
	{
		while((PIN_SENS & (1<<DHT11_PIN)) == 0);  /* check received bit 0 or 1 */
		
		_delay_us(30);
		if(PIN_SENS & (1<<DHT11_PIN))/* if high pulse is greater than 30ms */
			c = (c<<1)|(0x01);	/* then its logic HIGH */
		else			/* otherwise its logic LOW */
			c = (c<<1);
		while(PIN_SENS & (1<<DHT11_PIN));
	}
	return c;
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
	//LCD_wr_instruction(LCD_Cmd_ModeDcS); //Entry mode set ID S
	LCD_wr_instruction(0b10000000); //posici?n 0 ->
	LCD_wr_instruction(LCD_Cmd_OnsCsB); //Enciende el display
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






int main(void)
{
	DDRA = 0;
	PORTA = 0;
	char IZQ_hum[5], DER_hum[5], IZQ_temp[5], DER_temp[5];
	LCD_init();
	//LCD_wr_string("Sarita :D");
	while (1)
	{
		Request_HUMTEMP();		/* send start pulse */
		Response_HUMTEMP();		/* receive response */
		if(Response_HUMTEMP() != 1) /* receive response */
		{
			LCD_wr_string("3");
			I_RH = Receive_data_HUMTEMP(); /* store first eight bit in I_RH */
			LCD_wr_string("4");
			D_RH = Receive_data_HUMTEMP(); /* store next eight bit in D_RH */
			LCD_wr_string("5");
			I_Temp = Receive_data_HUMTEMP(); /* store next eight bit in I_Temp */
			D_Temp = Receive_data_HUMTEMP(); /* store next eight bit in D_Temp */
			CheckSum = Receive_data_HUMTEMP();/* store next eight bit in CheckSum */
			LCD_wr_string("6");
		}

		LCD_wr_string("3 :D");
		I_RH=Receive_data_HUMTEMP();	/* store first eight bit in I_RH */
		LCD_wr_string("4");
		D_RH=Receive_data_HUMTEMP();	/* store next eight bit in D_RH */
		I_Temp=Receive_data_HUMTEMP();	/* store next eight bit in I_Temp */
		D_Temp=Receive_data_HUMTEMP();	/* store next eight bit in D_Temp */
		CheckSum=Receive_data_HUMTEMP();/* store next eight bit in CheckSum */
		LCD_wr_string("7");
		if((I_RH + D_RH + I_Temp + D_Temp) != CheckSum){ //error
			LCD_wr_string("Error!!");
		}else{
			/* HUM */
			//itoa(I_RH, IZQ_hum, 10); //val,char,base
			//itoa(D_RH, DER_hum, 10); //val,char,base
			//sprintf(uno, "%c.%c", IZQ_hum, DER_hum);
			///* TEMP */
			//itoa(I_Temp,IZQ_temp,10);
			//itoa(D_Temp,DER_temp,10);
			//sprintf(dos, "%c.%c", IZQ_temp, DER_temp);
			//LCD_wr_lines(uno,dos);
			
			
			sprintf(uno, "H: %d %d,T: %d %d",I_RH, D_RH, I_Temp, D_Temp );
			LCD_wr_lineOne(uno);
		}
	}
}