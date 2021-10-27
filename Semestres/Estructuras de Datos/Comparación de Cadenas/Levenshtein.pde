void setup() {
  String s1 = "escuela";
  String s2 = "estudiante";

  s1 = s1.toLowerCase();
  s2 = s2.toLowerCase();

  println("\tCadena 1:", s1);
  println("\tCadena 2:", s2);
  println("\t*Edit Distance: ", distancia_levenshtein(s1, s2));
}

int minimo(int a, int b, int c){
  return min(a, min(b, c));
}

int distancia_levenshtein(String s1, String s2) {
  int dist = 0;
  int tabla[][] = new int[s1.length()+1][s2.length()+1];

  for (int i=0; i<=s1.length(); i++) {
    tabla[i][0]=i; //filas
    for (int j=0; j<=s2.length(); j++) {
     tabla[0][j]=j;//columnas
    }
  }
  
  for (int i=1; i<s1.length()+1; i++) {
    for (int j=1; j<s2.length()+1; j++) {
      if (s1.charAt(i-1) == s2.charAt(j-1)) {
        dist =0;
      } else {
        dist=1;
      }
      tabla[i][j] = minimo(tabla[i-1][j]+1,tabla[i][j-1]+1,tabla[i-1][j-1]+dist);
    }
  }
   return tabla[s1.length()][s2.length()];
}
