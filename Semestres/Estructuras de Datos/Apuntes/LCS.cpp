/*
  Longest Common Subsequence
    *Complejidad: O(mn)
*/

  //Código base
    if(stra[i-1] == strb[j-1]) //si son iguales
      mat[i][j] = mat[i-1][j-1]+1;   //--> diagonal + 1
    else //si son diferentes
      mat[i][j] = max(mat[i-1][j], mat[i][j-1]); //--> max(izq, arriba)

