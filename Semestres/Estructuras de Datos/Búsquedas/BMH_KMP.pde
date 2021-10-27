import java.util.Arrays;
void setup() {
    String texto = "What does distance mean if we´ve got music?";
    String patron = "music";
  
    texto = texto.toLowerCase();
    patron = patron.toLowerCase();
  
    println("Texto:", texto);
    println("Patron:", patron);
    println("Búsqueda kmp:", busqueda_kmp(texto, patron));
    println("Búsqueda BMH:", busqueda_bmh(texto, patron));
}
  ArrayList<Integer> busqueda_kmp(String texto, String patron) {
  ArrayList<Integer> lista = new ArrayList<Integer>();

  int estado;
  //Paso 1. Patrón, calcular regresos
  int[] regreso = new int[patron.length()];
  regreso[0] = -1;
  for (int i=1; i<patron.length(); i++) {
    estado = regreso[i-1]+1;
    while (patron.charAt(i)!= patron.charAt(estado)) {

      if (estado==0) {
        estado = -1;
        break;
      }
      estado = regreso[estado-1]+1;
    }
    regreso[i] = estado;
  }  

  estado = -1;  //el paso 2 inicia desde -1
  int n= patron.length()-1, m = texto.length();
  //Paso 2. Patron dentro del texto
  for (int i=0; i<m; i++) {
    estado++;
    while (texto.charAt(i)!= patron.charAt(estado) && estado>-1) {
      estado = estado == 0? -1: estado; //si estado ==0, se cambia su valor a -1
      if (estado == -1) break;
      estado = regreso[estado-1]+1;
    } 
    if (estado==n) {
      lista.add(i-estado);
      estado=regreso[estado];
    }
  }  
  return lista;
}

ArrayList<Integer> busqueda_bmh(String texto, String patron) {
  ArrayList lista = new ArrayList<Integer>();
  int arr[] = new int[255];
  int k=0;
  int m=0;
  int i=0;
  int N= patron.length();

  for (i = 0; i < N- 1; i++ ) 
    arr[(int)patron.charAt(i)] = N - i - 1;

  while (N+k <= texto.length() ) {
    while (m < N && texto.charAt(k) == patron.charAt(m)) {
      k++;
      m++;
    }
    if (m==N) {
      lista.add(k-N);
      k-=m;
    }
    if ( arr[texto.charAt(k+N-1)] == 0 ){
      k = k + N;
    }
    else {
      k = k + arr[texto.charAt(k+N-1)];
      m = 0;
    }
  }

return lista;
}
