
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
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.setMail = new System.Windows.Forms.TextBox();
            this.setPassword = new System.Windows.Forms.TextBox();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label2 = new System.Windows.Forms.Label();
            this.sign_inbutton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(23)))), ((int)(((byte)(57)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 450);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(982, 450);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Enabled = false;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 465;
            this.lineShape1.X2 = 805;
            this.lineShape1.Y1 = 192;
            this.lineShape1.Y2 = 192;
            this.lineShape1.Click += new System.EventHandler(this.lineShape1_Click);
            // 
            // setMail
            // 
            this.setMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
            this.setMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.setMail.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.setMail.Location = new System.Drawing.Point(466, 152);
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
            this.setPassword.Location = new System.Drawing.Point(466, 254);
            this.setPassword.Name = "setPassword";
            this.setPassword.Size = new System.Drawing.Size(341, 31);
            this.setPassword.TabIndex = 2;
            this.setPassword.Text = "Password";
            this.setPassword.TextChanged += new System.EventHandler(this.setPassword_TextChanged);
            this.setPassword.Enter += new System.EventHandler(this.setPassword_Enter);
            this.setPassword.Leave += new System.EventHandler(this.setPassword_Leave);
            // 
            // lineShape2
            // 
            this.lineShape2.Enabled = false;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 466;
            this.lineShape2.X2 = 806;
            this.lineShape2.Y1 = 293;
            this.lineShape2.Y2 = 293;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.label2.Location = new System.Drawing.Point(537, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "L O G I N";
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
            this.sign_inbutton.Location = new System.Drawing.Point(508, 347);
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
            this.exitButton.Location = new System.Drawing.Point(957, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(22, 22);
            this.exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exitButton.TabIndex = 6;
            this.exitButton.TabStop = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(982, 450);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.sign_inbutton);
            this.Controls.Add(this.label2);
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
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox setMail;
        private System.Windows.Forms.TextBox setPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sign_inbutton;
        private System.Windows.Forms.PictureBox exitButton;
    }
}

