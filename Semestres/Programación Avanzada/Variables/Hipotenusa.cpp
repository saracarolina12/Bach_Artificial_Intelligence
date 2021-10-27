#include<iostream>
#include <cmath>
using namespace std;
int main(){
    float cat1, cat2, hip;
    cout<<"Cateto 1: ";
    cin>> cat1;
    cout<<"Cateto 2: ";
    cin>> cat2;
    hip = sqrt(pow(cat1,2)+pow(cat2,2));
    cout<<hip<<'\n';
    return 0;
}
