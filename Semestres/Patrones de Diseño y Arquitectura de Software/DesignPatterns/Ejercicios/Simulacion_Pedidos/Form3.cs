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
            datagrid.Checked = Start.CB_datagrid;
            textfile.Checked = Start.CB_texfile;
            textbox.Checked = Start.CB_textBox;
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
            //Console.WriteLine(DateTime.Now.ToShortTimeString());
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
