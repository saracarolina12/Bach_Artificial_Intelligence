/*
 * 02BotónDecr_GomezDelgado.cpp
 *
 * Created: 01/02/2022 03:07:43 p. m.
 * Author : Sara Carolina Gómez Delgado
 */ 

#define F_CPU 1000000
#include <avr/io.h>
#include <util/delay.h>
#include <stdio.h>

uint8_t cont = 0;

//funciones
uint8_t cero_en_bit(volatile uint8_t *LUGAR, uint8_t BIT){
	return (!(*LUGAR&(1<<BIT)));
}
void imprime(void){
	uint8_t u=0, d=0;
	d=cont/10;
	u=cont%10;
	u=u<<4;
	u|=d;							
	PORTC = u;
}

//main
int main(void)
{
	//botones
	DDRA = 0;
	PORTA = 0xFF;				//necesitan pullups
	
	//display
	DDRC = 0xFF;
	PORTC = 0;					//cátodo común, enciende con 0
	
    while (1) 
    {
		if((cero_en_bit(&PINA,7)) && cont != 0){
			//al presionar
			_delay_ms(50);
			while(cero_en_bit(&PINA,7));
			_delay_ms(50);
			//al soltar
			cont--;
			imprime();
		}else if((cero_en_bit(&PINA,0)) && cont != 99){
			//al presionar
			_delay_ms(50);
			while(cero_en_bit(&PINA,0));
			_delay_ms(50);
			//al soltar
			cont++;
			imprime();
		}
		
    }
}



