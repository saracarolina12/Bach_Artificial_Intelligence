/*TEMPLATE*/

//LCD
#define F_CPU 4000000
#define PINT PINC
#define PORTT PORTC
#define DDRT DDRC
#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <stdint.h>
#include <stdlib.h>
#include <stdio.h>
//#include <cstdlib>//random

#define isClear(r, i) (!(r & (1 << i)))
#define isSet(r, i) (r & (1 << i))
#define mZERO(who) memset(who, 0, sizeof(who));
#define mONE(who) memset(who, 1, sizeof(who));
#define mNEG(who) memset(who, -1, sizeof(who));
#define delay(t) _delay_ms(t)

#define DDRLCD DDRA
#define PORTLCD PORTA
#define PINLCD PINA
#define RS 4
#define RW 5
#define E 7
#define BF 3
#define LCD_Cmd_Clear      0b00000001	// replace all characters with ASCII 'space'
#define LCD_Cmd_Home       0b00000010  // return cursor to first position on first line
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

void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT);
void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT);
void LCD_wr_inst_ini(uint8_t instruccion);
void LCD_wr_char(uint8_t data);
void LCD_wr_instruction(uint8_t instruccion);
void LCD_wait_flag(void);
void LCD_init(void);
void LCD_wr_string(volatile uint8_t *s);
void LCD_wr_lines(uint8_t *a, uint8_t *b);

uint8_t seed = 0;
uint8_t keyb[4][4] =
{
	{0x7, 0x8, 0x9, 0xa},
	{0x4, 0x5, 0x6, 0xb},
	{0x1, 0x2, 0x3, 0xc},
	{0xe, 0x0, 0xf, 0xd}
};

void RTR(uint8_t pin){
	_delay_ms(50);
	while(isClear(PINC,pin));
	_delay_ms(50);
}

uint8_t pressed(void){
	while(1){
		seed++;
		PORTT = ~(1<<0);				//1111_1110 rota tierra
		asm("nop");
		asm("nop");
		//DCBA
		if(isClear(PINT,7)){		//A
			RTR(7);
			return(keyb[0][3]);
		}
		if(isClear(PINT,6)){		//9
			RTR(6);
			return(keyb[0][2]);
		}
		if(isClear(PINT,5)){		//8
			RTR(5);
			return(keyb[0][1]);
		}
		if(isClear(PINT,4)){		//7
			RTR(4);
			return(keyb[0][0]);
		}
		PORTT = ~(1<<1);
		
		//3,6,9,#(F)
		if(isClear(PINT,7)){		//A
			RTR(7);
			return(keyb[1][3]);
		}
		if(isClear(PINT,6)){		//B
			RTR(6);
			return(keyb[1][2]);
		}
		if(isClear(PINT,5)){		//C
			RTR(5);
			return(keyb[1][1]);
		}
		if(isClear(PINT,4)){		//D
			RTR(4);
			return(keyb[1][0]);
		}
		PORTT = ~(1<<2);
		
		//2,5,8,0
		if(isClear(PINT,7)){		//-
			RTR(7);
			return(keyb[2][3]);
		}
		if(isClear(PINT,6)){		//3
			RTR(6);
			return(keyb[2][2]);
		}
		if(isClear(PINT,5)){		//2
			RTR(5);
			return(keyb[2][1]);
		}
		if(isClear(PINT,4)){		//1
			RTR(4);
			return(keyb[2][0]);
		}
		PORTT = ~(1<<3);
		
		//1,4,7,*(E)
		if(isClear(PINT,7)){		//e
			RTR(7);
			return(keyb[3][3]);
		}
		if(isClear(PINT,6)){		//B
			RTR(6);
			return(keyb[3][2]);
		}
		if(isClear(PINT,5)){		//C
			RTR(5);
			return(keyb[3][1]);
		}
		if(isClear(PINT,4)){		//D
			RTR(4);
			return(keyb[3][0]);
		}

	}
}
uint8_t uno[16], dos[16],lectura, moneda=0, price=0, cont=0, letter=0, prodID=0, interr = 0, sum=0, cambio=0;
int main(void)
{
	sei();
	GIFR = 0b11100000;
	MCUCSR = 0b01000000; //flanco de subida
	//GICR = 0b00100000; //todavía no, hasta que ya haya puesto A/B, 1/2 producto
	LCD_init();
	//teclado
	DDRT = 0b00001111;					//7->4: entradas,3->0: salidas(rotar tierra)
	PORTT = 0b11111111;
	//LCD_wr_string("hola");
	//pruebas
	DDRD = 0;
	
	//dipswitch + botón
	DDRB=0b000000001; //entradas
	PORTB=0b11111010; //botón no requiere pullups
	
	uint8_t tecla;
	
	while (1){
		if(cont == 0){
			sprintf(uno, "Elige Producto");
			sprintf(dos, "");
			LCD_wr_lines(uno,dos);
			cont++;
		}
		tecla = pressed();
		if(tecla){ //si se presiona una tecla
			if(cont == 1){ //sólo debería recibir A y B
				if(tecla == 10 || tecla == 11){
					letter = tecla;
					//PORTD = tecla;
					sprintf(uno, "Elige Producto");
					sprintf(dos, "%c", letter+'7');
					LCD_wr_lines(uno,dos);
					cont++;
				}
			}else if(cont == 2){
				if(tecla == 1 || tecla == 2){
					prodID = tecla;
					//PORTD = tecla;
					sprintf(uno, "Elige un producto");
					sprintf(dos, "%c %d", letter+'7',prodID);
					LCD_wr_lines(uno,dos);
					GICR = 0b00100000; // activo interrupción para empezar a recibir monedas
					delay(1000);
					cont++;
				}
			} 
		} //If tecla
		if(cont == 3){
			if(letter = 10 && prodID == 1) price = 3;
			else if(letter== 10 && prodID == 2) price = 9;
			else if(letter == 11 && prodID == 1) price = 23;
			else if(letter == 11 && prodID == 2) price = 31;
			sprintf(uno, "Inserta $%d.00", price);
			sprintf(dos, "Tienes $00.00");
			LCD_wr_lines(uno,dos);
			PORTD = 0xFF;
			delay(1000);
			//leo el dipswitch
			while(interr == 0){
				if(isSet(PINB, 3) && isClear(PINB, 4) && isClear(PINB, 5)  && isClear(PINB, 6) ){ //$1
					moneda = 1;
					PORTD = 1;
				}else if(isClear(PINB, 3) && isSet(PINB, 4) && isClear(PINB, 5)  && isClear(PINB, 6) ){ //$2
					moneda = 2;
					PORTD = 2;
				}else if(isSet(PINB, 3) && isSet(PINB, 4) && isClear(PINB, 5)  && isClear(PINB, 6) ){ //$5
					moneda = 5;
					PORTD = 5;
				}else if(isClear(PINB, 3) && isClear(PINB, 4) && isSet(PINB, 5)  && isClear(PINB, 6) ){ //$10
					moneda = 10;
					PORTD = 10;
				}
			}
			interr=0;
			cont++;
		}
		
	} //while(1)
	
} //main


ISR(INT2_vect){
	PORTD = 3;
	//delay(3000);
	if(sum == price){//se entrega el producto
		PORTD = 1;
		sprintf(uno, "Entregando...");
		if(cambio < 10) sprintf(dos, "Cambio $0%d.00", cambio);
		else sprintf(dos, "Cambio $%d.00", cambio);
		LCD_wr_lines(uno,dos);
		
		saca_uno(PINB,0); //enciendo led
		delay(2000); //espero dos segundos
		
		//restablezco valores
		 uno[16], dos[16],lectura, moneda=0, price=0, cont=0, letter=0, prodID=0, interr = 0, sum=0, cambio=0;
		 
		 sei();
		 GIFR = 0b11100000;
		 MCUCSR = 0b01000000; //flanco de subida
		 //GICR = 0b00100000; //todavía no, hasta que ya haya puesto A/B, 1/2 producto
		 LCD_init();
		 //teclado
		 DDRT = 0b00001111;					//7->4: entradas,3->0: salidas(rotar tierra)
		 PORTT = 0b11111111;
		 
		 //pruebas
		 DDRD = 0;
		 
		 //dipswitch + botón
		 DDRB=0b000000001; //entradas
		 PORTB=0b11111010; //botón no requiere pullups
	}
	
	//PORTD = sum;
	//delay(1000);
	//PORTD = moneda;
	//delay(2000);
	//sum += moneda;
	//PORTD = sum;
	interr = 1; // sí hubo interrupción
	sprintf(uno, "Inserta $%d.00", price);
	if(sum < 10) sprintf(dos, "Tienes $0%d.00", sum);
	else sprintf(dos, "Tienes $%d.00", sum);
	//interr = 0;
	
}


void LCD_wr_string(volatile uint8_t *s){
	uint8_t c;
	while((c=*s++)){
		LCD_wr_char(c);
	}
}


void LCD_wr_lines(uint8_t *a, uint8_t *b){
	LCD_wr_instruction(LCD_Cmd_Clear);
	LCD_wr_instruction(LCD_Cmd_Home);
	LCD_wr_string(a);
	LCD_wr_instruction(0b11000000);
	LCD_wr_string(b);
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
	LCD_wr_instruction(LCD_Cmd_ModeDnS); //Entry mode set ID S
	//LCD_wr_instruction(LCD_Cmd_OnsCsB); //Enciende el display
	LCD_wr_instruction(LCD_Cmd_OncCcB); //con blink
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

void LCD_wr_inst_ini(uint8_t instruccion){
	PORTLCD=instruccion; //Saco el dato y le digo que escribir? un dato
	saca_cero(&PORTLCD,RS);
	saca_cero(&PORTLCD,RW);
	saca_uno(&PORTLCD,E);
	_delay_ms(10);
	saca_cero(&PORTLCD,E);
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


void LCD_wait_flag(void){
	//	_delay_ms(100);
	DDRLCD&=0b11110000; //Para poner el pin BF como entrada para leer la bandera lo dem?s salida
	saca_cero(&PORTLCD,RS);// Instrucci?n
	saca_uno(&PORTLCD,RW); // Leer
	while(1){
		saca_uno(&PORTLCD,E); //pregunto por el primer nibble
		_delay_ms(10);
		saca_cero(&PORTLCD,E);
		if(isSet(PINLCD,BF)) {break;} //uno_en_bit para protues, 0 para la vida real
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


void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT){ // al usarla, no olvidar el &
	*LUGAR=*LUGAR|(1<<BIT);
}

void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT){// al usarla, no olvidar el &
	*LUGAR=*LUGAR&~(1<<BIT);
}
