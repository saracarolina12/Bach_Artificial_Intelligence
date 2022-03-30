#include <bits/stdc++.h>
using namespace std;

priority_queue<int> L, H;
int n, num;
double median;

int main() {
  scanf("%d", &n);
  for (int i = 0; i < n; i++) {
    scanf("%d", &num);
    if (i == 0) {
      L.push(num);
      median = num;
    } else {
      if (num <= L.top()) {
        L.push(num);
      } else {
        H.push(-num);
      }
    }

    if ((int)L.size() - (int)H.size() >= 2) {
      num = L.top();
      L.pop();
      H.push(-num);
    } else if((int)H.size() - (int)L.size() >= 2) {
      num = H.top() * -1;
      H.pop();
      L.push(num);
    }

    if ((int)L.size() > (int)H.size()) {
      median = L.top();
    } else if ((int)L.size() < (int)H.size()) {
      median = H.top() * -1;
    } else {
      median = (L.top() - H.top()) / 2.0;
    }

    printf("%.1lf\n", median);
  }

  return 0;
}