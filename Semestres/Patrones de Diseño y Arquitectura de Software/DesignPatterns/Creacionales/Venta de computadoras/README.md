## Venta de computadoras
####  Para resolver este problema se han utilizado dos implementaciones del patron de diseño conocido como "Builder". Las cuales se dividen de la siguiente manera:
#### a) Computadora: nuestro "todo", que es el builder encargado de unir los componentes por cada tipo de computadora (en nuestro caso, son 'Basic Computer' y 'Medium Computer')
#### b) Componentes de la computadora: Cuyos componentes básicos incluyen entradas, salidas y unidad central. Además de tener la opción de añadir otros periféricos más (como lo es en el caso de medium computer, quien tiene dos entradas y varias salidas).
#### El problema en sí es lo suficientemente complejo y cumple con los puntos más importantes que conforman a dicho patrón de diseño:
#### 1. Se define un director que llama a un método builder en el orden correcto.
#### 2. El cliente no usa la sentencia "new" en ninguna parte y solo use el builder para crear nuevas instancias.
#### Además de que builder te permite otorgar un orden de construcción, lo cual es vital al construir una computadora (en la vida real). 
#### Por último, me gustaría añadir que para este problema, utilizar builder nos resulta beneficioso a futuro, debido a que el 'molde' o interfaz de una computadora puede llegar a representarse de demasiadas maneras, pues cada marca saca su propia versión. Por lo tanto, builder es el patrón ideal, ya que se encarga de representar un producto de varias maneras posibles. 

