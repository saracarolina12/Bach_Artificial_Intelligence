/*
~Polinomio interpolante~
  INPUT:
    -Grado
    -# datos
    -valores x
    -valores f(x)
    -valores f'(x)
  
*/
#include<bits/stdc++.h>
using namespace std;
int main(){
    int  grado, ndat;
    cout<<"Grado: "; cin>>grado;
    cout<<"Numero de datos: "; cin>>ndat;
    double x[ndat]={0},fx[ndat]={0},fdx[ndat]={0};
    double mat[2*ndat][2*ndat];
    memset(mat, 0, sizeof(mat));
    cout<<"*Ingrese x:\n";
    for(int i=0; i<ndat; i++){
        cout<<"\tx("<<i<<"): "; 
        cin>>x[i];
    }   
    cout<<"*Ingrese f(x):\n";
    for(int i=0; i<ndat; i++){
        cout<<"\tf(x"<<i<<"): ";
        cin>>fx[i];
    }
    cout<<"*Ingrese f'(x):\n";
    for(int i=0; i<ndat; i++){
        cout<<"\tf'(x"<<i<<"): ";
        cin>>fdx[i];
    }
    for(int i=0; i<ndat; i++){
        mat[2*i][0] = mat[2*i+1][0] = fx[i];
        mat[2*i][1] = fdx[i];
        if(i>0) mat[2*i-1][1] = (mat[2*i][0]-mat[2*i-1][0])/(x[i]-x[i-1]);
    }
    string ev="",pol="";
    for(int i=2; i<2*ndat; i++){
        for(int j=0; j<2*ndat-i; j++){
            mat[j][i] = (mat[j+1][i-1] - mat[j][i-1])/(x[int((i+j)/2)] - x[int(j/2)]);
        }
        ev = to_string(mat[0][0]);
        pol = "";
    }
    cout<<"\n\t*MATRIZ HERMITE: "<<endl;
    for(int i=0; i<ndat*2; i++){
    	for(int j=0; j<ndat*2; j++){
    		if(mat[i][j]==0) cout<<"\t\t     "<<mat[i][j]<<"   ";
            else cout<<"\t\t"<<mat[i][j]<<"   ";
    	}
    	cout<<endl;
    }
    for(int i=1; i<2*ndat; i++){
        pol += "(x - "  + to_string( x[(i-1)/2]) + ")";
        ev += " + " + to_string(mat[0][i]) + pol;
    }
    cout<<"P(x): "<<ev<<endl;
return 0;
}
