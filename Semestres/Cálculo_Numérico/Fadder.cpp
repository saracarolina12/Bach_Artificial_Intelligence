#include<bits/stdc++.h>
using namespace std;
#define N 100000
int main(){
  int ite, k=1, bn=0, bnk=1, n, tr=0;
  cout<<"-tamaño de matriz: ";cin>>n;
  int C[n][n]; memset(C, 0, sizeof(C));
  int A[n][n], B0[n][n], ident[n][n], res2[n][n], res[n][n], Bn[n][n], B1[n][n];
  memset(A, 0, sizeof(A)); memset(B0, 0, sizeof(B0)); memset(ident, 0, sizeof(ident)); memset(res,0,sizeof(res)); memset(Bn,0,sizeof(Bn)); memset(B1, 0, sizeof(B1)); memset(res2,0, sizeof(res2));
  cout<<"-numero de iteraciones: ";cin>>ite;
  cout<<"-Ingrese la matriz:\n";
  for(int i=0; i<n; i++){
    for(int j=0; j<n; j++)
      cin>>A[i][j];
  }
  //matriz identidad:
  for(int i=0; i<n; i++)
    ident[i][i] = 1; 
  for(int i=0; i<ite; i++){
  	//Calcular B1,B2,...,Bn
        //A*B0 + bnk*ident = B1
	//A*B0
	for(int i=0; i<n; i++){
	  for(int j=0; j<n; j++){
	    for(int k=0; k<n; k++){
	      	res[i][j] += A[i][k] * B0[k][j];
	    }
	  }
	}
	//bnk*ident
	cout<<"derecha "<<endl;
	for(int i=0; i<n; i++){
	  for(int j=0; j<n; j++){
	    res2[i][j] = bnk*ident[i][j];
	    cout<<res2[i][j]<<" ";
	  }
	  cout<<endl;
        }
       //B1
       cout<<"\nfinal: "<<endl;
	for(int i=0; i<n; i++){
	  for(int j=0; j<n; j++){
	    res[i][j]+=res2[i][j];
	    cout<<res[i][j]<<" ";
	  }
	  cout<<endl;
      }
	
      //calcular traza
      //A*B1
      for(int i=0; i<n; i++){
	for(int j=0; j<n; j++){
	  for(int x=0; x<n; x++){
	    C[i][j] += A[i][x] * res2[x][j];
	  }
	}
      }
      for(int i=0; i<n; i++){
	tr += C[i][i];
      }
      bn = (-(1/k))*tr;
      cout<<"\t*bn-k = "<<bn<<endl;
      cout<<"\t*k: "<<k<<endl;
      for(int i=0; i<n; i++){
	for(int j=0; j<n; j++){
	  B0[i][j] = res[i][j];
	}
	 cout<<endl; 
      }
      k++;
      bnk = bn; 
  }
  return 0;


