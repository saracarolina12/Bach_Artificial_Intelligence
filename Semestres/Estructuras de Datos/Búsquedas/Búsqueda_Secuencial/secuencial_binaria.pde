void setup(){
    // Crear la lista de estudiantes
    int N = 20;
    Estudiante[] lista = new Estudiante[N];
    for(int i=0;i<N;i++){
      lista[i] = new Estudiante();
    }
    bubble_sort(lista);
    print_estudiantes(lista);
    
    // Buscar un estudiante por su id
    int id = (int) random(1200,1250);
    Estudiante e;
    e = busqueda_binaria(lista,id);
    println("Estudiante con el id:",id);
    if(e == null){
      println("No se encontró el registro");
    }else{
      print(e);
    }
}
Estudiante busqueda_secuencial(Estudiante[] lista,int id){
    for(int i=0;i<lista.length;i++){
       if( lista[i].ID == id ){
           return lista[i];
       }
    }
    return null;
}

Estudiante busqueda_binaria(Estudiante[] lista,int id){
    int ini=0;
    int f=lista.length-1;
    int m = ini+(f-ini)/2;
    // Paso 2. Búsqueda binaria
   while(ini<=f){
     m = ini+(f-ini)/2;
     if(lista[m].ID==id){
       return lista[m];
     }else if(id<lista[m].ID){
      f = m-1;
    }else{
      ini = m+1;
    }
   }
    return null;
}

  // Paso 1. Ordenar la lista de estudiantes por id
void bubble_sort(Estudiante [] lista){
    for(int i=lista.length-1;i>0;i--){
      for(int j=0;j<i;j++){
       if(lista[j].ID>lista[j+1].ID){
        swap(lista,j,j+1); 
       }
      } 
    }
 }
 
void swap(Estudiante []lista,int i, int j){
     Estudiante aux=lista[i];
     lista[i] = lista[j];
     lista[j]=aux; 
}

void print_estudiantes(Estudiante[] lista){
    for(int i=0;i<lista.length;i++){
      print(lista[i]);
    }
}
