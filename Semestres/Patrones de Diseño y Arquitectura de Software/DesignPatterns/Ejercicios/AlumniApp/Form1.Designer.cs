
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
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.showMail = new System.Windows.Forms.Label();
            this.showHometown = new System.Windows.Forms.Label();
            this.showBday = new System.Windows.Forms.Label();
            this.showName = new System.Windows.Forms.Label();
            this.showID = new System.Windows.Forms.Label();
            this.dataBasicInfo = new System.Windows.Forms.Label();
            this.basicinfo = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.line2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.setMail = new System.Windows.Forms.TextBox();
            this.setPassword = new System.Windows.Forms.TextBox();
            this.pagetittle = new System.Windows.Forms.Label();
            this.sign_inbutton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.downloadbutton = new System.Windows.Forms.Button();
            this.StudentBasicInfo = new System.Windows.Forms.Label();
            this.showCareer = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(23)))), ((int)(((byte)(57)))));
            this.panel1.Controls.Add(this.showCareer);
            this.panel1.Controls.Add(this.StudentBasicInfo);
            this.panel1.Controls.Add(this.showMail);
            this.panel1.Controls.Add(this.showHometown);
            this.panel1.Controls.Add(this.showBday);
            this.panel1.Controls.Add(this.showName);
            this.panel1.Controls.Add(this.showID);
            this.panel1.Controls.Add(this.dataBasicInfo);
            this.panel1.Controls.Add(this.basicinfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 450);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // showMail
            // 
            this.showMail.AutoSize = true;
            this.showMail.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showMail.ForeColor = System.Drawing.Color.White;
            this.showMail.Location = new System.Drawing.Point(101, 316);
            this.showMail.Name = "showMail";
            this.showMail.Size = new System.Drawing.Size(0, 23);
            this.showMail.TabIndex = 6;
            this.showMail.Visible = false;
            this.showMail.Click += new System.EventHandler(this.showMail_Click);
            // 
            // showHometown
            // 
            this.showHometown.AutoSize = true;
            this.showHometown.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showHometown.ForeColor = System.Drawing.Color.White;
            this.showHometown.Location = new System.Drawing.Point(153, 271);
            this.showHometown.Name = "showHometown";
            this.showHometown.Size = new System.Drawing.Size(0, 23);
            this.showHometown.TabIndex = 5;
            this.showHometown.Visible = false;
            this.showHometown.Click += new System.EventHandler(this.showHometown_Click);
            // 
            // showBday
            // 
            this.showBday.AutoSize = true;
            this.showBday.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showBday.ForeColor = System.Drawing.Color.White;
            this.showBday.Location = new System.Drawing.Point(152, 224);
            this.showBday.Name = "showBday";
            this.showBday.Size = new System.Drawing.Size(0, 23);
            this.showBday.TabIndex = 4;
            this.showBday.Visible = false;
            this.showBday.Click += new System.EventHandler(this.showBday_Click);
            // 
            // showName
            // 
            this.showName.AutoSize = true;
            this.showName.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showName.ForeColor = System.Drawing.Color.White;
            this.showName.Location = new System.Drawing.Point(119, 179);
            this.showName.Name = "showName";
            this.showName.Size = new System.Drawing.Size(0, 23);
            this.showName.TabIndex = 3;
            this.showName.Visible = false;
            this.showName.Click += new System.EventHandler(this.showName_Click);
            // 
            // showID
            // 
            this.showID.AutoSize = true;
            this.showID.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showID.ForeColor = System.Drawing.Color.White;
            this.showID.Location = new System.Drawing.Point(87, 132);
            this.showID.Name = "showID";
            this.showID.Size = new System.Drawing.Size(0, 23);
            this.showID.TabIndex = 2;
            this.showID.Visible = false;
            this.showID.Click += new System.EventHandler(this.showID_Click);
            // 
            // dataBasicInfo
            // 
            this.dataBasicInfo.AutoSize = true;
            this.dataBasicInfo.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataBasicInfo.ForeColor = System.Drawing.Color.White;
            this.dataBasicInfo.Location = new System.Drawing.Point(37, 132);
            this.dataBasicInfo.Name = "dataBasicInfo";
            this.dataBasicInfo.Size = new System.Drawing.Size(109, 207);
            this.dataBasicInfo.TabIndex = 1;
            this.dataBasicInfo.Text = "ID:\r\n\r\nName:\r\n\r\nBirth Year:\r\n\r\nHometown:\r\n\r\nMail:";
            this.dataBasicInfo.Visible = false;
            this.dataBasicInfo.Click += new System.EventHandler(this.dataBasicInfo_Click);
            // 
            // basicinfo
            // 
            this.basicinfo.AutoSize = true;
            this.basicinfo.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.basicinfo.ForeColor = System.Drawing.Color.White;
            this.basicinfo.Location = new System.Drawing.Point(85, 34);
            this.basicinfo.Name = "basicinfo";
            this.basicinfo.Size = new System.Drawing.Size(248, 32);
            this.basicinfo.TabIndex = 0;
            this.basicinfo.Text = "Basic Information:";
            this.basicinfo.Visible = false;
            this.basicinfo.Click += new System.EventHandler(this.label1_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.line2,
            this.line1});
            this.shapeContainer1.Size = new System.Drawing.Size(1200, 450);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // line2
            // 
            this.line2.Enabled = false;
            this.line2.Name = "line2";
            this.line2.X1 = 675;
            this.line2.X2 = 1015;
            this.line2.Y1 = 289;
            this.line2.Y2 = 289;
            // 
            // line1
            // 
            this.line1.Enabled = false;
            this.line1.Name = "line1";
            this.line1.X1 = 676;
            this.line1.X2 = 1016;
            this.line1.Y1 = 188;
            this.line1.Y2 = 188;
            this.line1.Click += new System.EventHandler(this.lineShape1_Click);
            // 
            // setMail
            // 
            this.setMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
            this.setMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.setMail.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.setMail.Location = new System.Drawing.Point(674, 152);
            this.setMail.Name = "setMail";
            this.setMail.Size = new System.Drawing.Size(341, 31);
            this.setMail.TabIndex = 1;
            this.setMail.Text = "Mail";
            this.setMail.TextChanged += new System.EventHandler(this.setMail_TextChanged);
            this.setMail.Enter += new System.EventHandler(this.setMail_Enter);
            this.setMail.Leave += new System.EventHandler(this.setMail_Leave);
            // 
            // setPassword
            // 
            this.setPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
            this.setPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.setPassword.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.setPassword.Location = new System.Drawing.Point(674, 254);
            this.setPassword.Name = "setPassword";
            this.setPassword.Size = new System.Drawing.Size(341, 31);
            this.setPassword.TabIndex = 2;
            this.setPassword.Text = "Password";
            this.setPassword.TextChanged += new System.EventHandler(this.setPassword_TextChanged);
            this.setPassword.Enter += new System.EventHandler(this.setPassword_Enter);
            this.setPassword.Leave += new System.EventHandler(this.setPassword_Leave);
            // 
            // pagetittle
            // 
            this.pagetittle.AutoSize = true;
            this.pagetittle.Font = new System.Drawing.Font("Georgia", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagetittle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.pagetittle.Location = new System.Drawing.Point(745, 34);
            this.pagetittle.Name = "pagetittle";
            this.pagetittle.Size = new System.Drawing.Size(156, 38);
            this.pagetittle.TabIndex = 5;
            this.pagetittle.Text = "L O G I N";
            this.pagetittle.Click += new System.EventHandler(this.pagetittle_Click);
            // 
            // sign_inbutton
            // 
            this.sign_inbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(80)))), ((int)(((byte)(94)))));
            this.sign_inbutton.FlatAppearance.BorderSize = 0;
            this.sign_inbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.sign_inbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.sign_inbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_inbutton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_inbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(235)))), ((int)(((byte)(223)))));
            this.sign_inbutton.Location = new System.Drawing.Point(716, 347);
            this.sign_inbutton.Name = "sign_inbutton";
            this.sign_inbutton.Size = new System.Drawing.Size(240, 48);
            this.sign_inbutton.TabIndex = 0;
            this.sign_inbutton.Text = "Sign in";
            this.sign_inbutton.UseVisualStyleBackColor = false;
            this.sign_inbutton.Click += new System.EventHandler(this.sign_inbutton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Image = global::AlumniApp.Properties.Resources.X;
            this.exitButton.Location = new System.Drawing.Point(1175, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(22, 22);
            this.exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exitButton.TabIndex = 6;
            this.exitButton.TabStop = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // downloadbutton
            // 
            this.downloadbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(80)))), ((int)(((byte)(94)))));
            this.downloadbutton.FlatAppearance.BorderSize = 0;
            this.downloadbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.downloadbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.downloadbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadbutton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(235)))), ((int)(((byte)(223)))));
            this.downloadbutton.Location = new System.Drawing.Point(983, 347);
            this.downloadbutton.Name = "downloadbutton";
            this.downloadbutton.Size = new System.Drawing.Size(138, 48);
            this.downloadbutton.TabIndex = 7;
            this.downloadbutton.Text = "Download";
            this.downloadbutton.UseVisualStyleBackColor = false;
            this.downloadbutton.Visible = false;
            this.downloadbutton.Click += new System.EventHandler(this.downloadbutton_Click);
            // 
            // StudentBasicInfo
            // 
            this.StudentBasicInfo.AutoSize = true;
            this.StudentBasicInfo.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentBasicInfo.ForeColor = System.Drawing.Color.White;
            this.StudentBasicInfo.Location = new System.Drawing.Point(37, 361);
            this.StudentBasicInfo.Name = "StudentBasicInfo";
            this.StudentBasicInfo.Size = new System.Drawing.Size(72, 23);
            this.StudentBasicInfo.TabIndex = 7;
            this.StudentBasicInfo.Text = "Career:";
            this.StudentBasicInfo.Visible = false;
            this.StudentBasicInfo.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // showCareer
            // 
            this.showCareer.AutoSize = true;
            this.showCareer.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showCareer.ForeColor = System.Drawing.Color.White;
            this.showCareer.Location = new System.Drawing.Point(119, 361);
            this.showCareer.Name = "showCareer";
            this.showCareer.Size = new System.Drawing.Size(0, 23);
            this.showCareer.TabIndex = 8;
            this.showCareer.Visible = false;
            this.showCareer.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(1200, 450);
            this.Controls.Add(this.downloadbutton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.sign_inbutton);
            this.Controls.Add(this.pagetittle);
            this.Controls.Add(this.setPassword);
            this.Controls.Add(this.setMail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape line2;
        private Microsoft.VisualBasic.PowerPacks.LineShape line1;
        private System.Windows.Forms.TextBox setMail;
        private System.Windows.Forms.TextBox setPassword;
        private System.Windows.Forms.Label pagetittle;
        private System.Windows.Forms.Button sign_inbutton;
        private System.Windows.Forms.PictureBox exitButton;
        private System.Windows.Forms.Label basicinfo;
        private System.Windows.Forms.Label dataBasicInfo;
        private System.Windows.Forms.Label showMail;
        private System.Windows.Forms.Label showHometown;
        private System.Windows.Forms.Label showBday;
        private System.Windows.Forms.Label showName;
        private System.Windows.Forms.Label showID;
        private System.Windows.Forms.Button downloadbutton;
        private System.Windows.Forms.Label StudentBasicInfo;
        private System.Windows.Forms.Label showCareer;
    }
}

