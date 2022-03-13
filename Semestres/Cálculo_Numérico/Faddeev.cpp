/*
~Determina polinomio caraterístico~
  INPUT:
    -Tamaño de la matriz A (n*n)
    -Matriz A
    -# iteraciones

*/
#include<bits/stdc++.h>
using namespace std;
#define N 100000
#define CLR(x) memset(x,0,sizeof(x))
#define vi vector<int>
#define pb push_back
int main(){
  double tr=0, k=1.0, bnk=1;
  int ite, n;
  cout<<"-tamaño de matriz: ";cin>>n;
  int arr[n+2]; CLR(arr);
  int A[n][n], B0[n][n], ident[n][n], res2[n][n], res[n][n], Bn[n][n], B1[n][n], fin[n][n];
  CLR(A); CLR(B0); CLR(ident); CLR(ident); CLR(res); CLR(Bn); CLR(B1); CLR(fin);
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
	CLR(res); CLR(res2);
	cout<<"\t~Iteracion #"<<k<<endl;
        //A*B0 + bnk*ident = B1
	//A*B0
	for(int i=0; i<n; i++){
	  for(int j=0; j<n; j++){
	    for(int k=0; k<n; k++)
	      	res[i][j] += A[i][k] * B0[k][j];
	  }
	}
	//bnk*ident
	for(int i=0; i<n; i++){
	  for(int j=0; j<n; j++)
	    res2[i][j] = bnk*ident[i][j];
        }
       //B1
	for(int i=0; i<n; i++){
	  for(int j=0; j<n; j++)
	    fin[i][j]= res[i][j] + res2[i][j];
      }
	
      //calcular traza
      //A*B1
      int C[n][n]; CLR(C);
      for(int i=0; i<n; i++){
	for(int j=0; j<n; j++){
	  for(int x=0; x<n; x++)
	    C[i][j] += A[i][x] * fin[x][j];
	}
      }
      for(int i=0; i<n; i++)
	tr += C[i][i];
      double bn = (-(1/k))*tr;
      cout<<"\t\t*b: "<<setprecision(3)<<bn<<endl<<fixed;
      arr[i] = bn;
      for(int i=0; i<n; i++){
	for(int j=0; j<n; j++)
	  B0[i][j] = fin[i][j];
      }
      bnk = bn;
      tr = 0;
      k++;
  }
  string s="";
  cout<<"\t\t\t*Polinomio:  m^"<<to_string(n)<<" + ";
  int x=n,i=0; n-=1;
  while(x){
    if((x-1)!=0 && (x-1)!=1) cout<<arr[i]<<"m^"<<x-1<<" + ";
    else if((x-1)==1) cout<<arr[i]<<"m + ";
    else cout<<arr[i];
    i++;
    x--;
  }
  return 0;
}
