#
#
#
#¿Es función fmp?
#

evaluar <- function(x){
  print((1/30)*((x*x)+4))
  return((1/30)*((x*x)+4))
}

suma = 0

x=0
repeat{
  suma = suma + evaluar(x)
  if(x==3){
    if(suma==1)print("Sí es fmp")
    else print("No es")
    break
  }
  x = x + 1
}