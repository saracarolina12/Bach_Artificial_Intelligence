//BIT
#include<bits/stdc++.h>
#define N 100000
using namespace std;

long long BIT[N+2];
long long X[N+2]={0};
	
int CumulativeSum(long k){
	long s = 0;
	k++;
	while(k > 0){
		s += BIT[k]; //calcular la suma
		k -= (k & (-k)); //C2
	}
	return s;
}

void Update(long k, long delta){
	k++;
	while( k <= N){
		BIT[k] += delta;
		k += (k & (-k));
	}
}

int main(){
	long n, m; //n: 3 5 1 0 11 8 23 4
	cin>>n>>m;
	
	//construir BIT
	for(int i=0; i<n; i++){
		cin>>X[i];
		Update(i, X[i]);
	}
	
	long op,a,b;
	for(int i=0; i<m; i++){
		cin>>op>>a>>b;
		if(op == 1){
			long sumb = CumulativeSum(b);
			long suma = CumulativeSum(a-1);
			sumb -= suma;
			cout<<sumb<<endl;
		}else{
			X[a] = b;
			memset(BIT, 0, sizeof(BIT));
			for(int i=0; i<n; i++){
				Update(i, X[i]);
			}
		}
	}

	return 0;
}