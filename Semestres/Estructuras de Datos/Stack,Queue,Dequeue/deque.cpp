#include<iostream>
using namespace std;

template<class D>
class Deque{
    public:
       class Node{
           public: 
              D data;
              Node* next;
              Node* prev;
              Node(D data){
                  cout<<" "<<data<<endl;   
                  this->data = data;
                  this->next = nullptr;
                  this->prev = nullptr;
              }
              ~Node(){
                  cout<<"\n~"<<data<<" ";
              }
              friend ostream& operator<<(ostream& output, const Node &n){
                 output<< "(data:"<< n.data<<"prev:"<<n.prev<<" next:"<< n.next <<")";        
                 return output;
            }
       };

       Node* first;
       Node* last;
       Deque(){
           //cout<<"  Deque()"<<endl;
           first = nullptr;
           last = nullptr;
       }
       ~Deque(){
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
    void push_front(D data){
        if(first == nullptr && last == nullptr){
            Node* n = new Node(data);
            first = n;
            last = n;
        }
        else{
            Node* n = new Node(data);
            n->next = first;
            first->prev = n;
            first = n;
        }
    }

    void push_back(D data){
        if(first == nullptr && last == nullptr){
            Node* n = new Node(data);
            first = n;
            last = n;
        }
        else{
            Node* n = new Node(data);
            n->prev = last;
            last->next = n;
            last = n;
        }
    }

    D pop_front(){
        if(first == nullptr && last == nullptr){
            return 0;
        }
        else if(first == last){
            Node* aux = last;
            last = nullptr;
            first = nullptr;
            delete aux;
            return aux->data;  
        }
        else{
            Node* aux = first;
            first = first->next;
            first->prev = nullptr;
            delete aux;
            return aux->data;
        }

    }

    D pop_back(){
        if(first == nullptr && last == nullptr){
            return 0;
        }
        else if(first==last){
            Node* aux = last;
            last = nullptr;
            first = nullptr;
            delete aux;
            return aux->data;
        }
        else{
            Node* aux = last;
            last = last->prev;
            last->next = nullptr;
            delete aux;
            return aux->data;
        }
    }

    D front(){
        if(first == nullptr && last == nullptr){
            return 0;
        }
        else{
            Node* aux = first;
            return aux->data;
        }
    }

    D back(){
        if(first == nullptr && last == nullptr){
            return 0;
        }
        else{
            Node* aux = last;
            return aux->data;
        }
    }

    bool isEmpty(){
        if(first == nullptr && last == nullptr){
            return true;
        }
        else{
            return false;
        }
        
    }

    void print_memory(){
        cout<<"\n\t*first:"<<first<<"\t*last:"<<last<<endl;
        if( first != nullptr){
            Deque::Node* aux = first;
            while( aux != NULL){
                cout<<"\t ["<< aux->data<<":"<<aux<<" ||prev:"<<aux->prev<<" ||sig:"<<aux->next<<"]"<<endl;
                aux = aux->next;
            }
        }
    }
};  
int main(){
    Deque<int> dq;
    dq.push_front(6);
 //   dq.push_front(3);
 //   dq.push_front(1);
    dq.print_memory();
    cout<<"\n";
    cout<<"\t*Front: "<<dq.front()<<endl;
    cout<<"\t*Back:  "<<dq.back()<<endl;
    cout<<"\t*Empty?: "<<dq.isEmpty()<<endl;
   // cout<<"\t*pop back: "<<dq.pop_back()<<endl;
  //  cout<<"\t*pop front: "<<dq.pop_front()<<endl;

    dq.print_memory();

    
    
}