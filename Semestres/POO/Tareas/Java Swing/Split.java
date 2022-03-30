import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
public class Split
{
 public static void main(String args[])
 {
 	JFrame f = new JFrame("Ejemplo JSplitPane");
	f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
 
    JLabel peru = new JLabel();
	peru.setPreferredSize(new Dimension(650,900));
	peru.setIcon(new ImageIcon("peru.jpg"));
	
	JLabel lili = new JLabel();
	lili.setPreferredSize(new Dimension(900,900));
	lili.setIcon(new ImageIcon("lili.jpg"));
	
	JPanel p1 = new JPanel();
	JPanel p2 = new JPanel();
	
	p1.add(peru);
	p2.add(lili);
	
	JSplitPane spl = new JSplitPane(SwingConstants.VERTICAL,p1,p2);
	spl.setOrientation(SwingConstants.VERTICAL);
	spl.setDividerLocation(750);
    spl.setOneTouchExpandable(true);
	f.add(spl);
	f.setSize(1500,1500);
	f.setVisible(true);
 }
}
