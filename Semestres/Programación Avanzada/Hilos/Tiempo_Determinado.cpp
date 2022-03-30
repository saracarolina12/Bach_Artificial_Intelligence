#include <iostream>
#include <thread>
#include <chrono>
using namespace std;

void delays(int n){
  this_thread::sleep_for(chrono::milliseconds(n*1000) );
}

int main(){
  int tiempo =0;
  int dur=0;
  cout<<"Ingrese un tiempo maximo de 60 segundos: "<<endl;
  cin>>tiempo;

  if(tiempo<=0)cout<<"no fue posible"<<endl;
  else{
      while(tiempo>0){
       if(tiempo-5>=0){
           dur=5;
       }
       else if(tiempo-3>=0){
           dur=3;
       }
       else{
           dur=1;
       }
       tiempo= tiempo-dur;
       thread thrd(delays,dur);
       thrd.join();
     }
   }
  return 0;
}
