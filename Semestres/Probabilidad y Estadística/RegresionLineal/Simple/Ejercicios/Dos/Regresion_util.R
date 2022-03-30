# Universidad Panamericana
# Campus Bonaterra
# Departamento de Matemáticas
# Probabilidad y Estadística para Ingeniería
# 
# Paul RC
# 2021 11 01
# =====
# Archivo de utilerías para Regresión Lineal Simple
# -----
# Funciones
# -----
# Cálculo de los principales resultados de una Regresión Lineal Simple
regresion_lineal_simple = function(datos, x_nueva=NULL) {
  # Esta función asume que la primera columna contiene los valores para x y la segunda para y
  x = datos[,1]
  y = datos[,2]
  n = dim(datos)[1]
  # ---
  # Calculamos beta_gorro0 y beta_gorro1
  Sxx = sum(x^2) - 1/n*(sum(x))^2
  Sxy = sum(x*y) - 1/n*(sum(x))*sum(y)
  Syy = sum(y^2) - 1/n*(sum(y))^2
  beta_gorro1 = Sxy/Sxx
  beta_gorro0 = mean(y) - beta_gorro1*mean(x)
  # Calculamos r y r^2
  r = Sxy/sqrt(Sxx*Syy)
  r2 = r^2
  # Calculamos los residuos
  y_gorro = beta_gorro0 + beta_gorro1*x
  residuos = y - y_gorro
  
  # ---
  # Gráfica de dispersión
  par(mfrow = c(1, 1))
  plot(x, y, main="Gráfica de Dispersión",
       xlab=names(datos)[1], ylab=names(datos)[2],
       pch=16, col="blue")
  # Agregamos la recta de regresión
  abline(a=beta_gorro0, b=beta_gorro1, col="red")
  
  # ---
  # Gráficas de residuos
  par(mfrow=c(2,2))
  # --
  # ---
  # Residuos estandarizados
  residuosEstandarizados = (residuos - mean(residuos))/sd(residuos)
  # ---
  
  # Dispersión de Residuos vs x
  titulo = paste("Residuos vs", names(datos)[1])
  plot(x, residuosEstandarizados, pch=16, col="green", main=titulo, xlab=names(datos)[1],
       ylab="Residuos")
  # Histograma de residuos
  hist(residuosEstandarizados, main="Histograma de Residuos", xlab="Residuos", ylab="Frecuencia", col="green")
  # Gráfica de probabilidad normal (Q-Q Plot)
  qqnorm(residuosEstandarizados, pch = 16, col = "green", 
         main = "Grafica de probabilidad normal \n Residuos estandarizados",
         xlab = "Cuantiles Esperados", ylab = "Cuantiles Observados")
  qqline(residuosEstandarizados, col = "red")
  # Grafica secuencial de residuos
  plot(residuosEstandarizados, col = "green", 
       main = "Grafica secuencial de residuos std", 
       xlab = "Posicion", ylab = "Residuos Estandarizados",
       type = "b")
  abline(h = 0, col = "red", lty = 2)
  
  par(mfrow=c(1,1))
  
  # ---
  # Pronóstico de y para x_nueva
  if (! is.null(x_nueva)) {
    y_nueva = beta_gorro0 + beta_gorro1*x_nueva
  } else {
    y_nueva = NULL
  }
  
  # ---
  # Devolvemos el resultado al programa principal
  resultado = list(beta_gorro0=beta_gorro0, beta_gorro1=beta_gorro1,
                   r=r, r2=r2, y_nueva=y_nueva, residuos = residuos,residuosEstandarizados = residuosEstandarizados)
  
  return(resultado)
}