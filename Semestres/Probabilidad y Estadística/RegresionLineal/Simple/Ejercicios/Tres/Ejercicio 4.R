source("C:/Users/scago/Documents/GitHub/IA_School/Semestres/Probabilidad y Estadística/RegresionLineal/Simple/Ejercicios/Tres/Regresion_util.r")

# 4. La Comisión Federal de Comunicaciones (FCC, por sus siglas en inglés) de Estados Unidos especifica
# que las emisiones electromagnéticas radiadas por dispositivos digitales se deben medir en un sitio
# de prueba de campo abierto. A fin de verificar la aceptabilidad de un sitio de prueba es preciso
# evaluar la atenuación del sitio (es decir, la pérdida de transmisión desde un dipolo de media onda hasta la salida de otro cuando ambos dipolos se colocan sobre el plano de tierra).
# Un estudio realizado en un sitio de prueba en Fort Collins, Colorado, produjo los siguientes datos de atenuación del sitio (en decibeles) y frecuencia de transmisión (en megahertz) para dipolos a una distancia de 3 metros.

# Frecuencia de transmisión, x, MHz
fTransmision = c(50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000)
# Atenuación del sitio, y, dBL 
atenuacion = c(11.5, 15.8, 18.2, 22.6, 26.2, 27.1, 29.5, 30.7, 31.3, 32.6, 34.9)

# a. Elabore un diagrama de dispersión para los datos. ¿Es evidente una relación lineal entre x y y?
regresion_lineal_simple(data.frame(cbind(fTransmision, atenuacion)))
# No parece muy lineal, porque los datos asemejan el comportamiento de una curva.

# b. Encuentre la línea de mínimos cuadrados que relaciona la atenuación del sitio y con la frecuencia de transmisión x.
# El modelo de regresión lineal que relaciona a las variables es:
  # Ygorro = Betagorro0 + Betagorro1*x
# Entonces la línea de mínimos cuadrados es:
  # Atenuaciongorro = 14.17492 + 0.02242*Frecuencia

# c. Trace la línea de mínimos cuadrados sobre el diagrama de dispersión para verificar sus cálculos.
# Listo, es la línea recta sobre el diagrama de dispersión (Gráfica de página 1)

# d. Interprete los valores de BetaGorroCero y BetaGorroUno.
# BetaGorroCero representa el punto donde se corta al eje de las Y. O sea, es nuestra línea evaluada en 0. Pero como no debería haber atenuación porque no hay emisión (Transmisión = 0), beta 0 debería ser 0.
# BetaGorroUno es la pendiente de la recta. Por cada MHz que en la transmisión, se incrementa 0.22db la atenuación.

# e. Elabore y analice las graficas de residuos estandarizados para ver si identifica violaciones a las suposiciones del modelo.
# Gráfica de dispersión vs x: 
  # Los datos asimilan una relación cuadrática respecto a x, ya que comienzan por debajo del 0, incrementan hasta cruzar la línea de 0 y después vuelven a bajar. No parecen valores aleatorizados.
# Histograma de residuos:
  # No parece cercano a una distribución normal. Hay valores en los extremos y hueco en el centro.
# Gráfico de probabilidad normal:
  # No se observan violaciones claras como en el histograma, aunque sí se observa una separación entre el primero y último dato, por lo que se les puede considerar valores extremos.
# Gráfico secuencial de residuos.
  # Debido a que los datos fueron tomados en orden ascendente, se observa el mismo resultado que en el gráfico de dispersión residuos vs x. O sea que los residuos suben y bajan respecto a su promedio.
# Todas las gráficas se ven correctas. Aunque hay una correlación positive en la grafica secuencial de residuos.
