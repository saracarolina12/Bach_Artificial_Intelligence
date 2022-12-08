//la secuencia ascendente más larga posible 1,4,7,9,15
//COMPLEJIDAD: O(logn)
#include<bits/stdc++.h>
using namespace std;

int main(){
    int n, nums;
    cin>>n;
    int inp[n+4]={0}, len[n+4]={0};

    for(int i=0; i<n; i++){
        cin>>inp[i];
        len[i]=0;
    }

    int ind[n+4]={0};
    memset(ind, -1, sizeof(ind));

    for(int i=0; i<n; i++){
        for(int j=0; j<i; j++){
            if(inp[j] > inp[i]){
                //len[i] = max(len[i], len[j]);
                if(len[j]>len[i]){
                    len[i] = len[j];
                    ind[i] = j;
                }
            }
        }
        len[i]++;
    }

    int res=0;
    int indi = 0;
    for(int i=0; i<n; i++){
        if(len[i]>res){
            res = len[i];
            indi = i;
        }
    }
    cout<<res<<"\n";

    vector<int> v;

    while(indi!=-1){
        v.emplace_back(indi);
        indi = ind[indi];
    }
    reverse(v.begin(), v.end());
    for(int i=0; i<v.size(); i++){
        cout<<v[i]<<" ";
    }
    

    return 0;
}