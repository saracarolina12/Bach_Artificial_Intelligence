library(dequer)

#Búsqueda Tabú
profit =c(10,14,9,8,7,5,9,3)                  #beneficio
weights = c(7,12,8,9,8,6,11,5)                
restr = 38                                    #j<=38
sol = c(1,0,0,1,1,1,0,0)                      #solución inicial
neighbors = c()                               #lista de vecinos (xj=1)
tabulist = c()                                #size = 2 
sol_prof = 0
sol_wei = 0


for(i in 1:length(profit)){
  sol_prof = sol_prof + (profit[i]*sol[i])    
  sol_wei = sol_wei + (weights[i]*sol[i])     #<=38
}

# print(sol_prof)                       
# print(sol_wei)



