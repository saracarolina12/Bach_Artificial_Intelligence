#Búsqueda Tabú
profit =c(10,14,9,8,7,5,9,3)                  #beneficio
weights = c(7,12,8,9,8,6,11,5)                
restr = 38                                    #j<=38
sol = c(1,0,0,1,1,1,0,1)                      #solución inicial
tabulist = c()                                #size = 2 
sol_prof = sum(sol*profit)
#sol_wei = sum(weights*sol)
for(i in 1:15){
  
 #busca mejor solución
  benef_local = 0
 for(j in length(sol)){
   sol[j] = 1 ^ sol[j]                        #XOR
   if(sum(sol*profit) > benef_local && sum(sol*weights)<=restr && !(j%in%tabulist)){
     benef_local = sum(sol*profit)
     indice = j
   }
   sol[j] = 1 ^ sol[j]                        #regreso el valor que tenía
 }
  sol[indice] = 1 ^ sol[indice]
  tabulist = c(tabulist, indice)
  if(length(tabulist) == 3) tabulist = tabulist[2:3]  #borro el último elemento 
  sol_prof = max(c(sol_prof,benef_local))
}

print(sol_prof)




