#include<iostream>
using namespace std;

template<class Q>
class Queue{
    public:
      class Node{
          public:
            Q data;
            Node* next;
            Node(Q data){
                cout<<" "<<data<<endl;
                  this->data = data;
                  this->next = nullptr;
            } 
            ~Node(){
                  cout<<"~"<<data<<endl;
              }
            friend ostream& operator<<(ostream& output, const Node &n){
                 output<< "(data:"<< n.data <<" next:"<< n.next <<")";      
                 return output;
                 
            }
      };
    Node *first;
    Node *last;
    Queue(){
        //cout<<"  Queue()"<<endl;
        first = nullptr;
        last = nullptr;
    }
    ~Queue(){
        //cout<<"  ~Queue()"<<endl;
        if(first == nullptr && last == nullptr){
            return;
        }
        Node* aux = first;
        Node* aux2 = aux->next;
        while(aux != nullptr){
            delete aux;
            aux = aux2;
            if(aux2 !=nullptr){
                aux2 = aux2->next;
            }
        }
    }

    void push(Q data){
        Node* n = new Node(data);
        if(first == nullptr && last == nullptr){
            first=n;
            last=n;
        }
        else{
            last->next = n;
            last = n;
        }
    }

Q pop(){
        if(first == nullptr && last == nullptr){
            return 0;
        }
        if(first->next == nullptr){
            Node* aux = first;
            first = nullptr;
            last = nullptr; //<-Esto faltaba
            delete aux;
            return aux->data;
        }
        else{
            //cout<<"\nfirst: "<<first->data<<endl;
            Node* aux = first;
            first = first->next;
            delete aux;
            return aux->data;
        }
    }

    Q front(){
        if(first == nullptr){
            return 0;
        }
        else{
            Node* aux = first;
      //      cout<<"Elemento front:"<<aux->data<<endl;
            return aux->data;
        }

    }

    bool isEmpty(){
        if(first == nullptr && last == nullptr){
       //     cout<<"Queue is empty"<<endl;
            return true;
        }
        else{
           // cout<<"Queue is not empty"<<endl;
            return false;
        }
    }


 
};

int main(){
    Queue<int> qu;
    qu.push(1);
    qu.push(3);
    qu.push(6);
    

    //qu.isEmpty();
   // qu.front();
    qu.pop();
    /*cout<<"pop: "<<qu.pop()<<endl;
    cout<<"front: "<<qu.front()<<endl;
    cout<<"empty: "<<qu.isEmpty()<<endl;*/
}