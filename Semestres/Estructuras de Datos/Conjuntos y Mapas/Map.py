#HASH-MAP
class MAP:
    def __init__(self):
        self.n = 7
        self.table = [[]] #lista de listas
        for i in range(self.n):
            self.table.append([])#hacerlo tipo matriz
    
    def __str__(self):
        s = "\t"
        for i in range(0, len(self.table)):
            for j in range(0, len(self.table[i])): 
                s += str(self.table[i][j]) + " "  #por qué imprime ()?
            if(self.table[i]): 
                s += "\n\t"
        return s 
    
    def assign(self, key):
        if isinstance(key, int):
            return key%self.n
        else:  
            num = 0
            for i in range(0, len(key)):
                num += ord(key[i])*(26**i) #cuando sea caracter, lo paso a ascii 
            return num%self.n
        

    def insert(self,key,value):
        pos = self.assign(key)
        for i in range(0,len(self.table[pos])):
            if self.table[pos][i][0] == key:#si first en la tupla es igual a key, entonces second es value
                self.table[pos][i] = (key,value)
                return
        self.table[pos].append((key,value))
    
    def remove(self,key):
        pos = self.assign(key) 
        value = self.get(key)
        self.table[pos].remove((key,value))
               
    def contains(self,key):
        pos = self.assign(key)
        for i in self.table[pos]:
            if i[0] == key: #primer elemento (key)
                return True
        return False
    
    def get(self, key):
        pos = self.assign(key)
        for i in self.table[pos]:
            if i[0] == key:
                return i[1]
        return "No existe"

m = MAP()
m.insert(8,"sara")
m.insert(9,"carolina")
m.insert(10,"gomez")
m.insert(20,"ola")
m.insert(10,"omg")
#print(m.contains(10))
#print(m.get(10))
m.remove(10)

print(m)
