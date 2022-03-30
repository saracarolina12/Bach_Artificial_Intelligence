void setup() {
    String texto = "saracarolina";
    String patron = "caro";
  
    texto = texto.toLowerCase();
    patron = patron.toLowerCase();
  
    println("\t*Texto original:\t\t", texto);
    println("\t*Patron que coincide:\t", patron);
    //tamaño de coincidencia
    println("\t*Búsqueda kmp:\t\t", busqueda_kmp(texto, patron));
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
        estado = estado == 0? -1: estado;
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
