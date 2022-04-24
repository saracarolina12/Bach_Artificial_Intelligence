'''
lst = []

for i in range(0, 4):
    user_movies = int(input("Write 5 ID's of your favourite movies: "))

    lst.append(user_movies) # adding the element
     
print(lst)
'''

user_movies = list(map(int,input("Write 5 ID's of your favourite movies: ").strip().split()))[:5]
 
print("\nList is - ", user_movies[0])
