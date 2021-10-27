void setup() {
    int[] array = new int[20];
    for (int i=0; i<array.length; i++)
      array[i] = (int)random(0, 100);
    print_array(array);
    print("\n");
    quicksort(array);
    print_array(array);
}

void quicksort(int[] array) {
    quicksortR(array, 0, array.length-1);
}

void quicksortR(int[] array, int inicio, int fin) {
    if (inicio>=fin) return;
      if (fin-inicio == 1) {
        if (array[inicio]>array[fin]) {
          swap(array, inicio, fin);
        }
      return;
    }
    int p = inicio;
    int i = inicio+1;
    int d = fin;
   
    //indice izquierdo
    while (d!=i) {
      while (array[i]<=array[p]) {
        if (d==i) {
          break;
        }
        i++;
        
        
        //indice derecho
      }
      while (array[d]>array[p]) {
        if (d==i) {
          break;
        }
        d--;
      }
      if (d==i) {
        break;
      } else {
        swap(array, d, i);
      }
    }
    
    //pivote
    if (array[p]<=array[i]) {
      swap(array, p, i-1);
      p=i-1;
    } else {
      swap(array, p, i);
      p=1;
    }
    quicksortR(array, inicio, p-1);
    quicksortR(array, p+1, fin);
}


void swap(int[] array, int i, int j) {
    int aux   = array[i];
    array[i]  = array[j];
    array[j]  = aux;
}
void print_array(int[] array) {
    print("[");
    for (int i=0; i<array.length; i++) {
      print(array[i]);
      print(",");
    }
    println("]");
}
