/*
INPUT:
  -Función 
  -# iteraciones
  -Punto inicial (p0)
  -Err0r
*/
#include<bits/stdc++.h>
using namespace std;
double f(double x){
	return sqrt( (3+x-x*x*x*x)/2 ); 
}
int main(){
	double aproxi, p0, error, ite, p;
	cout<<"Cuantas iteraciones? "; cin>>ite;
	cout<<"Digite p0: "; cin>>p0;
	cout<<"Digite error: "; cin>>error;
	for(int i=0; i<ite; i++){
		p = f(p0);
		cout<<"\t*p: "<<p<<endl;
		cout<<"\t*p0: "<<p0<<endl;
		cout<<"\t\t*error: "<<abs((p-p0)/p)*100<<endl;
		cout<<endl;
		if( (abs((p-p0)/p)*100) < error ){
			cout<<"Resultado: "<<p<<endl;
			break;
		}
		p0 = p;
	}
	return 0;
}
