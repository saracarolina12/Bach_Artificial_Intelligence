#include<iostream>
using namespace std;
int mat[100][100];
int filas,columnas;
int main(){
    cout<<"numero de filas: "; cin>>filas;
    cout<<"numero de columnas: ";cin>>columnas;
    for(int i=0;i<filas;i++){                   //pedir datos
        for(int j=0; j<columnas;j++){
            cout<<"["<<i<<"]["<<j<<"]: "; 
            scanf("%d", (*(mat + i) + j));
        }
    } 
    for(int i=0;i<filas;i++){                   //imprimir matriz original
        for(int j=0;j<columnas;j++){
            printf("%d ", *(*(mat + i) + j));
        }
        cout<<"\n";
    }
    cout<<"\n";
    for(int i=0;i<filas;i++){ 
        for(int j=0;j<columnas;j++){             //transponer matriz
           printf("%d ", *(*(mat + j) + i)); 
        }
        cout<<"\n";
    }
    return 0;
}
