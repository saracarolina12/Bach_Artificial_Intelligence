
namespace AlumniApp
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
        /// 
        private void InitializePrivateComponents()
        {
            SuspendLayout();
            panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(1200, 450);
            this.Controls.Add(noaccess);
            this.Controls.Add(gradesTable);
            this.Controls.Add(downloadbutton);
            this.Controls.Add(exitButton);
            this.Controls.Add(sign_inbutton);
            this.Controls.Add(pagetittle);
            this.Controls.Add(setPassword);
            this.Controls.Add(setMail);
            this.Controls.Add(panel1);
            this.Controls.Add(shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(Form1_MouseDown);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(gradesTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(exitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(logoUP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        public static void InitializeComponent()
        {
            panel1 = new System.Windows.Forms.Panel();
            showCareer = new System.Windows.Forms.Label();
            StudentBasicInfo = new System.Windows.Forms.Label();
            showMail = new System.Windows.Forms.Label();
            showHometown = new System.Windows.Forms.Label();
            showBday = new System.Windows.Forms.Label();
            showName = new System.Windows.Forms.Label();
            showID = new System.Windows.Forms.Label();
            dataBasicInfo = new System.Windows.Forms.Label();
            basicinfo = new System.Windows.Forms.Label();
            shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            line2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            setMail = new System.Windows.Forms.TextBox();
            setPassword = new System.Windows.Forms.TextBox();
            pagetittle = new System.Windows.Forms.Label();
            sign_inbutton = new System.Windows.Forms.Button();
            downloadbutton = new System.Windows.Forms.Button();
            gradesTable = new System.Windows.Forms.DataGridView();
            exitButton = new System.Windows.Forms.PictureBox();
            logoUP = new System.Windows.Forms.PictureBox();
            setSubject = new System.Windows.Forms.Label();
            showSubject = new System.Windows.Forms.Label();
            noaccess = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(gradesTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(exitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(logoUP)).BeginInit();
            //SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(23)))), ((int)(((byte)(57)))));
            panel1.Controls.Add(showSubject);
            panel1.Controls.Add(setSubject);
            panel1.Controls.Add(logoUP);
            panel1.Controls.Add(showCareer);
            panel1.Controls.Add(StudentBasicInfo);
            panel1.Controls.Add(showMail);
            panel1.Controls.Add(showHometown);
            panel1.Controls.Add(showBday);
            panel1.Controls.Add(showName);
            panel1.Controls.Add(showID);
            panel1.Controls.Add(dataBasicInfo);
            panel1.Controls.Add(basicinfo);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(457, 450);
            panel1.TabIndex = 0;
//            panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // showCareer
            // 
            showCareer.AutoSize = true;
            showCareer.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            showCareer.ForeColor = System.Drawing.Color.White;
            showCareer.Location = new System.Drawing.Point(119, 361);
            showCareer.Name = "showCareer";
            showCareer.Size = new System.Drawing.Size(0, 23);
            showCareer.TabIndex = 8;
            showCareer.Visible = false;
            showCareer.Click += new System.EventHandler(label1_Click_2);
            // 
            // StudentBasicInfo
            // 
            StudentBasicInfo.AutoSize = true;
            StudentBasicInfo.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            StudentBasicInfo.ForeColor = System.Drawing.Color.White;
            StudentBasicInfo.Location = new System.Drawing.Point(37, 361);
            StudentBasicInfo.Name = "StudentBasicInfo";
            StudentBasicInfo.Size = new System.Drawing.Size(72, 23);
            StudentBasicInfo.TabIndex = 7;
            StudentBasicInfo.Text = "Career:";
            StudentBasicInfo.Visible = false;
            StudentBasicInfo.Click += new System.EventHandler(label1_Click_1);
            // 
            // showMail
            // 
            showMail.AutoSize = true;
            showMail.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            showMail.ForeColor = System.Drawing.Color.White;
            showMail.Location = new System.Drawing.Point(101, 316);
            showMail.Name = "showMail";
            showMail.Size = new System.Drawing.Size(0, 23);
            showMail.TabIndex = 6;
            showMail.Visible = false;
            showMail.Click += new System.EventHandler(showMail_Click);
            // 
            // showHometown
            // 
            showHometown.AutoSize = true;
            showHometown.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            showHometown.ForeColor = System.Drawing.Color.White;
            showHometown.Location = new System.Drawing.Point(153, 271);
            showHometown.Name = "showHometown";
            showHometown.Size = new System.Drawing.Size(0, 23);
            showHometown.TabIndex = 5;
            showHometown.Visible = false;
            showHometown.Click += new System.EventHandler(showHometown_Click);
            // 
            // showBday
            // 
            showBday.AutoSize = true;
            showBday.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            showBday.ForeColor = System.Drawing.Color.White;
            showBday.Location = new System.Drawing.Point(152, 224);
            showBday.Name = "showBday";
            showBday.Size = new System.Drawing.Size(0, 23);
            showBday.TabIndex = 4;
            showBday.Visible = false;
            showBday.Click += new System.EventHandler(showBday_Click);
            // 
            // showName
            // 
            showName.AutoSize = true;
            showName.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            showName.ForeColor = System.Drawing.Color.White;
            showName.Location = new System.Drawing.Point(119, 179);
            showName.Name = "showName";
            showName.Size = new System.Drawing.Size(0, 23);
            showName.TabIndex = 3;
            showName.Visible = false;
            showName.Click += new System.EventHandler(showName_Click);
            // 
            // showID
            // 
            showID.AutoSize = true;
            showID.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            showID.ForeColor = System.Drawing.Color.White;
            showID.Location = new System.Drawing.Point(87, 132);
            showID.Name = "showID";
            showID.Size = new System.Drawing.Size(0, 23);
            showID.TabIndex = 2;
            showID.Visible = false;
            showID.Click += new System.EventHandler(showID_Click);
            // 
            // dataBasicInfo
            // 
            dataBasicInfo.AutoSize = true;
            dataBasicInfo.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataBasicInfo.ForeColor = System.Drawing.Color.White;
            dataBasicInfo.Location = new System.Drawing.Point(37, 132);
            dataBasicInfo.Name = "dataBasicInfo";
            dataBasicInfo.Size = new System.Drawing.Size(109, 207);
            dataBasicInfo.TabIndex = 1;
            dataBasicInfo.Text = "ID:\r\n\r\nName:\r\n\r\nBirth Year:\r\n\r\nHometown:\r\n\r\nMail:";
            dataBasicInfo.Visible = false;
            dataBasicInfo.Click += new System.EventHandler(dataBasicInfo_Click);
            // 
            // basicinfo
            // 
            basicinfo.AutoSize = true;
            basicinfo.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            basicinfo.ForeColor = System.Drawing.Color.White;
            basicinfo.Location = new System.Drawing.Point(85, 34);
            basicinfo.Name = "basicinfo";
            basicinfo.Size = new System.Drawing.Size(248, 32);
            basicinfo.TabIndex = 0;
            basicinfo.Text = "Basic Information:";
            basicinfo.Visible = false;
            basicinfo.Click += new System.EventHandler(label1_Click);
            // 
            // shapeContainer1
            // 
            shapeContainer1.Location = new System.Drawing.Point(0, 0);
            shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            shapeContainer1.Name = "shapeContainer1";
            shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            line2,
            line1});
            shapeContainer1.Size = new System.Drawing.Size(1200, 450);
            shapeContainer1.TabIndex = 1;
            shapeContainer1.TabStop = false;
            // 
            // line2
            // 
            line2.Enabled = false;
            line2.Name = "line2";
            line2.X1 = 675;
            line2.X2 = 1015;
            line2.Y1 = 289;
            line2.Y2 = 289;
            // 
            // line1
            // 
            line1.Enabled = false;
            line1.Name = "line1";
            line1.X1 = 676;
            line1.X2 = 1016;
            line1.Y1 = 188;
            line1.Y2 = 188;
            line1.Click += new System.EventHandler(lineShape1_Click);
            // 
            // setMail
            // 
            setMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
            setMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            setMail.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            setMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            setMail.Location = new System.Drawing.Point(674, 152);
            setMail.Name = "setMail";
            setMail.Size = new System.Drawing.Size(341, 31);
            setMail.TabIndex = 1;
            setMail.Text = "Mail";
            setMail.TextChanged += new System.EventHandler(setMail_TextChanged);
            setMail.Enter += new System.EventHandler(setMail_Enter);
            setMail.Leave += new System.EventHandler(setMail_Leave);
            // 
            // setPassword
            // 
            setPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
            setPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            setPassword.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            setPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            setPassword.Location = new System.Drawing.Point(674, 254);
            setPassword.Name = "setPassword";
            setPassword.Size = new System.Drawing.Size(341, 31);
            setPassword.TabIndex = 2;
            setPassword.Text = "Password";
            setPassword.TextChanged += new System.EventHandler(setPassword_TextChanged);
            setPassword.Enter += new System.EventHandler(setPassword_Enter);
            setPassword.Leave += new System.EventHandler(setPassword_Leave);
            // 
            // pagetittle
            // 
            pagetittle.AutoSize = true;
            pagetittle.Font = new System.Drawing.Font("Georgia", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pagetittle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            pagetittle.Location = new System.Drawing.Point(745, 34);
            pagetittle.Name = "pagetittle";
            pagetittle.Size = new System.Drawing.Size(156, 38);
            pagetittle.TabIndex = 5;
            pagetittle.Text = "L O G I N";
            pagetittle.Click += new System.EventHandler(pagetittle_Click);
            // 
            // sign_inbutton
            // 
            sign_inbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(80)))), ((int)(((byte)(94)))));
            sign_inbutton.FlatAppearance.BorderSize = 0;
            sign_inbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            sign_inbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            sign_inbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            sign_inbutton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sign_inbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(235)))), ((int)(((byte)(223)))));
            sign_inbutton.Location = new System.Drawing.Point(716, 347);
            sign_inbutton.Name = "sign_inbutton";
            sign_inbutton.Size = new System.Drawing.Size(240, 48);
            sign_inbutton.TabIndex = 0;
            sign_inbutton.Text = "Sign in";
            sign_inbutton.UseVisualStyleBackColor = false;
            sign_inbutton.Click += new System.EventHandler(sign_inbutton_Click);
            // 
            // downloadbutton
            // 
            downloadbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(80)))), ((int)(((byte)(94)))));
            downloadbutton.FlatAppearance.BorderSize = 0;
            downloadbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            downloadbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            downloadbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            downloadbutton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            downloadbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(235)))), ((int)(((byte)(223)))));
            downloadbutton.Location = new System.Drawing.Point(774, 377);
            downloadbutton.Name = "downloadbutton";
            downloadbutton.Size = new System.Drawing.Size(127, 34);
            downloadbutton.TabIndex = 7;
            downloadbutton.Text = "Download";
            downloadbutton.UseVisualStyleBackColor = false;
            downloadbutton.Visible = false;
            downloadbutton.Click += new System.EventHandler(downloadbutton_Click);
            // 
            // gradesTable
            // 
            gradesTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            gradesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gradesTable.Location = new System.Drawing.Point(542, 107);
            gradesTable.Name = "gradesTable";
            gradesTable.ReadOnly = true;
            gradesTable.RowHeadersWidth = 51;
            gradesTable.RowTemplate.Height = 24;
            gradesTable.Size = new System.Drawing.Size(580, 264);
            gradesTable.TabIndex = 8;
            gradesTable.Visible = false;
            // 
            // exitButton
            // 
            exitButton.Image = global::AlumniApp.Properties.Resources.X;
            exitButton.Location = new System.Drawing.Point(1175, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(22, 22);
            exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            exitButton.TabIndex = 6;
            exitButton.TabStop = false;
            exitButton.Click += new System.EventHandler(exitButton_Click);
            // 
            // logoUP
            // 
            logoUP.Cursor = System.Windows.Forms.Cursors.Arrow;
            logoUP.Image = global::AlumniApp.Properties.Resources.logoUP;
            logoUP.Location = new System.Drawing.Point(91, 80);
            logoUP.Name = "logoUP";
            logoUP.Size = new System.Drawing.Size(274, 304);
            logoUP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            logoUP.TabIndex = 9;
            logoUP.TabStop = false;
            // 
            // setSubject
            // 
            setSubject.AutoSize = true;
            setSubject.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            setSubject.ForeColor = System.Drawing.Color.White;
            setSubject.Location = new System.Drawing.Point(37, 361);
            setSubject.Name = "setSubject";
            setSubject.Size = new System.Drawing.Size(80, 23);
            setSubject.TabIndex = 10;
            setSubject.Text = "Subject:";
            setSubject.Visible = false;
            // 
            // showSubject
            // 
            showSubject.AutoSize = true;
            showSubject.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            showSubject.ForeColor = System.Drawing.Color.White;
            showSubject.Location = new System.Drawing.Point(123, 361);
            showSubject.Name = "showSubject";
            showSubject.Size = new System.Drawing.Size(0, 23);
            showSubject.TabIndex = 11;
            showSubject.Visible = false;
            // 
            // noaccess
            // 
            noaccess.AutoSize = true;
            noaccess.Enabled = false;
            noaccess.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            noaccess.ForeColor = System.Drawing.Color.DimGray;
            noaccess.Location = new System.Drawing.Point(550, 188);
            noaccess.Name = "noaccess";
            noaccess.Size = new System.Drawing.Size(563, 96);
            noaccess.TabIndex = 12;
            noaccess.Text = "                      We are sorry!\r\n\r\nYou don\'t have access to this information " +
    ":(";
            noaccess.Visible = false;
           

        }

        #endregion

        public static System.Windows.Forms.Panel panel1;
        public static Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        public static Microsoft.VisualBasic.PowerPacks.LineShape line2;
        public static Microsoft.VisualBasic.PowerPacks.LineShape line1;
        public static System.Windows.Forms.TextBox setMail;
        public static System.Windows.Forms.TextBox setPassword;
        public static System.Windows.Forms.Label pagetittle;
        public static System.Windows.Forms.Button sign_inbutton;
        public static System.Windows.Forms.PictureBox exitButton;
        public static System.Windows.Forms.Label basicinfo;
        public static System.Windows.Forms.Label dataBasicInfo;
        public static System.Windows.Forms.Label showMail;
        public static System.Windows.Forms.Label showHometown;
        public static System.Windows.Forms.Label showBday;
        public static System.Windows.Forms.Label showName;
        public static System.Windows.Forms.Label showID;
        public static System.Windows.Forms.Button downloadbutton;
        public static System.Windows.Forms.Label StudentBasicInfo;
        public static System.Windows.Forms.Label showCareer;
        public static System.Windows.Forms.DataGridView gradesTable;
        public static System.Windows.Forms.PictureBox logoUP;
        public static System.Windows.Forms.Label showSubject;
        public static System.Windows.Forms.Label setSubject;
        public static System.Windows.Forms.Label noaccess;
    }
}

