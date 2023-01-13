#include <iostream>
#include "olcNoiseMaker.h" 
#include <windows.h>
#include <unordered_map>

#define r 1.059463
#define C0 16.3516
#define PI 3.14159265358979323846264338327950288
#define C 32.7032	
#define CS 34.6479
#define D 36.7081
#define DS 38.8909
#define E 41.2035	
#define F 43.6536
#define FS 46.2493	
#define G 48.9995
#define GS 51.9130	
#define A 55.0000
#define AS 58.2705	
#define B 61.7354	

atomic<double> freq = 0.0;

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

double getFreq(int oct, char note) {
    note = toupper(note);
    unordered_map<char, int> mp = { 
                                    {'C', 0},
                                    {'CS', 1},
                                    {'D', 2},
                                    {'DS', 3},
                                    {'E', 4},
                                    {'F', 5},
                                    {'FS', 6},
                                    {'G', 7},
                                    {'GS', 8},
                                    {'A', 9},
                                    {'AS', 10},
                                    {'B', 11},
                                  };
    double f = C0 * pow(r, (12 * oct) + mp[note]);
    cout << "freq: " << f << endl;
    return f;
}

int main()
{
        //// Get all sound hardware
        //vector<wstring> devices = olcNoiseMaker<short>::Enumerate();
        //// Display sound hardware
        //for (auto d : devices) {
        //    wcout<<"New device: "<<d<<endl;
        //}
        ////Create sound machine
        ///*
        //    Changing the data type received by the olcNoiseMaker will make the amplitude of the sound more accurate.
        //    * char: 8 bit
        //    * int: 32 bit
        //    * short: 16 bits
        //*/
        //olcNoiseMaker<short> sound(devices[0],44100,1,8,512); 

        ////Link Noise function with hardware sound
        //sound.SetUserFunction(MakeNoise);
    

    
   int octave = 1;
   while (1) {
        char pressedKey = GetKey();
        cout << (int)pressedKey << endl;
        if ((int)pressedKey == 39 || (int)pressedKey == 37) {
            if ((int)pressedKey == 39) {
                if (octave + 1 <= 8) octave++;
            }
            else if ((int)pressedKey == 37) {
                if (octave - 1 >= 0) octave--;
            }
            cout << " ***** Current Octave: "<< octave <<" *****"  << endl;
        }

        // Natural Notes
        if (pressedKey == 'A' || pressedKey == 'a') { //Do 
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        }
        if (pressedKey == 'S' || pressedKey == 's') { //Re
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        }
        if (pressedKey == 'D' || pressedKey == 'd') { //Mi
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        }
        if (pressedKey == 'F' || pressedKey == 'f') { //Fa
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        }
        if (pressedKey == 'J' || pressedKey == 'j') { //Sol
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        }
        if (pressedKey == 'K' || pressedKey == 'k') { //La
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        }
        if (pressedKey == 'L' || pressedKey == 'l') { //Si
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        }

        // Sharp (#) and flat (b)
        if (pressedKey == 'W' || pressedKey == 'w') { //Do #
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        }
        if (pressedKey == 'E' || pressedKey == 'e') { //Re #
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        }
        if (pressedKey == 'R' || pressedKey == 'R') { //Fa #
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        }
        if (pressedKey == 'U' || pressedKey == 'u') { //Sol #
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        } 
        if (pressedKey == 'I' || pressedKey == 'i') { //La #
            freq = getFreq(octave, pressedKey);
            Beep(freq, 100);
        }

   }
   return 0;
}