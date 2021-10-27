# Universidad Panamericana
# Campus Bonaterra
# Departamento de Matemáticas
# Probabilidad y Estadística para Ingeniería
# 
# Paul RC
# 2021 10 06
# =====
# Ejemplo 1. Intervalo de confianza para la proporción (aproximación normal)
# =====
# Funciones
# -----
IC_p_aprox_normal = function(x, n, coef_conf) {
  alfa = 1 - coef_conf
  z_alfa_medios = qnorm(alfa/2, lower.tail=FALSE)
  p_gorro = x/n
  
  LIC = p_gorro - z_alfa_medios*sqrt(p_gorro*(1 - p_gorro)/n)
  LSC = p_gorro + z_alfa_medios*sqrt(p_gorro*(1 - p_gorro)/n)
  
  resultado = list(lim_inf_conf=LIC, lim_sup_conf=LSC)
  
  return(resultado)
}
# =====
# Programa principal
# -----
# Ejemplo 1.
# En una encuesta a los estudiantes de la Universidad se preguntó a 85 de ellos si había reprobado algún examen en el periodo anterior
# Suponga que 8 de ellos respondieron afirmativamente
# Calcule un intervalo de confianza de 95% para la verdadera proporción de estudiantes que reprobó algún examen en el periodo anterior
# R: P([0.032,0.156] ni p) = 0.95
x = 8
n = 85
coefConf = 0.95

ICP1 = IC_p_aprox_normal(x, n, coefConf)
ICP1

# -----
# Ejemplo 2
# Suponga que el Sistema de Administración Tributaria realizó una encuesta entre sus usuarios y obtuvo que de entre los 1,100 entrevistados, 486 dijeron haber tenido algún problema con el sistema de emisión de comprobantes fiscales electrónicos
# Calcule un intervalo de confianza de 99% para el verdadero valor de la proporción de usuarios que ha tenido algún problema con el sistema de emisión de comprobantes electrónicos
# R: P([0.403,0.481] ni p) = 0.99
x = 486
n = 1100
coefConf = 0.99

ICP2 = IC_p_aprox_normal(x, n, coefConf)
ICP2





