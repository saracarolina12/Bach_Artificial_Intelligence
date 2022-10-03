import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.util.*;
import java.awt.Dimension;

public class Tarea7 {
  static ImageIcon[] imagen = new ImageIcon[6];
  static String conjuntos[] = {"A","B","A "+(char)0x2229+" B","A "+(char)0x222A+"B","A - B","B - A"};
  static JRadioButton circulos[] = new JRadioButton[6];
  static ButtonGroup group = new ButtonGroup();
  static JLabel pic = new JLabel();

  public static void main(String args[]){
    JFrame f = new JFrame("Gomez Delgado");
    f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    f.setLayout(new GridLayout(3, 1, 5, 0));

    imagen[0] = new ImageIcon(new ImageIcon((new Object().getClass().getResource("/A.png")) 
).getImage().getScaledInstance(360,270, Image.SCALE_DEFAULT));
    imagen[1] = new ImageIcon(new ImageIcon((new Object().getClass().getResource("/B.png")) 
).getImage().getScaledInstance(360,270, Image.SCALE_DEFAULT));
    imagen[2] = new ImageIcon(new ImageIcon((new Object().getClass().getResource("/AyB.png")) 
).getImage().getScaledInstance(360,270, Image.SCALE_DEFAULT));
    imagen[3] = new ImageIcon(new ImageIcon((new Object().getClass().getResource("/AoB.png")) 
).getImage().getScaledInstance(360,270, Image.SCALE_DEFAULT));
    imagen[4] = new ImageIcon(new ImageIcon((new Object().getClass().getResource("/A-B.png")) 
).getImage().getScaledInstance(360,270, Image.SCALE_DEFAULT));
    imagen[5] = new ImageIcon(new ImageIcon((new Object().getClass().getResource("/B-A.png")) 
).getImage().getScaledInstance(360,270, Image.SCALE_DEFAULT));
    

    JPanel puno = new JPanel(new GridLayout(1,2,5,0));
    //JPanel punopuntodos = new JPanel(new GridLayout());
    JPanel pdos = new JPanel(new GridLayout(1, 2));
    JPanel ptres = new JPanel(new GridLayout(1,1));

    JPanel punopuntodos = new JPanel(new GridLayout(3,2));
    

    JTextArea t1 = new JTextArea("a b c 1 2 3",50, 30);
    JTextArea t2 = new JTextArea("A B C 1 2 3",50, 30);

    JTextArea instruccion = new JTextArea("Introduzca elementos separados por espacios en cada conjunto y seleccione una operacion");
    instruccion.setLineWrap(true);
    
    puno.add(t1);
    puno.add(t2);
    
    pdos.add(punopuntodos);
    ptres.add(instruccion);

    for ( int i = 0; i < 6; i++ ) {
      circulos[i] = new JRadioButton(conjuntos[i]);
      punopuntodos.add(circulos[i]);
      group.add(circulos[i]);
    }

    f.add(puno);
    
    f.add(pdos);
    pic.setIcon(imagen[0]);
    
    pdos.add(pic);
    f.add(ptres);


    circulos[0].addActionListener(
      new ActionListener() {
      @Override
        public void actionPerformed(ActionEvent e) {
        pic.setIcon(imagen[0]);
        String[] A = t1.getText().split(" ");
        TreeSet<String> set = new TreeSet<>();
        for ( String str : A )
        set.add(str);
        instruccion.setText("");
        for ( Object x : set )
        instruccion.append(x + " ");
      }
    }
    );
    circulos[1].addActionListener(
      new ActionListener() {
      @Override
        public void actionPerformed(ActionEvent e) {
        pic.setIcon(imagen[1]);
        String[] B = t2.getText().split(" ");
        TreeSet<String> set = new TreeSet<>();
        for ( String str : B )
        set.add(str);
        instruccion.setText("");
        for ( Object x : set )
        instruccion.append(x + " ");
      }
    }
    );
    circulos[2].addActionListener(
      new ActionListener() {
      @Override
        public void actionPerformed(ActionEvent e) {
        pic.setIcon(imagen[2]);
        String[] B = t2.getText().split(" ");
        TreeSet<String> inte = new TreeSet<>();
        String[] A = t1.getText().split(" ");
        TreeSet<String> set = new TreeSet<>();
        for ( String str : A )
        set.add(str);
        instruccion.setText("");

        for ( String str : B )
        if ( set.contains(str) )
        inte.add(str);
        for ( Object x : inte )
        instruccion.append(x + " ");
      }
    }
    );
    circulos[3].addActionListener(
      new ActionListener() {
      @Override
        public void actionPerformed(ActionEvent e) {
        pic.setIcon(imagen[3]);
        String[] A = t1.getText().split(" ");
        String[] B = t2.getText().split(" ");
        TreeSet<String> set = new TreeSet<>();
        for ( String str : A )
        set.add(str);
        for ( String str : B )
        set.add(str);
        instruccion.setText("");
        for ( Object x : set )
        instruccion.append(x + " ");
      }
    }
    );
    circulos[4].addActionListener(
      new ActionListener() {
      @Override
        public void actionPerformed(ActionEvent e) {
        pic.setIcon(imagen[4]);
        String[] A = t1.getText().split(" ");
        TreeSet<String> set = new TreeSet<>();
        String[] B = t2.getText().split(" ");
        for ( String str : A )
        set.add(str);
        instruccion.setText("");
        for ( String str : B )
        if ( set.contains(str) )
        set.remove(str);
        for ( Object x : set )
        instruccion.append(x + " ");
      }
    }
    );
    circulos[5].addActionListener(
      new ActionListener() {
      @Override
        public void actionPerformed(ActionEvent e) {
        pic.setIcon(imagen[5]);
        String[] A = t1.getText().split(" ");
        String[] B = t2.getText().split(" ");
        TreeSet<String> set = new TreeSet<>();
        for ( String str : B )
        set.add(str);
        instruccion.setText("");
        for ( String str : A )
        if ( set.contains(str) )
        set.remove(str);
        for ( Object x : set )
        instruccion.append(x + " ");
      }
    }
    );
    f.setSize(730, 750);
    f.setVisible(true);
  }
}
