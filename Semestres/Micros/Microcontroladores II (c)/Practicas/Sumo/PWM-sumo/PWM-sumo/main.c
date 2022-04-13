/*
 * Sumo.c
 *
 * Created: 02/04/2022 05:22:07 p. m.
 * Author : Alfredo
 */ 

#define F_CPU 8000000
#define isSet(r,i) (r&(1<<i))
#define ID 0
#define IR 1
#define DD 2
#define DR 3
#define IB 4
#define DB 5
#define DDRANALOG DDRA
#define PORTANALOG DDRA
#define PINANALOG PINA
#define DDRDIGITAL DDRC
#define PORTDIGITAL DDRC
#define PINDIGITAL PINC

#include <avr/io.h>
#include <util/delay.h>
#include <stdint.h>


int main(void)
{
	PORTDIGITAL = ( (1<<ID)|(1<<DD) );
	//Varia el ocr
	//delay(500)
	//Varia el ocr
	//delay(500)
	//Varia el ocr
	//delay(500)
	//PWM
	TIFR = 0b00000011;
	TCNT0 = 0;
	OCR0 = 255;
	TCCR0 = 0b01101011;
	//Lecturas analogicas
    ADMUX = 0b01100000;
    ADCSRA = 0b11000000;
	DDRANALOG = 0; 
	PORTANALOG = 0; 
	//Motores y sensores logicos
    DDRDIGITAL = ( (0<<DB) | (0<<IB) | (1<<DR) | (1<<DD) | (1<<IR) | (1<<ID) );
    PORTDIGITAL = 0;
	
	//PWM
	DDRB |= (1<<3);
	DDRD |= (1<<7);
	
    uint8_t val;
	uint8_t lower_val = 50;
	uint8_t upper_val = 200;
	uint8_t izq = 0;
	uint8_t der = 0;
	uint8_t sharp_izq = 0;
	uint8_t sharp_der = 0;
	uint8_t bool_izq = 0;
	uint8_t bool_der = 0;
	
	_delay_ms(5000);
	
    while (1) 
    {
		//Sensor sharp izquierdo
	    ADMUX = 0b01100000;
	    ADCSRA|=(1<<6);
	    while( ADCSRA & (1<<ADSC) );
	    val = (ADCH*5)/256;
		if(val < lower_val && val > upper_val) sharp_izq = 0;
		else sharp_izq = 1;
	    
	    //Sensor sharp izquierdo
	    ADMUX = 0b01100001;
	    ADCSRA|=(1<<6);
	    while( ADCSRA & (1<<ADSC) );
	    val = (ADCH*5)/256;
	    if(val < lower_val && val > upper_val) sharp_der = 0;
		else sharp_der = 1;
    
		//Sensor piso izquierdo
		if(PINDIGITAL & (1 << IB)) bool_izq = 1;
		else bool_izq = 0;
    
		//Sensor piso derecho
		if(PINDIGITAL & (1 << DB)) bool_der = 1;
		else bool_der = 0;
		
		//Decidir movimiento
		switch((bool_izq<<1) & (bool_der)){
			case 0: //No esta al borde
				
			break;
			case 1: //Derecha al borde
				PORTDIGITAL = ( (1<<DR) );
			break;
			case 2: //Izquierda al borde
				PORTDIGITAL = ( (1<<IR) );
			break;
			case 3: //Ambos al borde
				PORTDIGITAL = ( (1<<IR)|(1<<DR) );
				_delay_ms(250);
			break;
			default:
			break;
		}
		
    }
}