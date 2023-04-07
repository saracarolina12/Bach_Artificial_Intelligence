import java.util.HashMap;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        HashMap<String, String> diccionario = new HashMap<String, String>();
        
        for(int i=0; i<5; i++){
            System.out.println("\tInserte key");
            String key = sc.nextLine();
            if(!diccionario.containsKey(key)){
                System.out.println("\tInserte value");
                String value = sc.nextLine();
                diccionario.put(key, value);
            }else{
                System.out.println("------- Duplicado. Intente nuevamente. -------");
                i-=1;
            }
        }
        
        for (String i : diccionario.keySet()) {
            System.out.println(i);
        }
    }
}
