#Valor Esperado y Varianza  
#
#

#
#Función para evaluar
evaluar <- function(x){
  return((1/30)*((x*x)+4))
}
#-----------------------------

#Valor Esperado dado fmp
i=0 
E = 0
repeat{
  esp = (evaluar(i))*i
  E = E + esp
  i = i + 1
  if(i == 4) break
}
print(E)

#----------------
#Varianza dado fmp
j=0 
V = 0
repeat{
  vari = ((j-E)**2)*(evaluar(j))
  V = V + vari
  j = j + 1
  if(j == 4) break
}
print(V)


#Desviación estándar
print(sqrt(V))


