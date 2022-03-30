/*
~Determina el polinomio característico~
  INPUT:
    -Grado
    -Numero de datos
    -Si conocemos la funcion o no
      SI: 
        *funcion
      NO:
	*Valor a aproximar
*/
#include<bits/stdc++.h>
using namespace std;
double f(double x){
     return log(x);
}
int main(){
	int n, cant;
	cout<<"Ingrese el grado: "; cin>>n;
	n+=1;
	cout<<"Ingrese el numero de datos: "; cin>>cant;
	double x[cant], fx[cant];
	for(int i=0; i<cant; i++){
		cout<<"\t-x["<<i<<"]: ";
		cin>>x[i];
	}
	cout<<'\n';
	char yei;
	cout<<"Conocemos la funcion?[y/n] "; cin>>yei;
	cout<<"\tcalculando ...\n\n";
	if(yei=='y'){
		int size_r = sizeof(x)/sizeof(x[0]); 
		for(int i=0; i<size_r ;i++){
			fx[i] = f(x[i]);
			cout<<endl<<fx[i]<<" ";
		}
	}else{
		for(int i=0; i<cant; i++){
		cout<<"\t-f(x"<<i<<"): ";
			cin>>fx[i];
		}
	}
	char siono;
	cout<<"Conocemos x? [y/n] "; cin>>siono;
	if(siono == 'y'){
		double valor;
		string s;
		cout<<"\tIngrese el valor a aproximar: "; cin>>valor;
		double z, w, sum=0.0, u=1, d=1;
		for(int i=0; i<n; i++){
			string p = to_string(double(fx[i]));
			for(int j=0; j<n; j++){
				if(j!=i){
					p += "*(x - " + to_string(double(x[j])) + ")/(" + to_string(double(x[i])) + " - " + to_string(double(x[j])) + ")";
					u=u*(valor-x[j]);
					d=d*(x[i]-x[j]);
				}
			}
			if(i) s += " + " + p;
			else s += "" + p;
			sum += (fx[i]*(u/d));
			u=d=1;
		}
		cout<<"*Polinomio:\n";
		cout<<s<<endl;
		cout<<"\nInterpolacion por Lagrange: ";
		cout<<sum<<'\n';
	}else if(siono == 'n'){
		double valor;
		string s;
		cout<<"\nInterpolacion por Lagrange:\n";
		double sum=0.0, u=1, d=1;
		for(int i=0; i<n; i++){
			string p = to_string(fx[i]);
			for(int j=0; j<n; j++){
				if(j!=i)
					p += "*(x - " + to_string(int(x[j])) + ")/(" + to_string(int(x[i])) + " - " + to_string(int(x[j])) + ")";
			}
			if(i) s += " + " + p;
			else s += "" + p;
		}
		cout<<s<<'\n';

	}else{
		cout<<"Lo siento, esta letra no es valida"<<'\n';
	}
	return 0;
}
