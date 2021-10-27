void setup() {

  int[] array = {0, 9, 2, 5, 1, 3, 7, 6, 4, 8};

  print_array(array);
  heap_sort(array);
  print_array(array);
}
void heap_sort(int[] array) {
  //Inserción
  int N = array.length;
  //int p = h/2;
  //int h1 = p*2;
  //int h2 = p*2+1;
  for (int i=2; i<N; i++) {
    int j=i;
    while (j>1 && array[j/2]<array[j]) {
      swap(array, j/2, j);
      j=j/2;
    }
  }
  //Eliminación
  for (int i=N-1; i>0; i--) {    
    swap(array, 1, i);
    int p = 1;
    int h1 = p*2;
    int h2 = p*2+1;
   while (h1<i || h2<i) {
      if (h2<i && array[h1]<array[h2] && array[h2]>array[p]) {
        swap(array, p, h2);
        p=h2;
      } else if (h1<i && array[p]<array[h1]) {
        swap(array, p, h1);
        p=h1;
      } else {
        break;
      }
      h1=p*2;
      h2=p*2+1;
    }
  }
}


void swap(int[] array, int i, int j) {
  int aux = array[i];
  array[i] = array[j];
  array[j] = aux;
}
void print_array(int[] array) {
  print("[");
  int N = array.length;
  for (int i=0; i<N; i++) {
    print(array[i]); 
    print(",");
  }
  println("]");
}
