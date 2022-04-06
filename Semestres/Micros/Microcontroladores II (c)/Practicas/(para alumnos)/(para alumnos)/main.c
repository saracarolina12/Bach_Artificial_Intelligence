/*
 * Practica16.c
 *
 * Created: 04/04/2022 10:15:31 p. m.
 * Author : sarita
 */ 

#include <avr/io.h>

// CPU
#define F_CPU 1000000 
// Definiciones del puerto serial
#define BAUD 4800
#define MYUBRR F_CPU/16/BAUD-1

// Librerias necesarias
#include <avr/io.h>
#include <util/delay.h>		// Para poder hacer retardos
#include <stdint.h>
#include <stdlib.h>
#include <avr/interrupt.h>
#include <time.h>


// Esqueletos de comunicacion serial
void USART_Init(uint16_t ubrr);
void USART_Transmit(uint8_t data);
uint8_t USART_Receive(void);

// Esqueletos de funciones utiles
uint8_t cero_en_bit(volatile uint8_t *LUGAR, uint8_t BIT);
uint8_t uno_en_bit(volatile uint8_t *LUGAR, uint8_t BIT);
void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT);
void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT);
uint8_t hasta_tecla(void);

// Variables
volatile uint8_t dato;
uint16_t res = 0;

int main(void)
{
    // Declaramos puertos de entrada y de salida
	// A es de entrada con pull ups porque son los botones
	DDRA = 0; //ENTRADA
	PORTA = 255; //PULL UPS
	
	// B es de salida apagado porque es el timer
	DDRB = 255;
	PORTB = 0;
	
	sei();
	
	// Inicializacion del puerto serial
	USART_Init(MYUBRR); //Se calcula con la formula arriba en las definiciones para ver la tabla cada vez
	
    while (1) 
    {
		
		for(uint8_t i=0; i<8; i++)
		{
				if(cero_en_bit(&PINA, i))
				{
					//RTR
					//código al presionar
					_delay_ms(50);
					while(cero_en_bit(&PINA,i))
					{
					} //esta es una traba mientras tiene 0
					_delay_ms(50);
					//código al soltar
					if(i==7)
					{
						USART_Transmit('I');
					}
					else
					{
						if(i+1 == dato-48) //i+1 porque el DO manda un 1 por el UDR, y es dato-48 porque lo que lee lo lee en ASCII entonces restamos 48 para que de el valor en decimal
						{
							switch(i) //empiezo desde el 0 por el num de PIN en proteus
							{
								case 0:
									DO();
									break;
								case 1:
									RE();
									break;
								case 2:
									MI();
									break;
								case 3:
									FA();
									break;
								case 4:
									SOL();
									break;
								case 5:
									LA();
									break;
								case 6:
									SI();
									break;
								default:
									break;
							}
							
						}
						
						USART_Transmit(i+'1');
						
					}
				}
				
		}
    }
}

void DO()
{
	float t = 0.0019111;
	// para que suene
	OCR0 = 238;
	TCCR0 = 0b00011010;
	_delay_ms(1000);
	//para que se calle
	TCCR0 = 0b00011000;
}

void RE()
{
	float t = 0.0017026;
	// para que suene
	OCR0 = 212;
	TCCR0 = 0b00011010;
	_delay_ms(1000);
	//para que se calle
	TCCR0 = 0b00011000;
}

void MI()
{
	float t = 0.0015168;
	// para que suene
	OCR0 = 189;
	TCCR0 = 0b00011010;
	_delay_ms(1000);
	//para que se calle
	TCCR0 = 0b00011000;
}

void FA()
{
	float t = 0.0014317;
	// para que suene
	OCR0 = 178;
	TCCR0 = 0b00011010;
	_delay_ms(1000);
	//para que se calle
	TCCR0 = 0b00011000;
}

void SOL()
{
	float t = 0.0012755;
	// para que suene
	OCR0 = 158;
	TCCR0 = 0b00011010;
	_delay_ms(1000);
	//para que se calle
	TCCR0 = 0b00011000;
}

void LA()
{
	float t = 0.0011363;
	// para que suene
	OCR0 = 141;
	TCCR0 = 0b00011010;
	_delay_ms(1000);
	//para que se calle
	TCCR0 = 0b00011000;
}

void SI()
{
	float t = 0.0010123;
	// para que suene
	OCR0 = 126;
	TCCR0 = 0b00011010;
	_delay_ms(1000);
	//para que se calle
	TCCR0 = 0b00011000;
}

// Funciones del puerto serial
void USART_Init(uint16_t ubrr){
	// Entradas y salidas
	DDRD |= 0b00000010;
	
	// Set baud rate
	UBRRH = (uint16_t) (ubrr >> 8);
	UBRRL = (uint16_t) ubrr;
	
	// Enable receiver and transmitter
	UCSRB = (1<<RXEN) | (1<<TXEN) | (1<<RXCIE); // (recep, trans, int)
	// Set frame format: 8data, 1stop bit
	UCSRC = (1<<URSEL) | (0<<USBS) | (3<<UCSZ0);
}

void USART_Transmit(uint8_t data){
	// Wait for empty transmit buffer
	while( !(UCSRA & (1<<UDRE)) ) {}
	// Put data into buffer, sends the data
	UDR = data;
}


uint8_t USART_Receive(void){ // Esta se utiliza cuando no se ocupa la interrupcion de recepcion
	// Wait for data to be received
	while( !(UCSRA & (1<<RXC)) ) {}
	
	// Get and return received data from buffer
	return UDR;
}

ISR(USART_RXC_vect){ // Esta se utiliza cuando se ocupa la interrupcion de recepcion
	dato = UDR;
}

// Funciones utiles
uint8_t cero_en_bit(volatile uint8_t *LUGAR, uint8_t BIT){
	return (!(*LUGAR&(1<<BIT)));
}

uint8_t uno_en_bit(volatile uint8_t *LUGAR, uint8_t BIT){
	return (*LUGAR&(1<<BIT));
}
void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT){
	*LUGAR=*LUGAR|(1<<BIT);
}

void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT){
	*LUGAR=*LUGAR&~(1<<BIT);
}
