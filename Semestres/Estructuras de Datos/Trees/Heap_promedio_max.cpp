#include<bits/stdc++.h>
using namespace std;
int main(){
	double n, k, suma=0;
	priority_queue<double> h;
	double x;
	cin>>n>>k;
	for(int i=0; i<n; i++){
		cin>>x;
		if(h.size() < k){
			h.emplace(-x);
			suma += x;
		}else if(x > -h.top()){
			suma -= -h.top();
			suma += x;
			h.emplace(-x);
			h.pop();
		}
		cout<<fixed<<setprecision(2)<<suma/h.size()<<endl;	
	}
	return 0;
}