## EJERCICIO 1
#Método de Newton Raphson
#--------------------
library('Deriv')
#función a optimizar
f <- function(x){
  x^2 + x^4 
}

graficar <- function(a,b){
  x = seq(a, b, 0.1)
  # plot(x, f(x), type="l")
}
#--------------------
newtonraphson <- function(x,e,ite){
  d1 <- Deriv(f) #primera derivada
  d2 <- Deriv(d1) #segunda derivada
  
  xPrev <- 0
  v = c() #tablita
  vx = c()
  vy = c()
  while(abs(x - xPrev) > e){
    if(ite==10){
      cat("\nEl algoritmo fracasó para la iteración #",ite)
      break
    }
    xPrev <- x
    v = c(v, x, f(x), d1(x), d2(x)) #tablita
    x <- xPrev - (d1(x)/d2(x))
    # xPlot <- c(xPrev, x) #Graphing
    # lines(xPlot, f(xPlot), type = "b") #Graphing
    ite = ite + 1
    vx <- c(vx, ite)
    vy <- c(vy, f(xPrev))
    cat("\niteracion #",ite,"\n\t~x: ", x, "\n\t~f(x): ", f(x), "\n\t~d1(x): ", d1(x), "\n\t~d2(x): ", d2(x))
  }
  vx <- c(vx, ite+1)
  vy <- c(vy, f(x))
  plot(vx, vy, type="b")
  return(matrix(v, ncol = 4, byrow = TRUE))
}


#newtonraphson(x,error,iteraciones)
#newtonraphson(-4,1e-8,0)


#graficar(-4, 4) 
write.csv(newtonraphson(-4,1e-8,0), file = "GitHub/School/Semestres/Optimización y Metaheurísticas/Algoritmos_Derivadas/Tarea_Optimización_Derivadas_(NewtonR,Sec)/1/Tabla_NewtonRaphson.csv")
