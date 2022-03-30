#include <iostream>
using namespace std;
template<class R>
class RBT{
	public:
		class Node {
		public:
			R data; 
			bool color;
			Node *parent; 
			Node *left; 
			Node *right; 
			~Node(){
				//cout<<"~Node"<<endl;
			}
	};
	RBT() {
		cout<<"RBT"<<endl;
		n = new Node;
		n->color = false;
		n->left = nullptr;
		n->right = nullptr;
		root = n;
	}
	~RBT(){
		cout<<"~RBT"<<endl;
		postOrder(root);
	}
	void postOrder(Node* n){
		if(n != nullptr){
			if(n->left != nullptr) postOrder(n->left);
			if(n->right != nullptr) postOrder(n->right);
			delete n;
		}
	}

	Node* root;
	Node* n;

    bool find(R data){
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

	void reorder(Node* temp){
		Node* temp2;
		while (temp->parent->color == true) {
			if (temp->parent == temp->parent->parent->right) {
				temp2 = temp->parent->parent->left;
				if (temp2->color == true) {
					temp2->color = false;
					temp->parent->color = false;
					temp->parent->parent->color = true;
					temp = temp->parent->parent;
				} else {
					if (temp == temp->parent->left) {
						temp = temp->parent;
						rightR(temp);
					}
					temp->parent->color = false;
					temp->parent->parent->color = true;
					leftR(temp->parent->parent);
				}
			}else{
				temp2 = temp->parent->parent->right;
				if(temp2->color == true){
					temp2->color = false;
					temp->parent->color = false;
					temp->parent->parent->color = true;
					temp = temp->parent->parent;	
				}else{
					if(temp == temp->parent->right) {
						temp = temp->parent;
						leftR(temp);
					}
					temp->parent->color = false;
					temp->parent->parent->color = true;
					rightR(temp->parent->parent);
				}
			}
			if (temp == root) {
				break;
			}
		}
		root->color=false;
	}

	void show(string s,Node* root, bool last) {
		if(root== nullptr){
			return;
		}
	   	if (root != n) {
		   cout<<s;
		   if (last) {
		      cout<<"->";
		      s+= "     ";
		   } else {
		      cout<<"->";
		      s += "    ";
		   }
           string paint;
           if(root->color==true){
               paint = "red";
           }else{
               paint = "black";
           }
		   cout<<"["<<root->data<<"] "<<paint<<endl;
		   show(s,root->left, false);
		   show(s,root->right, true);
		}
	}

	void rightR(Node* aux2) {
		Node* aux = aux2->left;
		aux2->left = aux->right;
		if (aux->right != n) {
			aux->right->parent = aux2;
		}
		aux->parent = aux2->parent;
		if (aux2->parent == nullptr) {
			root = aux;
		} else if (aux2 == aux2->parent->right) {
			aux2->parent->right = aux;
		} else {
			aux2->parent->left = aux;
		}
		aux->right = aux2;
		aux2->parent = aux;
	}

		void leftR(Node* aux2) {
		Node* aux = aux2->right;
		aux2->right = aux->left;
		if (aux->left != n) {
			aux->left->parent = aux2;
		}
		aux->parent = aux2->parent;
		if (aux2->parent == nullptr) {
			root = aux;
		} else if (aux2 == aux2->parent->left) {
			aux2->parent->left = aux;
		} else {
			aux2->parent->right = aux;
		}
		aux->left = aux2;
		aux2->parent = aux;
	}

	void insert(R data) {
		Node* nw = new Node;
		Node* aux = nullptr;
		Node* aux2 = root;
		nw->parent = nullptr;
		nw->data = data;
		nw->left = n;
		nw->right = n;
		nw->color = true; 
		while (aux2 != n) {
			aux = aux2;
			if (nw->data < aux2->data) {
				aux2 = aux2->left;
			} else {
				aux2 = aux2->right;
			}
		}
		nw->parent = aux;
		if (aux == nullptr) {
			root = nw;
		} else if (nw->data < aux->data) {
			aux->left = nw;
		} else {
			aux->right = nw;
		}
		if (nw->parent == nullptr){
			nw->color = false;
			return;
		}
		if (nw->parent->parent == nullptr) {
			return;
		}
		reorder(nw);
	}
	Node* getRoot(){
		return root;
	}	
};

int main() {
	RBT <int> rbt;
	cout<<"\n\t------RED BLACK TREE------"<<endl;
	cout<<endl;
	rbt.insert(37);
	rbt.insert(77);
	rbt.insert(20);
	rbt.insert(40);
	rbt.insert(5);
	rbt.insert(20);
	rbt.insert(7);
	
	rbt.show("",rbt.getRoot(), true);

	if(rbt.find(7)==true){
		cout<<"\n\t||YES, IT IS IN THE TREE||"<<endl;
	}else{
		cout<<"\n\t||NO,IT IS NOT IN THE TREE||"<<endl;
	}
	return 0;
}
