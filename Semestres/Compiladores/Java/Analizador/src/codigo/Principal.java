/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package codigo;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

/**
 *
 * @author lalor
 */
public class Principal {
    public static void main(String[] args) throws Exception {
        String ruta1 = "C:\\Users\\scago\\Documents\\GitHub\\IA_School\\Semestres\\Compiladores\\Java\\Analizador\\src\\codigo\\Lexer.flex";
        String ruta2 = "C:\\Users\\scago\\Documents\\GitHub\\IA_School\\Semestres\\Compiladores\\Java\\Analizador\\src\\codigo\\LexerCup.flex";
        String[] rutaS = {"-parser", "Sintax", "C:\\Users\\scago\\Documents\\GitHub\\IA_School\\Semestres\\Compiladores\\Java\\Analizador\\src\\codigo\\Sintax.cup"};
        generar(ruta1, ruta2, rutaS);
    }
    public static void generarLexer(String ruta){
        File archivo = new File(ruta);
        JFlex.Main.generate(archivo);
    }
    public static void generar(String ruta1, String ruta2, String[] rutaS) throws IOException, Exception {
        File archivo;
        archivo = new File(ruta1);
        JFlex.Main.generate(archivo);
        archivo = new File(ruta2);
        JFlex.Main.generate(archivo);
        java_cup.Main.main(rutaS);
        Path rutaSym = Paths.get("C:\\Users\\scago\\Documents\\GitHub\\IA_School\\Semestres\\Compiladores\\Java\\Analizador\\src\\codigo\\sym.java");
        if(Files.exists(rutaSym)){
            Files.delete(rutaSym);
        }
        Files.move(
            Paths.get("C:\\Users\\scago\\Documents\\GitHub\\IA_School\\Semestres\\Compiladores\\Java\\Analizador\\sym.java"), 
            Paths.get("C:\\Users\\scago\\Documents\\GitHub\\IA_School\\Semestres\\Compiladores\\Java\\Analizador\\src\\codigo\\sym.java")
        );
        Path rutaSin = Paths.get("C:\\Users\\scago\\Documents\\GitHub\\IA_School\\Semestres\\Compiladores\\Java\\Analizador\\src\\codigo\\Sintax.java");
        if(Files.exists(rutaSin)){
            Files.delete(rutaSin);
        }
        Files.move(
            Paths.get("C:\\Users\\scago\\Documents\\GitHub\\IA_School\\Semestres\\Compiladores\\Java\\Analizador\\Sintax.java"), 
            Paths.get("C:\\Users\\scago\\Documents\\GitHub\\IA_School\\Semestres\\Compiladores\\Java\\Analizador\\src\\codigo\\Sintax.java")
        );
    }
}
