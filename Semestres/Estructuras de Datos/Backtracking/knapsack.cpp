#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

int ganancia = 0;
int capacidad = 5;                         //5 kg max
int obj_peso[] = {1,2,2,2};                //kilogramos
int obj_precio[] = {5,3,2,20};             //precio                    
double obj_precio_peso[4][2] = {0};      //ganacia
int answer[4] = {0,0,0,0};  

int main() {
    int lenn = sizeof(obj_peso)/sizeof(obj_peso[0]);  //tamaÃƒÂ±o de peso[] en kg
  
    for(int i=0;i<lenn;i++){
      obj_precio_peso[i][0] = double(obj_precio[i])/double(obj_peso[i]); //divide  precio/peso
      obj_precio_peso[i][1] = double(obj_peso[i]);                       //aÃƒÂ±ade el peso
    }   //quedarÃƒÂ­a ($/kg , peso en kg)
/*
    for( int i = 0; i < lenn-1; i++ ){
        for( int j = i+1; j > 0 && obj_precio_peso[j][0] > obj_precio_peso[j-1][0]; j-- ){
          double temp[] = {
          obj_precio_peso[j][0], obj_precio_peso[j][1]};
          obj_precio_peso[j][0] = obj_precio_peso[j-1][0];
          obj_precio_peso[j][1] = obj_precio_peso[j-1][1];
          obj_precio_peso[j-1][0] = temp[0];
          obj_precio_peso[j-1][1] = temp[1];
        }
    }*/

    sort(obj_precio_peso,obj_precio_peso+lenn);
    
    //paso 3
    for(int i=0;i<lenn;i++){
      if(obj_precio_peso[i][1]<=capacidad){
        answer[i]=1; 
        capacidad-=obj_precio_peso[i][1];
        ganancia+=obj_precio_peso[i][0]*obj_precio_peso[i][1];
      }
    }


    cout<<"La ganancia es: "<<ganancia << endl;
    cout<<"Areglo de unos y ceros con valores ordenados: " << endl;
    for( int i = 0; i < lenn; i++ )
        cout << answer[i] << " ";
    return 0;
}
