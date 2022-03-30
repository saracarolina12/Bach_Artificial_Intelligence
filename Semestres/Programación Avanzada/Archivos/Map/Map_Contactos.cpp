#include<iostream>
#include<fstream>
#include<string.h>
#include<stdlib.h>
#include<map>

using namespace std;
class Persona{
    private:
       string nombre;
    //  string apellido;
       string telefono;
    public:
       Persona():nombre(""),telefono(""){/**/}
       Persona(string nombre, string telefono):nombre(nombre),telefono(telefono){/**/}
       ~Persona(){/**/}
        void show() const{
            cout<<nombre<<": "<<telefono<<flush;
        }
        string getname() const{
            return nombre;
        }
        string gettel() const{
            return telefono;
        }
       
};

void ver(){
        ifstream ver("");
        map<int,string> contacto;
        ver.open("Contactos_map.txt",ios::in);
        if(ver.fail()){
            cout<<"No se puede ver el archivo";
            return;
        }
        int m=1;
        while(!ver.eof()){
            string datos;
            getline(ver,datos);
           // cout<<datos<<endl;
           contacto.insert(make_pair(m,datos));
            m++;
        }
       // ver.close();
        for(map<int,string>::iterator it=contacto.begin();it!=contacto.end();it++){
            cout<<it->second<<endl;
        }
}

void agregar(){
    ofstream nuevoarchivo("");
    map<string, Persona> add;
    string nombre,apellido,telefono;

    nuevoarchivo.open("Contactos_map.txt",ios::app); //crea el archivo

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

    add[nombre]=Persona(apellido,telefono);
    for(map<string, Persona>::iterator it = add.begin(); it != add.end();it++){
        nuevoarchivo<<"*"<<it->first<<" "<<it->second.getname()<<": "<<it->second.gettel()<<endl;
    }
    //nuevoarchivo<<nombre<<", "<<apellido<<", "<<telefono<<endl;
    nuevoarchivo.close(); //cierra de nuevo el archivo   
}

void crear(){
    ofstream nuevoarchivo("");
    map<string,Persona> people;
    string nombre,apellido,telefono;

    nuevoarchivo.open("Contactos_map.txt",ios::out); //crea el archivo

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
    cout<<"\n";
    people[nombre]= Persona(apellido, telefono);
    for(map<string,Persona>::iterator it = people.begin();it!=people.end();it++){
        nuevoarchivo<<"*"<<it->first<<" "<<it->second.getname()<<": "<<it->second.gettel()<<endl;
    }
   // nuevoarchivo<<nombre<<", "<<apellido<<", "<<telefono<<endl;
    nuevoarchivo.close(); //cierra de nuevo el archivo
}

void menu(){
    int opcion;
    do{
        cout<<"\n\tDigite alguna de las siguientes opciones: "<<endl;
        cout<<"\t1.Crear(nombre,apellidos,telefono)\n\t2.Agregar mas contactos(nombre,apellidos,telefono).\n\t3.Visualizar contactos existentes.\n\t4.salir"<<endl;
        cin>>opcion;
        cout<<"\n";
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
