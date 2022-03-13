import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Morse{
static String letra[] = {" ",   "0",     "1",   "2",    "3",    "4",    "5",    "6",    "7",   "8",    "9","B","C","F","H","J","L","P","Q","V","X","Y","Z","D","G","K","O","R","S","U","W","A","I","M","N","E","T"};
	static String morse[] = {"  ","-----",".----","..---","...--","....-",".....","-....","--...","---..","----.","-...","-.-.","..-.","....",".---",".-..",".--.","--.-","...-","-..-","-.--","--..","-..","--.","-.-","---",".-.","...","..-",".--",".-","..","--","-.",".","-"};

 public static void main(String args[])
 {
    JFrame f = new JFrame("Sara Carolina");
    f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    f.setLayout(new GridLayout(1,2,2,2));
    JTextArea t1 = new JTextArea(30,30);
    JTextArea t2 = new JTextArea(30,30);

    JButton mt = new JButton("Morse to Text");
    JButton tm = new JButton("Text to Morse");

    JScrollPane scro1 = new JScrollPane(t1, JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED, JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);	
    JScrollPane scro2 = new JScrollPane(t2, JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED, JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);	


    f.add(scro1);
    f.add(tm);
    f.add(mt); 
    f.add(scro2);
 
   tm.addActionListener(new ActionListener()
     {
	@Override
	 public void actionPerformed(ActionEvent e)
	  {
	    String cadena1 = t1.getText();
		cadena1 = cadena1.toUpperCase();
            for(int i=0; i<letra.length; i++ )
            cadena1 = cadena1.replaceAll(letra[i], morse[i]+" ");
            t2.setText(cadena1);
	  }
      });

    mt.addActionListener( new ActionListener(){
	  @Override
          public void actionPerformed(ActionEvent e){
		String cadena2 = t2.getText();
	  for( int i=0; i<morse.length; i++)
	cadena2 = cadena2.replaceAll("\\Q"+morse[i]+"\\E\\s", letra[i]);
	  t1.setText(cadena2);	
	 }
      });
    f.setSize(650,400);
    f.setVisible(true); 
 }
}
