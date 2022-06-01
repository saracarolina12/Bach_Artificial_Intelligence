
namespace Simulacion_Pedidos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.start_sim = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.sub_vegetables = new System.Windows.Forms.PictureBox();
            this.add_vegetables = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.sub_bread = new System.Windows.Forms.PictureBox();
            this.add_bread = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sub_soda = new System.Windows.Forms.PictureBox();
            this.add_soda = new System.Windows.Forms.PictureBox();
            this.vegetables_demand_label = new System.Windows.Forms.Label();
            this.bread_demand_label = new System.Windows.Forms.Label();
            this.soda_demand_label = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toStockList = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape6 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_trucks = new System.Windows.Forms.Panel();
            this.Nvegetables_trucks = new System.Windows.Forms.Label();
            this.Nbread_trucks = new System.Windows.Forms.Label();
            this.Nsoda_trucks = new System.Windows.Forms.Label();
            this.bread_truck = new System.Windows.Forms.Label();
            this.vegetables_truck = new System.Windows.Forms.Label();
            this.soda_truck = new System.Windows.Forms.Label();
            this.Available_trucks = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.readQR = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Ideal_route = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sub_vegetables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_vegetables)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sub_bread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_bread)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sub_soda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_soda)).BeginInit();
            this.toStockList.SuspendLayout();
            this.panel_trucks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Ideal_route.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(191)))), ((int)(((byte)(188)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.start_sim);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.vegetables_demand_label);
            this.panel1.Controls.Add(this.bread_demand_label);
            this.panel1.Controls.Add(this.soda_demand_label);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.toStockList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.shapeContainer2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 577);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(156)))), ((int)(((byte)(154)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.button1.Location = new System.Drawing.Point(233, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 42);
            this.button1.TabIndex = 17;
            this.button1.Text = "Report";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // start_sim
            // 
            this.start_sim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(156)))), ((int)(((byte)(154)))));
            this.start_sim.FlatAppearance.BorderSize = 0;
            this.start_sim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_sim.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_sim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.start_sim.Location = new System.Drawing.Point(32, 493);
            this.start_sim.Name = "start_sim";
            this.start_sim.Size = new System.Drawing.Size(180, 42);
            this.start_sim.TabIndex = 12;
            this.start_sim.Text = "Simulate Route";
            this.start_sim.UseVisualStyleBackColor = false;
            this.start_sim.Click += new System.EventHandler(this.start_sim_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.sub_vegetables);
            this.panel5.Controls.Add(this.add_vegetables);
            this.panel5.Location = new System.Drawing.Point(28, 359);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(67, 28);
            this.panel5.TabIndex = 16;
            // 
            // sub_vegetables
            // 
            this.sub_vegetables.Image = ((System.Drawing.Image)(resources.GetObject("sub_vegetables.Image")));
            this.sub_vegetables.Location = new System.Drawing.Point(3, 0);
            this.sub_vegetables.Name = "sub_vegetables";
            this.sub_vegetables.Size = new System.Drawing.Size(28, 28);
            this.sub_vegetables.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sub_vegetables.TabIndex = 12;
            this.sub_vegetables.TabStop = false;
            this.sub_vegetables.Click += new System.EventHandler(this.sub_vegetables_Click);
            // 
            // add_vegetables
            // 
            this.add_vegetables.Image = ((System.Drawing.Image)(resources.GetObject("add_vegetables.Image")));
            this.add_vegetables.Location = new System.Drawing.Point(39, 0);
            this.add_vegetables.Name = "add_vegetables";
            this.add_vegetables.Size = new System.Drawing.Size(28, 28);
            this.add_vegetables.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.add_vegetables.TabIndex = 13;
            this.add_vegetables.TabStop = false;
            this.add_vegetables.Click += new System.EventHandler(this.add_vegetables_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.sub_bread);
            this.panel4.Controls.Add(this.add_bread);
            this.panel4.Location = new System.Drawing.Point(29, 434);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(67, 28);
            this.panel4.TabIndex = 15;
            // 
            // sub_bread
            // 
            this.sub_bread.Image = ((System.Drawing.Image)(resources.GetObject("sub_bread.Image")));
            this.sub_bread.Location = new System.Drawing.Point(3, 0);
            this.sub_bread.Name = "sub_bread";
            this.sub_bread.Size = new System.Drawing.Size(28, 28);
            this.sub_bread.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sub_bread.TabIndex = 12;
            this.sub_bread.TabStop = false;
            this.sub_bread.Click += new System.EventHandler(this.sub_bread_Click);
            // 
            // add_bread
            // 
            this.add_bread.Image = ((System.Drawing.Image)(resources.GetObject("add_bread.Image")));
            this.add_bread.Location = new System.Drawing.Point(39, 0);
            this.add_bread.Name = "add_bread";
            this.add_bread.Size = new System.Drawing.Size(28, 28);
            this.add_bread.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.add_bread.TabIndex = 13;
            this.add_bread.TabStop = false;
            this.add_bread.Click += new System.EventHandler(this.add_bread_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sub_soda);
            this.panel2.Controls.Add(this.add_soda);
            this.panel2.Location = new System.Drawing.Point(28, 396);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(67, 28);
            this.panel2.TabIndex = 14;
            // 
            // sub_soda
            // 
            this.sub_soda.Image = ((System.Drawing.Image)(resources.GetObject("sub_soda.Image")));
            this.sub_soda.Location = new System.Drawing.Point(3, 0);
            this.sub_soda.Name = "sub_soda";
            this.sub_soda.Size = new System.Drawing.Size(28, 28);
            this.sub_soda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sub_soda.TabIndex = 12;
            this.sub_soda.TabStop = false;
            this.sub_soda.Click += new System.EventHandler(this.sub_soda_Click);
            // 
            // add_soda
            // 
            this.add_soda.Image = ((System.Drawing.Image)(resources.GetObject("add_soda.Image")));
            this.add_soda.Location = new System.Drawing.Point(39, 0);
            this.add_soda.Name = "add_soda";
            this.add_soda.Size = new System.Drawing.Size(28, 28);
            this.add_soda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.add_soda.TabIndex = 13;
            this.add_soda.TabStop = false;
            this.add_soda.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // vegetables_demand_label
            // 
            this.vegetables_demand_label.AutoSize = true;
            this.vegetables_demand_label.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vegetables_demand_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.vegetables_demand_label.Location = new System.Drawing.Point(229, 367);
            this.vegetables_demand_label.Name = "vegetables_demand_label";
            this.vegetables_demand_label.Size = new System.Drawing.Size(103, 20);
            this.vegetables_demand_label.TabIndex = 13;
            this.vegetables_demand_label.Text = "Not fulfilled";
            // 
            // bread_demand_label
            // 
            this.bread_demand_label.AutoSize = true;
            this.bread_demand_label.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bread_demand_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bread_demand_label.Location = new System.Drawing.Point(229, 440);
            this.bread_demand_label.Name = "bread_demand_label";
            this.bread_demand_label.Size = new System.Drawing.Size(103, 20);
            this.bread_demand_label.TabIndex = 12;
            this.bread_demand_label.Text = "Not fulfilled";
            // 
            // soda_demand_label
            // 
            this.soda_demand_label.AutoSize = true;
            this.soda_demand_label.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soda_demand_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.soda_demand_label.Location = new System.Drawing.Point(229, 401);
            this.soda_demand_label.Name = "soda_demand_label";
            this.soda_demand_label.Size = new System.Drawing.Size(103, 20);
            this.soda_demand_label.TabIndex = 11;
            this.soda_demand_label.Text = "Not fulfilled";
            this.soda_demand_label.Click += new System.EventHandler(this.label16_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label14.Location = new System.Drawing.Point(97, 367);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 20);
            this.label14.TabIndex = 10;
            this.label14.Text = "Vegetables:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label13.Location = new System.Drawing.Point(98, 440);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 20);
            this.label13.TabIndex = 10;
            this.label13.Text = "Bread:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label12.Location = new System.Drawing.Point(99, 401);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 20);
            this.label12.TabIndex = 10;
            this.label12.Text = "Soda:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label6.Location = new System.Drawing.Point(110, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 30);
            this.label6.TabIndex = 2;
            this.label6.Text = "Demand";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // toStockList
            // 
            this.toStockList.AutoSize = true;
            this.toStockList.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.toStockList.ColumnCount = 3;
            this.toStockList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.90173F));
            this.toStockList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.09827F));
            this.toStockList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.toStockList.Controls.Add(this.label8, 2, 0);
            this.toStockList.Controls.Add(this.label7, 0, 0);
            this.toStockList.Controls.Add(this.label15, 1, 0);
            this.toStockList.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.toStockList.Location = new System.Drawing.Point(41, 137);
            this.toStockList.Name = "toStockList";
            this.toStockList.RowCount = 1;
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.68493F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.31507F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toStockList.Size = new System.Drawing.Size(257, 48);
            this.toStockList.TabIndex = 1;
            this.toStockList.Paint += new System.Windows.Forms.PaintEventHandler(this.toStockList_Paint);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label8.Location = new System.Drawing.Point(152, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 21);
            this.label8.TabIndex = 11;
            this.label8.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label7.Location = new System.Drawing.Point(4, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "ID";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label15.Location = new System.Drawing.Point(58, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 21);
            this.label15.TabIndex = 19;
            this.label15.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label1.Location = new System.Drawing.Point(54, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Products to stock";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape5,
            this.lineShape6,
            this.lineShape4});
            this.shapeContainer2.Size = new System.Drawing.Size(353, 577);
            this.shapeContainer2.TabIndex = 14;
            this.shapeContainer2.TabStop = false;
            // 
            // lineShape5
            // 
            this.lineShape5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.lineShape5.Name = "lineShape5";
            this.lineShape5.X1 = 159;
            this.lineShape5.X2 = 233;
            this.lineShape5.Y1 = 413;
            this.lineShape5.Y2 = 413;
            this.lineShape5.Click += new System.EventHandler(this.lineShape1_Click);
            // 
            // lineShape6
            // 
            this.lineShape6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.lineShape6.Name = "lineShape6";
            this.lineShape6.X1 = 117;
            this.lineShape6.X2 = 282;
            this.lineShape6.Y1 = 448;
            this.lineShape6.Y2 = 448;
            this.lineShape6.Click += new System.EventHandler(this.lineShape1_Click);
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 158;
            this.lineShape4.X2 = 232;
            this.lineShape4.Y1 = 377;
            this.lineShape4.Y2 = 377;
            this.lineShape4.Click += new System.EventHandler(this.lineShape1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label2.Location = new System.Drawing.Point(525, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "Simulation";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel_trucks
            // 
            this.panel_trucks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(191)))), ((int)(((byte)(188)))));
            this.panel_trucks.Controls.Add(this.Nvegetables_trucks);
            this.panel_trucks.Controls.Add(this.Nbread_trucks);
            this.panel_trucks.Controls.Add(this.Nsoda_trucks);
            this.panel_trucks.Controls.Add(this.bread_truck);
            this.panel_trucks.Controls.Add(this.vegetables_truck);
            this.panel_trucks.Controls.Add(this.soda_truck);
            this.panel_trucks.Controls.Add(this.Available_trucks);
            this.panel_trucks.Controls.Add(this.shapeContainer1);
            this.panel_trucks.Location = new System.Drawing.Point(382, 82);
            this.panel_trucks.Margin = new System.Windows.Forms.Padding(0);
            this.panel_trucks.Name = "panel_trucks";
            this.panel_trucks.Size = new System.Drawing.Size(537, 132);
            this.panel_trucks.TabIndex = 3;
            this.panel_trucks.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Nvegetables_trucks
            // 
            this.Nvegetables_trucks.AutoSize = true;
            this.Nvegetables_trucks.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nvegetables_trucks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.Nvegetables_trucks.Location = new System.Drawing.Point(487, 97);
            this.Nvegetables_trucks.Name = "Nvegetables_trucks";
            this.Nvegetables_trucks.Size = new System.Drawing.Size(19, 20);
            this.Nvegetables_trucks.TabIndex = 7;
            this.Nvegetables_trucks.Text = "0";
            // 
            // Nbread_trucks
            // 
            this.Nbread_trucks.AutoSize = true;
            this.Nbread_trucks.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nbread_trucks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.Nbread_trucks.Location = new System.Drawing.Point(487, 69);
            this.Nbread_trucks.Name = "Nbread_trucks";
            this.Nbread_trucks.Size = new System.Drawing.Size(19, 20);
            this.Nbread_trucks.TabIndex = 6;
            this.Nbread_trucks.Text = "0";
            // 
            // Nsoda_trucks
            // 
            this.Nsoda_trucks.AutoSize = true;
            this.Nsoda_trucks.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nsoda_trucks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.Nsoda_trucks.Location = new System.Drawing.Point(487, 40);
            this.Nsoda_trucks.Name = "Nsoda_trucks";
            this.Nsoda_trucks.Size = new System.Drawing.Size(19, 20);
            this.Nsoda_trucks.TabIndex = 5;
            this.Nsoda_trucks.Text = "0";
            this.Nsoda_trucks.Click += new System.EventHandler(this.Nsoda_trucks_Click);
            // 
            // bread_truck
            // 
            this.bread_truck.AutoSize = true;
            this.bread_truck.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bread_truck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.bread_truck.Location = new System.Drawing.Point(50, 69);
            this.bread_truck.Name = "bread_truck";
            this.bread_truck.Size = new System.Drawing.Size(74, 20);
            this.bread_truck.TabIndex = 4;
            this.bread_truck.Text = "* Bread:";
            // 
            // vegetables_truck
            // 
            this.vegetables_truck.AutoSize = true;
            this.vegetables_truck.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vegetables_truck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.vegetables_truck.Location = new System.Drawing.Point(50, 97);
            this.vegetables_truck.Name = "vegetables_truck";
            this.vegetables_truck.Size = new System.Drawing.Size(166, 20);
            this.vegetables_truck.TabIndex = 3;
            this.vegetables_truck.Text = "* Frozen vegetables:";
            // 
            // soda_truck
            // 
            this.soda_truck.AutoSize = true;
            this.soda_truck.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soda_truck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.soda_truck.Location = new System.Drawing.Point(50, 40);
            this.soda_truck.Name = "soda_truck";
            this.soda_truck.Size = new System.Drawing.Size(68, 20);
            this.soda_truck.TabIndex = 2;
            this.soda_truck.Text = "* Soda:";
            // 
            // Available_trucks
            // 
            this.Available_trucks.AutoSize = true;
            this.Available_trucks.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Available_trucks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.Available_trucks.Location = new System.Drawing.Point(3, 9);
            this.Available_trucks.Name = "Available_trucks";
            this.Available_trucks.Size = new System.Drawing.Size(185, 25);
            this.Available_trucks.TabIndex = 2;
            this.Available_trucks.Text = "Available trucks";
            this.Available_trucks.Click += new System.EventHandler(this.label3_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(537, 132);
            this.shapeContainer1.TabIndex = 9;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 121;
            this.lineShape3.X2 = 479;
            this.lineShape3.Y1 = 111;
            this.lineShape3.Y2 = 111;
            this.lineShape3.Click += new System.EventHandler(this.lineShape1_Click);
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 120;
            this.lineShape2.X2 = 478;
            this.lineShape2.Y1 = 83;
            this.lineShape2.Y2 = 83;
            this.lineShape2.Click += new System.EventHandler(this.lineShape1_Click);
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 120;
            this.lineShape1.X2 = 479;
            this.lineShape1.Y1 = 55;
            this.lineShape1.Y2 = 55;
            this.lineShape1.Click += new System.EventHandler(this.lineShape1_Click);
            // 
            // readQR
            // 
            this.readQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(191)))), ((int)(((byte)(188)))));
            this.readQR.FlatAppearance.BorderSize = 0;
            this.readQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readQR.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readQR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.readQR.Location = new System.Drawing.Point(776, 516);
            this.readQR.Name = "readQR";
            this.readQR.Size = new System.Drawing.Size(143, 38);
            this.readQR.TabIndex = 4;
            this.readQR.Text = "Create order";
            this.readQR.UseVisualStyleBackColor = false;
            this.readQR.Click += new System.EventHandler(this.readQR_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(910, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label5.Location = new System.Drawing.Point(552, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 31);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ideal Route";
            // 
            // Ideal_route
            // 
            this.Ideal_route.AutoSize = true;
            this.Ideal_route.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.Ideal_route.ColumnCount = 3;
            this.Ideal_route.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.74074F));
            this.Ideal_route.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.25926F));
            this.Ideal_route.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.Ideal_route.Controls.Add(this.label11, 2, 0);
            this.Ideal_route.Controls.Add(this.label10, 1, 0);
            this.Ideal_route.Controls.Add(this.label9, 0, 0);
            this.Ideal_route.Location = new System.Drawing.Point(464, 265);
            this.Ideal_route.Name = "Ideal_route";
            this.Ideal_route.RowCount = 1;
            this.Ideal_route.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.57143F));
            this.Ideal_route.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.42857F));
            this.Ideal_route.Size = new System.Drawing.Size(276, 33);
            this.Ideal_route.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label11.Location = new System.Drawing.Point(196, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 21);
            this.label11.TabIndex = 13;
            this.label11.Text = "Profit";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label10.Location = new System.Drawing.Point(95, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 21);
            this.label10.TabIndex = 12;
            this.label10.Text = "Name";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label9.Location = new System.Drawing.Point(20, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 21);
            this.label9.TabIndex = 11;
            this.label9.Text = "ID";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.pictureBox5);
            this.panel3.Location = new System.Drawing.Point(20, 444);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(67, 28);
            this.panel3.TabIndex = 15;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(39, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(28, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(252)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.Ideal_route);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.readQR);
            this.Controls.Add(this.panel_trucks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sub_vegetables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_vegetables)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sub_bread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_bread)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sub_soda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_soda)).EndInit();
            this.toStockList.ResumeLayout(false);
            this.toStockList.PerformLayout();
            this.panel_trucks.ResumeLayout(false);
            this.panel_trucks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Ideal_route.ResumeLayout(false);
            this.Ideal_route.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_trucks;
        private System.Windows.Forms.Label Available_trucks;
        private System.Windows.Forms.Label soda_truck;
        private System.Windows.Forms.Label bread_truck;
        private System.Windows.Forms.Label vegetables_truck;
        private System.Windows.Forms.Label Nvegetables_trucks;
        private System.Windows.Forms.Label Nbread_trucks;
        private System.Windows.Forms.Label Nsoda_trucks;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Button readQR;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel toStockList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel Ideal_route;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label soda_demand_label;
        private System.Windows.Forms.Label vegetables_demand_label;
        private System.Windows.Forms.Label bread_demand_label;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox sub_soda;
        private System.Windows.Forms.PictureBox add_soda;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox sub_vegetables;
        private System.Windows.Forms.PictureBox add_vegetables;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox sub_bread;
        private System.Windows.Forms.PictureBox add_bread;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button start_sim;
        private System.Windows.Forms.Button button1;
    }
}

