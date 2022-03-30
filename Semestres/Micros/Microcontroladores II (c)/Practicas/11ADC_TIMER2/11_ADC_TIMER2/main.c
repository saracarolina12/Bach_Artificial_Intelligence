/*
 * 11_ADC_TIMER2.c
 *
 * Created: 13/03/2022 11:52:38 a. m.
 * Author : scago
 */ 

/*TEMPLATE*/

//LCD
#define F_CPU 1000000
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

uint8_t seed = 0;
uint16_t lastVal=-1;
uint16_t adcRange=204.5, rej;

void RTR(uint8_t pin){
	_delay_ms(50);
	while(isClear(PINA,pin));
	_delay_ms(50);
}

uint8_t cont = 0;
int main(void)
{
	sei();
	//TIMER 0
	TIFR = 0b00000011;
	TIMSK = 0b00000010;
	OCR0 = 97; //CAMBIAR
	TCNT0 = 0;
	TCCR0 = 0b0001101; //CAMBIAR

	
	//TIMER2 - pwm
	//TIFR = 0b00000011; //no necesaria por pwm
	//TIMSK = 0b00000010; //no necesaria por pwm
	DDRD = 0xFF; //salida
	PORTD = 0;
	OCR2 = 0; //CAMBIAR
	TCNT2 = 0;
	TCCR2 = 0b01101100; //CAMBIAR
	
	//ADC
	ADMUX =     0b01000010; //patita A2 que es donde entra la señal a replicar
	SFIOR =     0b00000011; //Trigger timer0-comp
	ADCSRA =    0b11111011; 
	DDRA =      0;
	PORTA =     0; //ADC doesnt need pull up
	sei();
	ADCSRA |= (1<<ADSC); //le digo que inicie
	
	DDRC = 0xFF;
	PORTC = 0;
	
	while (1){}
}


//interrupciones
ISR(ADC_vect){ 
	uint16_t rej = ADC;
	rej /= 4; //convertir de 0->1023 a 0->255 de ocr
	PORTC = OCR2 = rej;
}
ISR(TIMER0_COMP_vect){ }

void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT){ // al usarla, no olvidar el &
	*LUGAR=*LUGAR|(1<<BIT);
}

void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT){// al usarla, no olvidar el &
	*LUGAR=*LUGAR&~(1<<BIT);
}


