#include<bits/stdc++.h>
using namespace std;

int main(){
    int n,m;
    cin>>n>>m;
    int stra[n]={0};
    int strb[m]={0};
    
    
    for(int i=0; i<n; i++)
        cin>>stra[i];
    
    for(int i=0; i<m; i++)
        cin>>strb[i];

    int mat[n+1][m+1];

    //inicializar en 0
    for(int i=0; i<n+1; i++){
        for(int j=0; j<m+1; j++){
            mat[i][j]=0;
        }
    }

    //ir sumando
    for(int i=1; i<n+1; i++){
        for(int j=1; j<m+1; j++){
            if(stra[i-1]==strb[j-1]){
                mat[i][j]=mat[i-1][j-1]+1;
            }else{
                mat[i][j]=max(mat[i][j-1],mat[i-1][j]);
            }
        }
    } 

    //imprimir
    cout<<mat[n][m]<<'\n';
    return 0;
}