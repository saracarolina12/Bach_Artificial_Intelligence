/*
~~
  INPUT:
   -Función
   -Rango(a,b)
   -Valor inicial Y(0)
   -Valor N
*/
#include<bits/stdc++.h>
using namespace std;
#define e 2.71828
double f(double t,double y){
  return (t*pow(e,3*t) - (2*y));
}
int main(){
  double a,b,N,h,t,y,y0,k1=0,k2=0,k3=0,k4=0;
  cout<<"ingrese a<= t <=b: ";cin>>a>>b;
  cout<<"ingrese y(0): "; cin>>y0;
  cout<<"ingrese N: "; cin>>N;
  h = (b-a)/N;
  t=a; y=y0;
  cout<<"\t*h: "<<h<<'\n';
  cout<<"\t\t~0: "<<"(t= "<<t<<", y= "<<y<<")"<<endl;
  for(int i=1; i<=N+1; i++){
    k1=h*f(t,y);
    k2=h*f(t+(h/2), y+(k1/2));
    k3=h*f(t+(h/2), y+(k2/2));
    k4=h*f(t+h, y+k3);
    cout<<"\t\t\t\t*k1: "<<k1<<endl;
    cout<<"\t\t\t\t*k2: "<<k2<<endl;
    cout<<"\t\t\t\t*k3: "<<k3<<endl;
    cout<<"\t\t\t\t*k4: "<<k4<<endl;
    y = y + (k1+ (2*k2) + (2*k3) + k4)/6;
    t = a + i*h;
    if(i!=N+1)cout<<"\t\t~"<<i<<"(t= "<<t<<", y= "<<y<<")"<<endl;
    else break;
  }
  return 0;
}
