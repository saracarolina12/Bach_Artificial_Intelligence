/*
~~
  INPUT:
    -funcion
    -Iteraciones
    -2 Valores iniciales (p0,p1)
    -Error
*/
#include<bits/stdc++.h>
using namespace std;
//ingresar función
double f(double x){
    double e = 2.71828;
    return (x*x) + (x*x*x*x);
}
int main(){
	double p0, p1, res, q0, q1, error;
	int ite=0;
	cout<<"-Digite el numero de iteraciones: "; cin>>ite;
	cout<<"-Digite p0: "; cin>>p0;
	cout<<"-Digite p1: "; cin>>p1;
	cout<<"-Digite el error: "; cin>>error;

	for(int i=0; i<ite; i++){
		cout<<"\t*Iteracion #"<<i+1<<endl;
		q0 = f(p0);
		q1 = f(p1);
		res = p1 - (q1*(p0 - p1))/((q0) - (q1));

		cout<<"\t\t\t~P: "<<res<<endl;
		cout<<"\t\t\t*error relativo: "<<abs((res - p1)/res)*100<<endl;
		cout<<"\t\t\t*error absoluto: "<<abs(res-p1)<<endl;
		if(abs(res-p1) < error){
			cout<<"la aproximacion es: "<<res<<endl;
			break;
		}else{
			p0 = p1;
			p1 = res;
		}	
	}	
	return 0;
}
