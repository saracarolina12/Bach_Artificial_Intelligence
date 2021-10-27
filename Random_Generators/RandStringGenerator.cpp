#include <bits/stdc++.h>
using namespace std;
#define N 26
#define FORI(n) for(int i=0; i<n; i++)
string randstr(int n){
    char abec[N]={'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
    string res = "";
    FORI(n)res += abec[rand()%N];
    return res;
}
int main(){
   srand(time(NULL));
   int n = 17;
   cout<<randstr(n);
   return 0;
}