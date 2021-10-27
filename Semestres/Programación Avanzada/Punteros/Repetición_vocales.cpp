#include<iostream>
#include<string.h>
using namespace std;
int main(){
    char str[40] ={0};
    int a=0,e=0,i=0,o=0,u=0;
    cout<<"Digite una palabra: ";
    cin.get(str,40); 
    int len = strlen(str); 
    for(int idx=0;idx<len;idx++){
        if(*(str+idx)=='a'||*(str+idx)=='A'){a++;}
        else if(*(str+idx)=='e'||*(str+idx)=='E'){e++;}
        else if(*(str+idx)=='i'||*(str+idx)=='I'){i++;}
        else if(*(str+idx)=='o'||*(str+idx)=='O'){o++;}
        else if(*(str+idx)=='u'||*(str+idx)=='U'){u++;}
    }
    cout<<"Hay "<<a<<" a";
    cout<<"\nHay "<<e<<" e";
    cout<<"\nHay "<<i<<" i";
    cout<<"\nHay "<<o<<" o";
    cout<<"\nHay "<<u<<" u";
    return 0;
}
