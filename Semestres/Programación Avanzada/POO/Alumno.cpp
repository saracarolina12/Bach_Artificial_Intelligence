#include<iostream>
#include<string>
#include<string.h>
using namespace std;
class Alumno{
    private:       //atributos
      string nombre;
      int par1;
      int par2;
      int par3;
      int final;
      
    public:     //metodos
     Alumno();   //constructor por defecto 
     Alumno(string,int,int,int);      //ponemos los prototipos
     void calcular_promedio();       //prototipos de la funci贸n 
};
//constructor
Alumno::Alumno(string _nombre,int _par1, int _par2, int _par3){
    nombre=_nombre;
    par1=_par1;
    par2=_par2;
    par3=_par3;
}
Alumno::Alumno(){   
  //constructor extra (sirve para que los arreglos de tipo "Alumno" funcionen)
}
//función alumno
void Alumno::calcular_promedio(){   //funci贸n para calcular el promedio
    final=(par1+par2+par3)/3;
    cout<< "Calificacion Final de " <<nombre<< " es: " << final<<endl;
}
int main(){
    Alumno personitas[10];  //areglo de objetos tipo alumno
    string names[10]={"Sara","Vanessa","Gustavo","Marco","Lalo","Jaime","Pedrito","Ale","Yessy","Alo"};
    int p1[10]={10,9,7,10,5,7,4,10,10,8};   //parcial 1
    int p2[10]={10,6,10,10,10,10,6,5,9,10}; //parcial 2
    int p3[10]={9,7,7,8,9,8,8,10,10,10};  //parcial 3

    for(int i=0;i<10;i++){
     personitas[i]=Alumno(names[i],p1[i],p2[i],p3[i]);   //le da valor a nombre, y parciales [usando los arreglos de arriba]
    }

   for(int i=0;i<10;i++){
    personitas[i].calcular_promedio();    //llama la función calcular_promedio
   }
return 0;    
}
