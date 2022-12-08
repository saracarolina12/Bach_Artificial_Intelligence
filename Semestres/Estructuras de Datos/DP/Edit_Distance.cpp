#include<bits/stdc++.h>
using namespace std;

int main(){
	string stra="", strb="";
	cin>>stra>>strb;
	
	int mat[stra.size()+1][strb.size()+2];
	for(int i=0; i<stra.size()+1; i++){
		for(int j=0; j<strb.size()+1; j++){
			mat[i][j] = 0;
		}
	}
	
	for(int i=0; i<stra.size()+1; i++){
		for(int j=0; j<strb.size()+1; j++){
			if(j==0) mat[i][j] = i;
			if(i==0) mat[i][j] = j;
		}
	}
	
	//sumar
	int mn=0;
	for(int i=1; i<=stra.size(); i++){
		for(int j=1; j<=strb.size(); j++){
			if(stra[i-1]==strb[j-1]){
				mat[i][j] = mat[i-1][j-1];
			}else{
				mn = min(mat[i-1][j], mat[i][j-1]);
				mn = min(mn,mat[i-1][j-1]);
				mat[i][j] = mn+1;
			}
		}
	}
	
	//imprimir matriz final
	
	/*for(int i=0; i<stra.size()+1; i++){
		for(int j=0; j<strb.size()+1; j++){
			cout<<mat[i][j]<<" ";
		}
		cout<<'\n';
	}*/
	
	cout<<mat[stra.size()][strb.size()]<<endl;
	
	
	
}