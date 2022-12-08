/*
		C++ Priority queue
		Insert: O(logn)
		Delete: O(logn)
		Top: O(1)
*/

#include<bits/stdc++.h>
using namespace std;
int main(){
	//HEAP
	priority_queue<int> h;
	h.emplace(10);
	h.emplace(5);
	h.emplace(7);
	h.emplace(2);
	h.emplace(9);
	cout<<h.top()<<endl; //returns 10 ---> maximum number
	cout<<h.top()*-1<<endl; //returns -10 ---> minimum number
	return 0;
}