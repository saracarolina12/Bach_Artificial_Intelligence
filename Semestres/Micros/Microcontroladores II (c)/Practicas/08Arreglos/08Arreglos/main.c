/*
 * 08Arreglos.c
 *
 * Created: 22/02/2022 03:17:27 p. m.
 * Author : scago
 */ 
//LCD
#define F_CPU 1000000
#define PINT PINA
#define PORTT PORTA
#define DDRT DDRA
#include <avr/io.h>
#include <util/delay.h>
#include <stdint.h>
#include <stdlib.h>
//#include <stdio.h> //randoms
#include <avr/interrupt.h>
#define isClear(r, i) (!(r & (1 << i)))
#define isSet(r, i) (r & (1 << i))
#define delay(t) _delay_ms(t)
#define FIL 2
#define COL 10

#define DDRLCD DDRC
#define PORTLCD PORTC
#define PINLCD PINC
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

void saca_uno(volatile uint8_t *LUGAR, uint8_t BIT);
void saca_cero(volatile uint8_t *LUGAR, uint8_t BIT);
void LCD_wr_inst_ini(uint8_t instruccion);
void LCD_wr_char(uint8_t data);
void LCD_wr_instruction(uint8_t instruccion);
void LCD_wait_flag(void);
void LCD_init(void);
void LCD_wr_string(volatile uint8_t *s);
void LCD_wr_lines(uint8_t *a, uint8_t *b);

uint8_t x,y, seed=0;
uint8_t hidden[FIL][COL], input[FIL][COL];

//uint8_t keyb[4][4] =
//{
//{0x7, 0x8, 0x9, 0xA},
//{0x4, 0x5, 0x6, 0xB},
//{0x1, 0x2, 0x3, 0xC},
//{0xE, 0x0, 0xF, 0xD}
//};
uint8_t keyb[4][4] =
{
	{0x1, 0x2, 0x3, 0xA},
	{0x4, 0x5, 0x6, 0xB},
	{0x7, 0x8, 0x9, 0xC},
	{0xE, 0x0, 0xF, 0xD}
};

void RTR(uint8_t pin){
	_delay_ms(50);
	while(isClear(PINA,pin));
	_delay_ms(50);
}

uint8_t pressed(void){
	while(1){
		seed++;
		PORTT = ~(1<<0);				//1111_1110 rota tierra
		asm("nop");
		asm("nop");
		//DCBA
		if(isClear(PINT,4)){		//+,D
			RTR(4);
			return(keyb[3][3]);
		}
		if(isClear(PINT,5)){		//-,C
			RTR(5);
			return(keyb[2][3]);
		}
		if(isClear(PINT,6)){		//x,B
			RTR(6);
			return(keyb[1][3]);
		}
		if(isClear(PINT,7)){		// entre, A
			RTR(7);
			return(keyb[0][3]);
		}
		PORTT = ~(1<<1);
		
		//3,6,9,#(F)
		if(isClear(PINT,4)){		//A
			RTR(4);
			return(keyb[3][2]);										
		}
		if(isClear(PINT,5)){		//B
			RTR(5);
			return(keyb[2][2]);
		}
		if(isClear(PINT,6)){		//C
			RTR(6);
			return(keyb[1][2]);
		}
		if(isClear(PINT,7)){		//D
			RTR(7);
			return(keyb[0][2]);
		}
		PORTT = ~(1<<2);
		
		//2,5,8,0
		if(isClear(PINT,4)){		//A
			RTR(4);
			return(keyb[3][1]);
		}
		if(isClear(PINT,5)){		//B
			RTR(5);
			return(keyb[2][1]);
		}
		if(isClear(PINT,6)){		//C
			RTR(6);
			return(keyb[1][1]);
		}
		if(isClear(PINT,7)){		//D
			RTR(7);
			return(keyb[0][1]);
		}
		PORTT = ~(1<<3);
		
		//1,4,7,*(E)
		if(isClear(PINT,4)){		//A
			RTR(4);
			return(keyb[3][0]);
		}
		if(isClear(PINT,5)){		//B
			RTR(5);
			return(keyb[2][0]);
		}
		if(isClear(PINT,6)){		//C
			RTR(6);
			return(keyb[1][0]);
		}
		if(isClear(PINT,7)){		//D
			RTR(7);
			return(keyb[0][0]);
		}		

	}
}

int main(void)
{
	memset(hidden, 0, sizeof(hidden));
	memset(input, 0,sizeof(input));
	LCD_init();
	//teclado
    DDRT = 0b00001111;					//7->4: entradas,3->0: salidas(rotar tierra)
	PORTT = 0b11111111;
	//display
	DDRB = 0xFF;
	PORTB = 0;
	//pruebas
	DDRD = 0;
	
	uint8_t tecla,uno[17], dos[17], cont=0, cuadrito, flag = 0, Nint=0, aciertos=0,Ux,Uy,userTry=1, intentos=1;
	//sprintf(uno, "Cuantas coordenadas?");
	//sprintf(dos, "");
	//LCD_wr_lines(uno, dos);
    while (1){
		if(cont == 0){
			sprintf(uno, "Cuantas coordenadas?");
			sprintf(dos, "");
			LCD_wr_lines(uno, dos);
			cont++;
		}
		tecla = pressed();
		srand(seed); //seed
		if(tecla){	//si se presionó una tecla
			if(cont == 1){ //primera vez que se presiona (#coordenadas)
				if(tecla != 0 && tecla !=10 && tecla !=11 && tecla != 12 && tecla != 13 && tecla != 14 && tecla != 15){
					cuadrito = tecla;
					sprintf(uno, "Escondere %d", tecla);
					sprintf(dos, "coordenadas.");
					LCD_wr_lines(uno,dos);
					_delay_ms(1500); //segundo y medio
					
					sprintf(uno, "Tu debes buscar");
					sprintf(dos, "%d coordenadas.", tecla);
					LCD_wr_lines(uno,dos);
					_delay_ms(1500); //segundo y medio
					
					sprintf(uno, "2 filas (0,1)");
					sprintf(dos, "10 cols (0,9)");
					LCD_wr_lines(uno,dos);
					_delay_ms(1500); //segundo y medio
					
					sprintf(uno, "Presiona + ");
					sprintf(dos, "para continuar...");
					LCD_wr_lines(uno,dos);
					_delay_ms(1500); //segundo y medio
					cont++;
				}
			}else if(cont == 2){//(#continuar)
				if(tecla == 13){ //si es +(D) la tecla
					sprintf(uno, "Trata de");
					sprintf(dos, "memorizar...");
					LCD_wr_lines(uno,dos);
					_delay_ms(1000); //segundo y medio
	
					for(uint8_t i=1; i<=cuadrito; i++){
						do{ //para que no se repitan las coordenadas
							x = rand() % 2, y = rand() % 10; //Random within a limit [0:10), [0:2)
							//PORTD = x;
							//delay(1000);
							//PORTD = y;
							//delay(1000);
						}
						while(hidden[x][y]);
						hidden[x][y]=1;
						sprintf(uno, "Cuadrito %d", i);
						sprintf(dos, "%d,%d",x,y);
						LCD_wr_lines(uno,dos);
						_delay_ms(1000); //segundo y medio
					}
					Nint = cuadrito*2;
					sprintf(uno, "Tienes %d", Nint);
					sprintf(dos, "intentos");
					LCD_wr_lines(uno,dos);
					_delay_ms(500); //segundo y medio
					cont++;
					flag = 1; 

				}
				//
			}
			
			
		} // if tecla presionada
		if(flag==1){ //si ya estamos en la parte de los intentos
			cont++;
			for(uint8_t i=1; i<=Nint; i++){
				intentos=i;
				sprintf(uno, "Intento %d", userTry);
				sprintf(dos, "");
				LCD_wr_lines(uno,dos);
				_delay_ms(500); //segundo y medio
				do{
					tecla = pressed(); //X
				}while(tecla >=10);
				
				Ux = tecla;
				sprintf(uno, "Intento %d (%d", userTry,Ux);
				sprintf(dos, "");
				LCD_wr_lines(uno,dos);
				do{
					tecla = pressed(); //Y
				}while(tecla >=10);
				Uy = tecla;
				input[Ux][Uy]++;
				sprintf(uno, "Intento %d (%d, %d)", userTry,Ux,Uy);
				sprintf(dos, "");
				LCD_wr_lines(uno,dos);
				delay(300);
				
				if(Ux >= 2){//no existe
					sprintf(uno, "Intento %d (%d, %d)",userTry, Ux,Uy);
					sprintf(dos, "No existe lugar");
					LCD_wr_lines(uno,dos);
					delay(1000);
					userTry++;
				}
				else if(hidden[Ux][Uy] == 1 && input[Ux][Uy] == 1){ //correcto
					aciertos++;
					sprintf(uno, "Intento %d (%d, %d)",userTry, Ux,Uy);
					sprintf(dos, "Acierto");
					LCD_wr_lines(uno,dos);
					delay(1000);
					userTry++;	
					PORTB = aciertos;
				} 
				else if(((hidden[Ux][Uy] == 1 && input[Ux][Uy] == 0) || (hidden[Ux][Uy] == 0 && input[Ux][Uy] == 1) )){ //incorrecto
					sprintf(uno, "Intento #%d (%d, %d)",userTry, Ux,Uy);
					sprintf(dos, "Error");
					LCD_wr_lines(uno,dos);
					delay(1000);
					userTry++;
				}

				if(aciertos == cuadrito){ //Naciertos = NcoordenadasEscondidas (jugador gana)
					sprintf(uno, "Tienes excelente");
					sprintf(dos, "memoria!!!");
					LCD_wr_lines(uno,dos);
					delay(1000);
					sprintf(uno, "Ganaste!!!");
					sprintf(dos, "Felicidades!");
					LCD_wr_lines(uno,dos);
					delay(1000);
					
					
					//resetea variables
					memset(hidden, 0, sizeof(hidden));
					memset(input, 0,sizeof(input));
					LCD_init();
					//teclado
					DDRT = 0b00001111;					//7->4: entradas,3->0: salidas(rotar tierra)
					PORTT = 0b11111111;
					//display
					DDRB = 0xFF;
					PORTB = 0;
					//pruebas
					DDRD = 0;
					tecla,uno[17], dos[17], cont=0, cuadrito, flag = 0, Nint=0, aciertos=0,Ux,Uy,userTry=1, intentos=1;
					break;
				}else{
					if(i==Nint && aciertos < cuadrito){
						sprintf(uno, "Tu memoria no es");
						sprintf(dos, "tan buena :(");
						LCD_wr_lines(uno,dos);
						delay(1000);
						sprintf(uno, "Perdiste!!!");
						sprintf(dos, "Intenta de nuevo");
						LCD_wr_lines(uno,dos);
						delay(1000);
						
						//resetea variables
						memset(hidden, 0, sizeof(hidden));
						memset(input, 0,sizeof(input));
						LCD_init();
						//teclado
						DDRT = 0b00001111;					//7->4: entradas,3->0: salidas(rotar tierra)
						PORTT = 0b11111111;
						//display
						DDRB = 0xFF;
						PORTB = 0;
						//pruebas
						DDRD = 0;
						tecla,uno[17], dos[17], cont=0, cuadrito, flag = 0, Nint=0, aciertos=0,Ux,Uy,userTry=1, intentos=1;
						break;
					}
				}
				
			}//for
			
		}//if
    }//while
	
}//main


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
	LCD_wr_instruction(LCD_Cmd_OnsCsB); //Enciende el display
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
