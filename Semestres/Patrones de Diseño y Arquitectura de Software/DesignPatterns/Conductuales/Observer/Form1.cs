using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Observer
{
    public partial class Form1 : Form
    {
        public decimal cant_value=0;
            
        public Form1()
        {
            InitializeComponent();
            radioButton2.Checked = true;
            radioButton4.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cambio_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cambio_TB.Text != "") cant_value = decimal.Parse(cambio_TB.Text);

            var subject = new Subject();

            // instantiate 3 observers
            var Walmart = new Observer("Observer 1");
            var Oxxo = new Observer("Observer 2");

            
                /* Walmart */
                if (radioButton1.Checked == true)
                {
                    subject.ONnotif += Walmart.Update;
                }
                else if (radioButton2.Checked == true)
                {
                    subject.ONnotif -= Walmart.Update;
                }
                /* Oxxo */
                if (radioButton3.Checked == true)
                {
                    subject.ONnotif += Oxxo.Update;
                }
                else if (radioButton4.Checked == true)
                {
                    subject.ONnotif -= Oxxo.Update;
                }
                // change the subject state
                subject.ChangeState(cant_value); //cambiar color
            
            

            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
