#Búsqueda Tabú
profit =c(10,14,9,8,7,5,9,3)                  #Beneficio
weights = c(7,12,8,9,8,6,11,5)                
restr = 38                                    #j<=38
sol = c(1,0,0,1,1,1,0,1)                      #Inicializar solución inicial
tabulist = c()                                #Bloqueos 
sol_prof = sum(sol*profit)
#sol_wei = sum(weights*sol)
currsol = c()


for(i in 1:15){                               #Número de iteraciones
 #busca mejor solución
 benef_local = 0
 for(j in 1:length(sol)){
   #sol[j] = 1 ^ sol[j]                        #XOR (forzar 1->0, 0->1)
   sol[j] = xor(1,sol[j])
   if(sum(sol*profit) > benef_local && sum(sol*weights)<=restr && !(j%in%tabulist)){
     benef_local = sum(sol*profit)
     indice = j
   }
   #sol[j] = 1 ^ sol[j]                        #regreso el valor que tenía
   sol[j] = xor(1,sol[j])
 }
  #sol[indice] = 1 ^ sol[indice]
  sol[indice] = xor(1, sol[indice])
  tabulist = c(tabulist, indice)
  if(length(tabulist) == 3) tabulist = tabulist[2:3]  #borro el último elemento 
  sol_prof = max(c(sol_prof,benef_local))
  # #imprimir Current solution
  # for(x in 1:8) if(sol[x] == 1) currsol = c(currsol, x)
  # print(currsol)
  # currsol = c()
  # #imprimir iteraciones
  # print(i)
  # #imprimir profit
  # print(sol_prof)
  # #imprimir weigth
  # print(sum(sol*weights))
  # #imprimir tabu active
  #print(tabulist)
  print(sum(sol*weights))
  # #imprimir movimiento
  # print(tabulist[1])
 #if(i==1) break;
}


# print(sol_prof)







