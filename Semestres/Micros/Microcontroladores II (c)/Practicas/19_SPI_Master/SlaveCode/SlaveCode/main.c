/*
 * main.c
 *
 * Created: 5/5/2022 1:22:14 PM
 *  Author: david
 */ 


#define F_CPU 1000000
#define isClear(r, i) (!(r & (1 << i)))
#define isSet(r, i) (r & (1 << i))
#define offBit(x,i) !(x & (1<<i))
#define onBit(x,i)  ((int)(x) & (int)(1<<i))

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <stdint.h>
#include <stdlib.h>
#include <stdio.h>
// #include <cstdlib>
#include <time.h>

void SPI_INIT_SLAVE(){
	// MISO como salida, MOSI, SCK y SS como entrada
	DDRB = (1<<6); // MOSI 5  SCK 7  MISO 6 
	// Configurar SPCR (Habilitarlo y ponerlo como esclavo?), si hiciera falta tambi?n SPSR (para interrupciones o velocidad).
	SPCR = (1 << SPE) | (0 << MSTR) | (1<< SPR1) | (1<< SPR0); // Enable, Slave, 128 Fosc
}

uint8_t SPI_RECEIVE(uint8_t data){
	SPDR = data;
	// Esperar hasta que el bit SPIF tenga un 1 (o bien hasta que se genere la interrupci?n).
	while( !( SPSR &  (1<<SPIF)) ){}
	// Leer el valor del SPDR.
	return SPDR;
}

void ADC_INIT(){
	ADMUX  = 0b01000111;
	ADCSRA = 0b10010100; // 1MHZ
	DDRA = 0x00;	// Entrada
	PORTA = 0x00;	// No Pull ups
}

#define ADMUX_PIN0 0b01000000
#define ADMUX_PIN1 0b01000001
#define ADMUX_PIN2 0b01000010
#define ADMUX_PIN7 0b01000111

#define adc_to_5(x) x=((x/200.0)*(500.0/511.0))

uint8_t readPin(uint8_t pin){
	ADMUX = pin;
	ADCSRA |= (1<<ADSC);
	while( onBit(ADCSRA, ADSC) ){}
	float cosa = ADC;
	cosa /= 16.0;
	cosa = (cosa/32.0)*5.0;
	uint8_t val = cosa*10.01;
	return val;
}

void start(){
	
	ADC_INIT();
	SPI_INIT_SLAVE();
	
}

int main(void)
{
	start();
	uint8_t valor_adc, data;
    while(1)
    {
        data = SPI_RECEIVE(32);
		if(data == 0){
			valor_adc = readPin(ADMUX_PIN0);
		}else{
			valor_adc = readPin(ADMUX_PIN7);
		}
		data = SPI_RECEIVE(valor_adc);
    }
}