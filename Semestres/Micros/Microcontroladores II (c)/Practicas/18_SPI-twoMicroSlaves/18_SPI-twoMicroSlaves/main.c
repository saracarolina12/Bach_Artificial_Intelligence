/*
 * main.c
 *
 * Created: 9/5/2022 11:59:18 AM
 *  Author: scago
 */ 

#define F_CPU 8000000

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <stdint.h>
#include <stdlib.h>
#include <stdio.h>
#define isClear(r, i) (!(r & (1 << i)))
#define isSet(r, i) (r & (1 << i))

void SPI_INIT_MASTER(){
	DDRB = (1<<MOSI_BIT) | (1<<7);  //mosi, sck
	SPCR = (1 << SPE) | (1 << MSTR) | (1<< SPR1) | (1<< SPR0); 
	DDRA = 0XFF;
	PORTA = 0XFF;
}

uint8_t SPI_TRANSMIT(uint8_t slave_idx, uint8_t data){
	PORTA = ~(1<<slave_idx);
	SPDR = data;
	while( !( SPSR &  (1<<SPIF)) ); //trabo hasta que termine de transmitir
	PORTA |= (1<<slave_idx);
	data = SPDR;
	return data;
}

int main(void)
{
	SPI_INIT_MASTER();
	DDRC = 0x00;
	PORTC = 0xFF;
	uint8_t dato;
    while(1)
    {
        if( isClear(PINC, 0) ){
			dato = SPI_TRANSMIT(6, 0b11111110);
			dato = SPI_TRANSMIT(7, 0b11110000);
		}
    }
}