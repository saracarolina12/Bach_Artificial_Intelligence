#include<bits/stdc++.h>
using namespace std;

double f(double x){
    double res = x*x*x*x - 2*x*x*x - 4*x*x + 4*x +4;
    return res;
}

int main(){
    double a=0, p=0, b=0;
    int ite = 0;
    double funa=0, funb=0, funp=0, error=0;
    cout<<"ingresa a: "; cin>>a;
    cout<<"ingresa b: "; cin>>b;
    cout<<"cuantas veces desea iterar "; cin>>ite;
    cout<<"ingrese el error: "; cin>>error;
    
    for(int i=0; i<ite; i++){
        funa = f(a);
        funb = f(b);
        p = (a+b)/2;
        funp = f(p);

        cout<<"\ti: "<<i+1<<endl;
        cout<<"\t*fun: "<<funp<<endl;
        
        if(funp==0 || abs(0 - funp) < error){
           cout<<"\t***La aproximacion es: "<<p<<"***"<<endl;
            return 0;
        }
        if(funa*funp>0){
            a=p;
        }else{
            b=p;
        }   
    }
    cout << "fracaso";
    return 0;
}
