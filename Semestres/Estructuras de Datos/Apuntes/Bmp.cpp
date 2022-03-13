/*
  //Máx parejitas de derecha a izquierda en un grafo bipartito sin que haya varios (de der->izq)
    O(n^2*m)
*/

  //Código base
  vector<int> L,R,visited;
  L.assign(n,-1); R.assign(n,-1);
  for(int i=0; i<n; i++){
      vi.assign(n,0);
      if(bmp(i)) mx++;
   }
