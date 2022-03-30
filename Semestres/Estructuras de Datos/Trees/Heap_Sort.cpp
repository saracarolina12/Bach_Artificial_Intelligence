//heap
#include<bits/stdc++.h>
using namespace std;
int main(){
	int n; //cant numeritos
	cin>>n;
	int arr[n+2]={0}; //para guardar los numeritos
	for(int i=0; i<n; i++)
		cin>>arr[i];
	//construir y reordenar
	for(int i=1; i<=n; i++){
		int izq = (2*i)+1, der = (2*i)+2, dad = (i-1)/2;
		cout<<"dad: "<<arr[dad]<<endl;
		cout<<"izq: "<<arr[izq]<<endl;
		cout<<"der: "<<arr[der]<<endl;
		cout<<endl;
		if(izq >=n ){
			return 0;
		}
		int maxChild = izq;
		if(der < n && arr[der] > arr[izq]){
			maxChild = der;
		}
		
		if(arr[i] < arr[maxChild]){
			swap(arr[i], arr[maxChild]);
			arr[i] = maxChild;
		}else{
			break;
		}
	}
	
	for(int i=0; i<n; i++)
		cout<<arr[i]<<" ";
	return 0;
}
