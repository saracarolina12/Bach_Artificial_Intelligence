#include <iostream>
#include <string>
using namespace std;

///////////////////////////Singly Linked List
class SinglyLinkedList{
public:
            class Node{
                  public:
                    int data;
                    Node* next;
                    Node(int data){
                        cout<<"  Node("<<data<<")"<<endl;
                        this->data = data;
                        this->next = nullptr;
                    }
                    ~Node(){
                        cout<<"  ~Node("<<data<<")"<<endl;
                    }
                    friend ostream& operator<<(ostream& output,const Node& n){
                        output<< "(data:"<< n.data <<" next:"<< n.next <<")";
                        return output;
                    }
            };

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
    void insert_head(int data){
        SinglyLinkedList::Node* n = new Node(data);
        if(head==nullptr){
            head = n;
        }else{
            n->next = head;
            head = n;
        }
    }
    void insert_tail(int data){
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
    void remove(int data){
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
};

///////////////////////////Doubly Linked List
class DoublyLinkedList{
    public:
       class Node{
          public:
                int data;
                Node* prev;
                Node* next;
                Node(int data){
                        cout<<"   Node("<<data<<")"<<endl;
                        this->data = data;
                        this->prev = nullptr;
                        this->next = nullptr;
                }
                ~Node(){
                        cout<<"  ~Node("<<data<<")"<<endl;
                }
                friend ostream& operator<<(ostream& output,const Node& n){
                        output<< "(data:"<< n.data <<" prev:"<< n.prev <<" next:"<<n.next<<")";
                      // output<< "\n(data:"<< n.data <<" prev:"<< n.prev <<" next:"<<n.next<<")\n";
                        return output;
                }
       };
       DoublyLinkedList::Node* first;
       DoublyLinkedList::Node* last;
       DoublyLinkedList(){
           first = nullptr;
           cout<<" DoublyLinkedList()"<<endl;
       }

       ~DoublyLinkedList(){
           cout<<" ~DoublyLinkedList()"<<endl;
           if(first == nullptr){
               return;
           }
            DoublyLinkedList::Node* aux= first;
            DoublyLinkedList::Node* aux2=aux->next;
            while(aux != nullptr){
                delete aux;
                aux = aux2;
                if(aux2 != nullptr){
                    aux2 = aux2->next;
                }
            }
       }

       void push_front(int data){
           DoublyLinkedList::Node* n = new Node(data);
           if(first == nullptr){
               first = n;
               last = n;
           }
           else{
               n->next = first;
               first->prev = n;
               first = n;
           }
       }

       void push_back(int data){
           DoublyLinkedList::Node* n = new Node(data);
           if(first == nullptr){
               first=n;
               last=n;
           }else{
               last->next = n;
               n->prev = last;
               last = n;
           }
       }

       void pop_front(){
           if(first ==  nullptr)return;
           if(first==last){
               delete first;
               first = nullptr;
               last = nullptr;
           }
           else{
               DoublyLinkedList::Node* aux = first;
               first->next->prev = nullptr;
               first = first->next;
               delete aux;
           }

       }

       void pop_back(){
           if(first == nullptr)return;
           if(first==last){
               delete first;
               first = nullptr;
               last = nullptr;
           }else{
               DoublyLinkedList::Node* aux = last;
               last->prev->next = nullptr;
               last = last->prev;
               delete aux;
           }
       }

       void print_reverse(){
           if(first == nullptr)return;   //10,8,6------> 6,8,10
           string s;
           DoublyLinkedList::Node* aux = last;
           while(aux->next!=nullptr){
               s+=to_string(aux->data);
               //cout<<aux->data<<",";
               aux = aux->prev;
           }
           cout<<s;
       }


       void remove(int data){
           if(first==nullptr)return;
           if(first==last){
               if(first->data == data){
                   pop_front();
                   return;
               }else{
                   return;
               }
           }
           if(first->data == data){
               pop_front(); return;
           }
           if(last->data==data){
               pop_back(); return;
           }

           DoublyLinkedList::Node* aux = first;
           while(aux != nullptr){
               if(aux->data == data){
                   break;
               }
               aux = aux->next;
           }
           if(aux == nullptr)return;
           aux->prev->next = aux->next;
           aux->next->prev = aux->prev;
           delete aux;
       }

       friend ostream& operator<<(ostream& output,const DoublyLinkedList& doubly){
        output<< "[";
        if( doubly.first != nullptr){
            DoublyLinkedList::Node* aux = doubly.first;
            while( aux != NULL){
                output<< (*aux);
                aux = aux->next;
            }
        }
        output<< "]";
        return output;
    }

    void print_memory(){
        cout<<"[ first:"<<first<<" last:"<<last;
        if( first != nullptr){
            DoublyLinkedList::Node* aux = first;
            while( aux != NULL){
                cout<<" ("<< aux->data<<":"<<aux<<" prev:"<<aux->prev<<" sig:"<<aux->next<<")";
                aux = aux->next;
            }
        }
        cout<< "]"<<endl;
    }
};

///////////////////////////Circular Linked List
class CircularLinkedList{
    public:
          class Node{
              public:
                int data;
                Node* next;
                Node(int data){
                    cout<<"  Node("<<data<<")"<<endl;
                    this->data = data;
                    this->next = nullptr;
                }
                ~Node(){
                    cout<<"  ~Node("<<data<<")"<<endl;
                }
                friend ostream& operator<<(ostream& output, const Node& n){
                    output<<"(data:"<<n.data<<" next:"<<n.next<<")";
                    return output;
                }
          };
    CircularLinkedList::Node* head;
    CircularLinkedList(){
        head = nullptr;
        cout<<" CircularLinkedList()"<<endl;
    }
    ~CircularLinkedList(){
        cout<<" ~CircularLinkedList()"<<endl;
        if(head == nullptr){
            return;
        }
        CircularLinkedList::Node* aux = head;
        CircularLinkedList::Node* aux2 = aux->next;
        while(aux != head){
            delete aux;
            aux=aux2;
            if(aux2 !=head){
                aux2 = aux2->next;
            }
        }
    }

    void insert_head(int data){
        CircularLinkedList::Node* n= new Node(data);
        if(head == nullptr){
            head = n;
            n->next = head;
        }else{
            CircularLinkedList::Node* aux=head;
            while(aux->next != head){
                aux = aux->next;
            }
            aux->next = n;
            n->next = head;
            head = n;
        }
    }

    void insert_tail(int data){
        CircularLinkedList::Node* n=new Node(data);
        if(head == nullptr){
            head= n;
        }else{
            CircularLinkedList::Node* aux = head;
            while(aux->next != head){
                aux = aux->next;
            }
            aux->next = n;
        }
        n->next = head;
    }

       void remove(int data){
        if(head == nullptr){ //lista nula
            return;
        }
        if(head->next == head){ //sólo un caso
            CircularLinkedList::Node* aux = head;
            if(head->data ==data){
             head = nullptr;
             delete aux;
             return;
           }
        }else{ //si hay más de un nodo
            if(head->data == data){
                CircularLinkedList::Node* aux = head;
                while(aux->next != head){
                    aux = aux->next;
                }
                CircularLinkedList::Node* erase = aux->next;
                //aux->next = head->next;
                head = aux->next = aux->next->next;
                delete erase;
                return;
                
            }else{ //para borrar cualquier otro que no se encuentre en la cabeza
                CircularLinkedList::Node* aux = head;
                while(aux->next != head){
                    if(aux->next->data == data){
                        CircularLinkedList::Node* erase = aux->next;
                        aux->next = aux->next->next;
                        delete erase;
                        return;
                    }
                    aux = aux->next;
                }    
            }

        }
        
    }

    void print_memory(){
        cout<<"[ head:"<<head<<endl;
        if(head!=nullptr){
                CircularLinkedList::Node* aux = head;
                while(1){
                    cout<<" ("<< aux->data<<":"<<aux<<" sig:"<<aux->next<<")"<<endl;
                    aux = aux->next;
                    if(aux==head) break;

                }
        }
        cout<< "]"<<endl;
    }

friend ostream& operator<<(ostream& output,const CircularLinkedList& circular){
        output<< "[";
       CircularLinkedList::Node* aux = circular.head;
        if(aux ==nullptr){
            output<<"[]";
        }
        else if(aux->next == aux){
            output<<"[";
            output<<(*aux);
            output<<"]";
        }else{
            output<<"[";
            output<<(*aux);
            aux = aux->next;
            while(aux!=circular.head){
                output<<(*aux);
                aux=aux->next;
            }
            output<< "]";
        }

        return output;
    }


};

int main(){
    /*SinglyLinkedList singly;
    cout<<"Lista Singly:"<<singly<<endl;
    singly.insert_head(1);
    singly.insert_head(2);
    singly.remove(2);
    cout<<"FIN SINGLY"<<endl;
    cout<<"\n\n";*/


   /* DoublyLinkedList doubly;
    cout<<"Lista Doubly: "<<endl;
    doubly.push_front(6);             //1,2,4,6
    doubly.push_front(4);
    doubly.push_front(2);
    doubly.push_front(1);
    //doubly.print_reverse();
    doubly.remove(6);
    cout<<"FIN DOUBLY"<<endl;
    cout<<"\n\n";*/


    CircularLinkedList circular;
    cout<<"Lista Circular: "<<endl;
    circular.insert_tail(2);
    circular.insert_tail(4);
    circular.insert_tail(6);
   // circular.print_memory();

    circular.remove(4);
   // circular.print_memory();
    cout<<"FIN CIRCULAR"<<endl;

}