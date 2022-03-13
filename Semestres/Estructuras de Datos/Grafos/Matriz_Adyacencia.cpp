//matriz de adyacencia
#include<bits/stdc++.h>
using namespace std;
int main(){
	int n, m, a, b;
	cin>>n>>m;
	int mat[n][n];
	for(int i=0; i<n; i++){
		for(int j=0; j<n; j++){
			mat[i][j] = 0;
		}
	}
	for(int i=0; i<m; i++){
		cin>>a>>b;
		mat[a][b] = mat[b][a] = 1;
	}
	for(int i=0; i<n; i++){
		for(int j=0; j<n; j++){
			cout<<mat[i][j]<<" ";
		}
		cout<<endl;
	}
	return 0;
}
