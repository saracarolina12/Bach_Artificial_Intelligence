#include <iostream>
#include <fstream>
#include <sstream>
#include <queue>
#include <vector>
#include <string>
#include <map>
using namespace std;

queue<pair<string, string> > tokenList;
map<string, string> variables;
map<string,int> enteros;
map<string,string> cadenas;
map<string,float> flotantes;
map<string,bool> booleanos;

bool isExpressionToken(string s);
class Expresion{
public:
    queue<pair<string, string> > lista;
    Expresion(){
        //lista.clear();
        while(!lista.empty()) lista.pop();
        while(!tokenList.empty() && isExpressionToken(tokenList.front().first)){
            lista.push(tokenList.front());
            tokenList.pop();
        }
        if(lista.empty()){
            cout<<"Error de sintaxis - Expresion vacia\n";
            exit(0);
        }
    }
    void evaluar(){
    }
    void imprimir(){
        cout<<"Expresion: ";
        while(!lista.empty()){
            cout<<lista.front().second<<" ";
            lista.pop();
        }
        cout<<"\n";
    }
};

class Instruccion{
public:
    virtual void ejecutar(){cout<<"Ejecucion de clase padre\n";}
    virtual void imprimir(){cout<<"Impresion de clase padre\n";}
};
Instruccion* createInstruction();

class Declarar: public Instruccion{
public:
    string nombre;
    string tipo;
    Declarar(){
        if(tokenList.empty()){
            cout<<"Error de sintaxis -  falta de tokens en declaracion\n";
            exit(0);
        }
        if(tokenList.front().first!="204"){
            cout<<"Error de sintaxis -  tipo no valido en declaracion\n";
            exit(0);
        }
        tipo = tokenList.front().second;
        tokenList.pop();
        if(tokenList.empty()){
            cout<<"Error de sintaxis -  falta de tokens en declaracion\n";
            exit(0);
        }
        if(tokenList.front().first!="400"){
            cout<<"Error de sintaxis - variable en declaracion no valida\n";
            exit(0);
        }
        nombre = tokenList.front().second;
        tokenList.pop();
    }
    virtual void ejecutar(){
        if(variables.find(nombre)!=variables.end()){
            cout<<"Error - Variable ya existente\n";
            exit(0);
        }
        variables[nombre] = tipo;
        if(tipo=="entero"){
            enteros[nombre]=0;
        }
        else if(tipo=="cadena"){
            cadenas[nombre]="";
        }
        else if(tipo=="flotante"){
            flotantes[nombre]=0.0;
        }
        else if(tipo=="boleano"){
            booleanos[nombre]=false;
        }
    }
    virtual void imprimir(){
        cout<<"Declarar: "<<nombre<<" tipo "<<tipo<<"\n";
    }
};

class Asignar: public Instruccion{
public:
    string nombre;
    Expresion* expresion;
    Asignar(){
        if(tokenList.empty()){
            cout<<"Error de sintaxis -  falta de tokens en asignacion\n";
            exit(0);
        }
        if(tokenList.front().first!="400"){
            cout<<"Error de sintaxis - variable en asignacion no valida\n";
            exit(0);
        }
        nombre=tokenList.front().second;
        tokenList.pop();
        if(tokenList.empty()){
            cout<<"Error de sintaxis -  falta de tokens en asignacion\n";
            exit(0);
        }
        if(tokenList.front().first!="305"){
            cout<<"Error de sintaxis - formato de asignacion incorrecto, falta =\n";
            exit(0);
        }
        tokenList.pop();
        expresion = new Expresion();
    }
    virtual void ejecutar(){
    }
    virtual void imprimir(){
        cout<<"Asignar: "<<nombre<<" la ";
        (*expresion).imprimir();
    }
};

class Imprimir: public Instruccion{
public:
    Expresion* expresion;
    Imprimir(){
        expresion = new Expresion();
    }
    virtual void ejecutar(){
    }
    virtual void imprimir(){
        cout<<"Imprimir la ";
        (*expresion).imprimir();
    }
};

class Recibir: public Instruccion{
public:
    string nombre;
    Recibir(){
        if(tokenList.empty()){
            cout<<"Error de sintaxis -  falta de tokens\n";
            exit(0);
        }
        if(tokenList.front().first!="400"){
            cout<<"Error de sintaxis - No se esta recibiendo en una variable\n";
            exit(0);
        }
        nombre = tokenList.front().second;
        tokenList.pop();
    }
    virtual void ejecutar(){
    }
    virtual void imprimir(){
        cout<<"Recibir: "<<nombre<<"\n";
    }
};

class CondicionIf: public Instruccion{
public:
    Expresion* expresion;
    queue<Instruccion*> listaVerdadero;
    queue<Instruccion*> listaFalso;
    CondicionIf(){
        expresion = new Expresion();
        if(tokenList.empty() || tokenList.front().second!="{"){
            cout<<"Error de sintaxis - Falta llave en if\n";
            exit(0);
        }
        tokenList.pop();
        while(!tokenList.empty() && tokenList.front().second!="}"){
            listaVerdadero.push(createInstruction());
        }
        if(tokenList.empty() || tokenList.front().second!="}"){
            cout<<"Error de sintaxis - Falta llave para cerrar en if\n";
            exit(0);
        }
        tokenList.pop();
        if(!tokenList.empty() && tokenList.front().second=="Else"){
            tokenList.pop();
            if(tokenList.empty()||tokenList.front().second!="{"){
                cout<<"Error de sintaxis - Falta llave en else\n";
                exit(0);
            }
            tokenList.pop();
            while(!tokenList.empty() && tokenList.front().second!="}"){
                listaFalso.push(createInstruction());
            }
            if(tokenList.empty() || tokenList.front().second!="}"){
                cout<<"Error de sintaxis - Falta llave para cerrar en else\n";
                exit(0);
            }
            tokenList.pop();
        }
    }
    virtual void ejecutar(){
    }
    virtual void imprimir(){
        cout<<"CondicionIf si: ";
        (*expresion).imprimir();
        cout<<"En caso verdadero\n";
        while(!listaVerdadero.empty()){
            cout<<"   ";
            (*listaVerdadero.front()).imprimir();
            listaVerdadero.pop();
        }
        cout<<"Fin de caso verdadero\n";
        if(!listaFalso.empty()){
            cout<<"En caso falso\n";
            while(!listaFalso.empty()){
                cout<<"   ";
                (*(listaFalso.front())).imprimir();
                listaFalso.pop();
            }
            cout<<"Fin de caso falso\n";
        }
    }
};

class CicloFor: public Instruccion{
public:
    string nombre;
    int valorInicial;
    int valorFinal;
    int incremento;
    queue<Instruccion*> lista;
    CicloFor(){
        if(tokenList.empty() || tokenList.front().first!="400"){
            cout<<"Error de sintaxis - variable en For\n";
            exit(0);
        }
        nombre = tokenList.front().second;
        tokenList.pop();
        if(tokenList.empty() || tokenList.front().first!="200"){
            cout<<"Error de sintaxis - valor en For\n";
            exit(0);
        }
        valorInicial = stoi(tokenList.front().second);
        tokenList.pop();
        if(tokenList.empty() || tokenList.front().first!="200"){
            cout<<"Error de sintaxis - valor en For\n";
            exit(0);
        }
        valorFinal = stoi(tokenList.front().second);
        tokenList.pop();
        if(tokenList.empty() || tokenList.front().first!="200"){
            cout<<"Error de sintaxis - valor en For\n";
            exit(0);
        }
        incremento = stoi(tokenList.front().second);
        tokenList.pop();
        if(tokenList.empty() || tokenList.front().second!="{"){
            cout<<"Error de sintaxis - Falta llave en For\n";
            exit(0);
        }
        tokenList.pop();
        while(!tokenList.empty() && tokenList.front().second!="}"){
            lista.push(createInstruction());
        }
        if(tokenList.empty() || tokenList.front().second!="}"){
            cout<<"Error de sintaxis - Falta llave para cerrar en For\n";
            exit(0);
        }
        tokenList.pop();
    }
    virtual void ejecutar(){
    }
    virtual void imprimir(){
        cout<<"CicloFor con variable "<<nombre<<" inicia en "<<valorInicial<<" termina en "<<valorFinal<<" con incremento de "<<incremento<<" e instrucciones:\n";
        while(!lista.empty()){
            cout<<"   ";
            (*lista.front()).imprimir();
            lista.pop();
        }
        cout<<"Fin de For de variable "<<nombre<<"\n";
    }
};

class CicloWhile: public Instruccion{
public:
    Expresion* expresion;
    queue<Instruccion*> lista;
    CicloWhile(){
        expresion = new Expresion();
        if(tokenList.empty() || tokenList.front().second!="{"){
            cout<<"Error de sintaxis - Falta llave en If\n";
            exit(0);
        }
        tokenList.pop();
        while(!tokenList.empty() && tokenList.front().second!="}"){
            lista.push(createInstruction());
        }
        if(tokenList.empty() || tokenList.front().second!="}"){
            cout<<"Error de sintaxis - Falta llave para cerrar en If\n";
            exit(0);
        }
        tokenList.pop();
    }
    virtual void ejecutar(){
    }
    virtual void imprimir(){
        cout<<"CicloWhile si: ";
        (*expresion).imprimir();
        cout<<"Con instrucciones:\n";
        while(!lista.empty()){
            cout<<"   ";
            (*lista.front()).imprimir();
            lista.pop();
        }
        cout<<"Fin de while\n";
    }
};

bool isInt(string s){
    for(int i=0; i<(int)s.size();i++){
        if(i==0 && s[i]=='-') continue;
        if(!isdigit(s[i])) return false;
    }
    return true;
}
bool isFloat(string s){
    bool punto = false;
    for(int i=0; i<(int)s.size();i++){
        if(i==0 && s[i]=='-') continue;
        if(!isdigit(s[i])){
            if(s[i]=='.'){
                if(punto) return false;
                else punto=true;
            }
            else{
                return false;
            }
        }
    }
    return true;
}
bool isVariable(string s){
    for(int i=0; i<(int)s.size(); i++){
        if(!isalnum(s[i])){
            return false;
        }
    }
    return true;
}
string tokenize(string s){
    int si = s.size();
    if(s[0]=='"' && s[si-1]=='"') return "203";
    if(isInt(s)) return "200";
    if(isFloat(s)) return "201";
    if(s=="True") return "202";
    if(s=="False") return "202";
    if(s=="Define") return "101";
    if(s=="Recibe") return "102";
    if(s=="Imprime") return "103";
    if(s=="If") return "104";
    if(s=="Else") return "105";
    if(s=="While") return "106";
    if(s=="For") return "107";
    if(s=="Asigna") return "108";
    if(s=="entero") return "204";
    if(s=="cadena") return "204";
    if(s=="flotante") return "204";
    if(s=="booleano") return "204";
    if(s=="+") return "300";
    if(s=="-") return "300";
    if(s=="*") return "300";
    if(s=="/") return "300";
    if(s=="<") return "301";
    if(s==">") return "301";
    if(s=="<=") return "301";
    if(s==">=") return "301";
    if(s=="==") return "301";
    if(s=="!=") return "301";
    if(s=="&&") return "302";
    if(s=="||") return "302";
    if(s=="!") return "302";
    if(s=="{") return "303";
    if(s=="}") return "303";
    if(s=="(") return "304";
    if(s==")") return "304";
    if(s=="=") return "305";
    if(isVariable(s)) return "400";
    return "99";
}

bool isInstructionToken(string s){
    if(s[0]=='1') return true;
    return false;
}

bool isExpressionToken(string s){
    if(s=="200") return true;
    if(s=="201") return true;
    if(s=="202") return true;
    if(s=="203") return true;
    if(s=="300") return true;
    if(s=="301") return true;
    if(s=="302") return true;
    if(s=="304") return true;
    if(s=="400") return true;
    return false;
}

Instruccion* createInstruction(){
    if(tokenList.empty()){
        cout<<"Error de sintaxis - Faltan tokens para crear instruccion\n";
        exit(0);
    }
    string ins = tokenList.front().first;
    tokenList.pop();
    if(ins=="101") return new Declarar();
    else if(ins=="102") return new Recibir();
    else if(ins=="103") return new Imprimir();
    else if(ins=="104") return new CondicionIf();
    else if(ins=="106") return new CicloWhile();
    else if(ins=="107") return new CicloFor();
    else if(ins=="108") return new Asignar();
    else if(ins=="105"){
        cout<<"Error de sintaxis - Else sin If\n";
        exit(0);
    }
    else{
        cout<<"Error de sintaxis - creacion de instruccion erronea\n";
        exit(0);
    }
    return nullptr;
}

int main()
{
    queue<Instruccion*> instructionList;
    ifstream in;
    ofstream out;
    in.open("in.txt", ifstream::in);
    out.open("out.txt", ofstream::out | ofstream::trunc);
    string is,s,t,temp, lastToken;
    while(!tokenList.empty())tokenList.pop();
    while(getline(in, is)){
        stringstream ss(is);
        while(ss>>is){
            if(is[0]=='"' && is[is.size()-1]!='"'){
                while( is[is.size()-1]!='"' &&  ss>>temp){
                    is+=' ';
                    is+=temp;
                }
                if(is[is.size()-1]!='"'){
                    cout<<"ERROR - Comillas sin cerrar\n";
                    in.close();
                    out.close();
                    return 0;
                }
            }
            t=tokenize(is);
            if(t=="99"){
                cout<<"ERROR - Token invalido\n";
                in.close();
                out.close();
                return 0;
            }
            tokenList.push(make_pair(t, is));
            out<<t<<" ";
        }
        out<<"\n";
    }
    in.close();
    out.close();/*
    while(!tokenList.empty()){
        cout<<tokenList.front().first<<" : "<<tokenList.front().second<<"\n";
        tokenList.pop();
    }*/

    while(!tokenList.empty() && isInstructionToken(tokenList.front().first)){
        instructionList.push(createInstruction());
    }
    if(!tokenList.empty()){
        cout<<"Error de sintaxis - token invalido de nueva instruccion\n";
        return 0;
    }
    while(!instructionList.empty()){
        //(*instructionList.front()).imprimir();
        (*instructionList.front()).ejecutar();
        instructionList.pop();
    }
    return 0;
}
