'''
#Libraries
    import heapq
        heapq.nlargest(3, arr)
        heapq.nsmallest(3, arr)   
    from collections import Counter 
        counter = Counter(arr)
        top_two = counter.most_common(3) #counts occurrences

#I/O
    x = input()  #input
    print(x) #output
    print('text {} more text').format(x)
    f = open("input.txt", "r") #to read
    f = open("output.txt", "w") #to write (re-write)
    f = open("output.txt", "a") #to write (add)
    f.close()

#Strings
    len('hi') #length
    str(6) #convert to string

#Boolean: to compare two elements (returns True or False)
    #comparing two booleans
        True is True #returns true
        True is not True #returns false
    #Other comparisons
        12 == 12 #returns true
        'dog' == 'cat' #returns false
        12 = '12' #returns false

#Functions
    def function():
    
#Extra
    #Sort
        arr.sort() #sorts a list ascending
        arr.sort(reverse=True) #sort the list descending
    #Split
        s = "Hello my name is x"
        s.split() #splits the string
'''
