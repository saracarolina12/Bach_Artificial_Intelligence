/*
~~
  INPUT:
    -Función
    -Derivada
    -Valor inicial p0
    -Error
    -#iteraciones
*/
#include<bits/stdc++.h>
using namespace std;

//ingresar función
double f(double x){
    double res = (x*x) - 6;
    return res;
}

//ingresar derivada de la función original
double fd(double x){
    double derivative = 2*x;
    return derivative;
}

int main(){
	double pi, p, error, cmp;
	char si;
	int ite;
	cout<<"Ingrese el valor inicial pi: "; cin>>pi;
	cout<<"Hay error? s/n "; cin>>si;
    if(si=='s'){
        cout<<"Ingrese el error: "; cin>>error;
    }
	cout<<"Ingrese el numero de iteraciones: "; cin>>ite;
	
	for(int i=0; i<ite; i++){
		p = pi - (f(pi)/fd(pi));
         cout<<"\t*error: "<<abs(1-(p/pi))*100<<endl;
		if(si=='s'){
            if( abs(1-(p/pi))*100 < error){
                cout<<"\t******La aproximacion de raiz es: "<<p<<"******"<<endl;
                return 0;
		    }
        }else{ cout<<"\t*Aproximacion '"<<i+1<<"' : "<<p<<endl;}
		pi = p;	
	}
	return 0;
}
