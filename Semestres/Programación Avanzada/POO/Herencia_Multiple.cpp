#include<iostream>
#include<string>
using namespace std;
class Persona{
    private:
        string nombre;
        int edad;
    public:
        Persona();
        Persona(string, int);
        void mostrarPersona();
};
class Alumno : public Persona{
    private:
       string Id;
       float notaFinal;
    public:
        Alumno();
        Alumno(string,int,string,float);
        void mostrarAlumno();
};
class AlumnoUP : public Alumno{
    private:
        string carrera;
    public:
        AlumnoUP();
        AlumnoUP(string _carrera,string,int,string,float);
        void mostrarAlumnoUP();
};
Alumno::Alumno(){}
Persona::Persona(){}
AlumnoUP::AlumnoUP(){}
AlumnoUP::AlumnoUP(string _carrera,string _nombre,int _edad,string _Id,float _notaFinal) : Alumno(_nombre,_edad,_Id,_notaFinal){
    carrera = _carrera;
}
Alumno::Alumno(string _nombre,int _edad,string _Id,float _notaFinal) : Persona(_nombre,_edad){
    Id= _Id;
    notaFinal = _notaFinal;
}
Persona::Persona(string _nombre, int _edad){
    nombre = _nombre;
    edad = _edad;
}
void Persona::mostrarPersona(){
    cout<<"Nombre: "<<nombre<<endl;
    cout<<"Edad: "<<edad<<endl;
}
void Alumno::mostrarAlumno(){
    mostrarPersona();
    cout<<"Codigo Alumno: "<<Id<<endl;
    cout<<"Nota Final: "<<notaFinal<<endl;
}
void AlumnoUP::mostrarAlumnoUP(){
    mostrarPersona();
    mostrarAlumno();
    cout<<"Carrera: "<<carrera<<endl;
}
int main(){
    AlumnoUP al1("IBE","Carlos",19,"012230",98.0);
    
    al1.mostrarAlumnoUP();

    Alumno a[10];

    return 0;
}
