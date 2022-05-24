using System.Collections.Specialized;
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
        //private ListDictionary storeProfits = new ListDictionary();   //store to order <ID, name>
        private Dictionary<int, double> storeProfits = new Dictionary<int, double>();
        private Dictionary<int, double> sortedProfits = new Dictionary<int, double>();

        public Form1()
        {
            InitializeComponent();

            Nsoda_trucks.Text = Start.SODA_TRUCK.ToString();
            Nbread_trucks.Text = Start.BREADK_TRUCK.ToString();
            Nvegetables_trucks.Text = Start.VEGETABLES_TRUCK.ToString();

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

            showProfitsDict();

            

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
            toStockList.Controls.Add(new Label() { Text = Start.TOTAL_VEGETABLES.ToString(), ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 2, 1);
            toStockList.Controls.Add(new Label() { Text = Start.TOTAL_SODA.ToString(), ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 2, 2);
            toStockList.Controls.Add(new Label() { Text = Start.TOTAL_BREAD.ToString(), ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 2, 3);
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

        private string getStoreName(int ID)
        {
            if (ID == 1)
            {
                return "Frozen vegetables";
            }
            else if (ID == 2)
            {
                return "Sodas";
            }
            else
            {
                return "Bread";
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
            
        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void readQR_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 f2 = new Form2();
            f2.Show();

        }
        internal void getProfits(int storeID, double profit)
        {
            storeProfits[storeID] = profit+=storeProfits[storeID];
            //foreach (KeyValuePair<int, double> x in storeProfits.OrderByDescending(key => key.Value))
            //{
            //    Console.WriteLine("thissss: {0}, otherrrr: {1}", x.Key, x.Value);
            //}
        }

      
        private void showProfitsDict()
        {

            //foreach (KeyValuePair<int, double> x in storeProfits.OrderByDescending(key => key.Value))
            //{
            //    Console.WriteLine("thissss: {0}, otherrrr: {1}", x.Key, x.Value);
            //}
            
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
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if ((Start.VEGETABLES_TRUCK + Start.SODA_TRUCK + Start.BREADK_TRUCK) + 1 != 6)
            {
                if (Start.SODA_TRUCK != 3)
                {
                    Start.SODA_TRUCK += 1;
                    Nsoda_trucks.Text = Start.SODA_TRUCK.ToString();
                }
            }
        }

        private void add_bread_Click(object sender, EventArgs e)
        {
            if ((Start.VEGETABLES_TRUCK + Start.SODA_TRUCK + Start.BREADK_TRUCK) + 1 != 6)
            {
                if (Start.BREADK_TRUCK != 3) 
                {
                    Start.BREADK_TRUCK += 1;
                    Nbread_trucks.Text = Start.BREADK_TRUCK.ToString();
                }
            }
        }

        private void add_vegetables_Click(object sender, EventArgs e)
        {
            if ((Start.VEGETABLES_TRUCK + Start.SODA_TRUCK + Start.BREADK_TRUCK) + 1 != 6)
            {
                if (Start.VEGETABLES_TRUCK != 3) 
                {
                    Start.VEGETABLES_TRUCK += 1;
                    Nvegetables_trucks.Text = Start.VEGETABLES_TRUCK.ToString();
                }
            }
        }

        private void sub_soda_Click(object sender, EventArgs e)
        {
            if ((Start.VEGETABLES_TRUCK + Start.SODA_TRUCK + Start.BREADK_TRUCK) - 1 != -1)
            {
                if (Start.SODA_TRUCK != 0)
                {
                    Start.SODA_TRUCK -= 1;
                    Nsoda_trucks.Text = Start.SODA_TRUCK.ToString();
                }
            }
        }

        private void sub_bread_Click(object sender, EventArgs e)
        {
            if ((Start.VEGETABLES_TRUCK + Start.SODA_TRUCK + Start.BREADK_TRUCK) - 1 != -1)
            {
                if (Start.BREADK_TRUCK != 0)
                {
                    Start.BREADK_TRUCK -= 1;
                    Nbread_trucks.Text = Start.BREADK_TRUCK.ToString();
                }
            }
        }

        private void sub_vegetables_Click(object sender, EventArgs e)
        {
            if ((Start.VEGETABLES_TRUCK + Start.SODA_TRUCK + Start.BREADK_TRUCK) - 1 != -1)
            {
                if (Start.VEGETABLES_TRUCK != 0)
                {
                    Start.VEGETABLES_TRUCK -= 1;
                    Nvegetables_trucks.Text = Start.VEGETABLES_TRUCK.ToString();
                }
            }
        }

        private void Nsoda_trucks_Click(object sender, EventArgs e)
        {

        }

        private void generateRoute()
        {
            for (int i = 1; i < Ideal_route.ColumnCount; i++)
            {
                Control Control = Ideal_route.GetControlFromPosition(0, i);
                Ideal_route.Controls.Remove(Control);
            }
            Ideal_route.RowStyles.RemoveAt(rowCount - 1);

            foreach (KeyValuePair<int, double> x in storeProfits.OrderByDescending(key => key.Value))
            {
                Console.WriteLine("****KEY: {0}, PROFIT: {1}", x.Key, x.Value);
                Ideal_route.RowCount = Ideal_route.RowCount + 1;
                Ideal_route.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                //ID
                Ideal_route.Controls.Add(new Label() { Text = x.Key.ToString(), ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 0, Ideal_route.RowCount - 1);
                Ideal_route.Controls.Add(new Label() { Text = getStoreName(x.Key), ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 1, Ideal_route.RowCount - 1);
                Ideal_route.Controls.Add(new Label() { Text = x.Value.ToString(), ForeColor = System.Drawing.Color.FromArgb(65, 95, 93), Font = new Font(new FontFamily("Mongolian Baiti"), 10.8f), Dock = DockStyle.None, Anchor = AnchorStyles.None, AutoSize = true }, 2, Ideal_route.RowCount - 1);
            }


        }

        private void start_sim_Click(object sender, EventArgs e)
        {
            /* Generate route */
            generateRoute();

            /* SODA */
            if(Start.TOTAL_SODA == 0)
            {
                
                soda_demand_label.ForeColor = Color.Green;
                soda_demand_label.Text = "Fulfilled";
            }
            else //calculate how many trucks we need
            {
                switch (Start.SODA_TRUCK)
                {
                    case 1:
                        if (120-Start.TOTAL_SODA >= 0)
                        {
                            soda_demand_label.ForeColor = Color.Green;
                            soda_demand_label.Text = "Fulfilled";
                        }
                        else
                        {
                            soda_demand_label.Text = "Not fulfilled";
                            soda_demand_label.ForeColor = Color.Red;
                        }
                        break;
                    case 2:
                        if (240-Start.TOTAL_SODA>= 0)
                        {
                            soda_demand_label.ForeColor = Color.Green;
                            soda_demand_label.Text = "Fulfilled";
                        }
                        else
                        {
                            soda_demand_label.Text = "Not fulfilled";
                            soda_demand_label.ForeColor = Color.Red;
                        }
                        break;
                    case 3:
                        if (360 - Start.TOTAL_SODA  >= 0)
                        {
                            soda_demand_label.ForeColor = Color.Green;
                            soda_demand_label.Text = "Fulfilled";
                        }
                        else
                        {
                            soda_demand_label.ForeColor = Color.Red;
                            soda_demand_label.Text = "Not fulfilled";
                        }
                        break;
                    default:
                        break;
                }
                if ((120 - Start.TOTAL_SODA < 0) && (240 - Start.TOTAL_SODA < 0) && (360 - Start.TOTAL_SODA < 0))
                {
                    string message = "Not enough products, we need " + Math.Abs((810 - Start.TOTAL_SODA)).ToString() + " more sodas";
                    MessageBox.Show(message);
                }
            }
            /* BREAD */ 
            if(Start.TOTAL_BREAD == 0)
            {
                bread_demand_label.Text = "Fulfilled";
                bread_demand_label.ForeColor = Color.Green;
            }
            else //calculate how many trucks we need
            {
                switch (Start.BREADK_TRUCK)
                {
                    case 1:
                        if (270 - Start.TOTAL_BREAD >= 0)
                        {
                            bread_demand_label.ForeColor = Color.Green;
                            bread_demand_label.Text = "Fulfilled";
                        }
                        else
                        {
                            bread_demand_label.Text = "Not fulfilled";
                            bread_demand_label.ForeColor = Color.Red;
                        }
                        break;
                    case 2:
                        if (540 - Start.TOTAL_BREAD >= 0)
                        {
                            bread_demand_label.ForeColor = Color.Green;
                            bread_demand_label.Text = "Fulfilled";
                        }
                        else
                        {
                            bread_demand_label.Text = "Not fulfilled";
                            bread_demand_label.ForeColor = Color.Red;
                        }
                        break;
                    case 3:
                        if (810 - Start.TOTAL_BREAD >= 0)
                        {
                            bread_demand_label.ForeColor = Color.Green;
                            bread_demand_label.Text = "Fulfilled";
                        }
                        else
                        {
                            bread_demand_label.Text = "Not fulfilled";
                            bread_demand_label.ForeColor = Color.Red;
                        }
                        break;
                    default:
                        break;
                }
                if ((270 - Start.TOTAL_BREAD < 0) && (540 - Start.TOTAL_BREAD < 0) && (810 - Start.TOTAL_BREAD < 0))
                {
                    string message = "Not enough products, we need " + Math.Abs((285 - Start.TOTAL_BREAD)).ToString() + " more breads";
                    MessageBox.Show(message);
                }
            }

            /* VEGETABLES */
            if(Start.TOTAL_VEGETABLES == 0)
            {
                vegetables_demand_label.Text = "Fulfilled";
                vegetables_demand_label.ForeColor = Color.Green;
            }
            else //calculate how many trucks we need
            {
                switch (Start.VEGETABLES_TRUCK)
                {
                    case 1:
                        if (95 - Start.TOTAL_VEGETABLES >= 0)
                        {
                            vegetables_demand_label.ForeColor = Color.Green;
                            vegetables_demand_label.Text = "Fulfilled";
                        }
                        else
                        {
                            vegetables_demand_label.Text = "Not fulfilled";
                            vegetables_demand_label.ForeColor = Color.Red;
                        }
                        break;
                    case 2:
                        if (190 - Start.TOTAL_VEGETABLES >= 0)
                        {
                            vegetables_demand_label.ForeColor = Color.Green;
                            vegetables_demand_label.Text = "Fulfilled";
                        }
                        else
                        {
                            vegetables_demand_label.Text = "Not fulfilled";
                            vegetables_demand_label.ForeColor = Color.Red;
                        }
                        break;
                    case 3:
                        if (285 - Start.TOTAL_VEGETABLES >= 0)
                        {
                            vegetables_demand_label.ForeColor = Color.Green;
                            vegetables_demand_label.Text = "Fulfilled";
                        }
                        else
                        {
                            vegetables_demand_label.Text = "Not fulfilled";
                            vegetables_demand_label.ForeColor = Color.Red;
                        }
                        break;
                    default:
                        break;
                }
                if ((95 - Start.TOTAL_VEGETABLES < 0) && (190 - Start.TOTAL_VEGETABLES < 0) && (285 - Start.TOTAL_VEGETABLES < 0))
                {
                    string message = "Not enough products, we need " + Math.Abs((285 - Start.TOTAL_VEGETABLES)).ToString() + " more vegetables";
                    MessageBox.Show(message);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
