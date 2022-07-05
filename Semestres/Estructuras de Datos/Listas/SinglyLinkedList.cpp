#include <iostream>
#include <string>
using namespace std;

template<class T>
///////////////////////////Singly Linked List
class SinglyLinkedList{
public:
            class Node{
                  public:
                    T data;
                    Node* next;
                    Node(T data){
                        cout<<"  Node("<<data<<")"<<endl;
                        this->data = data;
                        this->next = nullptr;
                    }
                    ~Node(){
                        cout<<"  ~Node("<<data<<")"<<endl;
                    }
                    friend ostream& operator<<(ostream& output,const Node& n){
                        output<< "(data: "<< n.data <<", next: "<< n.next <<")";
                        return output;
                    }
            };
    friend ostream& operator<<(ostream& output,const SinglyLinkedList& singly){
        output<< "[";
        if( singly.head != nullptr){
            SinglyLinkedList::Node* aux = singly.head;
            while( aux != NULL){
                output<< (*aux);
                aux = aux->next;
            }
        }
        output<< "]";
        return output;
    }

    SinglyLinkedList::Node* head;
    SinglyLinkedList(){
        head = nullptr;
        cout<<"  SinglyLinkedList()"<<endl;
    }
    ~SinglyLinkedList(){
        cout<<"  ~SinglyLinkedList()"<<endl;
        if( head == nullptr )
            return;
        SinglyLinkedList::Node* aux = head;
        SinglyLinkedList::Node* aux2 = aux->next;
        while( aux != nullptr){
            delete aux;
            aux = aux2;
            if( aux2 != nullptr ) aux2 = aux2->next;
        }
    }
    void insert_head(T data){
        SinglyLinkedList::Node* n = new Node(data);
        if(head==nullptr){
            head = n;
        }else{
            n->next = head;
            head = n;
        }
    }
    void insert_tail(T data){
        SinglyLinkedList::Node* n = new Node(data);

        if( head == nullptr ){
            head = n;
        }else{
            SinglyLinkedList::Node* aux = head;
            while( aux->next != NULL){
                aux = aux->next;
            }
            aux->next = n;
        }
    }
    void remove(T data){
        if( head == nullptr ) return;
        if( head->data == data){
            SinglyLinkedList::Node* ndelete = head;
            head = head->next;
            delete ndelete;
            return;
        }else{
            SinglyLinkedList::Node* aux = head;
            while( aux!=nullptr && aux->next!=nullptr && aux->next->data != data )
                aux = aux->next;

            if( aux->next!=nullptr && aux->next->data == data  ){
                SinglyLinkedList::Node* ndelete = aux->next;
                aux->next = aux->next->next;
                delete ndelete;
            }
        }
    }
    
    void reverse(){
        Node *prev = NULL, *now = head, *next = NULL;
        if(head == NULL)return;

        while(now != NULL){
            next = now->next;
            now->next = prev;
            prev = now;
            now = next;
        }
        head = prev;

    }    
};


int main(){
    SinglyLinkedList<int>singly;
    cout<<"Lista Singly:"<<endl;
    singly.insert_head(4);
    singly.insert_head(3);
    singly.insert_head(2);
    singly.insert_head(1);
    cout<<"\t\tList: "<<singly<<endl<<endl;
    

    singly.reverse();
    cout<<"Reversed Linked List\n";
    cout<<"\t\tReversed: "<<singly<<endl;
}