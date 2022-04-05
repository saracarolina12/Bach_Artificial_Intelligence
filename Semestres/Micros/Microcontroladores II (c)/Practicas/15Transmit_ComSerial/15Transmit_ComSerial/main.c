/*
 * 15Transmit_ComSerial.c
 *
 * Created: 29/03/2022 04:15:34 p. m.
 * Author : scago
 */ 


#define F_CPU 4000000

#include <avr/io.h>
#include <util/delay.h>
#include <stdint.h>
#include <stdlib.h>


#define BAUD 9600
#define MYUBRR F_CPU/16/BAUD-1

#define PINT PINA
#define PORTT PORTA
#define DDRT DDRA

uint8_t cero_en_bit(volatile uint8_t *LUGAR, uint8_t BIT);
uint8_t uno_en_bit(volatile uint8_t *LUGAR, uint8_t BIT);

void USART_Init(uint16_t ubrr);
void USART_Transmit(uint8_t data);
uint8_t USART_Receive(void);

volatile uint8_t data;

uint8_t hasta_tecla(void)
{
	uint8_t regreso[4][4] = {{0,0,0,0},{13,3,6,9},{0,2,5,8},{10,1,4,7}};
	while(1)
	{
		for(int i=0;i<4;i++)
		{
			PORTT = ~(1<<i);
			asm("nop");
			if(cero_en_bit(&PINT,4))
			{
				_delay_ms(50);
				while(cero_en_bit(&PINT,4)){}
				_delay_ms(50);
				return regreso[i][0];
			}
			if(cero_en_bit(&PINT,5))
			{
				_delay_ms(50);
				while(cero_en_bit(&PINT,5)){}
				_delay_ms(50);
				return regreso[i][1];
			}
			if(cero_en_bit(&PINT,6))
			{
				_delay_ms(50);
				while(cero_en_bit(&PINT,6)){}
				_delay_ms(50);
				return regreso[i][2];
			}
			if(cero_en_bit(&PINT,7))
			{
				_delay_ms(50);
				while(cero_en_bit(&PINT,7)){}
				_delay_ms(50);
				return regreso[i][3];
			}
		}
	}
	return 0;
}

int main(void)
{
	USART_Init(MYUBRR);
	
	DDRT = 0x0F;
	PORTT = 0xFF;
	
	uint8_t tecla;
	
	while (1)
	{
		tecla = hasta_tecla();
		USART_Transmit(tecla+48);
	}
}

void USART_Init(uint16_t ubrr)
{
	DDRD |= 0b00000010;
	UBRRH = (uint8_t)(ubrr>>8);
	UBRRL = (uint8_t)ubrr;
	UCSRB = (1<<RXEN)|(1<<TXEN)|(1<<RXCIE);
	UCSRC = (1<<URSEL)|(0<<USBS)|(3<<UCSZ0);
}

void USART_Transmit(uint8_t data)
{
	while (!(UCSRA&(1<<UDRE))) {}
	UDR = data;
}

uint8_t USART_Receive(void) //Se utiliza cuando no se configura la interrupción de recepción. De preferencia siempre trabajar con interrupción.
{
	while (!(UCSRA&(1<<RXC))) {}
	return UDR;
}

uint8_t cero_en_bit(volatile uint8_t *LUGAR, uint8_t BIT)
{
	return (!(*LUGAR&(1<<BIT)));
}

uint8_t uno_en_bit(volatile uint8_t *LUGAR, uint8_t BIT)
{
	return (*LUGAR&(1<<BIT));
}

