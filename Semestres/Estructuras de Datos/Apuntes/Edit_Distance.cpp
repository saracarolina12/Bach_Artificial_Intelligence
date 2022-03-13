/*
  Distancia de Levenshtein
   *Complejidad: O(n^2) u O(nlogn)
   
   Pasitos:
    1. Inicializar la matriz:
        if(j==0) mat[i][j] = i;
        if(i==0) mat[i][j] = j;
    2. Código base
*/

  //Código base
  if(stra[i-1]==strb[j-1]) //iguales
    mat[i][j] = mat[i-1][j-1]; //se copia la diagonal
  else //diferentes
    minimo = min(mat[i-1][j], mat[i][j-1], mat[i-1][j-1]) //-->min(izq, arriba, diagonal)
    mat[i][j] = minimo+1;
