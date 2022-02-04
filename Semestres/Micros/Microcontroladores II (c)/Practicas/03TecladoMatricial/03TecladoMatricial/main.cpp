/*
 * 03TecladoMatricial.cpp
 *
 * Created: 03/02/2022 03:05:44 p. m.
 * Author : scago
 */ 

//defines
#define PINT PINA
#define PORTT PORTA
#define DDRT DDRA
#define F_CPU 1000000

//includes
#include <avr/io.h>
#include <util/delay.h>
#include <stdio.h>

//globales
//uint8_t arr[16] = [10,11,12,13,3,6,9,14,2,5,8,0,1,4,7,15]; //14=#, 15=*

uint8_t cero_en_bit(volatile uint8_t *LUGAR, uint8_t BIT){
	return (!(*LUGAR&(1<<BIT)));
}
void RTR(uint8_t pin){
	_delay_ms(50);
	while(cero_en_bit(&PINA,pin));
	_delay_ms(50);
}

uint8_t pressed(void){
	while(1){
		PORTT = ~(1<<0);				//1111_1110 rota tierra
		asm("nop");
		asm("nop");
		//ABCD
		if(cero_en_bit(&PINT,4)){		//A
			RTR(4);
			return(13);
		}
		if(cero_en_bit(&PINT,5)){		//B
			RTR(5);
			return(12);
		}
		if(cero_en_bit(&PINT,6)){		//C
			RTR(6);
			return(11);
		}
		if(cero_en_bit(&PINT,7)){		//D
			RTR(7);
			return(10);
		}
		PORTT = ~(1<<1);
		
		//3,6,9,#(F)
		if(cero_en_bit(&PINT,4)){		//A
			RTR(4);
			return(15);
		}
		if(cero_en_bit(&PINT,5)){		//B
			RTR(5);
			return(9);
		}
		if(cero_en_bit(&PINT,6)){		//C
			RTR(6);
			return(6);
		}
		if(cero_en_bit(&PINT,7)){		//D
			RTR(7);
			return(3);
		}
		PORTT = ~(1<<2);
		
		//2,5,8,0
		if(cero_en_bit(&PINT,4)){		//A
			RTR(4);
			return(0);
		}
		if(cero_en_bit(&PINT,5)){		//B
			RTR(5);
			return(8);
		}
		if(cero_en_bit(&PINT,6)){		//C
			RTR(6);
			return(5);
		}
		if(cero_en_bit(&PINT,7)){		//D
			RTR(7);
			return(2);
		}
		PORTT = ~(1<<3);
		
		//1,4,7,*(E)
		if(cero_en_bit(&PINT,4)){		//A
			RTR(4);
			return(14);
		}
		if(cero_en_bit(&PINT,5)){		//B
			RTR(5);
			return(7);
		}
		if(cero_en_bit(&PINT,6)){		//C
			RTR(6);
			return(4);
		}
		if(cero_en_bit(&PINT,7)){		//D
			RTR(7);
			return(1);
		}
		
		
		
		//3,6,9,#
		//for(uint8_t x=0,pos=0,i=4; i<=7; i++){		//x=PORTT=~(1<<0,1,2,3), pos=teclapresionada, i=rotar tierra
			//if(cero_en_bit(&PINT,i)){				//i= 4,5,6,7
				//RTR(i);
				//return arr[pos++];
			//}
			//PORTT = ~(1<<x++);
		//}
	}
}

int main(void)
{
	//teclado
    DDRT = 0b00001111;					//7->4: entradas,3->0: salidas
	PORTT = 0b11111111;
	
	//declarar otras variables
	DDRC = 0b11111111;
	PORTC= 0;
	DDRD = 0b11111111;
	PORTD= 0;
	
	uint8_t tecla;
    while (1){
		//tecla = pressed();
		PORTD = pressed();
    }
}

