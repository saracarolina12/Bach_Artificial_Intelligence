#Método de la Secante
#--------------------
library('Deriv')
#función a optimizar
f <- function(x){
  x^2 + x^4 
}

graficar <- function(a,b){
  x = seq(a, b, 0.1)
  plot(x, f(x), type="l")
}
#--------------------

secante <- function(a,b,e){
  #paso1
  flag <- FALSE
  ite <- 0
  #paso2
  alpha <- (a+b)/2
  d1 <- Deriv(f)
  d2 <- Deriv(d1)
  v = c() #tablita
  
  while(abs(d2(alpha)) > e){
    
    if(ite==10){
      cat("\nEl algoritmo fracasó para la iteración #",ite)
      break
    }
    if(d1(a)*d2(alpha) < 0){
      b = alpha
      flag = TRUE
    }else{
      a = alpha
    }
    
    if(flag == TRUE){
      #paso 3
      alpha <- b - (d1(b)/((d1(b)-d1(a))/(b-a)))
      
      xPlot <- c(b, alpha) #grafica
      lines(xPlot, f(xPlot), type = "b") #grafica
      
      ite = ite + 1
      if(d2(alpha) > 0){
        b = alpha
      }else{
        a = alpha
      }
    }
    
    v = c(v, alpha, f(alpha), d1(alpha), d2(alpha)) #tablita
    #paso 4
    cat("\niteracion #",ite,"\n\t~alpha: ", alpha, "\n\t~f(alpha): ", f(alpha), "\n\t~d1(alpha): ", d1(alpha), "\n\t~d2(alpha): ", d2(alpha))
  }

  return(matrix(v, ncol = 4, byrow = TRUE)) #tablita
}

graficar(-4,4)

#secante(a,b,error)
write.csv(secante(-4,-3,0.00033), file = "GitHub/School/Semestres/Optimización y Metaheurísticas/Algoritmos_Derivadas/Tarea_Optimización_Derivadas_(NewtonR,Sec)/Tabla_Secante.csv")


