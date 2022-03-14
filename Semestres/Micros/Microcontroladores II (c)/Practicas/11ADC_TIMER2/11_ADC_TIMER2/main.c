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
	//pruebas
	DDRD = 0;
	
	//TIMER2
	TIFR = 0b00000011;
	TIMSK = 0b00000010;
	OCR2 = 1; //CAMBIAR
	TCNT2 = 0;
	TCCR2 = 0b; //CAMBIAR
	
	//ADC
	ADMUX =     0b01000010; //patita A2 que es donde entra la señal a replicar
	SFIOR =     0b00000011; //Trigger timer0-comp
	ADCSRA =    0b10011101; 
	DDRA =      0;
	PORTA =     0b00000000; //ADC doesnt need pull up
	sei();
	ADCSRA |= (1<<ADSC); //le digo que inicie
	
	//PWM
	
	while (1){}
}

ISR(ADC_vect){ //entra aqu? solito despu?s de la interrupci?n
	rej = ADC;
	if(lastVal != rej){ //si cambió...
		lastVal = rej; //respaldo 
		uint16_t u = (float)(rej/adcRange);
		uint16_t Udec = (float)(rej*10/adcRange);
		uint16_t Ddec = (float)(rej*100/adcRange);
		ADCSRA|=(1 << ADSC);//inicia una nueva conversi?n
	}
	else ADCSRA|=(1 << ADSC);//inicia una nueva conversi?n
}

void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT){ // al usarla, no olvidar el &
	*LUGAR=*LUGAR|(1<<BIT);
}

void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT){// al usarla, no olvidar el &
	*LUGAR=*LUGAR&~(1<<BIT);
}


