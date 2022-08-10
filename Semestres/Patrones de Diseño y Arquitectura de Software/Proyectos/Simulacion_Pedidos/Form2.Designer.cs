
namespace Simulacion_Pedidos
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_actual_QR = new System.Windows.Forms.Label();
            this.QR_container = new System.Windows.Forms.Panel();
            this.nameStoreLabel = new System.Windows.Forms.Label();
            this.idStoreLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.Add_button = new System.Windows.Forms.Button();
            this.listToStock = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.ID_table = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.save_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.listToStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(191)))), ((int)(((byte)(188)))));
            this.panel1.Controls.Add(this.label_actual_QR);
            this.panel1.Controls.Add(this.QR_container);
            this.panel1.Controls.Add(this.nameStoreLabel);
            this.panel1.Controls.Add(this.idStoreLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 577);
            this.panel1.TabIndex = 0;
            // 
            // label_actual_QR
            // 
            this.label_actual_QR.AutoSize = true;
            this.label_actual_QR.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_actual_QR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label_actual_QR.Location = new System.Drawing.Point(24, 261);
            this.label_actual_QR.Name = "label_actual_QR";
            this.label_actual_QR.Size = new System.Drawing.Size(133, 30);
            this.label_actual_QR.TabIndex = 4;
            this.label_actual_QR.Text = "Actual QR";
            // 
            // QR_container
            // 
            this.QR_container.AutoSize = true;
            this.QR_container.Location = new System.Drawing.Point(28, 305);
            this.QR_container.Name = "QR_container";
            this.QR_container.Size = new System.Drawing.Size(196, 199);
            this.QR_container.TabIndex = 1;
            this.QR_container.Paint += new System.Windows.Forms.PaintEventHandler(this.QR_container_Paint);
            // 
            // nameStoreLabel
            // 
            this.nameStoreLabel.AutoSize = true;
            this.nameStoreLabel.Font = new System.Drawing.Font("Mongolian Baiti", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameStoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.nameStoreLabel.Location = new System.Drawing.Point(24, 31);
            this.nameStoreLabel.Name = "nameStoreLabel";
            this.nameStoreLabel.Size = new System.Drawing.Size(178, 35);
            this.nameStoreLabel.TabIndex = 3;
            this.nameStoreLabel.Text = "Name store";
            // 
            // idStoreLabel
            // 
            this.idStoreLabel.AutoSize = true;
            this.idStoreLabel.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idStoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.idStoreLabel.Location = new System.Drawing.Point(24, 69);
            this.idStoreLabel.Name = "idStoreLabel";
            this.idStoreLabel.Size = new System.Drawing.Size(112, 31);
            this.idStoreLabel.TabIndex = 2;
            this.idStoreLabel.Text = "ID store";
            this.idStoreLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label3.Location = new System.Drawing.Point(363, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(440, 45);
            this.label3.TabIndex = 5;
            this.label3.Text = "New Products to Stock";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label4.Location = new System.Drawing.Point(367, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Product ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label5.Location = new System.Drawing.Point(556, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Quantity";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.numericUpDown1.Location = new System.Drawing.Point(560, 126);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 34);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.numericUpDown2.Location = new System.Drawing.Point(371, 126);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(183, 34);
            this.numericUpDown2.TabIndex = 8;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // Add_button
            // 
            this.Add_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(191)))), ((int)(((byte)(188)))));
            this.Add_button.FlatAppearance.BorderSize = 0;
            this.Add_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_button.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.Add_button.Location = new System.Drawing.Point(669, 126);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(116, 36);
            this.Add_button.TabIndex = 10;
            this.Add_button.Text = "Add";
            this.Add_button.UseVisualStyleBackColor = false;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // listToStock
            // 
            this.listToStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listToStock.AutoSize = true;
            this.listToStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.listToStock.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.listToStock.ColumnCount = 4;
            this.listToStock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.40816F));
            this.listToStock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.59184F));
            this.listToStock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.listToStock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.listToStock.Controls.Add(this.label8, 3, 0);
            this.listToStock.Controls.Add(this.label7, 2, 0);
            this.listToStock.Controls.Add(this.name_label, 1, 0);
            this.listToStock.Controls.Add(this.ID_table, 0, 0);
            this.listToStock.Location = new System.Drawing.Point(371, 235);
            this.listToStock.Name = "listToStock";
            this.listToStock.RowCount = 1;
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.listToStock.Size = new System.Drawing.Size(414, 36);
            this.listToStock.TabIndex = 11;
            this.listToStock.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label8.Location = new System.Drawing.Point(334, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "Amount";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label7.Location = new System.Drawing.Point(242, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "Price";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name_label
            // 
            this.name_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.name_label.Location = new System.Drawing.Point(70, 9);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(113, 18);
            this.name_label.TabIndex = 1;
            this.name_label.Text = "Product name";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ID_table
            // 
            this.ID_table.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ID_table.AutoSize = true;
            this.ID_table.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_table.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.ID_table.Location = new System.Drawing.Point(10, 9);
            this.ID_table.Name = "ID_table";
            this.ID_table.Size = new System.Drawing.Size(24, 18);
            this.ID_table.TabIndex = 0;
            this.ID_table.Text = "ID";
            this.ID_table.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ID_table.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label6.Location = new System.Drawing.Point(488, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "List to stock";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(893, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // save_button
            // 
            this.save_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(191)))), ((int)(((byte)(188)))));
            this.save_button.FlatAppearance.BorderSize = 0;
            this.save_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_button.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.save_button.Location = new System.Drawing.Point(770, 500);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(155, 49);
            this.save_button.TabIndex = 14;
            this.save_button.Text = "Next Store";
            this.save_button.UseVisualStyleBackColor = false;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(252)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listToStock);
            this.Controls.Add(this.Add_button);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.listToStock.ResumeLayout(false);
            this.listToStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label idStoreLabel;
        private System.Windows.Forms.Label nameStoreLabel;
        private System.Windows.Forms.Label label_actual_QR;
        private System.Windows.Forms.Panel QR_container;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.TableLayoutPanel listToStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ID_table;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label name_label;
    }
}