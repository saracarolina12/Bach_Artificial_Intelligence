class Estudiante{
    String nombre;
    String apellido;
    int ID;
    String carrera;
    
    Estudiante(){
         String[] nombres = {"Juan","Ana","Pedro","Raul","Gabriel"};
         String[] apellidos = {"López","Chávez","Martínez","Pérez","León"};
         String[] carreras = {"IIA","IM","IBE"};
         
         nombre = nombres[ (int)random(nombres.length) ];
         apellido = apellidos[ (int)random(apellidos.length) ];
         carrera = carreras[ (int)random(carreras.length) ];
         ID = (int) random(1200,1250);
         
    }
    public String toString(){
        return Integer.toString(ID) + " " + carrera + " " + nombre + " " + apellido +"\n";
    }
}
