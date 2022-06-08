/*
 * DHT_11-pruebas.c
 *
 * Created: 20/04/2022 06:23:10 p. m.
 * Author : scago
 */ 

#define F_CPU 1000000
#include <avr/io.h>
#include <util/delay.h>
#include <stdint.h>
#include <stdlib.h>
#include <stdio.h>
#include <util/twi.h>
#include <avr/interrupt.h>


#define DDRLCD DDRB
#define PORTLCD PORTB
#define PINLCD PINB
#define RS 4
#define RW 5
#define E 6
#define BF 3
#define LCD_Cmd_Clear      0b00000001
#define LCD_Cmd_Home       0b00000010
//#define LCD_Cmd_Mode     0b000001 ID  S
#define LCD_Cmd_ModeDnS	   0b00000110 //sin shift cursor a la derecha
#define LCD_Cmd_ModeInS	   0b00000100 //sin shift cursor a la izquierda
#define LCD_Cmd_ModeIcS	   0b00000111 //con shift desplazamiento a la izquierda
#define LCD_Cmd_ModeDcS	   0b00000101 //con shift desplazamiento a la derecha
//#define LCD_Cmd_OnOff    0b00001 D C B
#define LCD_Cmd_Off		   0b00001000
#define LCD_Cmd_OnsCsB	   0b00001100
#define LCD_Cmd_OncCsB     0b00001110
#define LCD_Cmd_OncCcB     0b00001111
//#define LCD_Cmd_Shift    0b0001 SC  RL 00
//#define LCD_Cmd_Function 0b001 DL  N  F  00
#define LCD_Cmd_Func2Lin   0b00101000
#define LCD_Cmd_Func1LinCh 0b00100000
#define LCD_Cmd_Func1LinG  0b00100100
//#define LCD_Cmd_DDRAM    0b1xxxxxxx
#define isClear(r, i) (!(r & (1 << i)))
#define isSet(r, i) (r & (1 << i))

//DHT-11 temphum
#define PIN 5
#define DHT_PIN PIND
#define DHT_PORT PORTD
#define DHT_DDR DDRD
#define maxTemp 32

//DS3231 reloj
#define DS3231_ReadMode_U8    (0xD1) /*1101 0001*/
#define DS3231_WriteMode_U8   (0xD0) /*1101 0000*/
#define DS3231_REG_Seconds    (0x00)
#define SCL_CLOCK  100000

//SERIAL COM
#define BAUD 9600
#define MYUBRR F_CPU/16/BAUD-1


/** VARIABLES **/
char uno[17], dos[17];
volatile uint8_t data = 0;

typedef struct
{
	uint8_t sec;
	uint8_t min;
	uint8_t hour;
	uint8_t weekDay;
	uint8_t date;
	uint8_t month;
	uint8_t year;
}rtc_t;

void init_i2c(void)
{
	/* initialize TWI clock: 100 kHz clock, TWPS = 0 => prescaler = 1 */
	
	TWSR = 0;                         /* no prescaler */
	TWBR = ((F_CPU/SCL_CLOCK)-16)/2;  /* must be > 10 for stable operation */
	TWCR = (1<<TWINT) | (1<<TWSTA) | (1<<TWEN); /*master transmisor*/
}

uint8_t i2c_readAck(void)
{
	TWCR = (1<<TWINT) | (1<<TWEN) | (1<<TWEA);
	while(!(TWCR & (1<<TWINT)));

	return TWDR;
}

uint8_t i2c_readNack(void)
{
	TWCR = (1<<TWINT) | (1<<TWEN);
	while(!(TWCR & (1<<TWINT)));
	
	return TWDR;
}

void i2c_stop(void)
{
	/* send stop condition */
	TWCR = (1<<TWINT) | (1<<TWEN) | (1<<TWSTO);
	while(TWCR & (1<<TWSTO)); // wait until stop condition is executed and bus released
}

uint8_t i2c_write(uint8_t byte_data)
{
	uint8_t   twst;
	
	// send data to the previously addressed device
	TWDR = byte_data;
	TWCR = (1<<TWINT) | (1<<TWEN);

	// wait until transmission completed
	while(!(TWCR & (1<<TWINT)));

	// check value of TWI Status Register. Mask prescaler bits
	twst = TW_STATUS & 0xF8;
	if( twst != TW_MT_DATA_ACK) return 1;
	return 0;
}

uint8_t i2c_start(uint8_t addr)
{
	uint8_t   twst;
	TWCR = (1<<TWINT) | (1<<TWSTA) | (1<<TWEN);
	while(!(TWCR & (1<<TWINT)));                    // wait until transmission completet
	twst = TW_STATUS & 0xF8;                    // check value of TWI Status Register. Mask prescaler bits.
	if ( (twst != TW_START) && (twst != TW_REP_START)) return 1;
	TWDR = addr;                             // send device address
	TWCR = (1<<TWINT) | (1<<TWEN);
	while(!(TWCR & (1<<TWINT)));            // wail until transmission completed and ACK/NACK has been received
	twst = TW_STATUS & 0xF8;               // check value of TWI Status Register. Mask prescaler bits.
	if ( (twst != TW_MT_SLA_ACK) && (twst != TW_MR_SLA_ACK) ) return 1;
	return 0;
}

uint8_t DS3231_Bin_Bcd(uint8_t binary_value)
{
	uint8_t temp;
	uint8_t retval;
	temp = binary_value;
	retval = 0;
	while(1)
	{
		if(temp >= 10){
			temp -= 10;
			retval += 0x10;
			}else{
			retval += temp;
			break;
		}
	}
	return(retval);
}

void DS3231_Set_Date_Time(uint8_t dy, uint8_t mth, uint8_t yr, uint8_t dw, uint8_t hr, uint8_t mn, uint8_t sc)
{
	//PORTB = 1;
	sc &= 0x7F;
	hr &= 0x3F;
	i2c_start(0xD1);
	i2c_write(0xD0);
	i2c_write(0x00);
	i2c_write(DS3231_Bin_Bcd(sc));
	i2c_write(DS3231_Bin_Bcd(mn));
	i2c_write(DS3231_Bin_Bcd(hr));
	i2c_write(DS3231_Bin_Bcd(dw));
	i2c_write(DS3231_Bin_Bcd(dy));
	i2c_write(DS3231_Bin_Bcd(mth));
	i2c_write(DS3231_Bin_Bcd(yr));
	i2c_stop();
	//PORTB = 2;
}

void ds3231_GetDateTime(rtc_t *rtc)
{
	i2c_start(0xD0);                            // Start I2C communication
	i2c_write(DS3231_WriteMode_U8);        // connect to ds3231 by sending its ID on I2c Bus
	i2c_write(DS3231_REG_Seconds);         // Request Sec RAM address at 00H
	i2c_stop();                            // Stop I2C communication after selecting Sec Register

	i2c_start(0xD1);                            // Start I2C communication
	//i2c_write(DS3231_ReadMode_U8);            // connect to ds3231(Read mode) by sending its ID

	rtc->sec = i2c_readAck();                // read second and return Positive ACK
	rtc->min = i2c_readAck();                 // read minute and return Positive ACK
	rtc->hour= i2c_readAck();               // read hour and return Negative/No ACK
	rtc->weekDay = i2c_readAck();           // read weekDay and return Positive ACK
	rtc->date= i2c_readAck();              // read Date and return Positive ACK
	rtc->month=i2c_readAck();            // read Month and return Positive ACK
	rtc->year =i2c_readNack();             // read Year and return Negative/No ACK
}


void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT){
	*LUGAR=*LUGAR|(1<<BIT);
}

void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT){
	*LUGAR=*LUGAR&~(1<<BIT);
}

void LCD_wait_flag(void){
	//	_delay_ms(100);
	DDRLCD&=0b11110000; //Para poner el pin BF como entrada para leer la bandera lo dem?s salida
	saca_cero(&PORTLCD,RS);// Instrucci?n
	saca_uno(&PORTLCD,RW); // Leer
	while(1){
		saca_uno(&PORTLCD,E); //pregunto por el primer nibble
		_delay_ms(10);
		saca_cero(&PORTLCD,E);
		if(isSet(PINLCD,BF)) {break;} //uno_en_bit para proteus, 0 para la vida real
		_delay_us(10);
		saca_uno(&PORTLCD,E); //pregunto por el segundo nibble
		_delay_ms(10);
		saca_cero(&PORTLCD,E);
	}
	saca_uno(&PORTLCD,E); //pregunto por el segundo nibble
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
	//entonces cuando tenga cero puede continuar con esto...
	saca_cero(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	DDRLCD|=(15<<0)|(1<<RS)|(1<<RW)|(1<<E);
}
void LCD_wr_inst_ini(uint8_t instruccion){
	PORTLCD=instruccion; //Saco el dato y le digo que escribir? un dato
	saca_cero(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
}

void LCD_wr_char(uint8_t data){
	//saco la parte m?s significativa del dato
	PORTLCD=data>>4; //Saco el dato y le digo que escribir? un dato
	saca_uno(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
	//saco la parte menos significativa del dato
	PORTLCD=data&0b00001111; //Saco el dato y le digo que escribir? un dato
	saca_uno(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
	saca_cero(&PORTLCD,RS);
	LCD_wait_flag();
	
}


void LCD_wr_instruction(uint8_t instruccion){
	//saco la parte m?s significativa de la instrucci?n
	PORTLCD=instruccion>>4; //Saco el dato y le digo que escribir? un dato
	saca_cero(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
	//saco la parte menos significativa de la instrucci?n
	PORTLCD=instruccion&0b00001111; //Saco el dato y le digo que escribir? un dato
	saca_cero(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
	LCD_wait_flag();
}


void LCD_wr_string(volatile uint8_t *s){
	uint8_t c;
	while((c=*s++)){
		LCD_wr_char(c);
	}
}

void LCD_init(void){
	DDRLCD=(15<<0)|(1<<RS)|(1<<RW)|(1<<E); //DDRLCD=DDRLCD|(0B01111111)
	_delay_ms(15);
	LCD_wr_inst_ini(0b00000011);
	_delay_ms(5);
	LCD_wr_inst_ini(0b00000011);
	_delay_us(100);
	LCD_wr_inst_ini(0b00000011);
	_delay_us(100);
	LCD_wr_inst_ini(0b00000010);
	_delay_us(100);
	LCD_wr_instruction(LCD_Cmd_Func2Lin); //4 Bits, n?mero de l?neas y tipo de letra
	LCD_wr_instruction(LCD_Cmd_Off); //apaga el display
	LCD_wr_instruction(LCD_Cmd_Clear); //limpia el display
	//LCD_wr_instruction(LCD_Cmd_ModeDcS); //Entry mode set ID S
	LCD_wr_instruction(0b10000000); //posici?n 0 ->
	LCD_wr_instruction(LCD_Cmd_OnsCsB); //Enciende el display
}

void LCD_wr_lineOne(volatile uint8_t a){
	LCD_wr_instruction(LCD_Cmd_Clear);
	LCD_wr_instruction(LCD_Cmd_Home);
	LCD_wr_string(a);
}
void LCD_wr_lineTwo(volatile uint8_t b){
	LCD_wr_instruction(0b11000000);
	LCD_wr_string(b);
}
void LCD_wr_lines(uint8_t *a, uint8_t *b){
	LCD_wr_instruction(LCD_Cmd_Clear);
	LCD_wr_instruction(LCD_Cmd_Home);
	LCD_wr_string(a);
	LCD_wr_instruction(0b11000000);
	LCD_wr_string(b);
}

void LCD_printTime(rtc_t rtc){
	uint8_t c[16];
	sprintf(c, "%d:%d", rtc.hour, rtc.min);
	LCD_wr_lines("", c);
}

void DHT11_init(void){						
	DHT_DDR |= (1<<PIN);					//salida
	DHT_PORT |= (1<<PIN);					//encendido
}

uint8_t DHT11_read(int *temp, int *hum){
	uint8_t bits[5];						//guardo valores que recibo
	uint8_t cont=0;		
	
	//MCU sends out start signal and pulls down voltage for 18ms
	DHT_PORT &= ~(1<<PIN);					//apagado 
	_delay_ms(18);
	DHT_PORT |= (1<<PIN);					//encendido
	DHT_DDR &= ~(1<<PIN);					//entrada para recibir datos
	
	//MCU pulls up voltage and waits for DHT response (20-40us)
	cont = 0;
	while(DHT_PIN & (1<<PIN)){
		_delay_us(2);
		cont +=2;							//incrementa cada 2us
		if(cont > 60){						//si entra aquí, hay error
			DHT_DDR |= (1<<PIN);			//salida
			DHT_PORT |= (1<<PIN);			//encendido
			return 0;
		}
	}
	
	//DHT sends out response signal & keeps it for 80us
	cont = 0;
	while(!(DHT_PIN & (1<<PIN))){
		_delay_us(2);
		cont+=2;
		if(cont > 100){
			DHT_DDR |= (1<<PIN);			//salida
			DHT_PORT |= (1<<PIN);			//encendido
			return 0;
		}
	}
	
	//DHT pulls up voltage and keeps it for 80us
	cont = 0;
	while(DHT_PIN & (1<<PIN)){
		_delay_us(2);
		cont+=2;
		if(cont > 100){
			DHT_DDR |= (1<<PIN);			//salida
			DHT_PORT |= (1<<PIN);			//encendido
			return 0;
		}
	}
	
	//Start data transmission
	for(uint8_t j=0; j<5; j++){
		uint8_t res = 0;
		for(uint8_t i=0; i<8; i++){
			while(!(DHT_PIN & (1<<PIN)));
				_delay_us(35);
			if(DHT_PIN & (1<<PIN)) 
				res |= (1<<(7-i));
			while(DHT_PIN & (1<<PIN));
		}
		bits[j] = res;
	}
	DHT_DDR |= (1<<PIN);					//salida
	DHT_PORT |= (1<<PIN);					//encendido
	
	//convert temp&hum
	if((uint8_t)(bits[0] + bits[1] + bits[2] + bits[3]) == bits[4]){ //si es igual a checksum, todo ok
		uint16_t rawhum = bits[0]<<8 | bits[1];
		uint16_t rawtemp = bits[2]<<8 | bits[3];
		
		if(rawtemp & 0x8000){				//temperatura negativa
			temp = (int)((rawtemp & 0x7fff)/10)-1;
		}else{
			*temp = (int)(rawtemp)/10;
		}
		*hum = (int)(rawhum)/10;
		return 1;
	}	
	return 1;
}

void USART_Init(uint16_t UBRR){
	DDRD |= 0b00000010; //Pin 1: TX; Pin0: RX
	UBRRH = (uint8_t)(UBRR >> 8); //UBRRH:UBRRL
	UBRRL = (uint8_t)(UBRR); //UBRRH:UBRRL
	UCSRB = (1<<RXEN) | (1<<TXEN) | (1<<RXCIE);
	UCSRC = (1<<URSEL) | (0<<USBS) | (3<<UCSZ0);
	
}
void USART_Transmit(uint8_t data) {
	while (!(UCSRA & (1<<UDRE)));
	UDR = data;
}

ISR(USART_RXC_vect){ //Cuando se recibe el dato, entra aqui
	data = UDR;
	//if(data=='M'){ //comparar para transmitir
		//PORTB = 8;
	//}else if(data = 'T'){
		//PORTB = 10;
	//}
}
		

int lastTemp, lastHum;
int main(void)
{
	/*App serial COMS*/
	sei();
	USART_Init(MYUBRR);
	
	int temp=0, hum=0;
	int moist=0.0;
	uint8_t mycont = 200;
	LCD_init();
	DHT11_init();
	/*Ventilador*/
	//DDRB = 0b000000001; //B0 salida
	/*Bomba de agua*/
	DDRD |= (1<<6); //D6 salida
	/*Reloj*/
	init_i2c();
	rtc_t rn;
	//DS3231_Set_Date_Time(15,5,22,0,11,42,0);            // Day,Month,Year,Day_Week,Hour,Minute,Second
		
	while (1)
	{
		mycont++;
		if(mycont>=200){				//leer cada 2000ms
			//ds3231_GetDateTime(&rn);
			//LCD_printTime(rn);
			//LCD_wr_instruction(LCD_Cmd_Home);
			uint8_t status = DHT11_read(&temp, &hum);
			if(status){
				if(lastTemp != temp/25){
						LCD_wr_instruction(LCD_Cmd_Home);
					lastTemp = temp/256;
					
					/*muestro temperatura*/
						LCD_wr_string("Temp: ");
					
					itoa(temp/25, uno, 10);
						LCD_wr_string(uno);
						LCD_wr_string(" C");
					/*Si excede a 32°, enciendo ventilador*/
					//if(temp/25 >= maxTemp) PORTB = 0;  //CAMBIAR 27 POR 32
					//else PORTB = 1;
				}
				if(lastHum != hum/25){
						LCD_wr_instruction(0b11000000);
						LCD_wr_string("Hum: ");
					dtostrf(hum/25.6,2,2, dos);
						LCD_wr_string(dos);
						LCD_wr_string(" %");
				}
			}else{
				LCD_wr_instruction(LCD_Cmd_Clear);
				LCD_wr_string(" ");
			}
		}
	}
}