#include <iostream>
#include <thread>
using namespace std;
void foo(int a){
    cout << a << '\n';
}
int main(){
    // Create and execute the thread
    thread thread(foo, 10); // foo is the function to execute, 10 is the argument to pass to it
    // Keep going; the thread is executed separately
    // Wait for the thread to finish; we stay here until it is done
    thread.join();
    /*for(int i=0;i<100;i++){
        cout<<"Hi from main"<<endl;
    }*/
    return 0;
}
