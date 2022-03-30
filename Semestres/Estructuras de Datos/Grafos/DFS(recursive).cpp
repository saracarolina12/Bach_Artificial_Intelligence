#include<bits/stdc++.h>
using namespace std;
int n, m, x, y;
char mat[52][52];
void DFS(int x,int y){ //pasa las coordenadas
	if(mat[x][y] == '*' || mat[x][y] == '#' || x>=n || y>=m || x<0 || y<0) return;
	mat[x][y] = '#';
	DFS(x+1,y); //abajo
	DFS(x-1,y); //arriba
	DFS(x,y+1); //derecha
	DFS(x,y-1); //izquierda
}
int main(){
	cin>>n>>m;
	for(int i=0; i<n; i++){
		for(int j=0; j<m; j++){
			cin>>mat[i][j];
			if(mat[i][j]=='#'){
				x=i,y=j; //para guardar la coordenada inicial
				mat[i][j] = '.'; //sustituir por puntito
			}
		}
	}
	DFS(x,y);//dfs 
	for(int i=0; i<n; i++){
		for(int j=0; j<m; j++)
			cout<<mat[i][j];
		cout<<endl;
	}
	return 0;
}
