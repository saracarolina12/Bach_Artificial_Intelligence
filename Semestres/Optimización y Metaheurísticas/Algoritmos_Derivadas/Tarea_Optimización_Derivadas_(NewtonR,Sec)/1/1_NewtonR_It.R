## EJERCICIO 1
#Método de Newton Raphson
#--------------------
library('Deriv')
#función a optimizar
f <- function(x){
  x^2 + x^4 
}
#--------------------
newtonraphson <- function(x,e,ite){
  d1 <- Deriv(f) #primera derivada
  d2 <- Deriv(d1) #segunda derivada
  xPrev <- 0
  v  = c()
  xG = seq(-4, 3, 0.1) #graficar derivada
  plot(xG, d1(xG), type="l", lwd="2") #graficar derivada
  historial = c()
  
  while(abs(x - xPrev) > e){
    if(ite==10)break
    xPrev <- x
    v <- c(v, x, f(x), d1(x), d2(x)) #tablita
    x <- xPrev - (d1(x)/d2(x))
    lines(c(xPrev, x), c(d1(xPrev), 0), type = "b", lty = 3)
    historial = rbind(historial, c(ite, x, d1(x), d2(x)))
    
    ite = ite + 1
    cat("\niteracion #",ite,"\n\t~x: ", x, "\n\t~f(x): ", f(x), "\n\t~d1(x): ", d1(x), "\n\t~d2(x): ", d2(x))
  }
  abline(h = 0, lty = 3)
  abline(v = 0, lty = 3)
  
  print(historial)
  
  curve(d1, -4, 3, lwd=1.5, xlab='x', ylab='deriv1(x)')
  abline(h=0, lty=3, col='gray', lwd=1.5)
  lines(historial[,2], historial[,3], col='red', type='b')
  
  return(matrix(v, ncol = 4, byrow = TRUE))
}
#newtonraphson(x,error,iteraciones)
write.csv(newtonraphson(-4,1e-8,0), file = "GitHub/School/Semestres/Optimización y Metaheurísticas/Algoritmos_Derivadas/Tarea_Optimización_Derivadas_(NewtonR,Sec)/1/Tabla_NewtonRaphsonit.csv")