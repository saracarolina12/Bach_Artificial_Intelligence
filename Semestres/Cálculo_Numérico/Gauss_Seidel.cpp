/*
INPUT:
  -Tamaño de la matriz (n*m)
  -Número de iteraciones
  -Error
  -Sistema de ecuaciones:
    Matriz
    Vector independiente
*/

#include<bits/stdc++.h>
using namespace std;
int main(){
	int n,m, iteraciones;
	cout<<"Ingrese el numero de ecuaciones(n): "; cin>>n;
	cout<<"Ingrese el numero de incognitas(m): "; cin>>m;
	cout<<"Ingrese el numero de iteraciones: "; cin>>iteraciones;
	double mat[n][m];
	double vec[n]={0};
	double res[n] = {0};
	double error=0;
	cout<<"Ingrese el error: "; cin>>error;
	memset(mat,0,sizeof(mat));
	cout<<"\t*Ingrese los valores de la matriz:\n";
	for(int i=0; i<n; i++){
		for(int j=0; j<m; j++){
			cin>>mat[i][j];
		}
	}
	cout<<"\t*Ingrese el vector independiente:\n";
	for(int i=0; i<n; i++){
		cin>>vec[i];
	}
	cout<<endl;
	for(int i=0; i<n; i++){
		for(int j=0; j<n; j++){
			cout<<mat[i][j]<<"x  ";
		}
		cout<<" = "<<vec[i]<<endl;
	}
	cout<<endl;
	for(int i=0; i<n; i++){
	  double ii = mat[i][i];
	  for(int j=0; j<m; j++){
	    mat[i][j] /= ii;
	  }
	  vec[i] /= ii;
	}
	for(int i=0; i<n; i++){
	  double x = vec[i];
	  for(int j=0; j<m; j++){
	    if(i!=j){
	      x -= mat[i][j]*res[j];
	    }
	  }
	  res[i]= x;
	}
	for(int r=0; r<iteraciones; r++){
	  for(int i = 0; i < n; i++) 
	    cout <<"\t"<< res[i] << " ";
	  cout << endl;
	  int centinela = 1;
	  for(int i=0; i<n; i++){
	    double t = res[i];
	    double x = vec[i];
	    for(int j=0; j<m; j++){
	      if(i!=j){
		x -= mat[i][j]*res[j];
	      }
	    }
	    res[i] = x;
	    if(t && res[i]){
	      double err = 100*abs((res[i] - t)/res[i]);
	      if(err > error){
		centinela = 0;
	      }
	    }
	  }
	  if(centinela) break;
	}
	cout<<"\n\tResultado final:\n\t";
	for(int i = 0; i < n; ++i)
	  cout<< res[i] <<"\t"; 
	return 0;
}

