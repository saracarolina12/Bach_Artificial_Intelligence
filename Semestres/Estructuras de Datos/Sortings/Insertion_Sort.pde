void setup(){
    int N = 10;
    int [] array = new int [N];
    for(int i=0; i<N;i++){
      array[i] = (int)random(0,100);
    }
    print("\t*Original: \t"); print_array(array); //original
    
    print("\n\t*Insertion: \t");
    insertion_sort(array); //insertion
    print_array(array);
}


void insertion_sort(int[] array){
  int N = array.length;
   for(int i=1; i<N; i++){
     for(int j=i; j>0 && array[j]<array[j-1]; j--){
         swap(array,j-1,j);
       }
    }
}

void swap(int []array,int i, int j){
   int aux=array[i];
   array[i] = array[j];
   array[j]=aux; 
}

void print_array(int [] array){
   print("["); 
   int N= array.length;
   for(int i=0;i<N;i++){
      print(array[i]);print(","); 
   }
  print("]");
}
