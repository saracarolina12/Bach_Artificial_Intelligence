#include <bits/stdc++.h>

using namespace std;

bool validIP(string ip){//1..2.2
	string temp = "";   //1
	int count=1; 		//3
	int dots = 0;//2
	for(int i=0; i<(int)ip.size(); i++){
		if(ip[i] == '.' || ((int)ip[i] >=48 && (int)ip[i] <=	57)){
			if(ip[i] != '.'){
				temp += ip[i];
			}else if(ip[i] == '.' || count == 4){
				dots++;
				if(dots>1) return false;
				dots = 0;
				count++;
				int x = stoi(temp); //190
				temp = "";
				if(x >= 0 && x<=255){
					continue;
				}
				else{
					return false;
				}
			}
		}else{
			return false;
		}
	}
	if(count < 4 ||count > 4) return false;
	return true;
}

int main() {
	string ip="";
	cin>>ip;
	string result = (validIP(ip) == 1)? "Valid :)" : "Not Valid >:v";
	cout<<result;
    return 0;
}