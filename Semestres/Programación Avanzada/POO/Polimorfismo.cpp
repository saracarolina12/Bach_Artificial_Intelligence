//Poliformismo en comer()
#include <iostream>
using namespace std;
class Animal{
    private:
      int edad;
    public: 
      Animal();
      Animal(int);
      virtual void comer();
};
class Humano: public Animal{
    private: 
      string nombre;
    public:
      Humano();
      Humano(int, string);
      void comer();
};

class Perro: public Animal{
    private:
      string nombre, raza;
    public:
      Perro();
      Perro(int, string, string);
      void comer();
};
Animal::Animal(){}
Animal::Animal(int _edad){
    edad = _edad;
}
void Animal::comer(){
//Se convierte en clase abstracta
} 
Humano::Humano(){}
Humano::Humano(int _edad, string _nombre): Animal(_edad){
    nombre = _nombre;
}
void Humano::comer(){
    cout << "Yo como en restaurante" << endl;
}
Perro::Perro(){ }
Perro::Perro(int _edad, string _nombre, string _raza): Animal(_edad){
    nombre = _nombre;
    raza = _raza;
}
void Perro::comer(){
    cout << "Yo como en el piso" << endl;
}
int main(){
    Animal *animales[2];
    animales[0] = new Humano(21, "Jorge");
    animales[1] = new Perro(4, "Fido", "Pastor Aleman");
    animales[0] -> comer(); //-> Lo miemo que punto
    animales[1] -> comer();
    return 0;
}
