#include <bits/stdc++.h>

using namespace std;

/*
	memoria: O(n)
	tiempo: O(n)
*/
string reverse_v1(string s){
	string x="";
	for(int i=(int)s.size()-1; i>=0; i--){
		x+=s[i];
	}
	return x;
}

/*
	memoria: O(1)
	tiempo: O(n)
*/
string reverse_v2(string s){ //anroliac
	int k=(int)s.size()-1;
	for(int i=0; i<((int)(s.size()))/2; i++){
		char x = s[i]; //a
		s[i] = s[k];
		s[k] = x;
		k--;
	}
	return s;
}

int main() {
	string s = "carolina";
	cout<<"Version 1: "<<reverse_v1(s)<<endl;
	cout<<"Version 2: "<<reverse_v2(s)<<endl;
    return 0;
}

/*
	1-10 -> [1,2,3,4,5,6,7,8,9,10]
	pilas - stack(max 3)
	
	a = []
	b = [0,1,2,3,4,6,8,9,10]
	c = []
	-------------------------------
	recibe string, y reverse
	caras
	sarac
	x=aras
*/
