#include<iostream>
#include<stack>
#include<queue>
using namespace std;

class BST{
    public:
      class Node{
          public:
            int data;
            Node* left;
            Node* right;
            Node(int data){
                cout<<" "<<data<<endl;
                  this->data = data;
                  this->left = nullptr;
                  this->right = nullptr;
            } 
            ~Node(){
                  cout<<"~"<<data<<endl;
              }
            friend ostream& operator<<(ostream& out, const Node &n){
                 out<<"data: "<<n.data<<"(left:"<< n.left <<" right:"<< n.right <<")"<<endl;      
                 return out;   
            }
      };

      Node *root;
      BST(){
          cout<<"\tBST()"<<endl;     
          root=nullptr;
      }

      ~BST(){
          cout<<"\t~BST()"<<endl;
          delete_post(root);
      }

      void delete_post(Node* n){
		if(n != nullptr){
			if(n->left != nullptr) delete_post(n->left);
			if(n->right != nullptr) delete_post(n->right);
			delete n;
		}
	  }

      void preOrder(Node* n){
          if(n != nullptr){
              cout<<n->data<<endl;
              preOrder(n->left);
              preOrder(n->right);
          }
      }

      void Order(Node* n){
          if(n != nullptr){
              Order(n->left);
              cout<<n->data<<endl;
              Order(n->right);
          }
      }

      void postOrder(Node* n){
          if(n != nullptr){
              postOrder(n->left);
              postOrder(n->right);
              cout<<n->data<<endl;
          }
      }


      void insert(int data){
          Node* n = new Node(data);
          if(root == nullptr){
              root = n;
          }else{
              Node* aux = root;
              while(1){
                  if(data<=aux->data){
                      if(aux->left == nullptr){
                          aux->left = n;
                          break;
                      }else{
                          aux = aux->left;
                      }
                  }else{
                     if(aux->right == nullptr){
                         aux->right = n;
                         break;
                     }else{
                         aux = aux->right;
                     }
                  }
              }
          }
      }

      bool contains(int data){
		if(root == nullptr){
			return false;
		}else{
			if(root->data == data){
				return true;
			}else{
				Node* aux = root;
				while(1){
					if(data <= aux->data){ //izquierda
						if(aux->left != nullptr){
							if(aux->left->data != data){
								aux = aux->left;
							}else{
								return true;
							}
						}else{
							return false;
						}
					}else{
						if(aux->right != nullptr){ //DERECHA
							if(aux->right->data != data){
								aux = aux->right;
							}else{
								return true;
							}
						}else{
							return false;
						}
					}
				}
			}
		}
	}


      string print(string space, Node* n){
          if(n == nullptr){
              return "";
          }
          string s = space+to_string(n->data)+"\n";
          s+= print(space+" - ",n->left);
          s+= print(space+" - ",n->right);
          return s;
      }

      string show(){
          return print("",root);
      }

      Node* getRoot(){
          return root; 
      }

      Node* search(int data){
          if(root == nullptr){
              return NULL; //sos
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
              cout<<"\t-Parent 2: "<<parent2->data<<" Node2: "<<n2->data<<endl;
              __remove(parent2,n2);
              n2->left = n->left;
              n2->right = n->right;
              if(parent == nullptr) root = n2;
              else if(parent->left == n) parent->left = n2;
              else if(parent->right == n) parent->right = n2;
          }

      }

      void remove(int data){
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
      cout<<"\t-Parent: "<<parent->data<<" Node: "<<n->data<<endl;
      __remove(parent, n);
      cout<<"\t**Delete "<<n->data<<"**"<<endl;
      delete n;
    }

      void BFS(){
          if(root==nullptr){
              return;
          }
          Node* lim = NULL;
          queue<Node*>q;
          q.push(root);
          q.push(lim);
          while(q.size()){
              Node* aux = q.front();
              q.pop();
              if(aux!=lim){
                  cout<<aux->data<<endl;
                  if(aux->left != nullptr){
                      q.push(aux->left);
                   }
                   if(aux->right != nullptr){
                      q.push(aux->right);
                   }
            }else{
                cout<<" "<<endl;
                if(q.empty() == true){
                    break;
                }
                q.push(lim);
            }
        }
    }

    void DFS(){
         if(root==nullptr){
              return;
          }
          Node* lim = NULL;
          stack<Node*>s;
          s.push(root);
          s.push(lim);
          while(s.empty()==false){
              Node* aux = s.top();
              s.pop();
              if(aux!=lim){
                  cout<<aux->data<<endl;
                   if(aux->right != nullptr){
                      s.push(aux->right);
                   }
                   if(aux->left != nullptr){
                      s.push(aux->left);
                   }
            }
        }
            
    }

    void invert(Node *node){ //mirror efect
        if(node==NULL) return;
        invert(node->left);
        invert(node->right);

        Node *temp=NULL;
        temp = node->left;
        node->left = node->right;
        node->right = temp;
    }
      
};

int main(){
    BST bst;

    bst.insert(50);
    bst.insert(17);
    bst.insert(72);
    bst.insert(12);
    bst.insert(23);
    bst.insert(25);
    bst.insert(74);
    bst.insert(76);
    bst.insert(19);
    cout<<"\n-ARBOLITO ORIGINAL:\n"<<bst.print("",bst.getRoot());
    cout<<"\n";

    bst.invert(bst.getRoot());
    cout<<"\n-Inverted Tree:\n"<<bst.print("",bst.getRoot());
    cout<<"\n";


    /*cout<<"\n-ARBOLITO CON REMOVE:\n"<<bst.print("",bst.getRoot());

    if(bst.contains(50)==false){
        cout<<"\n\t***FALSE, THE NODE WAS NOT FOUND***"<<endl;    //CONTAINS()
    }else if(bst.contains(50)==true){
        cout<<"\n\t***TRUE, THE NODE WAS FOUND***"<<endl;
    }

    cout<<"\n";
    cout<<"PREORDER:"<<endl;          //PREORDER
    bst.preOrder(bst.getRoot());

    cout<<"\n";
    cout<<"ORDER:"<<endl;            //ORDER
    bst.Order(bst.getRoot());

    cout<<"\n";
    cout<<"POSTORDER:"<<endl;          //POSTORDER
    bst.postOrder(bst.getRoot());

    cout<<"\n";
    cout<<"BFS:"<<endl;          //BFS
    bst.BFS();

    cout<<"\n";
    cout<<"DFS:"<<endl;          //DFS
    bst.DFS();
    */   
    
   

}