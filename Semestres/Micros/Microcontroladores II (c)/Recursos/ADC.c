Sin interrupciones
    ADMUX =     0b01000111;
    SFIOR =     0b00000000;
    ADCSRA =    0b10010101; //4 MHz, Fdiv = 32 SIN INTERRUPCIONES
    DDRx =      0b00000000;
    PORTA =     0b00000000; //ADC doesnt need pull up

    for(;;){
        ADCSRA = ADCSRA | (1 << ADSC);
        while(uno_en_bit(&ADSCRA, ADSC)){}
        uint16_t res = ADC;
        //
    }



Con interrupciones
    ADMUX =     0b01000111; //patita
    SFIOR =     0b00000000;
    ADCSRA =    0b10011101; //4 MHz, Fdiv = 32 CON INTERRUPCIONES
    DDRx =      0b00000000;
    PORTA =     0b00000000; //ADC doesnt need pull up

    sei();
    ADCSRA |= (1<<ADSC); //le digo que inicie
    while(1){}



    ISR(ADC_vect){ //entra aquí solito después de la interrupción
        uint16_t rej = ADC;
        //código después 

        ADCSRA|=(1 << ADSC);//inicia una nueva conversión
    }

