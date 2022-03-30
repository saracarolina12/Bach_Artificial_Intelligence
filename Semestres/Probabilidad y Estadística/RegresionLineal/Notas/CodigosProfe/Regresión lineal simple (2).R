# Universidad Panamericana
# Campus Bonaterra
# Departamento de Matemáticas
# Probabilidad y Estadística para Ingeniería
# 
# Paul RC
# 2021 10 25
# =====
# Ejemplo 1. Modelo de Regresión Lineal Simple
# -----
# Funciones
# -----
regresion_lineal_simple = function(datos, x_nueva=NULL) {
  # Esta función asume que la primera columna contiene los valores para x y la segunda para y
  x = datos[,1]
  y = datos[,2]
  n = dim(datos)[1]
  # ---
  # Calculamos beta_gorro0 y beta_gorro1
  Sxx = sum(x^2) - 1/n*(sum(x))^2
  Sxy = sum(x*y) - 1/n*(sum(x))*sum(y)
  beta_gorro1 = Sxy/Sxx
  beta_gorro0 = mean(y) - beta_gorro1*mean(x)
  
  # ---
  # Gráfica de dispersión
  plot(x, y, main="Gráfica de Dispersión",
       xlab=names(datos)[1], ylab=names(datos)[2],
       pch=16, col="blue")
  # Agregamos la recta de regresión
  abline(a=beta_gorro0, b=beta_gorro1, col="red")
  
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
                   y_nueva=y_nueva)
  
  return(resultado)
}
# =====
# Programa principal
# -----
# Ejemplo 1, presentación. Artículos
articulos = read.csv("C:\\Users\\Paul\\Google Drive\\UP\\UP_2020\\2021_2_Ing_Probabilidad_y_Estadística\\Unidad 7\\Artículos_datos.csv", header=TRUE)
articulos

# Estimación del modelo de regresión
regresion1 = regresion_lineal_simple(articulos)
regresion1

# Estimación del modelo de regresión y cálculo de y para x_nueva = 10
regresion1 = regresion_lineal_simple(articulos, x_nueva=10)
regresion1

# Estimación del modelo de regresión y cálculo de y para x_nueva = c(5, 10, 15, 20, 25)
regresion1 = regresion_lineal_simple(articulos, x_nueva=c(5, 10, 15, 20, 25))
regresion1

# =====
# Ejercicio 1, presentación. Inventarios
# Para estimar el inventario de este año (inventario en exceso), una compañía de neumáticos muestreó 5 comerciantes, obteniendo en cada caso las cifras de inventario tanto para el año pasado como para el presente. Los datos están en la tabla
# a) Elabore un modelo de regresión lineal simple para los datos.
# b) Interprete el valor de los coeficientes de regresión
# c) Estime el inventario para el año presente si el inventario del año pasado fue de 125 unidades
# ---
inventarios = read.csv("C:\\Users\\Paul\\Google Drive\\UP\\UP_2020\\2021_2_Ing_Probabilidad_y_Estadística\\Unidad 7\\Inventarios_datos.csv", header=TRUE)
inventarios

reg2_modelo = regresion_lineal_simple(inventarios, x_nueva=125)
reg2_modelo

