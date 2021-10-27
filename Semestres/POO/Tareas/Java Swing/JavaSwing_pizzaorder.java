import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Ejercicio9{
	static String Soda[] = {"coca-cola","manzana","naranja"};
	static JRadioButton saborcito[] = new JRadioButton[3];
	static JLabel Order= new JLabel("");

	public static void main(String args[]){
		JFrame f = new JFrame("Gomez Delgado");
		f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		f.setLayout(new GridLayout(5,1));

		JLabel  ORDER = new JLabel("Su orden es:");

		JPanel pedido = new JPanel(new GridLayout(1,3));
		JPanel npizzas = new JPanel(new GridLayout(1,3));
		JPanel pizzas = new JPanel(new GridLayout(1,3));
		JPanel numerorefrescos = new JPanel(new GridLayout(1,3));
		JPanel refrescos = new JPanel(new GridLayout(1,3));

		JTextField pizza = new JTextField(5);
		JTextField ref = new JTextField(5);
		JCheckBox queso = new JCheckBox("Quesito");
		JCheckBox ham = new JCheckBox("Jamon");
		JCheckBox pep = new JCheckBox("Pepperoni");
		ButtonGroup sabores = new ButtonGroup();
		JButton listo = new JButton("LISTO");
		JLabel p = new JLabel("Pizza(s)");
		JLabel r = new JLabel("Refresco(s)");
		JLabel space = new JLabel(" ");

		pedido.add(ORDER);
		pedido.add(Order);
		pedido.add(space);

		npizzas.add(pizza);
		npizzas.add(p);
		npizzas.add(listo);

		pizzas.setLayout(new GridLayout());
		pizzas.add(queso);
		pizzas.add(ham);
		pizzas.add(pep);

		numerorefrescos.add(ref);
		numerorefrescos.add(r);
		numerorefrescos.add(space);

		for(int i = 0;i < 3;i++){
			saborcito[i] = new JRadioButton(Soda[i]);

			sabores.add(saborcito[i]);

			refrescos.add(saborcito[i]);
		}

		f.add(pedido);
		f.add(npizzas);
		f.add(pizzas);
		f.add(numerorefrescos);
		f.add(refrescos);

		listo.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				String message = "";
				if(queso.isSelected())
					message = pizza.getText() + " pizza(s) de " + queso.getText();
				if(ham.isSelected())
					message = pizza.getText() + " pizza(s) de " + ham.getText();
				if(pep.isSelected())
					message = pizza.getText() + " pizza(s) de " + pep.getText();
				if(queso.isSelected() && ham.isSelected())
					message = pizza.getText() + " pizza(s) de " + queso.getText() + " y " + ham.getText();
				if(ham.isSelected() && pep.isSelected())
					message = pizza.getText() + " pizza(s) de " + ham.getText() + " y " + pep.getText();
				if(queso.isSelected() && pep.isSelected())
					message = pizza.getText() + " pizza(s) de " + queso.getText() + " y " + pep.getText();
				if(queso.isSelected() && ham.isSelected() && pep.isSelected())
					message = pizza.getText() + " pizza(s) de " + queso.getText() + ", " + ham.getText() + " y " + pep.getText();

				for(int i = 0;i < 3;i++)
					if(saborcito[i].isSelected())
						message = message + ", y " + ref.getText() + " refresco(s) de " + saborcito[i].getText() + ".";

				Order.setText(message);
			}
		});

		f.setSize(800,300);
		f.setVisible(true);

	}
}
