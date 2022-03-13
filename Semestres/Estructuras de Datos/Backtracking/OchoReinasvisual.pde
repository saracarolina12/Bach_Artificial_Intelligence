int [] sol={-1, -1, -1, -1, -1, -1, -1, -1};
int[][] soluciones = new int[92][8];
int cont=0;
void setup() {
  size(900, 900);

  backtracking(0);
  println(cont);
  frameRate(1);
  print_array();
}
void imprimir_tablero() {
  for (int i=0; i<8; i++) {
    for (int j=0; j<8; j++) {
      if ((i+j)%2==0) {
        fill(0);
      } else {
        fill(255);
      }
      rect(i*113, j*113, 113, 113);
    }
  }
}
int contador =0;
void draw() {
  imprimir_tablero();
  if (contador==92) contador = 0;

  for (int j=0; j<8; j++) {
    fill(255, 0, 0);
    circle(55+j*113, 55+soluciones[contador][j]*113, 55);
  }
  contador++;
}


boolean escorrecto(int col, int renglon) {
  for (int i=col-1; i>=0; i--) {
    if (sol[i]==renglon) return false;
  }

  for (int i=col-1, j=renglon-1; i>=0 && j>=0; i--, j--) {
    if (sol[i]==j) return false;
  }

  for (int i=col-1, j=renglon+1; i>=0 && j<8; i--, j++) {
    if (sol[i]==j) return false;
  }
  return true;
}

public void copyArr(int i) {
  for (int j = 0; j < 8; j++) {
    soluciones[i][j] = sol[j];
  }
}
void backtracking(int n) {
  if (n==8) { 
    print_array();
    copyArr(cont);
    cont++;
    return;
  }
  int i;
  for (i=0; i<8; i++) {
    if (escorrecto(n, i)) { 
      sol[n]=i;
      backtracking(n+1);
      sol[n]=-1;
    }
  }
}

void print_array() {
  print("[");
  for (int i =0; i < soluciones[0].length; i++) {
    if (i < soluciones[0].length - 1) print(soluciones[0][i] + ",");
    else print(soluciones[0][i]);
  }
  print("]\n");
}
