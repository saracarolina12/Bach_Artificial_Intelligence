//añadir botones a una imagen
import javax.swing.*;
import java.awt.*;

public class Tarea8 
{
 public static void main(String args[])
 {
   JFrame f = new JFrame("Gómez Delgado"); //create an object frame
   f.setLayout(new BorderLayout());
   f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

   ImageIcon img1 = new ImageIcon(new Object().getClass().getResource("panel1.png"));
   ImageIcon img2 = new ImageIcon(new Object().getClass().getResource("panel2.png"));
   ImageIcon img3 = new ImageIcon(new Object().getClass().getResource("panel3.png"));
   ImageIcon img4 = new ImageIcon(new Object().getClass().getResource("panel4.png"));

   f.add(new JLabel(img1),BorderLayout.NORTH);
   f.add(new JLabel(img2),BorderLayout.WEST);
   f.add(new JLabel(img3),BorderLayout.EAST);
   f.add(new JLabel(img4),BorderLayout.SOUTH);
   
    ImageIcon icon1 = new ImageIcon(new Object().getClass().getResource("num1.png"));
    ImageIcon icon2 = new ImageIcon(new Object().getClass().getResource("num2.png"));
    ImageIcon icon3 = new ImageIcon(new Object().getClass().getResource("num3.png"));
    ImageIcon icon4 = new ImageIcon(new Object().getClass().getResource("num4.png"));
    ImageIcon icon5 = new ImageIcon(new Object().getClass().getResource("num5.png"));
    ImageIcon icon6 = new ImageIcon(new Object().getClass().getResource("num6.png"));
    ImageIcon icon7 = new ImageIcon(new Object().getClass().getResource("num7.png"));
    ImageIcon icon8 = new ImageIcon(new Object().getClass().getResource("num8.png"));
    ImageIcon icon9 = new ImageIcon(new Object().getClass().getResource("num9.png"));
    ImageIcon icon10 = new ImageIcon(new Object().getClass().getResource("numasterisco.png"));
    ImageIcon icon11 = new ImageIcon(new Object().getClass().getResource("num0.png"));
    ImageIcon icon12 = new ImageIcon(new Object().getClass().getResource("numgato.png"));

    JPanel CenterPanel = new JPanel(new GridLayout(5,3,5,5));
    CenterPanel.add(new JButton( icon1 ));
    CenterPanel.add(new JButton( icon2 ));
    CenterPanel.add(new JButton( icon3 ));
    CenterPanel.add(new JButton( icon4 ));
    CenterPanel.add(new JButton( icon5 ));
    CenterPanel.add(new JButton( icon6 ));
    CenterPanel.add(new JButton( icon7 ));
    CenterPanel.add(new JButton( icon8 ));
    CenterPanel.add(new JButton( icon9 ));
    CenterPanel.add(new JButton( icon10 ));
    CenterPanel.add(new JButton( icon11 ));
    CenterPanel.add(new JButton( icon12 ));
    f.add(CenterPanel, BorderLayout.CENTER);

    f.pack();
    f.setVisible(true);
 }
}
