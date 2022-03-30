//includes
#define F_CPU 1000000 //Sets frequency for delays
#include <avr/io.h> //C functions
#include <stdint.h> //fixed size integers (uint8, etc.)
#include <util/delay.h> //delays
#include <avr/interrupt.h>
#include <stdlib.h> //LCD

// [0 -> 99] units in the most significant nibble IMPRIMIR
#define print(n) (((n % 10) << 4) | (n / 10))

//¿Bit set or clear?
#define isClear(r, i) (!(r & (1 << i)))
#define isSet(r, i) (r & (1 << i))

//RTR
void RTR(uint8_t pin); //prototype
void RTR(uint8_t pin){ //function
    //Al presionar
    _delay_ms(50);
    while(isClear(PINx, bit));
    _delay_ms(50);
    //Al soltar
}

//if button pressed BOTON con RTR
if(isClear(PINx, y)){
    //Al presionar
    _delay_ms(50);
    while(isClear(PINx, y));
    _delay_ms(50);
    //Al soltar
}

//swap and reverse bytes
#define swapB(r) ((r & 0xAA) >> 1 | (r & 0x55) << 1) //aux
#define swapP(r) ((r & 0xCC) >> 2 | (r & 0x33) << 2) //aux
#define swap(r) (r << 4 | r >> 4)                    //swap nibbles
#define reverse(r) swap(swapP(swapB(r)))             //reverses a variable (mirror effect)
    //ejemplo:
        DDRD = 0xFF;
		uint8_t hola = 0b00000001;
		PORTD = reverse(hola);

//Display 7 segmentos CÁTODO comun pines 0-6
#define cCERO 	    0b00111111
#define cUNO 	    0b00000110
#define cDOS 	    0b01011011
#define cTRES   	0b01001111
#define cCUATRO	    0b01100110
#define cCINCO	    0b01101101
#define cSEIS	    0b01111101
#define cSIETE	    0b01000111
#define cOCHO	    0b01111111
#define cNUEVE	    0b01101111

//Display 7 segmentos ÁNODO comun pines 0-6
#define aCERO	    0b11000000
#define aUNO	    0b11111001
#define aDOS	    0b10100100
#define aRES	    0b10110000
#define aCUATRO	    0b10011001
#define aCINCO	    0b10010010
#define aSEIS	    0b10000010
#define aSIETE	    0b11111000
#define aOCHO	    0b10000000
#define aNUEVE	    0b10010000

/************************************************************************/

//Teclado matricial 4X4
    #define PINT PINA	
    #define PORTT PORTA 
    #define DDRT DDRA 
    #define isClear(r, i) (!(r & (1 << i)))
    #define isSet(r, i) (r & (1 << i))
    //includes
    #define F_CPU 1000000 //Sets frequency for delays
    #include <avr/io.h> //C functions
    #include <stdint.h> //fixed size integers (uint8, etc.)
    #include <util/delay.h> //delays
    #include <avr/interrupt.h>
    #include <stdlib.h> //LCD

    // uint8_t keyboard[4][4] = 
    // {
    // 	{0x7, 0x8, 0x9, 0xA},
    // 	{0x4, 0x5, 0x6, 0xB},
    // 	{0x1, 0x2, 0x3, 0xC},
    // 	{0xE, 0x0, 0xF, 0xD}
    // };
    uint8_t keyboard[4][4] =
    {
        {0x1, 0x2, 0x3, 0xA},
        {0x4, 0x5, 0x6, 0xB},
        {0x7, 0x8, 0x9, 0xC},
        {0xE, 0x0, 0xF, 0xD}
    };

    uint8_t Tpressed(){
        for(uint8_t i = 0;; i++, i %= 4){
            PORTT = ~(1 << i);
            asm("nop");
            asm("nop");
            for(uint8_t j = 4; j < 8; j++){
                if(isClear(PINT, j)){
                    _delay_ms(50);
                    while(isClear(PINT, j));
                    _delay_ms(50);
                    return keyboard[7 - j][3 - i];
                }
            }
        }
    }
    int main(void)
    {
        //teclado
        DDRT = 0b00001111;					//7->4: entradas,3->0: salidas
        PORTT = 0b11111111;
        uint8_t tecla;
        while(1){
            tecla = Tpressed();
            //código usando mi tecla
        }
        
    }
    /*------------------------------°°°°°°°°°°°°°°-----------------------------------*/
    //opción 2
        //defines
        #define PINT PINA	
        #define PORTT PORTA 
        #define DDRT DDRA 
        #define F_CPU 1000000
        #define isClear(r, i) (!(r & (1 << i)))
        #define isSet(r, i) (r & (1 << i))

        //includes
        #include <avr/io.h>
        #include <util/delay.h>
        #include <stdio.h>

        x = [altura][derecha]
uint8_t keyb[4][4] =
{
	{0x7, 0x8, 0x9, 0xa},
	{0x4, 0x5, 0x6, 0xb},
	{0x1, 0x2, 0x3, 0xc},
	{0xe, 0x0, 0xf, 0xd}
};
        
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
                PORTT = ~(1<<0);				//1111_1110 rota tierra en 0,1,2,3
                asm("nop");
                asm("nop");
                //0
                //DCBA
                if(isClear(PINT,4)){		//+,D //isClear(PinNOTIERRA, )
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
                
                //1
                //3,6,9,#(F)
                if(isClear(PINT,4)){		//A
                    RTR(4);
                    return(keyb[3][2]);										//RESETEAR
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
                
                //2
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
                
                //3
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
            //teclado
            DDRT = 0b00001111;					//7->4: entradas,3->0: salidas(rotar tierra)
            PORTT = 0b11111111;
            
            
            DDRD = 0;
            uint8_t tecla;
            while (1){
                tecla = pressed();
                PORTD = tecla;
                //código con mi tecla
            }
        }

/************************************************************************/

//Servo
    /*
        OCRO = 5  (0°)
        OCR0 = 38 (180°)
    */
void showservo(uint8_t tec){ 
	PORTD = tec;
	if(tec == 0) OCR0 = 5;
	else if(tec == 1) OCR0 = 9;
	else if(tec == 2) OCR0 = 13;
	else if(tec == 3) OCR0 = 17;
	else if(tec == 4) OCR0 = 21;
	else if(tec == 5) OCR0 = 25;
	else if(tec == 6) OCR0 = 28;
	else if(tec == 7) OCR0 = 32;
	else if(tec == 8) OCR0 = 36;
	else if(tec == 9) OCR0 = 38;
}

/************************************************************************/
//LCD
#define F_CPU 1000000
#include <avr/io.h>
#include <util/delay.h>
#include <stdint.h>
#include <stdlib.h>
#include <avr/interrupt.h>

#define isClear(r, i) (!isSet(r, i))
#define isSet(r, i) (r & (1 << i))
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

int main(void)
{
	LCD_init();
	
	while(1){

    }
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



//EXTRAS
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

//sprintf usage
char arr[30];
uint8_t x = 3;
sprintf(arr, 'Tengo %d examenes hoy', x)

//Random
#include <cstdlib>
srand(); //Before generating randoms so we don't have the same sequence of rand nums
rdno = rand() % (b-a) + a; //Random within a limit [a;b)

/*EXAMPLE:
    srand(); //seed
	x = rand() % col; //Random within a limit [0:10)
	y = rand() % fil; //Random within a limit [0:2]
*/


//Matrix
    mat[3][3];


             0            1           2
             col          col         col          
   0 fil     [0][0]      [0][1]     [0][2]       

   1 fil     [1][0]      [1][1]     [1][2]
    
   2 fil     [2][0]      [2][1]     [2][2]