/*
  //Encuentra el camino más corto
  //Identifica si existe un ciclo negativo
  
  *A base de relajación de aristas
  *Funciona con pesos + y -

*/
  
  //Código base 
  D[j] = min(D[j], D[i] + W[i][j]);

  Nota:
    Para ver si hay ciclo negativo, se hace una relajación extra
  
