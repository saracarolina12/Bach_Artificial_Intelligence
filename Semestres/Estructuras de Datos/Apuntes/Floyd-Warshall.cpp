/*
  //Encontrar el costo del camino más corto
    O(n^3)
      *Funciona con + y -
      *La diferencia con otros algoritmos es que desde la primera vuelta obtiene el resultado
  */

  //Código base
  W[i][j] = min(W[i][j], W[i][k], W[k][j]);
