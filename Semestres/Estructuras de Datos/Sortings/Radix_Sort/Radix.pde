import java.util.Queue;
import java.util.LinkedList;

void setup() {
  Queue<Fecha> lista = new LinkedList<Fecha>(); 
  int N = 10; 
  Fecha f;

  for (int i= 0; i<N; i++) 
  { 
    f = new Fecha();
    lista.add(f);
    print(f);
  }

  print("\n");

  radixsort_fechas(lista); 
  println("Ordenamiento con Radixsort: ");
  while ( !lista.isEmpty()) 
  {
    f = lista.poll();
    print(f);
  }
}

void radixsort_fechas(Queue<Fecha> lista)
{
  Queue<Fecha>[] listas = new Queue[10];

  for (int l=0; l<10; l++)
  {
    listas[l] = new LinkedList<Fecha>();
  }

  Fecha f;

  int p; // unidad del dia


  for (int k = 0; k<=8; k++)
  {
    while ( !lista.isEmpty())
    {
      f = lista.poll(); 
      p = f.parte(k);
      listas[p].add(f);
    }
    for (int l=0; l<10; l++)
    {
      while ( !listas[l].isEmpty() ) 
      {
        f = listas[l].poll();
        lista.add(f);
      }
    }
  }
}
