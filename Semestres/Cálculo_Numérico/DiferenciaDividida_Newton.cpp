/*
~Interpolación de polinomios~
  INPUT:
    -# Datos
    -Datos x
    -¿Tenemos función?
      SI:
	*Función
	*f(x)
      NO:
	*x evaluadas
*/

	#include<bits/stdc++.h>
	using namespace std;
	double f(double x){
		return log(x);
	}
	int main(){
	int n;
	char siono;
	cout<<"Ingrese el número de datos: "; cin>>n;
	double arr[n], mat[n][n];
	for(int i=0; i<n; i++){
	  cout<<"\t*Ingrese x("<<i<<"): "; cin>>arr[i];
	}
 	 cout<<"Contamos con una funcion?[y/n] "; cin>>siono;
	if(siono == 'y'){
		for(int i=0; i<n; i++){
			mat[i][0] = f(arr[i]);
			cout<<"\t-f[x"<<i<<"] = "<<f(arr[i])<<endl;
		}
	}else if(siono == 'n'){
		cout<<"- Ingrese cada x evaluada -"<<endl;
		for(int i=0; i<n; i++)
			cin>>mat[i][0];
	}else {
		cout<<"la letra "<<siono<<" no es una letra valida"; 
		return 0;
	}
	for(int i=1; i<=n; i++){
		for(int j=0; j<=n-i; j++)
			mat[j][i] = (mat[j+1][i-1] - mat[j][i-1])/(arr[i+j] - arr[j]);
	}
	string ev, pol;
	if(siono == 'y') cout<<"P(x) = "<<f(arr[0]);
	else if(siono == 'n') cout<<"P(x) "<<mat[0][0];
	for(int i=1; i<n; i++){
	  pol += "(x-"+ to_string(float(arr[i-1])) + ")";
	  ev += " + " + to_string(mat[0][i]) + pol;
	}
	cout<<ev;
	return 0;
}
