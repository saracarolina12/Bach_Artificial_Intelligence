using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Simulacion_Pedidos
{
    public partial class Form1 : Form
    {

        string totalVeg = 34.ToString();
        string totalSoda = 64.ToString();
        string totalBread = 14.ToString();
        public Form1()
        {
            InitializeComponent();

            toStockList.Controls.Add(new Label() { Text = totalVeg,ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize= true }, 1, 1);
            toStockList.Controls.Add(new Label() { Text = totalSoda, ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 1, 2);
            toStockList.Controls.Add(new Label() { Text = totalBread, ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 1, 3);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Form with Rounded Borders in C#
            Rectangle Bounds = new Rectangle(0, 0, this.Width, this.Height);
            int CornerRadius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
            base.OnPaint(e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ////Form with Rounded Borders in C#
            //Rectangle Bounds = new Rectangle(0, 0, this.Width, this.Height);
            //int CornerRadius = 20;
            //System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            //path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            //path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            //path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            //path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            //path.CloseAllFigures();
            //this.Region = new Region(path);
            //base.OnPaint(e);
        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void readQR_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.getData("hola desde Form1");
            f2.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ID_store_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toStockList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
