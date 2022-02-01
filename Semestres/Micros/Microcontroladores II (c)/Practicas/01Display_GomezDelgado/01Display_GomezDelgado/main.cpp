/*
 * 01Display_GomezDelgado.cpp
 *
 * Created: 27/01/2022 03:41:25 p. m.
 * Author : Sara Carolina 
 */ 

#define F_CPU 1000000 //1Mhz
#include <avr/io.h> //porta, pina, ddra...
#include <stdio.h> //variables tipo uint8_t
#include <util/delay.h> //retardos

//prototipado de funciones

int main(void)
{
	//DipSwitch;
	DDRA=0;
	PORTA=0xFF;
	
	//display
	DDRC=0xFF;
	PORTC=0;			//cátodo común, enciende con 0
	
	DDRB=0xFF;
	PORTB=255;
	uint8_t lectura;
    while (1) 
    {
		lectura = PINA;	//puerto
		switch(lectura){
			case 0b11111111:		//0
				PORTC=0b00111111;
				break;	
			case 0b11101111:		//1
				PORTC=0b00000110;
				break;
			case 0b011011111:		//2
				PORTC=0b01011011;
				break;
			case 0b011001111:		//3
				PORTC=0b01001111;
				break;
			case 0b10111111:		//4
				PORTC=0b01100110;
				break;
			case 0b10101111:		//5
				PORTC=0b01101101;
				break;
			case 0b10011111:		//6
				PORTC=0b01111101;
				break;
			case 0b10001111:		//7
				PORTC=0b01000111;
				break;
			case 0b01111111:		//8
				PORTC=0b01111111;
				break;
			case 0b01101111:		//9
				PORTC=0b01101111;
				break;
			default:				//default
				PORTC=0b00000000;
				break;

		}
    }
}

