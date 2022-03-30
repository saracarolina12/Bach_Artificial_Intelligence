# Defino la funcion a optimizar
fobjetivo = function(x){
  -20*exp(-0.2*sqrt((x[1]^2 + x[2]^2)/2)) - exp((cos(2*pi*x[1]) + cos(2*pi*x[2]))/2) + 20 + exp(1)
}

# Dibujar la funcion que quiero optimizar
# seleccion de colores
require(colorRamps)
my.cols <- matlab.like(9)

# Limites de graficacion para x1 y x2
x1 <- seq(-5, 5, length.out=100)
x2 <- seq(-5, 5, length.out=100)

# crear mallado con x1 y x2, y evaluar cada par de puntos en la funcion fr
z <- fobjetivo(expand.grid(x1, x2)) 

# grafica de contorno: x1, x2 = axis, matrix = vals(100, 100)
contour(x1, x2, matrix(z$Var, length(x1)), col=my.cols, lwd=1, lty=1, nlevels = 14, xlab='x1', ylab='x2')

vec = (0) #crear vector

for(i in 1:30){
  # Paso 0 (inicializacion)
  x = c(4,5)
  mejorfx = fobjetivo(x)
  peorfx = mejorfx
  k = 0
  b = c(0, 0)
  
  points(x[1], x[2], col="blue", pch=25)
  
  while(k < 1500){
    k = k + 1
    
    # Paso 1:
    dk = rnorm(2, 0, 0.5) # sigma pequeña, saltos pequeños; sigma grande, saltos grandes
    xhat = x + b + dk
    if(xhat[1] >= -5 && xhat[1] <= 5 && xhat[2] >= -5 && xhat[2] <= 5){
      fxhat = fobjetivo(xhat)
    }
    else{
      fxhat = mejorfx
    }
    if(fxhat > peorfx){
      peorfx = fxhat
    }
    if(fxhat < mejorfx){
      x = xhat
      mejorfx = fxhat
      b = 0.2*b + 0.4*dk
      if(i==1)points(x[1], x[2], col="green", pch=19)
    }
    else{
      if(i==1)points(xhat[1], xhat[2], col="red", pch=19)
      xhat = x + b - dk
      if(xhat[1] >= -5 && xhat[1] <= 5 && xhat[2] >= -5 && xhat[2] <= 5){
        if(fobjetivo(xhat) < mejorfx){
          x = xhat
          b = b - 0.4*dk
        }
        else{
          b = 0.5*b
        }
      }
      else fxhat = mejorfx
    }
  }
  options(digits=8) # digitos para los decimales
  vec = c(vec, peorfx)
  cat(mejorfx, "\n")
}
cat(vec, sep="\n")