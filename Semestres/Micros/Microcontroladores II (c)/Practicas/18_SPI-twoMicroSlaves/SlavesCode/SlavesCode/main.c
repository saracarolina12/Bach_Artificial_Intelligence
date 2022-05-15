/*
 * SlavesCode.c
 *
 * Created: 09/05/2022 09:04:43 a. m.
 * Author : scago
 */ 

#define F_CPU 8000000

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>

void SPI_INIT_S(){
	DDRB = (1<<6); 
	SPCR = (1 << SPE)|(0 << MSTR)|(1<< SPR1)|(1<< SPR0);
	SPDR = 0; 
}

uint8_t RECEIVE_DATA(){
	while(!(SPSR&(1<<SPIF))); //trabo hasta que termine 
	uint8_t dato = SPDR;
	SPDR=0;
	return dato;
}

int main(void)
{
    DDRC = 0xFF;
	PORTC = 0;
	SPI_INIT_S();
    while (1) 
    {
		uint8_t x = RECEIVE_DATA();
		PORTC = x; //muestro el dato
		_delay_ms(1000); //espero 1 segundo
		PORTC = 0; //clear
    }
}

