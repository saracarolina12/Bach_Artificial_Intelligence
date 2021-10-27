# Introducción a R
# ----------------

# Operaciones aritméticas
2 + 2
3*(2+2)
2^10

# Definición de variables
a = 2+2
a #mostrar la variable
b = 3*(3*9)
d = 2^10
e = 1+2+3+4
E = 3:40
x= FALSE

# Vectores o arreglos

vector1 <- 1:5
vector2 = c(5,8,9,4,13) #c: función para concatenar, hace un vector
vector1
vector2
vectorsuma <- vector1 + vector2
vectorsuma


# Matrices
matrizA <- matrix(c(1,2,3,4,5,6,7,8), nrow=2, byrow=TRUE) #por filas
matrizA
matrizB <- matrix(c(1,2,3,4,5,6,7,8), nrow=2, byrow=FALSE) #acomoda por columnas
matrizB

# Seleccionar secciones de una matriz
reng = - matrizA[1,]
reng
col = matrizA[,2]
col
elemento = matrizA[2,3]
elemento

dosrengloness = matrizA[1:2, 2:4]
dosrengloness

# Graficar funciones
x = seq(0, 2*pi, length=50)
y = sin(x)
plot(x, y, type="l", col="red")
#linea más gruesa con lwd
plot(x, y, type="l", col="purple", lwd=7, lty=2)
abline(h=0, v=3, col="blue") #linea azul

