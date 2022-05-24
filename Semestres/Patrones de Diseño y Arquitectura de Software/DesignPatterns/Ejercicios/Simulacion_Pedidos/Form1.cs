﻿using System.Collections.Specialized;
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
        //private ListDictionary storeProfits = new ListDictionary();   //store to order <ID, name>
        private Dictionary<int, double> storeProfits = new Dictionary<int, double>();
        private Dictionary<int, double> sortedProfits = new Dictionary<int, double>();

        public Form1()
        {
            InitializeComponent();

            var fileCount = (from file in Directory.EnumerateFiles("..\\..\\Stores-data\\QRs\\", "*.png", SearchOption.AllDirectories)
                             select file).Count();
            

            /*iterate over filenames*/
            DirectoryInfo d = new DirectoryInfo("..\\..\\Stores-data\\QRs\\"); //Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.png"); //Getting Text files
            Root[] data;
            double prof = 0;
            foreach (FileInfo file in Files)
            {
                prof = 0;
                data = Adaptee.ReadQR("..\\..\\Stores-data\\QRs\\Tienda_"+ file.Name.Substring(file.Name.Length - 5, 1) + ".png");
                //str = file.Name.Substring(file.Name.Length-5,1);
               
                for(int j=0; j<data[0].products.Count; j++)
                {
                    prof += getPrice(data[0].products[j].quantity, data[0].products[j].name);
                    
                }
                storeProfits.Add(data[0].idStore, prof);
            }

            /*SORT INTIIAL PROFIT VALUES*/
            foreach (KeyValuePair<int, double> x in storeProfits.OrderByDescending(key => key.Value))
            {
                sortedProfits.Add(x.Key, x.Value);
                Console.WriteLine("Key: {0}, Value: {1}", x.Key, x.Value);
            }

            /*PANEL ARRAYS*/
            //for (int i = 0; i < 5; i++)
            //{
            //    Panel pnl = new Panel();
            //    pnl.Location = new Point(10 * i, 10 * i);
            //    pnl.BorderStyle = panel1.BorderStyle;
            //    pnl.BackColor = panel1.BackColor;
            //    pnl.Size = panel1.Size;
            //    pnl.Visible = true;

            //    foreach (Control c in panel1.Controls)
            //    {
            //        Control c2 = new Control();
            //        c2 = new Label();
            //        c2.Location = c.Location;
            //        c2.Size = c.Size;
            //        c2.Text = c.Text;
            //        pnl.Controls.Add(c2);
            //    }

            //    tabPage1.Controls.Add(pnl);
            //}



            /*INTIAL PRODUCTS VALUES*/
            toStockList.RowCount = toStockList.RowCount + 1;
            toStockList.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            /**/
            toStockList.Controls.Add(new Label() { Text = "1", ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 0, 1);
            toStockList.Controls.Add(new Label() { Text = "2", ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 0, 2);
            toStockList.Controls.Add(new Label() { Text = "3", ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 0, 3);
            /*names*/
            toStockList.Controls.Add(new Label() { Text = "Vegetables", ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 1, 1);
            toStockList.Controls.Add(new Label() { Text = "Sodas", ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 1, 2);
            toStockList.Controls.Add(new Label() { Text = "Bread", ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 1, 3);
            /*quantity available*/
            toStockList.Controls.Add(new Label() { Text = totalVeg, ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 2, 1);
            toStockList.Controls.Add(new Label() { Text = totalSoda, ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 2, 2);
            toStockList.Controls.Add(new Label() { Text = totalBread, ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 2, 3);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private double getPrice(int quantity, string prodName)
        {
            if (prodName == "Frozen vegetables")
            {
                return 100.0 * quantity;
            }
            else if (prodName == "Sodas")
            {
                return 15.0 * quantity;
            }
            else
            {
                return 5.0 * quantity;
            }
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
            //f2.getData("hola desde Form1");
            f2.Show();

        }
        internal void getProfits(int storeID, double profit)
        {
            storeProfits[storeID] = profit;
        }
        private void showProfitsDict()
        {
            foreach (KeyValuePair<int, double> x in storeProfits)
            {
                Console.WriteLine("thissss: {0}, otherrrr: {1}", x.Key, x.Value);
            }
            
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trucks_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void arrow_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    Panel pnl = new Panel();
            //    pnl.Location = new Point(300 * i, 100);
            //    pnl.BorderStyle = trucks_panel.BorderStyle;
            //    pnl.BackColor = trucks_panel.BackColor;
            //    pnl.Size = trucks_panel.Size;
            //    pnl.Visible = true;

            //    foreach (Control c in trucks_panel.Controls)
            //    {
            //        Control c2 = new Control();
            //        c2 = new Label();
            //        c2.Location = c.Location;
            //        c2.Size = c.Size;
            //        c2.Text = c.Text;
            //        pnl.Controls.Add(c2);
            //    }

            //    Controls.Add(pnl);
            //}
            showProfitsDict();

        }
    }
}
