/*
  Binary Indexed Tree (Fendwick Tree)
    //Encontrar suma dentro de un intervalo
      Características:
        *Los índices cambian a su representación binaria
        *Ideal para datos dinámicos(datos SÍ cambian)
    
      Complejidad:
          *Consulta: O(logn)
          *Update: O(logn)
          *Create: O(nlogn)
          *Memoria: O(n)
*/

  //Código base
  Cumulative_Sum(int k){
   int s=0;
    while(k>0)
      s+=BIT[k];
      k-=(k&(-k));
  }
  Update(int k, int delta){
    while(k<=n){
      BIT[k] += delta;
      k += (k&(-k));
    }
  }
