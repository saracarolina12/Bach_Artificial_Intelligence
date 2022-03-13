#Introducción al uso de funciones en R
#
#
#
#Función para elaborar una grafica de bastones

evaluar <- function(x){
  print((1/30)*((x*x)+4))
  return((1/30)*((x*x)+4))
}

graf_bastones = function(x, p) {
  plot(x, p, pch=16, col="slateblue")
  for(linea in 1:length(x)){
    lines(c(x[linea] ,x[linea]), c(0, p[linea]), col="slateblue")
  }
}

x = 0:3
#p = rep(1/6, times=6)
graf_bastones(x, evaluar(x))



#Heaviside
# x = 0:3
# prob = c(4,9,17,30)/30
# plot(x,prob,type="S")
