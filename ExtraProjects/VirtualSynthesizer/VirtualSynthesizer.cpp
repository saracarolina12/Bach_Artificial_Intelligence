#include <iostream>
#include "olcNoiseMaker.h" 

#define PI   3.14159265358979323846264338327950288
#define C4 261.63	
#define D4 293.66	
#define E4 329.63
#define F4 349.23
#define G4 392.00	
#define A4 440.00
#define B4 493.88	


using namespace std;


double MakeNoise(double dTime) {
    return 0.5 * sin(B4 * 2 * PI * dTime); // 440 hz = A
}

int main()
{
    // Get all sound hardware
    vector<wstring> devices = olcNoiseMaker<short>::Enumerate();
    // Display sound hardware
    for (auto d : devices) {
        wcout<<"New device: "<<d << endl;
    }
    //Create sound machine
    /*
        Changing the data type received by the olcNoiseMaker will make the amplitude of the sound more accurate.
        * char: 8 bit
        * int: 32 bit
        * short: 16 bits
    */
    olcNoiseMaker<short> sound(devices[0], 44100, 1, 8, 512); 

    //Link Noise function with hardware sound
    sound.SetUserFunction(MakeNoise);

    while (1) {

    }

    return 0;
}