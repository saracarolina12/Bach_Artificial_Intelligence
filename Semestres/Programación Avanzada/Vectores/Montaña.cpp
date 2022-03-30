#include<iostream>
#include<algorithm>
#include<string>
#include<vector> 
using namespace std;
int main(){
    int num=0; 
    int m=-1000;
    int aux;
    vector<int> arr;
    cout<<"Digite el tamanio del vector: "; cin>>num;
     if(num<3){
        cout<<"No puede ser vector montaÃ±a"<<endl;
        return 0;
    }
    cout<<"Ingrese "<<num<<" numeros: "<<endl;
    for(int i=0; i<num; i++){
        cin>>aux;
        arr.push_back(aux);
    }
    for(auto ir = arr.begin(); ir!=arr.end(); ++ir){
       if(*ir>m){
           m = *ir;
       }
    }
    if(arr[0]==m||arr[num-1]==m){
        cout<<"No puede ser vector montaÃ±a"<<endl;
    }else{
        for(int i=0;i<num;i++){
            if(arr[i]==m){
                cout<<i<<endl;
            }
        }
    }
    return 0;
}
