using System;
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

        public Form2()
        {
            InitializeComponent();

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

        private void Add_button_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(Adaptee.data[0]);
            //Write QR
            Bitmap imageTemporal = Adaptee.mywrite;
            Bitmap imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
            imagen.Save("QR-code", ImageFormat.Png);
            QR_container.BackgroundImage = imagen;
            //Save image as png
            Image image = (Image)QR_container.BackgroundImage.Clone();
            string path = "..\\..\\Stores-data\\QRs\\Tienda_1.png";
            image.Save(path);


            //FileInfo fileInfo = new FileInfo("..\\..\\Stores-data\\QRs\\Tienda_1.png");
            //Console.WriteLine(fileInfo.Length);
            //byte[] data = new byte[fileInfo.Length];

            //using (FileStream fs = fileInfo.OpenRead())
            //{
            //    fs.Read(data, 0, data.Length);
            //}
            ////fileInfo.Delete();
            //Image myimage;
            //using (MemoryStream memstr = new MemoryStream(data))
            //{
            //    myimage = Image.FromStream(memstr);
            //}
            ////QR_container.BackgroundImage = myimage;
            //MessagingToolkit.QRCode.Codec.QRCodeDecoder decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
            //Console.WriteLine(decoder.Decode(new QRCodeBitmapImage(myimage as Bitmap)));
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
            string message = "Your changes have been saved! :D";
            string title = "Info";
            MessageBox.Show(message);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
