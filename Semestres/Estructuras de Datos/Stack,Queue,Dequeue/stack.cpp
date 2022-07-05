#include<iostream>
using namespace std;

template<class S>
class Stack{
    public: 
       class Node{
           public:
             S data;
             Node* next;
             Node(S data){
                 cout<<"    \t\t ("<<data<<")"<<endl;
                 this->data = data;
                 this->next = nullptr;
             }
             ~Node(){
                 cout<<"   \t\t~("<<data<<")"<<endl;
             }
             friend ostream& operator<<(ostream& output, const Node &n){
                 output<<"(data:"<< n.data <<" next:"<< n.next <<")";   
                 return output;
             }
       };

    Node *first;
    Stack(){
        first = nullptr;
       // cout<<"  Stack()"<<endl;
    }
    ~Stack(){
        //cout<<"   ~Stack()"<<endl;
        if(first == nullptr){
            return;
        }
        Node* aux = first;
        Node* aux2 = aux->next;
        while(aux != nullptr){
            delete aux;
            aux = aux2;
            if(aux2 != nullptr){
                aux2 = aux2->next;
            }
        }
    }

    void push(S data){
        Node* n = new Node(data);
        if(first == nullptr){
             first = n;
             return;
        }
        else{
            n->next = first;
            first = n;
        }
    }

    S top(){
        if(first == nullptr){
            return 0;
        }
        else{
            Node* aux = first;
        //    cout<<"Elemento top: "<<aux->data;
            cout<<"\n";
            return aux->data;
        }
    }

    S pop(){
        if(first == nullptr){
            return 0;
        }
        if(first->next == nullptr){
            Node* aux = first;
       //     cout<<"Elemento eliminado:";
            first = nullptr;
            delete aux;
            return aux->data;
        }
        else{
            Node* aux = first;
            first = first->next;
       //     cout<<"Elemento eliminado:";
            delete aux;
            return aux->data;
        }
    }

    bool isEmpty(){
        if(first == nullptr){
         //   cout<<"Is Empty"<<endl;
            return true;
        }
        else{
         //   cout<<"Is not Empty"<<endl;
            return false;
        }
    }

};

int main(){
    Stack<int> st;
    st.push(1);
    st.push(9);
    st.push(3);
    //st.push(10);

    st.isEmpty();
    st.top();
    st.pop();

     cout<<"\n";

}