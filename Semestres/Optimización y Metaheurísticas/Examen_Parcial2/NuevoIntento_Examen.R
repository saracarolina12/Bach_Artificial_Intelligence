myFile = read.delim("C:/Users/scago/Documents/GitHub/School/Semestres/Optimización y Metaheurísticas/Examen_Parcial2/input.txt", header = FALSE, sep = " ") 
h = c()
elementos = myFile[1, 1]
grupos = myFile[1, 2]
lim_inf = myFile[2,1]
lim_sup = myFile[2,2]
pesos = myFile[3,]
m = matrix(nrow = elementos, ncol = elementos, byrow = FALSE)
for(i in 4:28683){
  m[myFile[i,1]+1, myFile[i,2]+1] = myFile[i,3] #matriz posición [a][b] = c
}
# print(m)                         
# print(elementos)
# print(grupos)
# print(lim_inf)
# print(lim_sup)
# print(pesos)
#------------------------termina lectura------------------------


#representar solución 
elementos_caja = c(1:elementos) 
peso_caja = c(rep(0,grupos)) #vector de ceros
beneficio_caja = c(1:grupos)

#acomodo inicial
for(i in 1:length(elementos)){
  nuevo_peso = 0 #nuevo peso de la caja random
  repeat{
    id_caja = sample(1:12, 1) #números random de 1:12
    nuevo_peso = peso_caja[id_caja] + pesos[i]
    if(nuevo_peso <= lim_sup && nuevo_peso >= lim_inf) break #si se encuentra dentro del rango
    #revisar límite inferior
  }
 
  elementos_caja[i] = id_caja #asigno cada random a cada elemento
  peso_caja[id_caja] = nuevo_peso
}

#swapear (nueva solución)





#imprimir solución