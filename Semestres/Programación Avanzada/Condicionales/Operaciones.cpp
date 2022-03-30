#include<iostream>
#include <math.h>
using namespace std;
int main(){
    int opcion=0, num=0;
    cout<<"Seleccione alguna de las siguientes opciones:\n 1. Cubo de un numero\n 2. Numero par o impar\n 3. Salir\n\n ";
    cin>>opcion;
    switch(opcion){
        case 1: {
            cout<<" Teclee un numero: ";
            cin>>num;
            cout<<pow(num,3);
            break;
        }
        case 2: {
            cout<<" Teclee un numero: ";
            cin>>num;
            if(num%2==0){
                cout<<"\nEl numero ingresado es par :)";
            }else{
                cout<<"\nEste numero no es par :S";
            }
            break;
        }
        dafault: break;
    }
}
