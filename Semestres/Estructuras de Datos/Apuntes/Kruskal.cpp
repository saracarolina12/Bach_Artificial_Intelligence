/*
  //Mínimo costo de MST y las aristas
    O(mlogm + mlogn)
    *ordena (menor->mayor) por pesos
*/

  //Código base
  if(!u.isSameSet(x.s.f, x.s.s)){
    	u.unionSet(x.s.f, x.s.s); 
     	cost += x.f;
    }
