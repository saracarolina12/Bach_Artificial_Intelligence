# Universidad Panamericana
# Campus Bonaterra
# Departamento de Matemáticas
# Probabilidad y Estadística para Ingeniería
# 
# Paul RC
# 2021 11 08
# =====
# Lectura del archivo de utilerías
source("C:\\Users\\Paul\\Google Drive\\UP\\UP_2020\\2021_2_Ing_Probabilidad_y_Estadística\\Unidad 7\\Regresion_util.r")
# =====
# Programa principal
# ---
# 4.	La Comisión Federal de Comunicaciones (FCC, por sus siglas en inglés) de Estados Unidos especifica que las emisiones electromagnéticas radiadas por dispositivos digitales se deben medir en un sitio de prueba de campo abierto. A fin de verificar la aceptabilidad de un sitio de prueba es preciso evaluar la atenuación del sitio (es decir, la pérdida de transmisión desde un dipolo de media onda hasta la salida de otro cuando ambos dipolos se colocan sobre el plano de tierra). Un estudio realizado en un sitio de prueba en Fort Collins, Colorado, produjo los siguientes datos de atenuación del sitio (en decibeles) y frecuencia de transmisión (en megahertz)  para dipolos a una distancia de 3 metros.
# Frecuencia de transmisión, x, MHz	50	100	200	300	400	500
# Atenuación del sitio, y, dBL	11.5	15.8	18.2	22.6	26.2	27.1
# --
# Frecuencia de transmisión, x, MHz	600	700	800	900	1000	
# Atenuación del sitio, y, dBL	29.5	30.7	31.3	32.6	34.9	
# --
# Definición de los datos
Frecuencia = c(50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000)
Atenuacion = c(11.5, 15.8, 18.2, 22.6, 26.2, 27.1, 29.5, 30.7, 31.3, 32.6, 34.9)
emisiones_datos = data.frame(cbind(Frecuencia, Atenuacion))
emisiones_datos
# ---
# a.	Elabore un diagrama de dispersión para los datos. ¿Es evidente una relación lineal entre x y y?
modelo1 = regresion_lineal_simple(emisiones_datos)
modelo1
# R: No parece muy lineal la relación entre las variables, porque se aprecia una curvatura en la disposición de los puntos. Comienzan por debajo de la recta, luego suben y después bajan y la vuelven a cruzar

# ---
#  b.	Encuentre la línea de mínimos cuadrados que relaciona la atenuación del sitio y con la frecuencia de transmisión x.
modelo1
# El modelo de regresión lineal simple que relaciona las variables es:
# y_gorro = beta_gorro0 + beta_gorro1*x
# Atenuacion_gorro = 14.1749 + 0.0224*Frecuencia

# ---
# c.	Trace la línea de mínimos cuadrados sobre el diagrama de dispersión para verificar sus cálculos.
# La recta se traza al ejecutar nuestra función de regresión lineal

# ---
# d.	Interprete los valores de beta_gorro0 y beta_gorro1
# beta_gorro0 = 14.1749
#     Esto significa que para una frecuencia de 0 MHz, la atenuación sería 
#     de 14.1749. Aunque dado que no habría atenuación si no hay emisión de
#     señal, parece que en realidad beta0 = 0
#
# beta_gorro1 = 0.0224
#     Esto se interpreta como que por cada MHz adicional en la señal radiada
#     la atenuación aumenta 0.0224 dB

# ---
# e.	Elabore y analice las gráficas de residuos estandarizados para ver si identifica violaciones a los supuestos del modelo
# Gráfica de dispersión vs x
#   Los residuos parecen tener una relación cuadrática con respecto a x dado
#   que comienzan siendo negativos, ascienden y se vuelven positivos y después
#   bajan y se hacen negativos de nuevo. Eso no parece un comportamiento
#   aleatorio
# Histograma de residuos
#   No parece muy cercano a una distribución Normal, parece haber valores
#   extremos a ambos lados de la media y un hueco en la parte central
# Gráfico de probabilidad Normal
#   No se observan violaciones claras al supuesto de Normalidad, al menos no
#   tan claras como en el histograma, aunque sí se aprecia que el primero y
#   el último dato están alejados del resto, por tanto se les puede considerar
#   como valores extremos
# Gráfica secuencial de residuos
#   Dado que los datos fueron tomados en orden ascendente en X (Frecuencia)
#   esta gráfica muestra el mismo comportamiento que ya habíamos visto en la
#   gráfica de dispersión: los residuos suben y luego bajan con respecto a su
#   valor promedio




















