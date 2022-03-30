#include<iostream>
#include<map>
#include<string>
using namespace std;

int main(){
    map<string,int> ages;

    ages["Mike"] = 40;
    ages["Roger"] = 20;
    ages["Ricardo"] = 21;

    ages.insert(make_pair("Caro",19));

    cout<<ages["Caro"]<<endl;

    if(ages.find("Sara") != ages.end()){
        cout<<"Found Sara"<<endl;
    }else{
        cout<<"Key not found Sara"<<endl;
    }

    for(map<string,int>::iterator it = ages.begin(); it != ages.end(); it++){
        pair<string, int> age = *it;
        cout<< age.first << ":" << age.second <<endl;
    }
    
    for(map<string,int>::iterator it = ages.begin(); it != ages.end(); it++){
       cout<< it->first << ":" <<  it->second  <<endl;
    }
    return 0;
}
