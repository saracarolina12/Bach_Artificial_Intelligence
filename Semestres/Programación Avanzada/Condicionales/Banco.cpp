#include<iostream>
using namespace std;
int main(){
   float saldo = 1000;
   int opcion = 0;
   int retiro=0;
   cout<<"\nSeleccione una opcion: \n1.Retirar Efectivo\n2.Ver Saldo\n\n";
   cin>>opcion;
   switch(opcion){
     case 1: {
         cout<<"¿Cuanto desea retirar? ";
         cin>>retiro;
         saldo= saldo-retiro;
         cout<<"\nRetiro realizado con exito :)";
         break;
     }
 
     case 2: {
         cout<<saldo;
         break;
     }
   }
   cout<<"\nSeleccione una opcion: \n1.Retirar Efectivo\n2.Ver Saldo\n\n";
   cin>>opcion;
   switch(opcion){
     case 1: {
         cout<<"¿Cuanto desea retirar? ";
         cin>>retiro;
         saldo= saldo-retiro;
         cout<<"\nRetiro realizado con exito :)";
         break;
     }
     case 2: {
         cout<<saldo;
         break;
     }
   }
   cout<<"\nSeleccione una opcion: \n1.Retirar Efectivo\n2.Ver Saldo\n\n";
   cin>>opcion;
   switch(opcion){
     case 1: {
         cout<<"¿Cuanto desea retirar? ";
         cin>>retiro;
         saldo= saldo-retiro;
         cout<<"\nRetiro realizado con exito :)";
         break;
     }
     case 2: {
         cout<<saldo;
         break;
     }
   }
}
