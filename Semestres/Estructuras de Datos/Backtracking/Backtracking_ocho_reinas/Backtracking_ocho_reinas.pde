int [] sol={-1,-1,-1,-1,-1,-1,-1,-1};
void setup(){
  print_array();
  backtracking(0);
}
void backtracking(int v){
  print_array();
  if(v >=sol.length) 
    return;
  for(int i=0; i<8; i++){
    sol[v] = i;
    backtracking(v+1);
    sol[v] = -1;
  }
}

void print_array(){
  print("[");
  for(int i =0; i < sol.length; i++){
    if(i < sol.length - 1) print(sol[i] + ",");
    else print(sol[i]);
  }
  print("]\n");
}
