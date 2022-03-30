#include<iostream>
#include<fstream>
#include<string.h>
#include<stdlib.h>

using namespace std;

void ver(){
        ifstream ver("");
        ver.open("Numeros_de_telefono.txt",ios::in);
        if(ver.fail()){
            cout<<"No se puede ver el archivo";
            return;
        }
        while(!ver.eof()){
            string datos;
            getline(ver,datos);
            cout<<datos<<endl;
        }
        ver.close();
}

void agregar(){
    ofstream nuevoarchivo("");
    string nombre,apellido,narchivo,telefono;

    nuevoarchivo.open("Numeros_de_telefono.txt",ios::app); //crea el archivo

    if(nuevoarchivo.fail()){ //Si ha ocurrido algun error
		cout<<"No se pudo abrir el archivo";
		exit(1);
	}
    fflush(stdin);
    cout<<"->Digite un nombre: ";
    getline(cin,nombre);
    cout<<"->Digite el apellido: ";
    getline(cin,apellido);
    cout<<"->Digite el numero telefonico: ";
    getline(cin,telefono);
    nuevoarchivo<<nombre<<", "<<apellido<<", "<<telefono<<endl;
    nuevoarchivo.close(); //cierra de nuevo el archivo

}

void crear(){
    ofstream nuevoarchivo("");
    string nombre,apellido,narchivo,telefono;

    nuevoarchivo.open("Numeros_de_telefono.txt",ios::out); //crea el archivo

    if(nuevoarchivo.fail()){ //Si ha ocurrido algun error
		cout<<"No se pudo abrir el archivo";
		exit(1);
	}
    fflush(stdin);
    cout<<"->Digite un nombre: ";
    getline(cin,nombre);
    cout<<"->Digite el apellido: ";
    getline(cin,apellido);
    cout<<"->Digite el numero telefonico: ";
    getline(cin,telefono);
    nuevoarchivo<<nombre<<", "<<apellido<<", "<<telefono<<endl;
    nuevoarchivo.close(); //cierra de nuevo el archivo
}

void menu(){
    int opcion;
    
    do{
        cout<<"Digite alguna de las siguientes opciones: "<<endl;
        cout<<"1.Crear(nombre,apellidos,telefono)\n2.Agregar mas contactos(nombre,apellidos,telefono).\n3.Visualizar contactos existentes.\n4.salir"<<endl;
        cin>>opcion;
        if(opcion==1){
            crear();
        }else if(opcion==2){
            agregar();
        }else if(opcion==3){
            ver();
        }else{
            cout<<"opcion no valida"<<endl;
        }
    }while(opcion!=4);

}

int main(){
    menu();
    return 0;
}
