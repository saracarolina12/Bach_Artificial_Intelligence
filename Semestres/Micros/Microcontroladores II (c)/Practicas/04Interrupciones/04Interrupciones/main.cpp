/*
 * 04Interrupciones.cpp
 *
 * Created: 08/02/2022 03:13:50 p. m.
 * Author : scago
 */ 

#define F_CPU 1000000	

#include <avr/io.h>
#include <util/delay.h>
#include <stdio.h>
#include <avr/interrupt.h>
#include <stdlib.h>

volatile uint8_t rnd;

uint8_t cero_en_bit(volatile uint8_t *LUGAR, uint8_t BIT){
	return (!(*LUGAR&(1<<BIT)));
}

int main(void)
{
	//leds
	DDRA = 0xFF;
	PORTA = 0;
	
	//botón
	DDRD = 0;
	PORTD = 0;
	
    sei();
	GIFR =0b11100000;
	MCUCR =0b00001010;
	GICR =0b01000000;
	srand(5);
    while (1) 
    {
		rnd = rand() % 6 + 1;
		
    }
}
ISR(INT0_vect){
	if(rnd == 1)PORTA = 0b00001000;
	else if(rnd == 2) PORTA = 0b00010100;
	else if(rnd == 3) PORTA = 0b00011100;
	else if(rnd == 4) PORTA = 0b01010101;
	else if(rnd == 5) PORTA = 0b01011101;
	else if(rnd == 6) PORTA = 0b01110111;
	_delay_ms(50);
	while(cero_en_bit(&PIND,2))
	_delay_ms(50);
}

