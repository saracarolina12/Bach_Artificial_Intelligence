//Bellman O(mn) detectar ciclo negativo 
#include<bits/stdc++.h>
using namespace std;
#define f first
#define s second
#define N 100000
int main(){
	int n,m,a,b,k;
	cin>>n>>m;
	vector<pair<pair<int,int>,int>> v(m);
	vector<int> D(n,N);
	D[0] = 0;
	for(int i=0; i<m; i++){
		cin>>a>>b>>k; 
		v[i] = {{a,b},k};
	}
	vector<int> last(m);
	bool siono=0;
	for(int i=0; i<=n; i++){ // n relajaciones  7 6
		for(int j=0; j<m; j++){// 0 a #ejes[m]
			last[i] = D[v[j].f.s];
			D[v[j].f.s] = min(D[v[j].f.s], D[v[j].f.f] + v[j].s);
	   		if(i == n && last[i] != D[v[j].f.s]) siono=1;
		}
	}
	if(siono)cout<<"YES"<<endl;
	else cout<<"NO"<<endl;
	return 0;
}
