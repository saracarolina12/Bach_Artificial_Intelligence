void setup() {
  String s1 = "escuela";
  String s2 = "estudiante";

  s1 = s1.toLowerCase();
  s2 = s2.toLowerCase();

  println("\tCadena 1:", s1);
  println("\tCadena 2:", s2);
  println("\t*Distancia Hamming: ", distancia_hamming(s1, s2));
}
int distancia_hamming(String s1, String s2) {
  int tamano_minimo = min(s1.length(), s2.length());
  int dist = 0;
  for (int i=0; i<tamano_minimo; i++) {
    if (s1.charAt(i) != s2.charAt(i) )
      dist++;
  }
  int diferencia_cadenas = abs(s1.length()-s2.length());
  dist = dist + diferencia_cadenas;
  return dist;
}

int minimo(int a, int b, int c){
  return min(a, min(b, c));
}
