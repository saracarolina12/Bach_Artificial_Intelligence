void setup(){
    int N = 10;
    int [] array = new int [N];
    for(int i=0; i<N;i++){
      array[i] = (int)random(0,100);
    }
    print("\t*Original: \t"); print_array(array); //original
    
    print("\n\t*Bubble: \t");
    bubble_sort(array); //bubble
    print_array(array);

}

void bubble_sort(int [] array){
    int N = array.length; 
    for(int i=N-1;i>0;i--){
      for(int j=0;j<i;j++){
       if(array[j]>array[j+1]){
        swap(array,j,j+1); 
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
