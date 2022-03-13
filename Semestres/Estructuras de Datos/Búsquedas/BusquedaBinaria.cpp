//Búsqueda Binaria
#include<bits/stdc++.h>
using namespace std;
int busqueda_binaria(vector<int> v,int val){
	int ini=0, fin=((int)v.size())-1, m=ini+(fin-ini)/2;
	while(ini <= fin){
		m = ini+(fin-ini)/2;
		if(v[m] == val) return m;
		else if(val < v[m]) fin = m-1;
		else ini = m+1;
	}
	return -1;
}
int main(){
	int len, val;
	cin>>len >> val;
	vector<int> v(len);
	for(int i=0; i<len; i++) cin>>v[i];
	sort(v.begin(), v.end());
	//for(int i=0; i<v.size(); i++) cout<<v[i]<<" ";
	//cout<<endl<<endl;
	//Búsqueda binaria
	cout<<busqueda_binaria(v, val)<<endl;
	return 0;
}

