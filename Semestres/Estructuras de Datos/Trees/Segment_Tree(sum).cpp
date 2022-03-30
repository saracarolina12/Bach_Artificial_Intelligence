//Segment Tree
#include<bits/stdc++.h>
using namespace std;
using ll = long long;
//1e5 = 10^5
const int N = 2e5;  // limit for array size
int n;  // array size
ll t[2 * N];

void build() {  // build the tree
  for (int i = n - 1; i > 0; --i)
  	t[i] = t[i<<1] + t[i<<1|1];
}

void modify(int p, ll value) {  // set value at position p
  for (t[p += n] = value; p > 1; p >>= 1) t[p>>1] = t[p] + t[p^1];
}
ll query(int l, int r) {  // sum on interval [l, r)
  ll res = 0;
  for (l += n, r += n; l < r; l >>= 1, r >>= 1) {
    if (l&1) res += t[l++];
    if (r&1) res += t[--r];
  }
  return res;
}

int main(){
	int q;
	cin >> n >> q;
	for(int i = 0; i< n; i++)
		cin >> t[i + n];
	build();
	for(int p, x, y, i = 0; i < q; i++){
		cin>>p>>x>>y;
		if(p == 0) modify(x, y);
		else cout<<query(x, y+1)<<'\n';
	}
	return 0;
}
