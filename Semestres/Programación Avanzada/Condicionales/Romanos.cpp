#include<iostream>
using namespace std;
int main(){
    int num,u,d,c,m;
    cout<<"a ver un numerito  ";
    cin>> num;
    u = num % 10;   //partir el numero dado en unidades para los cases
    num /= 10;
    d = num % 10;  //partir el numero dado en unidades para los cases
    num /= 10;
    c = num % 10;  //partir el numero dado en unidades para los cases
    num /= 10;
    m = num % 10;  //partir el numero dado en unidades para los cases
    num /= 10;
    switch (m){
    case 1: cout<<"M"; break;//1000
    case 2: cout<<"MM"; break;//2000
    case 3: cout<<"MMM"; break;//3000
    case 4: cout<<"IV"; break;//4000
    }

    switch (c){
    case 1: cout<<"C"; break; //100
    case 2: cout<<"CC"; break; //200
    case 3: cout<<"CCC"; break;//300
    case 4: cout<<"CD"; break;//400
    case 5: cout<<"D"; break;//500
    case 6: cout<<"DC"; break;//600
    case 7: cout<<"DCC"; break;//700
    case 8: cout<<"DCCC"; break;//800
    case 9: cout<<"CM"; break; //900
   }

    switch (d){
    case 1: cout<<"X"; break; //10
    case 2: cout<<"XX"; break;//20
    case 3: cout<<"XXX"; break;//30
    case 4: cout<<"XL"; break;//40
    case 5: cout<<"L"; break;//50
    case 6: cout<<"LX"; break;//60
    case 7: cout<<"LXX"; break;//70
    case 8: cout<<"LXXX"; break;//80
    case 9: cout<<"XC"; break; //90
   }

   switch (u){
    case 1: cout<<"I"; break;//1
    case 2: cout<<"II"; break;//2
    case 3: cout<<"III"; break;//3
    case 4: cout<<"IV"; break;//4
    case 5: cout<<"V"; break;//5
    case 6: cout<<"VI"; break;//6
    case 7: cout<<"VII"; break;//7
    case 8: cout<<"VIII"; break;//8
    case 9: cout<<"IX"; break;//9
   }
   return 0;
  }
