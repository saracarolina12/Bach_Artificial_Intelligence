//BFS
#include<bits/stdc++.h>
using namespace std;
#define f first
#define s second
int n, m, x, y, w, z, sum=0;
bool fin=0;
char mat[52][52];
int vi[52][52];
vector<pair<int,int>> c={{1,0},{-1,0},{0,1},{0,-1}};//S,N,E,O
bool isvalid(int x, int y){
	bool a,b,c;
	a=b=c=0;
	if(vi[x][y] == -1) a = 1;
	if(x>=0 && y>=0 && x<n && y<m) b = 1;
	if(mat[x][y] == '.') c = 1;
	return a && b && c;  //si y sólo si son verdaderos los 3
}
void BFS(int x,int y){ //pasa las coordenadas
	queue<pair<int,int>> q;
	q.emplace(x,y);
	memset(vi,-1,sizeof(vi));
	vi[x][y] = 0;
	while(!q.empty()){
		pair<int,int> num = q.front();
		q.pop();
		for(int i=0; i<(int)c.size(); i++){
			int a = num.f + c[i].f; //vecinos
			int b = num.s + c[i].s;
			if(isvalid(a,b)){
				vi[a][b] = vi[num.f][num.s]+1;
				q.emplace(a,b);
			}
		}
	}
}
int main(){
	cin>>n>>m;
	for(int i=0; i<n; i++){
		for(int j=0; j<m; j++){
			cin>>mat[i][j];
			if(mat[i][j]=='S'){
				x=i,y=j; //para guardar la coordenada inicial
				mat[i][j] = '.';
			}
			else if(mat[i][j]=='E'){
				w=i,z=j;
				mat[i][j] = '.';
			}
		}
	}
	BFS(x,y);
	cout<<vi[w][z]<<endl;
	return 0;
}