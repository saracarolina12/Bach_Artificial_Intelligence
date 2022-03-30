#include<iostream>
using namespace std;
int main(){
  int sum=0,a=0;
  for(int i=1;i<=10000;i++){
      sum=0;
      a=i;
      while(a>0){
          sum=sum+(a%10);
          a=a/10;
      }
      if(i%sum==0){
          cout<<i;
      }
  }
}
