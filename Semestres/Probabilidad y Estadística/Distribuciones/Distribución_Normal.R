#
#Distribución Normal
#
#
#Utilice la distribución N(0,1) en PQRS para obtener las siguientes probabilidades:
#  P(Z < -2.57) = 0.0051
#  P(Z < -1.96) = 0.0250
#  P(Z < -0.5) = 0.3085
#  P(Z > 2.33) = 0.0099
#  P(-1.64 < Z < 1.64) = 0.8990

#a) izquierdo
a = pnorm(-2.57)
a

#d del lado derecho
d = pnorm(2.33,lower.tail = FALSE) #forma 1
d
dp = 1- pnorm(2.33) #forma 2
dp

#e de ambos lados 
e = pnorm(1.64) -pnorm(-1.64)
e

# P(Z < z0) = 0.0606 R: z0 = -1.55
z0 = qnorm(0.0606)
z0

# P(-z0 < Z < z0) = 0.7814 R: z0 = 1.23
## alfa = (1 - 0.7814)/2
alfa = (1 - 0.7814)/2
alfa

zneg = qnorm(alfa, lower.tail = FALSE) #forma 1
zneg

zneg2 = -qnorm(alfa) #forma 2
zneg2