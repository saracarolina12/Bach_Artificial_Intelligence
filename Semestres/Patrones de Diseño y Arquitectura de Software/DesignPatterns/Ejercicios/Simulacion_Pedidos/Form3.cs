using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;


namespace Simulacion_Pedidos
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            foreach (var s in Start.textArray)
            {
                textBox1.AppendText(s);
                textBox1.AppendText(Environment.NewLine);
            }
            datagrid.Checked = Start.CB_datagrid;
            textfile.Checked = Start.CB_texfile;
            textbox.Checked = Start.CB_textBox;
            Start.thisForm3 = this;
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Start.CB_datagrid = datagrid.Checked;
            Start.CB_texfile = textfile.Checked;
            Start.CB_textBox = textbox.Checked;
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCheckBox1_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagridLabel_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
