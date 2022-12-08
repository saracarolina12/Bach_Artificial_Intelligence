//variante2
#include<bits/stdc++.h>
using namespace std;
int main(){
    int n, m;
    cin>>n>>m;
    int value[n+3]={0}, res[m+3]={0};

    for(int i=0; i<n; i++)
        cin>>value[i];

    res[0]=1;
    for(int i=0; i<n; i++){
        int c = value[i];
        for(int j=m; j>=0; j--){
            if(j-c >= 0){ 
                res[j] += res[j-c];
            }
        }  
    }

    for(int i=m; i>=0; i--){
        if(res[i]!=0){
            cout<<i<<endl;
            break;
        }
    }
    return 0;
}