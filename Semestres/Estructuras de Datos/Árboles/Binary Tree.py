8#############
#STACK
class NodeS:
    def __init__(self,data):
        self.next = None
        self.data = data
    def __str__(self):
        return str(self.data)
    
class Stack:
    def __init__(self):
        self.first = None
        
    def __str__(self):
        if self.first is None:
            return "''"
        if self.first is not None:
            s = ""
            aux = self.first
            while aux is not None:
                s+=aux.__str__()+"\n"
                aux = aux.next
            return s
    
    def push(self,data):
        n = NodeS(data) 
        if self.first is None:  #stack vacío
            self.first = n
            return
        else: 
            n.next = self.first
            self.first = n
           
    def pop(self):
        if self.first is None:   #stack vacío
            return 
        if self.first.next is None: #un elemento
            aux = self.first
            self.first = None 
            return aux.data
        else:                 #más elementos
            aux = self.first
            self.first = self.first.next
            return aux.data
    
    def top(self):
        if self.first is None:
            return ""
        else:
            aux = self.first
            return aux.data
    
    def isEmpty(self):
        if self.first is None:
            return True
        else:
            return False

#############
# QUEUE
class NodeQ:
    def __init__(self,data):
        self.next = None
        self.data = data
    def __str__(self):
        return str(self.data)
    
class Queue:
    def __init__(self):
        self.first = None
        self.last = None
        
    def __str__(self):
        if self.first is None and self.last is None:
            return "''"
        else:
            s = ""
            aux = self.first
            while aux is not None:
                s+=aux.__str__()+", "
                aux = aux.next
            return s
        
    def push(self,data):
        if self.first is None:
            n = NodeQ(data)
            self.first = n
            self.last = n
        else:
            n = NodeQ(data)
            self.last.next = n
            self.last = n
    
    def pop(self):
        if self.first is None:
            return ""
        else:
            aux = self.first
            self.first = aux.next    
            return aux.data
        
    def front(self):
        if self.first is None:
            return ""
        else:
            aux = self.first
            return aux.data
    
    def isEmpty(self):
        if self.first is None:
            return True
        else:
            return False
        
    def size(self):
        if self.first is None:
            return 0
        else:
            aux = self.first
            count = 1
            while aux.next is not None:
                aux=aux.next
                count+=1
            return count
        
#############
#BINARY TREE
class NodeB:
    def __init__(self,data):
        self.data = data
        self.left = None #hijo izquierdo
        self.right = None #hijo derecho
    def __str__(self):
        return str(self.data)
    
class BST:
    def __init__(self):
        self.root = None #nodo raíz
        
    def __print_node(self,space,node):
        if node is None: return ""
        
        s = space + str(node.data) + "\n"
        s +=  self.__print_node(space+" - ",node.left)
        s +=  self.__print_node(space+" - ",node.right)
        return s
    
    def __str__(self):
        return self.__print_node("",self.root)
    
    def mostrarArbol(self,node,cont):
        if node is None:
            return
        self.mostrarArbol(node.left,cont+1)
        s = ""
        for i in range(cont):
            s+="  "
        print(s,node.data)
        self.mostrarArbol(node.right,cont+1)
    
    def print(self):
        self.mostrarArbol(self.root,0)
        
              
    def insert(self,data):
        n=NodeB(data)
        if self.root is None:
            self.root = n  #el primer nodo sería la raíz
        else:
            aux = self.root
            while(1):
                if data<=aux.data: #si es menor, izquierda
                    if aux.left is None: #si es nulo, ahí lo pongo
                        aux.left = n
                        break
                    else:
                        aux = aux.left
                else: #si es mayor, va hacia la derecha
                    if aux.right is None:
                        aux.right = n
                        break
                    else:
                        aux = aux.right
                    
    def contains(self,data):
        if self.root is None:
            return False
        else:
            if self.root.data == data:
                return True
            else:
                aux= self.root
                while(1):
                    if data <= aux.data: #IZQUIERDA
                        if aux.left is not None:
                            if aux.left.data !=data:#buscar elemento parte izquierda
                                aux = aux.left
                            else:
                                return True
                        else:
                            return False
                    else:               #DERECHA
                        if aux.right is not None:#buscar elemento en la derecha
                            if aux.right.data != data:
                                aux = aux.right
                            else:
                                return True
                        else:
                            return False
                        
    
    def __search_parent_node(self,data):
        if self.root is None:
            return None, None
        parent = None
        node = self.root
        while True:
            if data == node.data:
                return parent, node
            elif data < node.data: #izquierda
                parent = node
                node = node.left
            elif data > node.data: #derecha
                parent = node
                node = node.right
            if node is None:
                return None,None
    
    def __remove(self,parent,node):
        if node.left is None and node.right is None:
            print('\tCaso 1')
            if parent is None: self.root = None
            elif parent.left == node:  parent.left = None
            elif parent.right == node: parent.right = None
            
        elif (node.left is None and node.right is not None) or (node.left is not None and node.right is None):
            print('\tCaso 2')
            if parent is None:
                if node.left is not None: self.root = node.left
                elif node.right is not None: self.root = node.right
            elif parent.left == node:
                if node.left is not None: parent.left = node.left
                elif node.right is not None: parent.left = node.right
            elif parent.right == node:
                if node.left is not None: parent.right = node.left
                elif node.right is not None: parent.right = node.right 
            
        elif node.left is not None and node.right is not None:
            print('\tCaso 3')
            parent2 = node
            node2 = node.left
            while node2.right is not None:
                parent2 = node2
                node2 = node2.right
            print('\t-parent2:',parent2,'node2:',node2)
            self.__remove(parent2,node2)
            node2.left = node.left
            node2.right = node.right
            if parent is None: self.root = node2
            elif parent.left == node:  parent.left = node2
            elif parent.right == node: parent.right = node2
        
        
    def remove(self,data):
        parent,node = self.__search_parent_node(data)
        if node is None:
            return
        print('\t-parent:',parent,'node:',node)
        self.__remove(parent,node)
        print('\t**Delete',node,"**")
            
    
    def Order(self,node):
        if node is not None:
            self.Order(node.left)
            print(node.data)
            self.Order(node.right)
        
            
    def preOrder(self,node):
        if node is not None:
            print(node.data)
            self.preOrder(node.left)
            self.preOrder(node.right)
            
    def postOrder(self,node):
        if node is not None:
            self.postOrder(node.left)
            self.postOrder(node.right)
            print(node.data)      
      
    def DFS(self):
        if self.root is None:
            return
        lim = None 
        s = Stack()
        s.push(self.root)
        s.push(lim) 
        while(s.isEmpty()==False):
            aux = s.top()
            s.pop()
            if(aux != lim):
                print(aux.data)
                if aux.right is not None:
                    s.push(aux.right)
                if aux.left is not None:
                    s.push(aux.left) 
    
    def BFS(self):
        if self.root is None:
            return
        lim = None 
        q = Queue()
        q.push(self.root)
        q.push(lim) 
        while(q.size()):
            aux = q.front()
            q.pop()
            if(aux != lim):
                print(aux.data)
                if aux.left is not None:
                    q.push(aux.left)
                if aux.right is not None:
                    q.push(aux.right)
            else:
                print(" ")
                if(q.isEmpty()==True):
                    break
                q.push(lim)
                
    def b_root(self):
        return self.root
        
    
b = BST()
b.insert(50)
b.insert(17)
b.insert(72)
b.insert(12)
b.insert(23)
b.insert(25)
b.insert(74)
b.insert(76)
b.insert(19)


print("\n\n-ARBOLITO ORIGINAL")
print(b)


b.remove(17)
print("\n\n-ARBOLITO CON REMOVE")
print(b)
print("\n")


if(b.contains(50)==False):
    print("\t***FALSE, THE NODE WAS NOT FOUND***")
elif(b.contains(50)==True):
    print("\t***TRUE, THE NODE WAS FOUND***")
else:
    print(":(")


print("\n\nPREORDER: ")
b.preOrder(b.b_root())
print("\n\nORDER: ")
b.Order(b.b_root())
print("\n\nPOSTORDER: ")
b.postOrder(b.b_root())


print("\n\nBFS: ")
b.BFS()
print("\n\nDFS: ")
b.DFS()






