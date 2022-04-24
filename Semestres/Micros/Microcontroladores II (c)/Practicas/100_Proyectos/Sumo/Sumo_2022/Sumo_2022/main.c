/*
 * Sumo_2022.c
 *
 * Created: 11/04/2022 02:27:52 p. m.
 * Author : scago
*/ 
#define F_CPU 1000000
#define isSet(r,i) (r&(1<<i))

#include <avr/io.h>
#include <util/delay.h>
#include <stdint.h>

int main(void)
{
    ADMUX = 0b01100000;
    ADCSRA = 0b11000000;
    DDRC = ~0;
    PORTC = ( (1<<0)|(1<<2) );
	//Sensor infrarrojo
	DDRA = 0; 
	PORTA = 0; 
	
    uint8_t val;
	uint8_t lower_val = 50;
	uint8_t upper_val = 200;
	uint8_t izq = 0;
	uint8_t der = 0;
	/*
	  //1: activo, 0:desactivo
		pin0: izq
		pin2: der
	*/
    while (1) 
    {
		//Sensor 1
	    ADMUX = 0b01100000;
	    ADCSRA|=(1<<6);
	    while( ADCSRA & (1<<ADSC) );
	    val = (ADCH*5)/256;
		if(val > upper_val){
			izq = 0;
		}else{
			izq = 1;
		}
	    
	    //Sensor 2
	    ADMUX = 0b01100001;
	    ADCSRA|=(1<<6);
	    while( ADCSRA & (1<<ADSC) );
	    val = (ADCH*5)/256;
	    if(val > upper_val){
		    der = 0;
		}else{
		    der = 1;
	    }
		if(isSet(PINA,0)){//zona negra
			/*avanza hacia adelante*/
			der = 0;
			izq = 0;
		}else{ //zona blanca
			/*va de reversa*/
			
		}
		//elegir a qu� direcci�n ir
		if(izq || der){
			PORTC = ( (izq<<0)|(der<<2) );
		}else{
			PORTC = ( (0<<0)|(2<<1) );
		}
		
		
    }
}


