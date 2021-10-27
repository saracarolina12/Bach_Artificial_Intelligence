#include <iostream>
#include <string>
#include <string.h>
#include <time.h>
#include <ctime>
using namespace std;
class Articulo{
  private:
    string nombre;
    string descripcion; 
    int mex;
  public:
    float precio;
    Articulo();
    Articulo(string, string , float, bool);
    void setNacionalidad(bool mex);
    bool getNacionalidad();
    ~Articulo();
    float getPrecio();
};
Articulo::Articulo(){
    //constructor vacio
}
//constructor
Articulo::Articulo(string _nombre, string _descripcion, float _precio,bool _mex){
    nombre = _nombre;
    descripcion = _descripcion;
    precio = _precio;
    mex = _mex;
}
void Articulo::setNacionalidad(bool sies){
    mex = sies;
}
bool Articulo:: getNacionalidad(){
    return mex;
}
float Articulo::getPrecio(){
    return precio;
}
Articulo::~Articulo(){ //vacio }
int main(){
    srand(time(0));
    int ran = rand();
    Articulo objetos[30];
    float sumita=0;

    for(int i=0;i<30;i++){
       objetos[i]=Articulo("Collar","Dorado",(rand()%100+1),rand()%2);   
    }
    for(int i=0;i<30;i++){
        if(objetos[i].getNacionalidad()==1){
        sumita+=objetos[i].precio*1.16;
        }
        else
        {
        sumita += objetos[i].precio;
        }
        
        objetos[i].~Articulo();
    }
    cout<<"El precio de con iva es: "<<sumita<<endl;
    return 0;
}
