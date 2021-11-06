# Universidad Panamericana
# Campus Bonaterra
# Departamento de Matemáticas
# Probabilidad y Estadística para Ingeniería
# 
# Paul RC
# 2021 11 01
# =====
# Ejercicio 1. Regresión Lineal Simple. Procesamiento de datos
# -----
# Lectura de archivo de funciones
# -----
source("C:\\Users\\Paul\\Google Drive\\UP\\UP_2020\\2021_2_Ing_Probabilidad_y_Estadística\\Unidad 7\\Regresion_util.r")
# -----
# Funciones
# -----

# =====
# Programa principal
# -----
# 1.	[Ejercicio suplementario 11.57 Mendenhall] Un nuevo paquete de software de consulta se diseñó con el objetivo de lograr un acceso y un mantenimiento más eficientes de los conjuntos de datos a gran escala. La eficiencia se mide en términos del número de operaciones de entrada/salida (E/S) de disco (llamadas bloques de almacenamiento) necesarias para acceder al conjunto de datos y darle mantenimiento; cuanto menor sea el número de bloques leídos, con mayor rapidez se efectuará la operación. A fin de evaluar el desempeño del nuevo sistema de software, se registró el número de operaciones de E/S de disco necesarias para acceder a un conjunto de datos a gran escala, para cada uno de una muestra de 15 conjuntos de datos de diversos tamaños (donde el tamaño se mide como el número de registros contenidos en el conjunto de datos, en miles)
# Registros	350	200	450	50	400	150	350	300	150	500	100	400	200	50	250
# E/S disco	36	20	45	5	40	18	38	32	21	54	11	43	19	7	26
# a.	Elabore la gráfica de dispersión. ¿Parece existir una relación lineal entre las variables?
# --
procesamiento_datos = read.csv("C:\\Users\\Paul\\Google Drive\\UP\\UP_2020\\2021_2_Ing_Probabilidad_y_Estadística\\Unidad 7\\Procesamiento_datos.csv")
procesamiento_datos
reg1 = regresion_lineal_simple(procesamiento_datos)
# R: Aparentemente los datos tienen un comportamiento lineal
# ---
#  b.	Estime puntualmente los coeficientes del modelo de regresión lineal simple e interprételos en el contexto del problema. Grafique la recta de regresión sobre la dispersión.
reg1
# beta_gorro0 = 1.403
#     Esto significa que cuando se procesa un archivo con 0 (miles de)
#     registros, se espera que el número de operaciones de ES sea de 1.403
#     Otra forma de interpretarlo sería:
#     El número mínimo de operaciones de ES que se requiere para procesar
#     un archivo es de 1.403.
#
# beta_gorro1 = 0.101
#     Esto significa que por cada 1 (mil) registros adicionales, se requerirá
#     de 0.101 operaciones de ES adicionales
# El modelo es, entonces:
#     y_gorro = 1.403 + 0.101*x
#     ES_operaciones = 1.403 + 0.101*Registros
#
# ---
# c.	Proporcione una estimación por intervalo del 90% de confianza para beta0. Interprete el resultado
# d.	Proporcione una estimación por intervalo del 90% de confianza para beta beta1. Interprete el resultado


# e.	Calcule el valor de r y r2 e interprete ambos resultados. ¿Corresponden con lo observado en el inciso a)?
reg1 = regresion_lineal_simple(procesamiento_datos)
reg1
# r = 0.992, lo cual indica que existe una relación lineal muy alta y positva
#             entre el número de (miles de) registros y el número de operaciones
#             de ES
# r^2 = 0.984, lo cual indica que el 98.4% de la variabilidad que se observa en
#             el número de operaciones de ES de disco está explicada por el
#             número de (miles de) registros
# Los valores de estas dos medidas nos dicen que la relación entre ambas
# variables es muy cercana a una línea recta
# ---
#  f.	Estime puntualmente el número medio de operaciones de E/S que se tendría si se procesa un archivo de 444 (miles de) registros
reg1 = regresion_lineal_simple(procesamiento_datos, x_nueva=444)
reg1
# Para Registros = 444 mil, el número de operaciones de ES es 46.253
# ---

# g.	Estime con un intervalo de confianza de 95% el número medio de operaciones de E/S (en miles) que se tendría si se procesa un archivo de 444 (miles de) registros
# h.	Estime con un intervalo de confianza de 95% el número observado de operaciones de E/S (en miles) que se tendría si se procesa un archivo de 444 (miles de) registros

# i.	Elabore para los residuos una gráfica de dispersión contra X, un histograma, una gráfica de cuantiles normales (probabilidad normal) y una gráfica secuencial y analícelas para establecer si presentan violaciones claras a los supuestos del modelo de regresión lineal simple
# ----
reg1 = regresion_lineal_simple(procesamiento_datos)
reg1
# Gráfica de dispersión
#   Los residuos no muestran tendencias claras y en general están por todo el
# espacio de la gráfica. Los podemos considerar correctos
# Histograma de residuos
#   Es ligeramente sesgado a la derecha; pero en general se ve bien.
# Aparentemente los residuos son Normales
# Gráfica de probabilidad Normal
#   Los residuos parecen estar aleatoriamente por arriba y por abajo de la recta
# además de que en general están muy cerca de esta. Los residuos parecen ser
# Normales
# Gráfica secuencial de residuos
#   No se aprecia claramente que haya correlación positiva ni negativa entre los
# residuos, por lo cual se pueden considerar correctos