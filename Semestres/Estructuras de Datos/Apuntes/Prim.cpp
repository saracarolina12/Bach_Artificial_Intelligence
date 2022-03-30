/*
  //Mínimo costo del MST (que conecte todos los nodos)
    O(n^2)
    **Implementación similar a Dijkstra
*/
      0    1    2    3    4
  D = [0][inf][inf][inf][inf]
  //Código base
  D[j] = min(D[j], W[k][j]);
