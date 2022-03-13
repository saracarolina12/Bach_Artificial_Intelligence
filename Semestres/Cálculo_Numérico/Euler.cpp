/*
~Solución de ecuaciones diferenciales~
  INPUT:
    -Función
    -Rango (a,b)
    -Punto inicial Y(0)
    -Valor N
*/
#include<bits/stdc++.h>
using namespace std;
double f(double t,double y){
  return -5*y + 5*(t*t) + 2*t;
}
int main(){
  double a,b,N,h,tn,yn,y0;
  cout<<"ingrese a<= t <=b: ";cin>>a>>b;
  cout<<"ingrese y(0): "; cin>>y0;
  cout<<"ingrese N: "; cin>>N;
  h = (b-a)/N;
  tn=a; yn=y0;
  cout<<"\t*h: "<<h<<'\n';
  cout<<"\t\t-0: "<<"(t= "<<tn<<", y= "<<yn<<")"<<endl;
  for(int i=1; i<=N; i++){
    yn = yn + h*f(tn, yn);
    tn = a + i*h;
    if(i!=N)cout<<"\t\t-"<<i<<": "<<"(t= "<<setprecision(1)<<tn<<", y="<<setprecision(3)<<yn<<")"<<'\n'<<fixed;
    else break;
  }
  return 0;
}
