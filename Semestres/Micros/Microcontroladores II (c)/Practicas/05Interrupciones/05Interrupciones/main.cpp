/*
 * 05Interrupciones.cpp
 *
 * Created: 10/02/2022 02:42:36 p. m.
 * Author : scago
 */ 

#define PINT PINA
#define PORTT PORTA
#define DDRT DDRA
#define F_CPU 4000000

#include <avr/io.h>
#include <util/delay.h>
#include <stdio.h>

//globales
uint8_t tecla, cont=0;

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
			return(15);										//RESETEAR
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
	}
}
						 
void imprimir(){
	if(cont == 0){PORTC = 0b00000000;}
	if(cont == 1){PORTC = 0b00100000;}
	if(cont == 2){PORTC = 0b00010000;}
	if(cont == 3){PORTC = 0b00110000;}
	if(cont == 4){PORTC = 0b00001000;}
	if(cont == 5){PORTC = 0b00101000;}
	if(cont == 6){PORTC = 0b00011000;}
	if(cont == 7){PORTC = 0b00111000;}
	if(cont == 8){PORTC = 0b00000100;}
	if(cont == 9){PORTC = 0b00100100;}
}
void showservo(uint8_t tec){
	PORTD = tec;
	if(tec == 0) OCR0 = 15;
	else if(tec == 1) OCR0 = 16;
	else if(tec == 2) OCR0 = 18;
	else if(tec == 3) OCR0 = 20;
	else if(tec == 4) OCR0 = 21;
	else if(tec == 5) OCR0 = 23;
	else if(tec == 6) OCR0 = 25;
	else if(tec == 7) OCR0 = 26;
	else if(tec == 8) OCR0 = 28;
	else if(tec == 9) OCR0 = 30;
}

int main(void){
    //teclado
    DDRT = 0b00001111;					//7->4: entradas,3->0: salidas
    PORTT = 0b11111111;
    
    //declarar otras variables
	//display
	DDRC = 0b11111111;
	PORTC = 0;
	//servo
	DDRB = 0b00001000;
	PORTB = 0xFF;
	
	TCNT0 = 0;
	OCR0 = 15;
	TCCR0 = 0b01101100; //N=256,4mhz,PWM,inicia en 1
	
	DDRD = 0xFF;
	PORTD = 0;
    while (1){
		tecla = pressed();
		if(tecla == 13){ //servo
			showservo(cont);
		}
		else if(tecla == 9 && cont<9){ //?
			cont++;
			DDRD = cont;
			imprimir();
		}
		else if(tecla == 1 && cont>0){ //?
			cont--;
			DDRD = cont;
			imprimir();
		}
    }
}

