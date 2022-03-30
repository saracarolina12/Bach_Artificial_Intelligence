#include<iostream>
using namespace std;
int main(){
 int anio;
 cout<<"Introduce un año: ";
 cin>>anio;
 if(anio%4==0 && anio%100!=0 || anio%400 ==0){
    cout<<"Si es bisiestoooo!!!";
 }
 else{
    cout<<"No es :(";
 }
 }
