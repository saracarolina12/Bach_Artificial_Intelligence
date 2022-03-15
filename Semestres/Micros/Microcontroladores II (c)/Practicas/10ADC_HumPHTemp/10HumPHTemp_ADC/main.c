/*
 * 10HumPHTemp_ADC.c
 *
 * Created: 08/03/2022 03:17:27 p. m.
 * Author : scago
 */ 

/*TEMPLATE*/

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

void RTR(uint8_t pin){
	_delay_ms(50);
	while(isClear(PINA,pin));
	_delay_ms(50);
}

uint8_t BlueMix, GreenMix, MixedResult, RedResult;
uint16_t adcRange=204.5, AZUL=0, VERDE=0, ROJO=0, tempA=0, tempV=0, tempR=0;
int main(void)
{	
	//rojo
	DDRC = 0xFF;
	PORTC = 0;
	//verde-azul
	DDRB = 0xFF;
	PORTB = 0;
	//ADC
	DDRA =      0; //entrada
	PORTA =     0; //ADC doesnt need pull up
	//pruebas
	DDRD = 0;
	
	while(1){
		//-----------------TEMPERATURA------------------//
		ADMUX =     0b01000000;
		SFIOR =     0;
		ADCSRA =	0b10010101;

		ADCSRA |= (1 << ADSC);
		while(isSet(ADCSRA, ADSC)){} //traba adc (mientras siga la conversión
		tempA = ADC;
		AZUL = (float)((tempA*10/adcRange))/10; //3.2V
		if(AZUL >= 0 && AZUL < 1) BlueMix = 0;
		else if(AZUL >=1 && AZUL < 2)BlueMix = 0b00000001;
		else if(AZUL >=2 && AZUL < 3)BlueMix = 0b00000011;
		else if(AZUL >=3 && AZUL < 4)BlueMix = 0b00000111;
		else if(AZUL >=4 && AZUL < 5) BlueMix = 0b00001111;
		//-----------------HUMEDAD---------------------//
		ADMUX =     0b01000001;
		ADCSRA |= (1 << ADSC);
		while(isSet(ADCSRA, ADSC)){} //traba adc (mientras siga la conversión
		tempV = ADC;
		VERDE = (float)((tempV*10/adcRange))/10; //3.2V
		if(VERDE >= 0 && VERDE < 1) GreenMix = 0;
		else if(VERDE >=1 && VERDE < 2)GreenMix = 0b00010000;
		else if(VERDE >=2 && VERDE < 3)GreenMix = 0b00110000;
		else if(VERDE >=3 && VERDE < 4)GreenMix = 0b01110000;
		else if(VERDE >=4 && VERDE < 5) GreenMix = 0b11110000;
		PORTB = (GreenMix | BlueMix);
		//-----------------PH-------------------------//
		ADMUX =     0b01000010;
		ADCSRA |= (1 << ADSC);
		while(isSet(ADCSRA, ADSC)){} //traba adc (mientras siga la conversión
		tempR = ADC;
		ROJO = (float)((tempR*10/adcRange))/10; //3.2V
		if(ROJO >= 0 && ROJO < 1) PORTC = 0;
		else if(ROJO >=1 && ROJO < 2) PORTC = 0b00000001;
		else if(ROJO >=2 && ROJO < 3) PORTC = 0b00000011;
		else if(ROJO >=3 && ROJO < 4) PORTC = 0b00000111;
		else if(ROJO >=4 && ROJO < 5) PORTC = 0b00001111;
	}
}

void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT){ // al usarla, no olvidar el &
	*LUGAR=*LUGAR|(1<<BIT);
}

void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT){// al usarla, no olvidar el &
	*LUGAR=*LUGAR&~(1<<BIT);
}




