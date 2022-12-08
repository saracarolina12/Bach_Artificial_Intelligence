//dynamic programming
//O(nk)
//formas de monedas, infinitas, var 1
#include<bits/stdc++.h>
using namespace std;
int main(){
    int n, k;
    cin>>n>>k;
    int tipos[n+3]={0}, coins[k+3]={0};
 
 	//recibe tipos de monedas disponibles
    for(int i=0; i<n; i++)
        cin>>tipos[i];

	//inicializa el arreglo
    for(int i=0; i<=k; i++)
        coins[i]=0;
        
    coins[0]=1;
    
    for(int i=0; i<n; i++){
    	int c = tipos[i];
    	for(int j=0; j<=k; j++){
    		if(j-c >= 0){
    			coins[j] += coins[j-c];
    		}
    	}
    }
    
    cout<<coins[k]<<endl;
    
    return 0;
}