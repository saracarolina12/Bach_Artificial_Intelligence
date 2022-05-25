using System;
using System.Collections.Specialized;
using System.Collections;
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
        private int oneTimeLastQR;
        private ListDictionary availableProds = new ListDictionary();   //products <ID, name>
        Root[] thisdata = Adaptee.ReadQR(Start.global_route);
        private double local_profit;
        private int local_bread=0;
        private int local_soda=0;
        private int local_vegetables=0;


        public Form2()
        {

            InitializeComponent();
            idStoreLabel.Text = Adaptee.data[0].idStore.ToString();
            nameStoreLabel.Text = Adaptee.data[0].storeName.ToString();
            oneTimeLastQR = 0;

            availableProds.Add(1, "Vegetables");
            availableProds.Add(2, "Sodas");
            availableProds.Add(3, "Bread");
            local_profit = 0;
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

        private double calculate_profit(double newprice)
        {
            return local_profit += newprice;
        }

        private double getPrice(int quantity, string prodName)
        {
            if (prodName == "Vegetables")
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

        private void quantityToStock(int quantity, string prodName)
        {
            if (prodName == "Vegetables")
            {
                Start.TOTAL_VEGETABLES += quantity;
            }
            else if (prodName == "Sodas")
            {
                Start.TOTAL_SODA += quantity;
            }
            else
            {
                Start.TOTAL_BREAD += quantity;

            }
        }

        private void addProductToStock(int try_id, int quantity)
        {
            var newprod = new Products();

            bool exists = false;

            IDictionaryEnumerator enumerator = availableProds.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (try_id == (int)enumerator.Key)
                {
                    exists = true;
                    newprod.idProduct = try_id;
                    newprod.name = (string)enumerator.Value;
                    newprod.quantity += quantity;

                    //Singleton.GeneratePath();
                    thisdata[0].products.Add(newprod);
                    listToStock.RowCount = listToStock.RowCount + 1;
                    double total_price = getPrice(quantity, (string)enumerator.Value);
                    double profit = calculate_profit(total_price);
                    quantityToStock(quantity, (string)enumerator.Value);
                    Console.WriteLine("soda: {0}",local_soda);
                    Console.WriteLine("bread: {0}", local_bread);
                    Console.WriteLine("veget: {0}", local_vegetables);
                    listToStock.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                    listToStock.Controls.Add(new Label() { Text = enumerator.Key.ToString(), ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 0, listToStock.RowCount - 1);
                    listToStock.Controls.Add(new Label() { Text = (string)enumerator.Value, ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 1, listToStock.RowCount - 1);
                    listToStock.Controls.Add(new Label() { Text = total_price.ToString(), ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 2, listToStock.RowCount - 1);
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

            if (exists == false)
            {
                string message = "This ID does not exist. Try again.";
                string title = "Error";
                MessageBox.Show(message, title);
            }

        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            if (((int)numericUpDown1.Value) != 0) addProductToStock(((int)numericUpDown2.Value), ((int)numericUpDown1.Value));
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
            //Root[] getData = Adaptee.ReadQR(Start.global_route);
            f1.getProfits(thisdata[0].idStore, local_profit);
            f1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void QR_container_Paint(object sender, PaintEventArgs e)
        {
            if (oneTimeLastQR == 0) QR_container.BackgroundImage = Image.FromFile(Start.global_route);
            oneTimeLastQR++;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            Start.global_route = Singleton.GenerateRoute();
            if (Start.global_route == "returnF1")
            {
                Start.route_index = 1;
                Start.global_route = Singleton.GenerateRoute();
                Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                //Save image as png
                //Image image = (Image)QR_container.BackgroundImage.Clone();
                //File.Delete(Start.global_route);
                //image.Save(Start.global_route);

                string message = "Your changes have been saved! :D";
                string title = "Info";
                MessageBox.Show(message);

                Hide();
                Form2 fn = new Form2();
                fn.Show();
            }
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
