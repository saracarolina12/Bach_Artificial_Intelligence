//Binary Search
#include <bits/stdc++.h>
using namespace std;

int BinarySearch(int arr[], int n, int x){
    int low=0, high =n-1;
    while(low<=high){
    	int mid = (low+high)/2;
    	if(x == arr[mid]) return mid;
    	else if(x<arr[mid]) high = mid-1;
    	else low = mid+1;
    }
    return -1;
}

int main(){
    int arr[] = {1,2,7,8,10,100,230,4000};
    int x;
    cin>>x; //number to search
    int ans = BinarySearch(arr,8, x);
    if(ans == -1) cout<<"Not found";
    else cout << "At index "<<ans;
}

