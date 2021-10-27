#include <iostream>
#include <string.h>
#include <string>
#include <time.h>
using namespace std;
class Rectangulo{
    private:  //atributos
      float largo;
      float ancho;
    
    public:   //metodos
      Rectangulo();
      Rectangulo(float,float);
      void perimetro();
      void area();
};
Rectangulo::Rectangulo(float _largo, float _ancho){
    largo = _largo;
    ancho = _ancho;
}
Rectangulo::Rectangulo(){}
void Rectangulo::perimetro(){
    float peri = (largo*2)+(ancho*2);
    cout<<"Perimetro es: "<<peri<<endl;
}
void Rectangulo::area(){
    float a = largo*ancho;
    cout<<"Area es:      "<<a<<endl;
}
int main(){
    srand(time(NULL));
    Rectangulo rect[10];
    //propiedades aleatorias
    float l[10]; // = {9.0,7.0,8.5,5.0,6.0,8.0,10.0,5.0,10.0,4.4};
    float a[10]; //= {9.0,7.0,8.5,5.0,6.0,8.0,10.0,5.0,10.0,4.4};
    for(int i=0;i<10;i++){
        l[i] = rand()%100+1;
     }
    for(int i=0;i<10;i++){
        a[i] = rand()%100+1;
     }
    for(int i=0;i<10;i++){
        rect[i]=Rectangulo(l[i],a[i]);
    }
    for(int i=0;i<10;i++){
        rect[i].area();
        rect[i].perimetro();
    }
    return 0;
}
