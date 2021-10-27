#include<iostream>
#include <cmath>
using namespace std;
int main(){
    int a=0,b=0,c=0;
    float x1, x2;
    cout<<"A: "; cin>>a;
    cout<<"B: "; cin>>b;
    cout<<"C: "; cin>>c;
    x1 = (-b+sqrt(pow(b,2)-4*a*c))/(2*a); 
    x2 = (-b-sqrt(pow(b,2)-4*a*c))/(2*a);
    cout<<"\nx1: "<< x1;
    cout<<"\nx2: "<< x2;
    return 0;
}
