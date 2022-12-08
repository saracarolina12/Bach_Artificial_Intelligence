//ramita variante dos, finitas
#include<bits/stdc++.h>
using namespace std;
int main(){
    int n, s=0;
    cin>>n;
    int value[n+3]={0};

    //suma de los valores para obtener s
    for(int i=0; i<n; i++)
    	cin>>value[i], s += value[i];
        
    int res[(s/2)+3]={0};
    res[0]=1;
    

    for(int i=0; i<n; i++){
        int c = value[i];
        for(int j=s/2; j>=0; j--){
            if(j-c >= 0){ 
                res[j] += res[j-c];
            }
        }  
    }
    
    for(int i=s/2; i>=0; i--){
        if(res[i]!=0){
            cout<<s-2*i<<endl;
            break;
        }
    }
    return 0;
}