#include<iostream>
#include<map>
#include<string>

using namespace std;

class Person{
    private: 
        string name;
        int age;
    public:
        Person():name(""),age(0){
         }
        Person(string name,int age): name(name),age(age){
        }
        void print() const{
            cout<<name<<":"<<age<<flush;
        }
        
        //persona1 == persona2
        bool operator<(const Person &other) const{
            if(name == other.name){
                return age < other.age;
            }else{
                return name < other.name;
            }
        }
};

int main(){
    map<Person,int> people;
    people[Person("Cristi",18)] = 40;
    people[Person("Frabrizio",18)] = 1;
    people[Person("Sebastian",18)] = 30;
    people[Person("Cristi",18)] = 90;

    for(map<Person,int>::iterator it = people.begin(); it != people.end(); it++){
       cout<<it->second<< ": ";
       it->first.print();
       cout<<endl;
    }


    return 0;
}
