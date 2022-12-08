#include<bits/stdc++.h>
using namespace std;

int main(){
    int n;
    string stra="";
    string strb="";
    cin>>n;
    cin>>stra;
    cin>>strb;

    int mat[stra.size()+1][strb.size()+1];

    //inicializar en 0
    for(int i=0; i<stra.size()+1; i++){
        for(int j=0; j<strb.size()+1; j++){
            mat[i][j]=0;
        }
    }

    //ir sumando
    for(int i=1; i<stra.size()+1; i++){
        for(int j=1; j<strb.size()+1; j++){
            if(stra[i-1]==strb[j-1]){
                mat[i][j]=mat[i-1][j-1]+1;
            }else{
                mat[i][j]=max(mat[i][j-1],mat[i-1][j]);
            }
        }
    } 

    //imprimir
    cout<<mat[stra.size()][strb.size()]<<'\n';
    return 0;
}