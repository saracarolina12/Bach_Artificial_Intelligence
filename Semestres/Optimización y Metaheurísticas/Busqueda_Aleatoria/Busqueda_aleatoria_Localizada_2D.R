# Defino la funcion a optimizar
fobjetivo = function(x){
  -x[1]*sin(sqrt(abs(x[1])))-x[2]*sin(sqrt(abs(x[2])))
}
# Dibujar la funcion que quiero optimizar
# seleccion de colores
require(colorRamps)
my.cols <- matlab.like(9)

# Limites de graficacion para x1 y x2
x1 <- seq(-500, 500, length.out=100)
x2 <- seq(-500, 500, length.out=100)

# crear mallado con x1 y x2, y evaluar cada par de puntos en la funcion fr
z <- fobjetivo(expand.grid(x1, x2)) 

# grafica de contorno: x1, x2 = axis, matrix = vals(100, 100)
contour(x1, x2, matrix(z$Var, length(x1)), col=my.cols, lwd=1, lty=1, nlevels = 14, xlab='x1', ylab='x2')

vec = (0) #crear vector
for(i in 1:30){
  # Paso 0 (inicializacion)
  x = c(0, 100)
  mejorfx = fobjetivo(x)
  peorfx = mejorfx
  k = 0

  points(x[1], x[2], col="blue", pch=25)
  while(k < 1500){
    k = k+1
    # Paso 1:
    dk = rnorm(2,0,300) # sigma pequeña, saltos pequeños; sigma grande, saltos grandes
    xhat = x + dk
    if(xhat[1] >= -500 && xhat[1] <= 500 && xhat[2] >= -500 && xhat[2] <= 500){
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
      if(i==1)points(x[1], x[2], col="green", pch=19)
    }
    else{
      if(i==1)points(xhat[1], xhat[2], col="red", pch=19)
    }
  }
  options(digits=8) # decimales
  vec = c(vec, peorfx)
  cat(mejorfx, "\n")
}
cat(vec, sep="\n")