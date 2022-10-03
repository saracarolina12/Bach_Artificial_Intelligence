import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Ejercicio10
{
   static String nom[] = {"Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"};
   static JComboBox comb = new JComboBox(nom);
   static JLabel lb = new JLabel("Mesesitos");
   static ImageIcon[] imagen = new ImageIcon[12];
   
 public static void main(String args[])
 {
    JFrame f = new JFrame("Gómez Delgado");
    f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    f.setLayout(new GridLayout(2,1,2,2));
	
    f.add(comb);
    f.add(lb);
	
   imagen[0] = new ImageIcon(new Object().getClass().getResource("/enero.jpg"));
   imagen[1] = new ImageIcon(new Object().getClass().getResource("/febrero.png"));
   imagen[2] = new ImageIcon(new Object().getClass().getResource("/marzo.png"));
   imagen[3] = new ImageIcon(new Object().getClass().getResource("/abril.jpg"));
   imagen[4] = new ImageIcon(new Object().getClass().getResource("/mayo.jpg"));
   imagen[5] = new ImageIcon(new Object().getClass().getResource("/junio.jpg"));
   imagen[6] = new ImageIcon(new Object().getClass().getResource("/julio.png"));
   imagen[7] = new ImageIcon(new Object().getClass().getResource("/agosto.png"));
   imagen[8] = new ImageIcon(new Object().getClass().getResource("/septiembre.png"));
   imagen[9] = new ImageIcon(new Object().getClass().getResource("/octubre.png"));
   imagen[10] = new ImageIcon(new Object().getClass().getResource("/noviembre.jpg"));
   imagen[11] = new ImageIcon(new Object().getClass().getResource("/diciembre.jpg"));

    comb.addActionListener( new ActionListener(){
       @Override
        public void actionPerformed(ActionEvent e)
         {
                 lb.setIcon( imagen[ comb.getSelectedIndex() ] );
         }
         });
         f.setSize(400,300);
         f.setVisible(true);
}
}
