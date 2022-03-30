#include<iostream>
#include<thread>
#include<time.h>
#include <bits/stdc++.h> 
using namespace std;

void swap(int arr2[], int i, int j){
    int aux = arr2[i];
    arr2[i] = arr2[j];
    arr2[j] = aux;
}

void burbujis(int arr2[],int cant){
   // int n = sizeof(arr)/sizeof(arr[0]);
    for(int i=cant-1;i>0;i--){
        for(int j=0;j<i;j++){
            if(arr2[j]>arr2[j+1]){
                swap(arr2[j], arr2[j+1]);
            }
        }
    }
    cout<<"Bubble: [";
    for(int i=0;i<cant;i++){
        cout<<arr2[i]<<",";
    }
    cout<<"]";
 //   this_thread::sleep_for(chrono::milliseconds(1000));
}

void mergesrotR(int arr[],int copy[],int ini, int fin){
    if(ini>=fin)return;
    if(fin-ini==1){
        if(arr[ini]>arr[fin]){
            swap(arr,ini,fin);
        }
        return;
    }
    int m = ini+(fin-ini)/2;
    mergesrotR(arr,copy,ini,m);
    mergesrotR(arr,copy,m+1,fin);

    int i=ini;
    int j=m+1;
    for(int k=ini;k<=fin;k++){
        if((i<=m && j<=fin && arr[i]<=arr[j]) || j>fin){
            copy[k] = arr[i];
            i++;
        }
        else{
            copy[k] = arr[j];
            j++;
        }
    }
    for(int k=ini;k<=fin;k++){
        arr[k] = copy[k];
    }
}
void mergecito(int arr[], int cant){
    int n_mer = cant; //sizeof(arr)/sizeof(arr[0]);
    int copy[n_mer];
    mergesrotR(arr,copy,0,n_mer-1);
    cout<<"\nMerge: [";
    for(int i=0;i<cant;i++){
         cout<<arr[i]<<",";
    }
    cout<<"]";
    cout<<"\n";
   // this_thread::sleep_for(chrono::milliseconds(1000));
}

int main(){
    srand(time(NULL));
    const int cant = 10;
    int arr[cant];
    int arr2[cant];
    for(int i=0;i<cant;i++){
        arr[i] = rand() % 100;
    }
    for(int i=0;i<cant;i++){
        arr2[i] = rand() % 100;
    }
    thread bu(burbujis,arr2,cant);
    bu.join();         // si se le quitan los joins, imprime desordenadamente
    thread me(mergecito,arr,cant);
    me.join();
    return 0;
}
