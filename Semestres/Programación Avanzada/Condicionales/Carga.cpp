#include<iostream>
using namespace std;
int main(){
  float carga,crg;
  cout<<"Ingrese la carga!! ";
  cin>>carga;
  if(carga <= 50){
     crg=carga*0.5;
  }else if(carga<=150){
    crg= carga*.75;
  }else if(carga<=250){
    crg = carga*1.20;
  }else{
    crg = carga*1.50;
  }
  cout<< crg+crg*.20;
}
