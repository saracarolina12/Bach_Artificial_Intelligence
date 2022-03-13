//mediana
#include<bits/stdc++.h>
using namespace std;
int main(){
	int n;
	cin>>n;
	priority_queue<double> maxh;
	priority_queue<double, vector<double>, greater<double> > minh;
	vector<double> mn(n/2), mx(n/2), a(n);
	for(int i=0; i<n; i++)
		cin>>a[i];
	sort(a.begin(), a.end());
	for(int i=0; i<n/2; i++){
		maxh.push(a[i]);
		//cout<<maxh.top()<<" ";
	}
	for(int i=n/2; i<int(a.size()); i++){
		minh.push(a[i]);
		//cout<<minh.top()<<" ";
		//minh.pop();
	}
	if(int(minh.size()) == int(maxh.size())) cout<<(minh.top()+maxh.top())/2;
	else{
		if(int(minh.size()) > int(maxh.size())){
			cout<<minh.top()<<endl;
		}else{
			cout<<maxh.top()<<endl;
		}
	} 
	
	return 0;
}