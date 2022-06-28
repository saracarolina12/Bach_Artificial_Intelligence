//DFS
#include<bits/stdc++.h>
using namespace std;
#define N 1000
int n,m,a,b;
int mat[N][N]={0};
bool visited[N] = {0};
void DFS(int x){
	int num; 
	stack<int> s; 
	visited[x] = 1; 
	s.push(x); 
	while(!s.empty()){
	 	num = s.top();
	 	s.pop();
	 	cout<<num<<" ";
	 	for(int i=0; i<n; i++){ //0 al numero de nodos
	 		if(mat[num][i]==1 && !visited[i]){
	 			visited[i] = 1;
	 			s.push(i);
	 		}
	 	}
	}
}
int main(){
	cin>>n>>m; //n=#nodos, m=
	for(int i=0; i<m; i++){
		cin>>a>>b; //conexiones entre nodos
		mat[a][b] = mat[b][a] = 1;
	}
	//DFS
	DFS(0);
	return 0;
}
