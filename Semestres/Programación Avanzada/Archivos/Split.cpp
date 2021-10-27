#include<iostream>
#include<fstream>
#include<string.h>
#include<string>
#include<vector>
#include<stdlib.h>

using namespace std;

void leer(vector <string>&v,string a){
    string text1;
    ifstream arch1;
       arch1.open(a,ios::in); 
        if(arch1.fail()){
            cout<<"No se puede ver el archivo 1";
            return;
        }
        while(!arch1.eof()){
            string datos1;
            getline(arch1,datos1);
            v.push_back(datos1);
        }
        arch1.close();
}

void escribir(vector <string> &v1){
    ofstream arch3;
    if(arch3.fail()){
        cout<<"No se puede abrir el archivo 3"<<endl;
        exit(1);
    }
    arch3.open("f3.txt",ios::out);
    for(int i=0;i<v1.size();i++){
        string datos3 = v1[i];
        fflush(stdin);
        arch3<<datos3<<endl;
    }
    arch3.close();
}

vector <string> separate(string s, string d){
    vector<string> numeros;
    size_t pos = 0;
    string token;
    while ((pos = s.find(d)) != string::npos ) {
        token = s.substr(0, pos);
        numeros.push_back(token);
        s.erase(0, pos + d.length());
    }
    numeros.push_back(s);
    return numeros;
}

string sameornot(string v1, string v2, int x){
    int size=0;
    vector <string> split1;
    vector <string> split2;
    string temp="";
    split1=separate(v1,":");
    split2=separate(v2,":");

    if(split1.size()<=split2.size()){
        size = split1.size();
    }
    else{
        size = split2.size();
    }

    for(int j=0;j<size;j++){
        bool b=false;
        if(split1[j]==split2[j]){
            b = true;
        }
        if(b==false){
            if(j>0){
                temp=temp+":";
            }
            temp+=split1[j];
            temp+=":";
            temp+=split2[j];
        }
    }
    cout<<temp<<endl;
    split1.clear();
    split2.clear();
    return temp;
}

int main(){
    string arc1,arc2;
    arc1="f1.txt";
    arc2="f2.txt";
    vector <string> a1;
    vector <string> a2;
    vector <string> a3;
    int size_arch;
    leer(a1,arc1);
    leer(a2,arc2);
    if(a1.size()<=a2.size()){
        size_arch = a1.size();
    }else{
        size_arch = a2.size();
    }
    fflush(stdin);
    for(int i=0;i<size_arch;i++){
        a3.push_back(sameornot(a2[i],a1[i],i));
    }
    escribir(a3);
    return 0;
}
