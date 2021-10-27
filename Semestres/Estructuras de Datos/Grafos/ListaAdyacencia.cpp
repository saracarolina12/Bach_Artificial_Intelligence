//lista de adyacencia
#include<bits/stdc++.h>
using namespace std;
int main(){
	int n, m, a, b;//vertices, aristas
	cin>>n>>m;
	vector<list<int> > v(n);
	for(int i=0; i<m; i++){
		cin>>a>>b;
		v[a].push_back(b);
		v[b].push_back(a);
	}
	
	for(int i=0; i<n; i++){
		int size = int(v[i].size());
		cout<<i<<": ";
		for(int j=0; j<size; j++){
			cout<<v[i].front();
			if(j<size-1){
				cout<<"->";
			}
			v[i].pop_front();
			
		}
		cout<<endl;
	}
	
	return 0;
}