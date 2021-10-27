# Defino la funcion a optimizar
fobjetivo = function(x){
  -20*exp(-0.2*sqrt((x[1]^2 + x[2]^2)/2)) - exp((cos(2*pi*x[1]) + cos(2*pi*x[2]))/2) + 20 + exp(1)
}

# Dibujar la funcion que quiero optimizar
vec = c(0)
# seleccion de colores
require(colorRamps)
my.cols <- matlab.like(9)

# Limites de graficacion para x1 y x2
x1 <- seq(-5, 5, length.out=100)
x2 <- seq(-5, 5, length.out=100)

# crear mallado con x1 y x2, y evaluar cada par de puntos en la funcion fr
z <- fobjetivo(expand.grid(x1, x2))

# grafica de contorno
contour(x1, x2, matrix(z$Var, length(x1)), col=my.cols, lwd=1.8, lty=2, nlevels = 14, xlab='x1', ylab='x2')

for(i in 1:30){
  # Paso 0 (inicializacion)
  x = c(4, 5)
  fx = fobjetivo(x)
  peorfx = fx
  k = 0
  
  points(x[1], x[2], col="blue", pch=19)
  
  while(k < 2000){
    k = k + 1
    
    # Paso 1:
    xhat = runif(2, -5, 5)
    if(xhat[1] <= 5 && xhat[1] >= -5 && xhat[2] <= 5 && xhat[2] >= -5)
      fxhat = fobjetivo(xhat)
    else fxhat = fx
    fxhat = fobjetivo(xhat)
    if(fxhat > peorfx) peorfx = fxhat
    if(fxhat < fx){
      x = xhat
      fx = fxhat
      if(i==1)points(x[1], x[2], col="green", pch=19)
      #text(x[1], x[2], k)
    }else{
      if(i==1)points(xhat[1], xhat[2], col="red", pch=19)
      #text(xhat[1], xhat[2], k)
    }
  }
  options(digits=8) # digitos para los decimales
  vec = c(vec, peorfx)
  cat(fx, "\n")
}
cat(vec, sep="\n")