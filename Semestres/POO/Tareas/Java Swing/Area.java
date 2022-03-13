import java.util.Scanner;
class args1{
  public static void main(String[] args) {
    Scanner inp = new Scanner(System.in);
    double b,h;
    System.out.print("*Ingrese la base: ");
    b=inp.nextDouble();
    System.out.print("*Ingrese la altura: ");
    h=inp.nextDouble();
    double area;
    area=b*h/2;
    System.out.print("\t-El area es: ");
    System.out.print(area);
   }
}
