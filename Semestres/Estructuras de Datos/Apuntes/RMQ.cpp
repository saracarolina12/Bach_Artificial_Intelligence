/*
  Range Minimum Query O(nlogn)
    Consultas (máx/mín)
    Características:
      -Ideal cuando los datos NO cambian
      -Crea una tabla (esto toma O(nlogn))
      -Una vez teniendo la tabla, se puede consultar en *O(2), lo que toma calcular log2
*/

  //Código base
    //comparar el renglón con la columna anterior con brincos a partir de donde estaba
    if(X[mat[i][j-1]] > X[mat[i + (1 << (j - 1))][j - 1]])
				mat[i][j] = mat[i][j-1];
    else
				mat[i][j] = mat[i + (1<<(j-1))][j-1];

    //Query
		int queryRMQ(int a, int b){
      int k = (int)log2(b - a + 1);
      int v1 = mat[a][k];
      int v2 = mat[b - (1 << k)+1][k]; //cachito que me falta
      return (X[v1] > X[v2] ? X[v1]: X[v2]);
  }
  
