#HASH-SET
class SET:
    def __init__(self):
        self.n = 7
        self.table = [[]] #lista de listas
        for i in range(self.n):
            self.table.append([])#hacerlo tipo matriz
    
    def __str__(self):
        s = "\t"
        for i in range(0, len(self.table)):
            for j in range(0, len(self.table[i])): 
                s += str(self.table[i][j]) + " "
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
        
    def insert(self, data):
        pos = self.assign(data)
        if not data in self.table[pos]:
            self.table[pos].append(data)
            
    def remove(self, data):
        pos = self.assign(data)
        if not data in self.table[pos]:
            print("\tNo está en la lista")
        else:
            self.table[pos].remove(data)
        
    def contains(self, data):
        pos = self.assign(data)
        return data in self.table[pos]
        
s=SET()
#print("LUGAR: ",s.assign("UP"))
#print("LUGAR: ", s.assign(8))
s.insert(24)
s.insert("olaSara")
s.insert(24)
s.insert(8)
s.contains(8)
print(s.contains(8))
print(s)

#s.remove(30)
#print(s)