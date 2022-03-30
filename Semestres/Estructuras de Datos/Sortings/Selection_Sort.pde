void setup(){
    int N = 10;
    int [] array = new int [N];
    for(int i=0; i<N;i++){
      array[i] = (int)random(0,100);
    }
    print("\t*Original: \t"); print_array(array); //original

    print("\n\t*Selection: \t");
    selection_sort(array); //selection
    print_array(array);
}


void selection_sort(int[]array){
    int N = array.length;
    for(int i=0; i<N-1; i++){
      for(int j=i+1; j<N;j++){
        if(array[j]<array[i]){
         swap(array,j,i);
        }
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
