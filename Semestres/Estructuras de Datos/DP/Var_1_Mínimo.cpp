//dynamic programming
//O(nk)
//mínimo de monedas, infinitas, var 1
#include<bits/stdc++.h>
using namespace std;
int main(){
    long long n, k;
    cin>>n>>k;
    long long tipos[n+3]={0}, coins[k+3]={0};
 
    for(int i=0; i<n; i++)
        cin>>tipos[i];
    for(int i=0; i<k+1; i++)
        coins[i]=1000;
    coins[0]=0;
    
    for(int i=0; i<n; i++){
        int c = tipos[i];
        for(int j=0; j<=k; j++){
            if(j - c >= 0) {
                coins[j] = min(coins[j-c]+1, coins[j]);
            }   

        } 
    }
    cout<<coins[k]<<endl;
    return 0;
}