#include<iostream>
#include<thread>
#include<time.h>
#include <chrono>
using namespace std;

void numbers(int n){
    for(int i=0;i<n;i++){
        cout<<"iteracion numero "<<i<<endl; //itera
    }
    cout<<"\n";
    cout<<"el parametro de entrada es: "<<n<<endl;
    cout<<"\n\n\n";
    this_thread::sleep_for(chrono::milliseconds(1000)); //delay 
}

int main(){
    srand(time(NULL));
    int n = rand()%100;
    int k = rand()%100;
    thread num(numbers,n);
    //num.join();
    thread num2(numbers,k);
    //num2.join();
    return 0;
}
