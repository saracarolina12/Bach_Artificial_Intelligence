## Ejercicio 1
#Método de la Secante
#--------------------
library('Deriv')
#función a optimizar
f <- function(x){
  x^2 + x^4 
}
# graficar <- function(a,b){
#   x = seq(a, b, 0.1)
#   plot(x, f(x), type="l")
# }
#--------------------
secante <- function(a,b,e){
  #paso1
  flag <- FALSE
  ite <- 0
  alpha <- 0
  deriv1 <- Deriv(f)
  v = c() #tablita
  vx = vy = c()
  alpha <- (a+b)/2
  
  
  while(abs(deriv1(alpha)) > e){
    if(ite == 10){
      cat("\nEl algoritmo fracasó para la iteración #",ite)
      break
    }
    ite = ite +1
    alpha <- b - (deriv1(b)/((deriv1(b)-deriv1(a))/(b-a)))
    vx <- c(vx, ite)
    vy <- c(vy, alpha)
    if(deriv1(alpha) > 0)b = alpha
    else a = alpha
    #paso 4
    cat("\niteracion #",ite,"\n\t~alpha: ", alpha, "\n\t~f(alpha): ", f(alpha),  "\n\t~f'(alpha): ", deriv1(alpha))
  }
    v = c(v, alpha, f(alpha), deriv1(alpha)) #tablita
   plot(vx, vy, type="b")
  return(matrix(v, ncol = 3, byrow = TRUE)) #tablita
}
#secante(a,b,error)
write.csv(secante(-4,3,1e-8), file = "GitHub/School/Semestres/Optimización y Metaheurísticas/Algoritmos_Derivadas/Tarea_Optimización_Derivadas_(NewtonR,Sec)/1/Tabla_Secante.csv")
