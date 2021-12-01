GRASP
Greedy
Randomized
Adaptive
Search
Procedure
->Consiste en dos fases:
	1. Fase constructiva (Greedy Randomized Adaptive): consiste en generar una buena solución factible.
	2. Fase de mejora local (Local Search): consiste en mejorar localmente la solución

La solución obtenida después de las dos fases, se almacena y se realiza una nueva iteración (guardando cada vez la mejor solución que se haya encontrada hasta el momento)

------------------------------------------------------------------------------------------
FASE #1 - Greedy Randomized Adaptive
	1. Algoritmo voraz: Siempre toma la mejor elección disponible en cada paso
	2. Función adaptativa (función greedy): función que indica qué elemento seleccionar para la solución parcial.
	3. Selección probabilista: 
		-Selecciona a los candidatos con los mejores valores de la función greedy, entre los cuales elegimos el siguiente elemento que se agregará a la solución parcial. (Lista restringida de cantidatos (RCL))
		-El siguiente candidato se selecciona aleatoriamente de la RCL