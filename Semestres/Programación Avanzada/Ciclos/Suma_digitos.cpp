#include<iostream>
using namespace std;
int main(){
 int num,u,d,c,m, sum;
  cout<<"Digite un numero: "<<endl;
  cin>>num;
    u = num % 10;  num /= 10;
    d = num % 10;  num /= 10;  
    c = num % 10;  num /= 10;
    m = num % 10;  num /= 10;
   sum = u+d+c+m;
   cout<<sum;
}
