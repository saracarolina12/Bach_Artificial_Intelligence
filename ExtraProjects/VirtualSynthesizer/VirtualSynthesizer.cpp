#include <iostream>
#include "olcNoiseMaker.h" 
#include <windows.h>


#define PI 3.14159265358979323846264338327950288
#define C4 261.63	
#define D4 293.66	
#define E4 329.63
#define F4 349.23
#define G4 392.00	
#define A4 440.00
#define B4 493.88	

atomic<double> freq = 220.0;

using namespace std;

TCHAR GetKey() 
{              
    INPUT_RECORD InputRecord;
    DWORD Writtten;
    HANDLE hStdIn = GetStdHandle(STD_INPUT_HANDLE);
    while (true)
    {
        ReadConsoleInputA(hStdIn, &InputRecord, 1, &Writtten);
        if (InputRecord.EventType == KEY_EVENT && InputRecord.Event.KeyEvent.bKeyDown) break;
    }
    char ASCII = InputRecord.Event.KeyEvent.uChar.AsciiChar;
    if (ASCII) return ASCII;
    return InputRecord.Event.KeyEvent.wVirtualKeyCode;
}

double MakeNoise(double dTime) {
    

    double sinWave = 1.0 * sin(freq * 2 * PI * dTime);

    return 0.3 * sin(freq * 2 * PI * dTime);
}

int main()
{
    
        // Get all sound hardware
        vector<wstring> devices = olcNoiseMaker<short>::Enumerate();
        // Display sound hardware
        for (auto d : devices) {
            wcout<<"New device: "<<d<<endl;
        }
        //Create sound machine
        /*
            Changing the data type received by the olcNoiseMaker will make the amplitude of the sound more accurate.
            * char: 8 bit
            * int: 32 bit
            * short: 16 bits
        */
        olcNoiseMaker<short> sound(devices[0],44100,1,8,512); 

        //Link Noise function with hardware sound
        sound.SetUserFunction(MakeNoise);
    

    while (1) {

       /* char pressedKey = GetKey();
        if (pressedKey == 'A' || pressedKey == 'a') {
            freq = 440.0;
            cout << "A"<<endl;
        }
        else {
            freq = 0.0;
        }*/

    }

    return 0;
}