import serial
with serial.Serial() as computer:
    computer.baudrate = 4800 
    computer.port = 'COM1' 
    computer.stopbits = 2 
    computer.bytesize = 8 
    computer.parity = 'N' 
    
    computer.open() 
    while(1):
        dato = computer.read() #lee el dato
        print(int.from_bytes(dato , byteorder='little') * 5/255) #lo imprime