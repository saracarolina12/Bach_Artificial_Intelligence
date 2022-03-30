# Universidad Panamericana
# Campus Bonaterra
# Departamento de Matemáticas
# Probabilidad y Estadística para Ingeniería
# 
# Paul RC
# 2021 10 06
# =====
# Ejemplo 1. Intervalo de confianza para la media con sigma conocida
# =====
# Funciones
# -----
IC_mu_sigma_conocida = function(x_barra, sigma, n, coef_conf) {
  alfa = 1 - coef_conf
  z_alfa_medios = qnorm(alfa/2, lower.tail=FALSE)
  
  LIC = x_barra - z_alfa_medios*sigma/sqrt(n)
  LSC = x_barra + z_alfa_medios*sigma/sqrt(n)
  
  resultado = list(lim_inf_conf=LIC, lim_sup_conf=LSC)
  
  return(resultado)
}

# =====
# Programa principal
# ------
# Ejemplo.
# [Walpole y Myers (1992). Probabilidad y Estadística. Mc Graw-Hill / Interamericana de México, S. A. de C. V. Prob. 8 Cap. 6 p.224 (aprox.)] Suponga que cierta máquina fabrica resistencias eléctricas cuyo valor sigue una distribución normal con una desviación estándar de 2 Ohms
# Una muestra de tamaño 36 produce una resistencia promedio de 1458 Ohms
# Obtenga un IC de 95% para la verdadera resistencia promedio de las piezas producidas por la máquina
media = 442.7
sigma = 21
tam_muestra = 10
coefConf = 0.98

IC1 = IC_mu_sigma_conocida(media, sigma, tam_muestra, coefConf)
IC1



