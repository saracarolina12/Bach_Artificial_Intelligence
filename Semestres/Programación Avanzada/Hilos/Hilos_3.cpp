#include <iostream> 
#include<string>
#include <thread> 
#include <chrono>
using namespace std; 

#define NUM_THREADS 5

void print(int n, const string &str)  {
  string msg = to_string(n) + " : " + str;
  cout << msg  << endl;
  this_thread::sleep_for(chrono::milliseconds(1000) );
}
 
int main() {
  string s[5] = {"IA", "IB", "IM", "II", "ITE"};
  thread threads[NUM_THREADS];
  for (int i = 0; i < NUM_THREADS; i++) {
        threads[i] = thread(print, i, s[i]);
  }
  for (int i = 0; i < NUM_THREADS; i++) {
        threads[i].join();
  }
  cout<<"Hi from main"<<endl;
  return 0;
}
