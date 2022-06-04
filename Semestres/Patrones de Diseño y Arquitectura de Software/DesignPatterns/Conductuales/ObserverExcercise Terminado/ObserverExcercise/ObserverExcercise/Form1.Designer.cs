namespace ObserverExcercise
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
            this.store1label = new System.Windows.Forms.Label();
            this.store2label = new System.Windows.Forms.Label();
            this.suscribe1lbl = new System.Windows.Forms.Button();
            this.unsuscribe1lbl = new System.Windows.Forms.Button();
            this.unsuscribe2btn = new System.Windows.Forms.Button();
            this.suscribe2btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.exchangeRateTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.applyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // store1label
            // 
            this.store1label.AutoSize = true;
            this.store1label.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.store1label.Location = new System.Drawing.Point(96, 104);
            this.store1label.Name = "store1label";
            this.store1label.Size = new System.Drawing.Size(158, 39);
            this.store1label.TabIndex = 0;
            this.store1label.Text = "Tienda 1";
            this.store1label.Click += new System.EventHandler(this.store1label_Click);
            // 
            // store2label
            // 
            this.store2label.AutoSize = true;
            this.store2label.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.store2label.Location = new System.Drawing.Point(96, 260);
            this.store2label.Name = "store2label";
            this.store2label.Size = new System.Drawing.Size(158, 39);
            this.store2label.TabIndex = 1;
            this.store2label.Text = "Tienda 2";
            // 
            // suscribe1lbl
            // 
            this.suscribe1lbl.Location = new System.Drawing.Point(261, 70);
            this.suscribe1lbl.Name = "suscribe1lbl";
            this.suscribe1lbl.Size = new System.Drawing.Size(135, 41);
            this.suscribe1lbl.TabIndex = 2;
            this.suscribe1lbl.Text = "Suscribirse";
            this.suscribe1lbl.UseVisualStyleBackColor = true;
            this.suscribe1lbl.Click += new System.EventHandler(this.button1_Click);
            // 
            // unsuscribe1lbl
            // 
            this.unsuscribe1lbl.Location = new System.Drawing.Point(260, 130);
            this.unsuscribe1lbl.Name = "unsuscribe1lbl";
            this.unsuscribe1lbl.Size = new System.Drawing.Size(135, 41);
            this.unsuscribe1lbl.TabIndex = 3;
            this.unsuscribe1lbl.Text = "Desuscribirse";
            this.unsuscribe1lbl.UseVisualStyleBackColor = true;
            this.unsuscribe1lbl.Click += new System.EventHandler(this.unsuscribe1lbl_Click);
            // 
            // unsuscribe2btn
            // 
            this.unsuscribe2btn.Location = new System.Drawing.Point(260, 296);
            this.unsuscribe2btn.Name = "unsuscribe2btn";
            this.unsuscribe2btn.Size = new System.Drawing.Size(135, 41);
            this.unsuscribe2btn.TabIndex = 5;
            this.unsuscribe2btn.Text = "Desuscribirse";
            this.unsuscribe2btn.UseVisualStyleBackColor = true;
            this.unsuscribe2btn.Click += new System.EventHandler(this.unsuscribe2btn_Click);
            // 
            // suscribe2btn
            // 
            this.suscribe2btn.Location = new System.Drawing.Point(260, 229);
            this.suscribe2btn.Name = "suscribe2btn";
            this.suscribe2btn.Size = new System.Drawing.Size(135, 41);
            this.suscribe2btn.TabIndex = 4;
            this.suscribe2btn.Text = "Suscribirse";
            this.suscribe2btn.UseVisualStyleBackColor = true;
            this.suscribe2btn.Click += new System.EventHandler(this.suscribe2btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(487, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tipo de cambio";
            // 
            // exchangeRateTB
            // 
            this.exchangeRateTB.Location = new System.Drawing.Point(494, 192);
            this.exchangeRateTB.Name = "exchangeRateTB";
            this.exchangeRateTB.Size = new System.Drawing.Size(100, 22);
            this.exchangeRateTB.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(617, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "México";
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(542, 229);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(135, 41);
            this.applyBtn.TabIndex = 9;
            this.applyBtn.Text = "Aplicar";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exchangeRateTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unsuscribe2btn);
            this.Controls.Add(this.suscribe2btn);
            this.Controls.Add(this.unsuscribe1lbl);
            this.Controls.Add(this.suscribe1lbl);
            this.Controls.Add(this.store2label);
            this.Controls.Add(this.store1label);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label store1label;
        private System.Windows.Forms.Label store2label;
        private System.Windows.Forms.Button suscribe1lbl;
        private System.Windows.Forms.Button unsuscribe1lbl;
        private System.Windows.Forms.Button unsuscribe2btn;
        private System.Windows.Forms.Button suscribe2btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox exchangeRateTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button applyBtn;
    }
}

