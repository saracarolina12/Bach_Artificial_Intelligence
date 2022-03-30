/*
  //Encontrar el camino más corto {{a,b}, w}
    O(nlogn)
      
      *Sólo pesos positivos (+)
      
      v[i] = 0;
      D[i]:
          i != a   {inf}
          i == a    {0} 
*/  
 
  //Código base
  D[j] = min(D[j], D[k] + G[k][j]);
