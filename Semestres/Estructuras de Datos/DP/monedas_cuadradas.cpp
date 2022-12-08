//mínimo de monedas, infinitas, var 1
#include<bits/stdc++.h>
using namespace std;
int main(){
    int n, sq;
    cin>>n;
    sq = sqrt(n);
    int tipos[sq+3]={0}, coins[n+3]={0};
 	
 	for(int i=1; i<=sq; i++)
 		tipos[i] = i*i;
 	for(int i=0; i<n+1; i++)
 		coins[i] = 1000;
 	coins[0] = 0; 	
 	
 	for(int i=0; i<sq; i++){
 		int c = tipos[i+1];
 		for(int j=0; j<=n; j++){
 			if(j - c >= 0) coins[j] = min(coins[j-c]+1, coins[j]);
 		}
 	}

 	cout<<coins[n]<<endl;
    return 0;
}