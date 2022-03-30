#include<iostream>
#include <algorithm>
#include<string>
#include<vector>
using namespace std;

int main(){
    int n=0;
    int digits=0;
    int k=0;
    cout<<"Digite el tamanio del vector: ";
    cin>>n;
    cout<<"cuantas veces lo va a rotar? ";
    cin>>k;

    vector<int> v;
    cout<<"Ingrese "<<n<<" numeros: ";
    for(int i=0;i<n;i++){
        cin>>digits;
        v.push_back(digits);
    }

    rotate(v.begin(),v.begin()+k+1,v.end());

    for(int i=0;i<n;i++){
        cout<<" "<<v[i];
    }
    cout<<"\n";
}
