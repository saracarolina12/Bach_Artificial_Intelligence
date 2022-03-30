//Sudoku
int mat[][] =   { {9, 6, 0, 1, 0, 4, 0, 5, 8}, 
  {0, 7, 8, 3, 2, 5, 6, 0, 9}, 
  {2, 5, 0, 6, 0, 0, 7, 0, 1}, 
  {8, 0, 1, 4, 0, 7, 5, 0, 6}, 
  {0, 9, 6, 0, 0, 2, 3, 0, 7}, 
  {7, 0, 5, 9, 6, 1, 0, 2, 4}, 
  {5, 0, 0, 7, 1, 0, 4, 6, 2}, 
  {3, 1, 7, 2, 0, 6, 9, 0, 0}, 
  {0, 4, 0, 5, 0, 8, 0, 7, 3} };
int matriz[][] = new int [9][9];
void printSol() {
  for (int i = 0; i < 9; i++) {
    for (int j = 0; j<9; j++) {
      matriz[i][j]= mat [i][j];
      print(matriz[i][j]+" ");
    }
    println();
  }
}
void board() {
  for (int j=0; j<9; j++) {
    for (int i= 0; i<9; i++) {
      if ((i+j) % 2 == 0) {
        fill(250);
      } else { 
        fill(255);
      }
      fill(255,195,random(255,176));
      rect(i*100, j*100, 100, 100);
    }
  }
}
boolean escorrecto(int renglon, int col, int i) {
  for (int j=0; j<9; j++) {
    if (mat[renglon][j]==i) { 
      return false;
    }
  }
  for (int j=0; j<9; j++) {
    if (mat[j][col]==i) {
      return false;
    }
  }
  int d=0;
  int a=0;
  if (col>=3 && col<6)a=3;
  if (col>=6)a=6;
  if (renglon>=3 && renglon<6)d=3;
  if (renglon>=6)d=6;
  for (int j=0+d; j<d+3; j++) {
    for (int k=0+a; k<a+3; k++) {
      if (mat[j][k]==i) {
        return false;
      }
    }
  }
  return true;
}
void backtracking(int renglon, int col) { 
  if (renglon==8 && col==9) {
    printSol();
    return;
  }
  if (col==9) {
    backtracking(renglon+1, 0);
    return;
  }
  if (mat[renglon][col]!= 0) {
    backtracking(renglon, col+1);
  } else {
    for (int i=1; i<=9; i++) {
      if (escorrecto(renglon, col, i)) {
        mat[renglon][col]=i;
        backtracking(renglon, col+1);
        mat[renglon][renglon]=0;
      }
    }
  }
  for(int i=0; i<9; i++){ 
    for(int j=0; j<9; j++){ 
      text(matriz[j][i], i*100+40, j*100+70);
    }
  }
}
void setup() {
  size(900, 900);
  board();
  fill(255,3,200);
  rect(3*100, 0, 7, 900);
  rect(6*100, 0, 7, 900);
  rect(0, 6*100, 900, 7);
  rect(0, 3*100, 900, 7);
  print();
  textSize(34);   
  backtracking(0, 0);
}
