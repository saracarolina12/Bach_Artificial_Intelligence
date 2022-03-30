class Node:
    def __init__(self,data):
        self.data = data
        self.left = None
        self.right = None
        self.parent = None
        self.balance = 0
        self.height = 1
    def __str__(self):
        s = str(self.data) 
        s+= "----> [h:"+str(self.height)
        s+= " , b:"+str(self.balance)+"]"
        return s
    
    def insert(self,node,root):
        if node.data <= self.data: 
            if self.left is None:  
                self.left = node
                node.parent = self
            else:
                self.left.insert(node,root)
        else:
            if self.right is None:  
                self.right = node
                node.parent = self
            else:
                self.right.insert(node,root)
        
        return self.mbalance(root)

    def rotate_left(self,node,root):
        parent = node.parent
        a = node
        b = node.right
        s2 = b.left
        
        a.right = s2
        if s2 is not None: s2.parent = a 
        
        b.left = a
        a.parent = b
        
        b.parent = parent
        
        if parent is None:#si es la raíz
            root=a.mbalance(root)
            root=b.mbalance(root)
            return b
        
        elif parent.left == a: parent.left = b #si no es la raíz
        elif parent.right == a: parent.right = b #si no es la raíz
        
        root = a.mbalance(root)
        root = b.mbalance(root)
        return root
    
    def rotate_right(self,node,root):
        parent = node.parent
        a = node
        b = node.left 
        s2 = b.right
        
        a.left = s2
        if s2 is not None: s2.parent = a
            
        b.right = a
        a.parent = b #nueva asignación de padre

        b.parent = parent
        
        if parent is None: #si es raíz
            root=a.mbalance(root)
            root=b.mbalance(root)
            return b
        
        elif parent.left == a: parent.left = b #si no es la raíz
        elif parent.right == a: parent.right = b  #si no es la raíz
        
        root = a.mbalance(root)
        root = b.mbalance(root)
        return root
        
    def mbalance(self,root):
        height_left = 0 if self.left is None else self.left.height
        height_right = 0 if self.right is None else self.right.height
        self.height = max(height_left+1,height_right+1)
        self.balance = height_left - height_right
        
        if self.balance<=-2 and self.right.balance<=0:
            root = self.rotate_left(self,root)
            
        elif self.balance<=-2 and self.right.balance==1:
            root = self.rotate_right(self.right,root)
            root = self.rotate_left(self,root)
            
        elif self.balance>=2 and self.left.balance==-1:
            root = self.rotate_left(self.left,root)
            root = self.rotate_right(self,root)
            
        elif self.balance>=2 and self.left.balance>=0:
            root = self.rotate_right(self,root)     
        return root
        
class AVL:
    def __init__(self):
        self.root = None
    
    def __print_node(self,node,sp):
        s = sp + node.__str__() + "\n"
        if node.left is not None: s+= self.__print_node(node.left,sp+" - ") #left
        if node.right is not None: s+= self.__print_node(node.right,sp+" - ") #right
        return s
        
    def __str__(self):
        if self.root is None: return "";
        else:  return self.__print_node(self.root,"")
        
    def insert(self,data):
        node = Node(data)
        if self.root is None:
            self.root = node
        else:
            self.root = self.root.insert(node,self.root)
            
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
            #print('\tCaso 1')
            if parent is None: self.root = None
            elif parent.left == node:  parent.left = None
            elif parent.right == node: parent.right = None
            
        elif (node.left is None and node.right is not None) or (node.left is not None and node.right is None):
            #print('\tCaso 2')
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
            #print('\tCaso 3')
            parent2 = node
            node2 = node.left
            while node2.right is not None:
                parent2 = node2
                node2 = node2.right
            #print('\t-parent2:',parent2,'node2:',node2)
            self.__remove(parent2,node2)
            node2.left = node.left
            node2.right = node.right
            if parent is None: self.root = node2
            elif parent.left == node:  parent.left = node2
            elif parent.right == node: parent.right = node2
        root = node.mbalance(self.root)
        return root
        
        
    def remove(self,data):
        parent,node = self.__search_parent_node(data)
        if node is None:
            return
        #print('\t-parent:',parent,'node:',node)
        self.__remove(parent,node)
        print('\t**Delete ',node,"**\n")
        if(self.root is not None):
            self.root=self.root.mbalance(self.root)
        
    def getRoot(self):
        return self.root
            
avl = AVL()
#para right rotation
'''
avl.insert(10)
avl.insert(5)
avl.insert(1)
print(avl) '''

#para left rotation
print("SIN REMOVE:\n")
avl.insert(9)
avl.insert(10)
avl.insert(1)
avl.insert(13)
avl.insert(14)
avl.insert(15)
print(avl)

#removes
print("REMOVE:\n")
avl.remove(15)
avl.remove(14)
print(avl)

