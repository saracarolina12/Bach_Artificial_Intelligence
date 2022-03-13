# Universidad Panamericana
# Campus Bonaterra
# Departamento de Matemáticas
# Probabilidad y Estadística para Ingeniería
# 
# Paul RC
# 2021 11 24
# =====
# Regresión Múltiple
# =====
# 4.	[Problema 14.18 p. 534 Lind et al.] Las tiendas de Fran's Convinience Marts están localizadas en el área metropolitana de Erie, Pennsylvania (EUA). A Fran, la dueña, le agradaría expandirse a otras comunidades del noroeste de Pennsylvania y el suroeste de Nueva York, tales como Jamestown, Corry, Meadville y Warren. Como parte de su presentación al banco local, le gustaría entender mejor los factores que hacen que una tienda particular sea lucrativa. La propietaria debe hacer todo el trabajo sola, así que no podrá analizar todos sus establecimientos. Selecciona una muestra aleatoria de 15 tiendas y de cada una registra el promedio de las ventas diarias (Y), la superficie (área), el número de cajones de estacionamiento, y el ingreso económico medio de familias en esa región
# Venta Diaria	Área de la Tienda	Cajones	Ingresos
# 1840	532	6	44
# 1746	478	4	51
# 1812	530	7	45
# 1806	508	7	46
# 1792	514	5	44
# 1825	556	6	46
# 1811	541	4	49
# 1803	513	6	52
# 1830	532	5	46
# 1827	537	5	46
# 1764	499	3	48
# 1825	510	8	47
# 1763	490	4	48
# 1846	516	8	45
# 1815	482	7	43
# =====
# Lectura de datos
tiendas_datos = read.csv("C:\\Users\\Paul\\Google Drive\\UP\\UP_2020\\2021_2_Ing_Probabilidad_y_Estadística\\Unidad 7\\Tiendas_datos.csv")
head(tiendas_datos)

# a.	Obtenga el mejor modelo de regresión lineal múltiple utilizando el método de selección de variables paso a paso.
# ---
# Obtención del modelo examinando las pruebas T individuales
tiendas_modelo = lm(VentaDiaria ~ AreaDeLaTienda + Cajones + Ingresos,
                    data=tiendas_datos)
summary(tiendas_modelo)
# Coefficients:
#   Estimate Std. Error t value Pr(>|t|)    
# (Intercept)    1480.7446   126.3042  11.724 1.48e-07 ***
#   AreaDeLaTienda    0.7315     0.1633   4.479 0.000933 ***
#   Cajones           9.9915     2.6000   3.843 0.002733 ** 
#   Ingresos         -2.3083     1.5947  -1.447 0.175655    
# ---
#   Signif. codes:  0 '***' 0.001 '**' 0.01 '*' 0.05 '.' 0.1 ' ' 1
# 
# Residual standard error: 13.42 on 11 degrees of freedom
# Multiple R-squared:  0.8354,	Adjusted R-squared:  0.7905 
# F-statistic:  18.6 on 3 and 11 DF,  p-value: 0.0001285
# ---
# Del resumen de los resultados del modelo, observamos que habría que conservar
# las variables AreaDeLaTienda y Cajones.
# Entonces:
tiendas_modelo = lm(VentaDiaria ~ AreaDeLaTienda + Cajones,
                    data=tiendas_datos)
summary(tiendas_modelo)
# Coefficients:
#   Estimate Std. Error t value Pr(>|t|)    
# (Intercept)    1342.4902    86.3319  15.550 2.57e-09 ***
#   AreaDeLaTienda    0.7727     0.1680   4.599 0.000612 ***
#   Cajones          11.6338     2.4438   4.761 0.000464 ***
#   ---
#   Signif. codes:  0 '***' 0.001 '**' 0.01 '*' 0.05 '.' 0.1 ' ' 1
# 
# Residual standard error: 14.02 on 12 degrees of freedom
# Multiple R-squared:  0.804,	Adjusted R-squared:  0.7713 
# F-statistic: 24.61 on 2 and 12 DF,  p-value: 5.67e-05
# ---
# El modelo es:
# VentasDiarias = 1342.4902 + 0.7727*AreaDeLaTienda + 11.6338*Cajones
# que explica el 77.13% de la variabilidad de las ventas diarias
# 
# Interpretación de los coeficientes:
# beta_gorro0 = 1342.4902, una tienda tiene ventas diarias promedio
#                           de 1342.4902, sin considerar el área y el
#                           número de cajones
# beta_gorro1 = 0.7727,    por cada pie^2 adicional de superficie en la
#                           tienda, las ventas diarias se incrementan
#                           0.7727
# beta_gorro2 = 11.6338,   por cada cajón de estacionamiento adicional
#                           las ventas diarias se incrementan 11.6338
# -----

# b.	Realice un análisis completo de residuos para el modelo obtenido.
# Residuos vs Area de la tienda
residuos = tiendas_modelo$residuals
graficas_residuos(residuos, tiendas_datos$AreaDeLaTienda, "Área de la tienda")
# En general los residuos parecen comportarse adecuadamente.
# Podría parecer que hay más residuos con valores por arriba de 1.0 que los
# que se esperaría
# ---
# Residuos vs Cajones
graficas_residuos(residuos, tiendas_datos$Cajones, "Cajones")
# Tampoco se observan comportamientos demasiado extraños en los residuos vs
# el número de cajones de estacionamiento






































