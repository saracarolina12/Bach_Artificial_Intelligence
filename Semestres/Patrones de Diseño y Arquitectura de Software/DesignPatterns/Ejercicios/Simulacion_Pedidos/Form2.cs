﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using System.IO;
using Newtonsoft.Json;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace Simulacion_Pedidos
{
    public partial class Form2 : Form
    {
        private string lastQRdata;
        private int oneTimeLastQR;
        private int QR_ID;
        private int price_vegetables = 100;
        private int price_sodas = 15;
        private int price_bread = 5;
        private double profit = 0;


        public Form2()
        {
            InitializeComponent();
            idStoreLabel.Text = Adaptee.data[0].idStore.ToString();
            nameStoreLabel.Text = Adaptee.data[0].storeName.ToString();
            oneTimeLastQR = 0;
        }

        internal void getData(String data)
        {
            //ordersTableAdapter.FillByCustomerID(northwindDataSet.Orders, CustomerID);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private double calculate_profit(Root[] data, int quantity, string prodName)
        {
            if (prodName == "Frozen vegetables")
            {
                profit += 100.0*quantity;
            }
            else if (prodName == "Sodas")
            {
                profit += 15.0*quantity;
            }
            else
            {
                profit += 5.0*quantity;
            }
            return profit;
        }

        private double getPrice(string prodName)
        {
            if (prodName == "Frozen vegetables")
            {
                return 100.0;
            }else if(prodName == "Sodas")
            {
                return 15.0;
            }
            else { 
                return 5.0;
            }
        }

        private void addProductToStock(int try_id, int quantity)
        {
            var newprod = new Products();
            int ID_newp=0;
            string name_newp = "";
            bool exists = false;
            string path = "..\\..\\Stores-data\\QRs\\" + Adaptee.data[0].storeName + ".png";
            Root[] thisdata = Adaptee.ReadQR(path);

            if (thisdata[0].products.Count != 0)
            {
                for (int i = 0; i < thisdata[0].products.Count; i++)
                {
                    double benef = calculate_profit(thisdata, thisdata[0].products[i].quantity, thisdata[0].products[i].name);
                    Console.WriteLine("profit: {0}", benef);
                    if (thisdata[0].products[i].idProduct == try_id)
                    {
                        exists = true;
                        newprod.idProduct = thisdata[0].products[i].idProduct;
                        newprod.name = thisdata[0].products[i].name;
                        newprod.quantity += quantity;
                        thisdata[0].products.Add(newprod);

                        listToStock.RowCount = listToStock.RowCount + 1;
                        listToStock.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                        listToStock.Controls.Add(new Label() { Text = thisdata[0].products[i].idProduct.ToString(), ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 0, listToStock.RowCount-1);
                        listToStock.Controls.Add(new Label() { Text = thisdata[0].products[i].name, ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 1, listToStock.RowCount - 1);
                        listToStock.Controls.Add(new Label() { Text = getPrice(thisdata[0].products[i].name).ToString(), ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 2, listToStock.RowCount - 1);
                        listToStock.Controls.Add(new Label() { Text = quantity.ToString(), ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 3, listToStock.RowCount - 1);

                        //Write QR WORKSSSS
                        Bitmap imageTemporal = Adaptee.WriteQR(thisdata);
                        Bitmap imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                        imagen.Save("QR-code", ImageFormat.Png);
                        QR_container.BackgroundImage = imagen;
                        ////Save image as png
                        //Image image = (Image)QR_container.BackgroundImage.Clone();
                        //image.Save(path);

                        break;
                    }
                    else
                    {
                        exists = false;
                    }
                }
                if(exists == false)
                {
                    string message = "This ID does not exist. Try again.";
                    string title = "Error";
                    MessageBox.Show(message, title);
                }
            }

        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            if(((int)numericUpDown1.Value) != 0) addProductToStock(((int)numericUpDown2.Value), ((int)numericUpDown1.Value));
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void readQR_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void QR_container_Paint(object sender, PaintEventArgs e)
        {
            
            if(oneTimeLastQR==0) QR_container.BackgroundImage = Image.FromFile(@"C:\Users\scago\Documents\store-name.png");
            oneTimeLastQR++;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            //Save image as png
            Image image = (Image)QR_container.BackgroundImage.Clone();
            image.Save("..\\..\\Stores-data\\QRs\\Tienda_2.png");

            string message = "Your changes have been saved! :D";
            string title = "Info";
            MessageBox.Show(message);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) //ID
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) //amount
        {

        }
    }
}
