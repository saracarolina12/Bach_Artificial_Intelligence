#include<iostream>
using namespace std;
int main(){
    int mod, cont, suma=0;
for (int i=1;i<=10000;i++){
    for (int j=1;j<=i;j++){
       mod=i%j;
       if(mod==0){
        cont++;
        }
    }if (cont<=2){
      suma += i;
    }  
    cont=0;
}
    cout<<suma+1;
}
