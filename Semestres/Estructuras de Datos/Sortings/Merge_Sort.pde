void setup() {
  int N = 6;
  int[] arr = new int[N];
  for (int i=0; i<arr.length; i++) {
    arr[i] = (int)random(0, 100);
  }
  print_array(arr);
  mergesort(arr);
  print_array(arr);
}

void mergesort(int[] arr) {
  int[] arr_copia = new int[arr.length];
  mergesortR(arr, arr_copia, 0, arr.length-1);
}
void mergesortR(int[] arr, int[] arr_copia, int inicio, int fin) {
 
  // Casos base, cuando tengo 1 o 2 elementos
  if (inicio>=fin) return;
    if (fin-inicio == 1) {
    if (arr[inicio]>arr[fin]) {
      swap(arr, inicio, fin);
    }
    return;
  }
 
  // Calcular el punto medio de la lista
  int m = inicio+(fin-inicio)/2;

  // Llamada recursiva
  
  // 1ra recursiva - del inicio al punto medio
  mergesortR(arr, arr_copia, inicio, m);

  // 2da recursiva - del punto medio +1 al fin
  mergesortR(arr, arr_copia, m+1, fin);

  // Merge: i, j, k
  int i = inicio;
  int j=m+1;
  
  for(int k=inicio;k<=fin; k++){
    if((i<=m && j<=fin && arr[i]<=arr[j]) || j>fin){
      arr_copia[k] = arr[i];
      i++;
    }
    else{
      arr_copia[k] = arr[j];
      j++;
    }
  }
  
  for(int k=inicio;k<=fin; k++){
    arr[k] = arr_copia[k];
  }
  
  
}

void swap(int[] arr, int i, int j) {
  int aux   = arr[i];
  arr[i]  = arr[j];
  arr[j]  = aux;
}

void print_array(int[] arr) {
  for (int i=0; i<arr.length; i++) {
    print(arr[i]);
    print(",");
  }
  println();
}
