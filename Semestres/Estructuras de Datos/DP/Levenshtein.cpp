#include<bits/stdc++.h>
using namespace std;

int main(){
    string stra="";
    string strb="";
    int dist=0;
    int miin=0;
    cin>>stra;
    cin>>strb;

    int mat[stra.size()+1][strb.size()+1];

    //inicializar en 0
    for(int i=0; i<stra.size()+1; i++){
        mat[i][0]=i;
        for(int j=0; j<strb.size()+1; j++){
        mat[0][j]=j;
      }
    }
    

    //sumar
    for(int i=1; i<stra.size()+1; i++){
      for(int j=1; j<strb.size()+1; j++){
        if(stra[i-1]==strb[j-1]){
          dist=0;
        }else{
          dist=1;
        }
        miin = min(mat[i-1][j]+1, mat[i][j-1]+1);
        mat[i][j]= min(miin, mat[i-1][j-1]+dist);
      }
    }

    //imprimir
    cout<<mat[stra.size()][strb.size()];

    return 0;
}