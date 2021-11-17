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
   sol[j] = !sol[j]                     #XOR (forzar 1->0, 0->1)
   if(sum(sol*profit) > benef_local && sum(sol*weights)<=restr && !(j%in%tabulist)){
     benef_local = sum(sol*profit)
     indice = j
   }
   sol[j] = !sol[j]                     #regreso el valor que tenía
 }
  sol[indice] =!sol[indice]
  tabulist = c(tabulist,indice)
  #tabulist = rev(tabulist)
  if(length(tabulist) == 3) tabulist = tabulist[2:3]  #borro el último elemento 
  sol_prof = max(c(sol_prof,benef_local))
  print(sol_prof)
}


# print(sol_prof)







