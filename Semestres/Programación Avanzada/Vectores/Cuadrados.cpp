#include<iostream>
#include<math.h>
#include <algorithm>
#include<string>
#include<vector>

using namespace std;

int main(){
    int n=0;
    int digits=0;
    cout<<"Digite el tamanio del vector: ";
    cin>>n;

    vector<int> v;
    cout<<"Ingrese "<<n<<" numeros: ";
    for(int i=0; i<n; i++){
        cin>>digits;
        v.push_back(digits);
    }
    for(int i=0; i<n; i++){
        v[i] = v[i]*v[i];
    }

    sort(v.begin(),v.end());

    for(int i=0; i<n; i++){
         cout<<v[i]<<" ";
    }

}
