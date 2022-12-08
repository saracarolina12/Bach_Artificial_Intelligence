#include<bits/stdc++.h>
using namespace std;

//FORMULA:  f(n) = 2*(v[n-1]+v[n-2])
int main(){
    int n;
    long long sum=0;
    vector<long long> vr;
    vr.emplace_back(1),vr.emplace_back(1);
  
    cin>>n;

    if( (n==1) || n==2){
        cout<<"2"<<endl;
    }else{
        for(int i=0; i<n; i++){
            sum=vr[i]+vr[i+1];
            vr.emplace_back(sum);
        }
        cout<<2*(vr[n-2]+vr[n-3]);
    }

    return 0;
}