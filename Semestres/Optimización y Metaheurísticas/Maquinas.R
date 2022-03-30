# Matrices
    tiempoProcesamiento = c(c(15, 12, -1), 
                            c(7,  20, 10),
                            c(-1, 13, 20),
                            c(15, -1, 30),
                            c(25, 13, 14),
                            c(15, 20, -1))
    
    tiempoAjuste = c(c(0,  5, 15, 10,  5, 35),
                     c(0,  0,  5, 15, 10, 45),
                     c(0,  0,  0, 10, 20, 15),
                     c(0,  0,  0,  0,  7, 24),
                     c(0,  0,  0,  0,  0, 13),
                     c(0,  0,  0,  0,  0,  0))
    
    tiempoProcesamiento = matrix(tiempoProcesamiento, ncol = 3, byrow = TRUE)
    tiempoAjuste = matrix(tiempoAjuste, ncol = 6, byrow = TRUE)


# Defino la funcion a optimizar
    fobjetivo = function(x){
      res = c(0,0,0)
      for(i in 1:6){
        if(tiempoProcesamiento[i, x[i]] != -1){
          res[x[i]] = res[x[i]] + tiempoProcesamiento[i, x[i]]
        }
      }
      
      for(i in 1:3){
        for(j in 1:6){
          if(x[j] == i){
            prev = j
            break
          }
        }
        for(j in 1:6){
          if(x[j] == i){
            res[i] = res[i] + tiempoAjuste[prev, j]
            prev = j
          }
        }
      }
      
      return(res)
    }
    
    
    g = function(x){
      itsValid = TRUE
      
      for(i in 1:6){
        if(tiempoProcesamiento[i, x[i]] == -1){
          itsValid = FALSE
        }
      }
      
      return(itsValid)
    }




#-------------------Repeticiones-------------------
      
# Valores generales
    mejorXGeneral = c()
    mejorFGeneral = 1e1000
    l = 0
    
    
# While general (comentar esto y lo de abajo si se ocupa una sola solución)
while(l < 100){
  l = l+1
  
# Paso 0 (inicializacion)
    x = sample(1:3, 6, replace = T) # (1,2,1,3,2,1)
    # print(x)
    fx = c() #(30,40,52)
    k = 0
    t = 1000
    err = 1e-70
    alfa = 0.99
    areaFlag = 0
    penalizacion = 1e10
    
    # Verifica que el vector x sea valido o si no, lo penaliza
      if(g(x) == TRUE){
        fx = fobjetivo(x)
      }
      else{
        fx = fobjetivo(x) + penalizacion
      }

# Variables grafica temperatura
    yTemperatura = c(t)

# Incumbente
    fmejor = 1e100
    xmejor = x

  while(k < 500 && t > err){
    k = k + 1 
    
    # Paso 1 - Generar vector xhat
      dk = sample(1:6, 2, replace = FALSE) # (2, 5)
      xhat = x
      for(i in 1:length(dk)){
        repeat{
          random = sample(1:3,1)
          if(xhat[dk[i]] != random){
            xhat[dk[i]] = random
            break
          }
        }
      }
      # (1,1,1,3,3,1)
      
      if(g(xhat) == TRUE){
        fxhat = fobjetivo(xhat)
      }
      else{
        fxhat = fobjetivo(xhat) + penalizacion
      }
      
    #Paso 2
      if(max(fxhat) < max(fx)){
        x = xhat
        fx = fxhat
      }
      else{
        if(runif(1,0,1) < exp( (max(fx) - max(fxhat)) / t ) ){
          x = xhat
        }
        else{
          x = x
        }
      }
      
      if(max(fxhat) < max(fmejor) && g(xhat) == TRUE){
        # print('Entre')
        fmejor = fxhat
        xmejor = xhat
      }
    
    # Paso 3
      t = alfa*t
      yTemperatura = c(yTemperatura, t)
  }

# While general (comentar esto y lo de abajo si se ocupa una sola solución)
  if(max(fmejor) < max(mejorFGeneral)){
    mejorXGeneral = xmejor
    mejorFGeneral = fmejor
  }
  cat("Solucion x=", xmejor, 'y f(x)=', fmejor, '\n')
}

plot(yTemperatura, type="l",col="blue",lwd=3)

options(digits=8) # digitos para los decimales
cat("Solucion x=", xmejor, 'y f(x)=', fmejor, '\n')
# cat("Solucion x=", mejorFGeneral, 'y f(x)=', mejorFGeneral, '\n')