#include<iostream>
#include <cmath>
using namespace std;
int main(){
  float x,y;
  float fun;
  cout<<"X: ";
  cin>>x;
  cout<<"Y: ";
  cin>>y;
  fun = sqrt(x) / (pow(y,2)-1);
  cout<<fun;
 return 0;
}
