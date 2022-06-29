#include<iostream>
using namespace std;


template<class A>
class AVL{
    public:
    class Node{
        public:
        A data;
        int balance=0;
        int height=1;
        Node* left;
        Node* right;
        Node* parent;
        Node(A data){
            cout<<"\t"<<data<<endl;
            this->data = data;
            this->left = nullptr;
            this->right = nullptr;
            this->parent = nullptr;
        }
        ~Node(){
            cout<<"\t~"<<data<<endl;
        }

        string print_node(){
            string s=to_string(data);
            s+="---->[h:"+to_string(height);
            s+=" b:"+to_string(balance)+"]";
            return s;
        }

        Node* insert(Node* n,Node* root){
            if(n->data <= data){
                if(left == nullptr){
                    left = n;
                    n->parent = this; 
                }else{
                    left->insert(n,root);
                }
            }else{
                if(right == nullptr){
                    right = n;
                    n->parent = this; 
                }else{
                    right->insert(n,root);
                }  
            }
            return mbalance(root);
        }

        Node* rotate_left(Node* n,Node* root){
            Node* parent = n->parent;
            Node* a = n;
            Node* b = n->right;
            Node* s2 = b->left;

            a->right = s2;
            if(s2 != nullptr){
                s2->parent = a;
            }

            b->left = a;
            a->parent = b;

            b->parent = parent;

            if(parent == nullptr){
                root = a->mbalance(root);
                root = b->mbalance(root);
                return b;
            }
            else if(parent->left == a){
                parent->left = b;
            }
            else if(parent->right == a){
                parent->right=b;
            }

            root = a->mbalance(root);
            root = b->mbalance(root);
            return root;
        }

        Node* rotate_right(Node* n, Node* root){
            Node* parent = n->parent;
            Node* a = n;
            Node* b = n->left;
            Node* s2 = b->right;

            a->left = s2;
            if(s2 != nullptr){
                s2->parent = a;
            }

            b->right = a;
            a->parent = b;

            b->parent = parent;

            if(parent == nullptr){
                root = a->mbalance(root);
                root = b->mbalance(root);
                return b; //regresa el nodo
            }
            else if(parent->left ==a){
                parent->left = b;
            }
            else if(parent->right == a){
                parent->right = b;
            }

            root = a->mbalance(root);
            root = b->mbalance(root);
            return root; //regresa la raíz
        }

        Node* mbalance(Node* root){
            int height_left;
            int height_right;
            height_left=(left==nullptr ? 0 : left->height);
            height_right=(right==nullptr? 0 : right->height);
            height = max(height_left+1,height_right+1);
            balance = height_left - height_right;

            if(balance<=-2 && right->balance<=0){
                root = rotate_left(this,root);
            }
            else if(balance<=-2 && right->balance==1){
                root = rotate_right(right,root);
                root = rotate_left(this,root);
            }
            else if(balance>=2 && left->balance==-1){
                root = rotate_left(left,root);
                root = rotate_right(this,root);
            }
            else if(balance>=2 && left->balance>=0){
                root= rotate_right(this,root);
            }
            return root;
        }

    };
    AVL::Node* root;
    
    //Node* root;
    AVL(){
        cout<<"\tAVL()"<<endl;
        root = nullptr;
    }

    ~AVL(){
        cout<<"\t~AVL()"<<endl;
        delete_post(root);
    }

    void delete_post(Node* n){
        if(n!=nullptr){
            if(n->left) delete_post(n->left);
            if(n->right) delete_post(n->right);
            delete n;
        }
    }

    string print_avl(string space, Node* n){
        string s;
      //  s = space+to_string(n->data)+"\n";
        s = space + n->print_node()+"\n";
        if(n->left != nullptr)s+=print_avl(space+" - ",n->left);
        if(n->right != nullptr)s+=print_avl(space+" - ",n->right);
        return s;
    }

    string print_node(){
        if(root == nullptr){
            return "";
        }else{
            return print_avl("",root);
        }
    }

    void insert(A data){
        AVL::Node* n = new Node(data);
        if(root == nullptr){
            root = n;
        }else{
            root = root->insert(n,root);   
        }
    }

    Node* getRoot(){
        return root;
    }


    Node* search(A data){
          if(root == nullptr){
              return NULL; 
          }
          Node* parent = nullptr;
          Node* n = root;
          while(1){
              if(data==n->data){
                  return parent;
              }
              else if(data < n->data){ //izquierda
                  parent = n;
                  n = n->left;
              }
              else if(data > n->data){
                  parent = n;
                  n = n->right;
              }
              if(n==nullptr){
                  return NULL; 
              }
          }
      }

      void __remove(Node* parent,Node* n){
          if((n->left == nullptr) && (n->right == nullptr)){  
              cout<<"\tCaso 1"<<endl;
              if(parent == nullptr) root = NULL;
              else if(parent->left == n) parent->left = NULL;
              else if(parent->right == n)parent->right = NULL;
          } 

          else if((n->left == nullptr && n->right != nullptr) || (n->left != nullptr && n->right == nullptr)){
              cout<<"\tCaso 2"<<endl;
              if(parent == nullptr){
                  if(n->left != nullptr) root = n->left;
                  else if(n->right != nullptr) root = n->right;
              }
              else if(parent->left == n){
                  if(n->left != nullptr) parent->left = n->left;
                  else if(n->right != nullptr) parent->right = n->right;   
              }else if(parent->right == n){
                  if(n->left != nullptr) parent->left = n->left;
                  else if(n->right != nullptr)parent->right = n->right;
              }
          }
          
          else if(n->left != nullptr && n->right != nullptr){
              cout<<"\tCaso 3"<<endl;
              Node* parent2 = n;
              Node* n2 = n->left;
              while(n2->right != nullptr){
                  parent2 = n2;
                  n2 = n2->right;
              }
             // cout<<"\t-Parent 2: "<<parent2->data<<" Node2: "<<n2->data<<endl;
              __remove(parent2,n2);
              n2->left = n->left;
              n2->right = n->right;
              if(parent == nullptr) root = n2;
              else if(parent->left == n) parent->left = n2;
              else if(parent->right == n) parent->right = n2;
          }

      }

      void remove(A data){
      Node *parent = search(data);
      Node* n;
      if(parent!=nullptr) {
          if(parent -> left && parent -> left -> data == data){
              n=parent->left;
          }else{
              n=parent->right;
          }
      }
      else{
          n = root;
      }
      if(!n || n->data!=data){
          return;
      }
     // cout<<"\t-Parent: "<<parent->data<<" Node: "<<n->data<<endl;
      __remove(parent, n);
      cout<<"\t**Delete "<<n->data<<"**"<<endl;
      delete n;

      //BALANCEO DESPUÉS DE ELIMINAR
      
      
    }


};


int main(){
    AVL<int> avl;
    cout<<"\n****ARBOLITO AVL****"<<"\n";
    /*avl.insert(10);
    avl.insert(5);
    avl.insert(1);
    cout<<avl.print_node()<<endl;*/


      string str = "SaraCarolinaGomezDelgado";   //BST for char
    for(auto i:str) avl.insert(i);

    /*avl.insert(9);
    avl.insert(10);
    avl.insert(1);
    avl.insert(13);
    avl.insert(14);
    avl.insert(15);*/
    cout<<"SIN REMOVE:\n"<<avl.print_node()<<endl;

    /*avl.remove(14);
    avl.remove(15);
    cout<<"REMOVE:\n"<<avl.print_node()<<endl;*/
}