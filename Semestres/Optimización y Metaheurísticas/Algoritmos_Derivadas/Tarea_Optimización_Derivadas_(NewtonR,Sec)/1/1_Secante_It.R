## Ejercicio 1
#Método de la Secante
#--------------------
library('Deriv')
#función a optimizar
f <- function(x){
  x^2 + x^4 
}
secante <- function(a,b,e){
  #paso1
  flag <- FALSE
  ite <- 0
  deriv1 <- Deriv(f)
  v = c() #tablita
  vx = vy = c()
  
  alpha <- b - (deriv1(b)/((deriv1(b)-deriv1(a))/(b-a)))
  
  historial = c()
  
  while(abs(deriv1(alpha)) > e){
    if(ite == 10){
      #cat("\nEl algoritmo fracasó para la iteración ",ite)
      break
    }
    ite = ite +1
    alpha <- b - (deriv1(b)/((deriv1(b)-deriv1(a))/(b-a)))
    historial = rbind(historial, c(ite, alpha, f(alpha), deriv1(alpha)))
    
    vx <- c(vx, ite)
    vy <- c(vy, alpha)
    if(deriv1(alpha) > 0)b = alpha
    else a = alpha
    #paso 4
    cat("\niteracion #",ite,"\n\t~alpha: ", alpha, "\n\t~f(alpha): ", f(alpha),  "\n\t~f'(alpha): ", deriv1(alpha))
  }
  v = c(v, alpha, f(alpha), deriv1(alpha)) #tablita
  
  
  #plot(vx, vy, type="b")
  
  #print(historial) #imprime todo en tablita
  
  #par(mfrow=c(1,2))
  #plot(historial[,1], historial[,3], col='red', type='b', xlab='iteracion', ylab='f(x)')
  
  curve(deriv1, -0.1, 1, lwd=1.5, xlab='x', ylab='deriv1(x)')
  abline(h=0, lty=3, col='gray', lwd=1.5)
  lines(historial[,2], historial[,4], col='red', type='b')
  
  return(matrix(v, ncol = 3, byrow = TRUE)) #tablita
  
}
#secante(a,b,error)
# secante(-4,3,1e-8)
write.csv(secante(-4,3,1e-8), file = "GitHub/School/Semestres/Optimización y Metaheurísticas/Algoritmos_Derivadas/Tarea_Optimización_Derivadas_(NewtonR,Sec)/2/Tabla_Secante.csv")
