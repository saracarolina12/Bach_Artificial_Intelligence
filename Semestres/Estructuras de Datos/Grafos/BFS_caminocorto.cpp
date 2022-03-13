#include<bits/stdc++.h>
using namespace std;
#define N 101
int vi[N];
void BFS(int st,int mat[N][N], int n){
	memset(vi,-1,sizeof(vi));
	queue<int> q;
	vi[st] = 0,q.push(st);
	while(!q.empty()){
		int nu = q.front();
		q.pop();
		for(int i=0; i<n; i++){
			if(vi[i]==-1 && mat[nu][i]){
				vi[i] = vi[nu]+1;
				q.push(i);
			}		
		}
	}
}
int main(){
	int n,m,st,fn;
	cin>>n>>m;
	int mat[N][N];
	for(int a,b,i=0; i<m; i++){
		cin>>a>>b;
		mat[a][b]= mat[b][a] = 1;
	}
	cin>>st>>fn;
	BFS(st, mat, n);
	if(vi[fn]==-1)cout<<"Imposible";
    else cout<<vi[fn];
	return 0;
}
