#include<bits/stdc++.h>
#include "Diagnostico.h"
using namespace std;
int main(){
    Persona p;
    read.open("input.txt");
    write.open("output.txt");
    read>>p.nombre>>p.apellido>>p.edad>>p.sexo>>p.estatura>>p.peso>>p.glucosa>>p.temperatura>>p.presion>>p.ayuno;
    write<<"EL paciente "<<p.nombre<<" "<<p.apellido<<" tiene el siguiente diagnóstico:\n";
    diagnostico(p.sexo,p.ayuno, p.estatura,p.peso, p.glucosa,p.temperatura, p.presion, p.edad);
    write<<"---------------------------------------------------------------"<<endl;
    if(v.empty()) write<<"\n\t\t***El paciente está sano***"<<endl;
    write.close();
    return 0;
}
