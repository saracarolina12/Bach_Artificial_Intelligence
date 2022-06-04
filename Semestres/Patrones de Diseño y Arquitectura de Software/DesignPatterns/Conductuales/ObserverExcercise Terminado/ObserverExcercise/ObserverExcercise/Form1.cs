using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverExcercise
{
    public partial class Form1 : Form
    {
        Subject subject;
        Observer observer1;
        Observer observer2;
        Timer timer;

        //LA INICIALILZACION DE LOS OBJETOS SIEMPRE VA EN EL CONTRUCTOR
        public Form1()
        {
            InitializeComponent();
            // timer que nos ayudara a regresar el color a la ettiqueta y simulará
            // el parpadeo con color rojo
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 2500;
            timer.Start();

            subject = new Subject();
            observer1 = new Observer("Tienda 1");
            observer2 = new Observer("Tienda 2");
            observer1.OnChangedColor += Observer1_OnChangedColor;
            observer2.OnChangedColor += Observer2_OnChangedColor;
        }

        //este evento del timer, entra en cada tick para camibar el color en caso de que este en rojo
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (store1label.ForeColor == Color.Red)
                store1label.ForeColor = Color.Black;
            if (store2label.ForeColor == Color.Red)
                store2label.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subject.OnNotify += observer1.Update;
        }

        private void store1label_Click(object sender, EventArgs e)
        {

        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            float exchangeRate = float.Parse(exchangeRateTB.Text);

            subject.ExchangeRateChanged(exchangeRate);
        }

        private void unsuscribe1lbl_Click(object sender, EventArgs e)
        {
            subject.OnNotify -= observer1.Update;
        }

        private void suscribe2btn_Click(object sender, EventArgs e)
        {
            subject.OnNotify += observer2.Update;
        }

        private void unsuscribe2btn_Click(object sender, EventArgs e)
        {
            subject.OnNotify -= observer2.Update;
        }


        // Si el observer esta suscrito y hace el update del tipo de cambio
        // se activará el evento onChangeColor y vendrá a su respectivo evento a cambiar el color de la etiqueta
        private void Observer2_OnChangedColor()
        {
            store2label.ForeColor = Color.Red;
        }

        private void Observer1_OnChangedColor()
        {
            store1label.ForeColor = Color.Red;        
        }
    }
}
