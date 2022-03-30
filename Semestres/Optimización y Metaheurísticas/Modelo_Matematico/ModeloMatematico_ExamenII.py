# Libreria de optimizacion
from docplex.mp.model import Model

# Cargar los datos

with open('input.txt') as f: 
   nElements, nClusters = [int(x) for x in next(f).split()] 
   next(f) 
   pesoMin, pesoMax = [int(x) for x in next(f).split()] 
   next(f)
   pesos = [int(x) for x in next(f).split()] 
   next(f) 
   beneficios = [[-1 for j in range(nElements)] for i in range(nElements)] 
   for line in f: 
      if(line!=""): 
         elem1, elem2, beneficio = [float(x) for x in line.split()] 
         beneficios[int(elem1)][int(elem2)] = beneficio 

# construir modelo
m = Model('Problema_examen_1')

# variables de decision
x = {}

for i in range(nElements):
   for k in range(nClusters):
         x[i,k] = m.binary_var(name='x_'+str(i)+'_'+str(k))

# funcion objetivo
m.maximize(m.sum(beneficios[i][j]*x[i,k]*x[j,k] for k in range(nClusters) for i in range(0, nElements-1) for j in range(nElements) if j > i))

# Restricciones
m.add_constraints(m.sum(pesos[i]*x[i,k] for i in range(nElements)) <= pesoMax for k in range(nClusters))

m.add_constraints(m.sum(pesos[i]*x[i,k] for i in range(nElements)) >= pesoMin for k in range(nClusters))

m.add_constraints(m.sum(x[i,k] for k in range(nClusters)) == 1 for i in range(nElements))

# Escribe modelo para su revision
#m.export_as_lp(basename="docplex_%s", path=".")


# llamado al solver de optimizacion
solucion = m.solve(log_output=True)

if(solucion):
   print('objective value =', m.sum(beneficios[i][j]*x[i,k].solution_value*x[j,k].solution_value for k in range(nClusters) for i in range(0, nElements-1) for j in range(nElements) if j > i))

   for k in range(nClusters):
      print('Grupo', k)
      for i in range(nElements):
         if x[i,k].solution_value == 1:
            print(x[i,k].name, end=" ")
      print('\n')

   for k in range(nClusters):
      print('Grupo', k, 'suma pesos=', m.sum(pesos[i]*x[i,k].solution_value for i in range(nElements)))

   for k in range(nClusters):
      print('Grupo', k, 'suma beneficios=', m.sum(beneficios[i][j]*x[i,k].solution_value*x[j,k].solution_value  for i in range(0, nElements-1) for j in range(nElements) if j > i))

