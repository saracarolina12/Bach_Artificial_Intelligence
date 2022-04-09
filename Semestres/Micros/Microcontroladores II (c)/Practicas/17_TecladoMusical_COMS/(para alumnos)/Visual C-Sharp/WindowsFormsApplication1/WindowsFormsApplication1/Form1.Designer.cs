namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.sPuerto = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblDato = new System.Windows.Forms.Label();
            this.btnDo = new System.Windows.Forms.Button();
            this.btnRe = new System.Windows.Forms.Button();
            this.btnMi = new System.Windows.Forms.Button();
            this.btnFa = new System.Windows.Forms.Button();
            this.btnSol = new System.Windows.Forms.Button();
            this.btnLa = new System.Windows.Forms.Button();
            this.btnSi = new System.Windows.Forms.Button();
            this.lblErr = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sPuerto
            // 
            this.sPuerto.BaudRate = 4800;
            this.sPuerto.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.sPuerto_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "El último dato recibido por el puerto serial (en decimal) fue:";
            // 
            // lblDato
            // 
            this.lblDato.AutoSize = true;
            this.lblDato.Location = new System.Drawing.Point(528, 310);
            this.lblDato.Name = "lblDato";
            this.lblDato.Size = new System.Drawing.Size(35, 13);
            this.lblDato.TabIndex = 1;
            this.lblDato.Text = "label2";
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(30, 128);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(70, 70);
            this.btnDo.TabIndex = 2;
            this.btnDo.UseVisualStyleBackColor = true;
            // 
            // btnRe
            // 
            this.btnRe.Location = new System.Drawing.Point(106, 128);
            this.btnRe.Name = "btnRe";
            this.btnRe.Size = new System.Drawing.Size(70, 70);
            this.btnRe.TabIndex = 3;
            this.btnRe.UseVisualStyleBackColor = true;
            // 
            // btnMi
            // 
            this.btnMi.Location = new System.Drawing.Point(182, 128);
            this.btnMi.Name = "btnMi";
            this.btnMi.Size = new System.Drawing.Size(70, 70);
            this.btnMi.TabIndex = 4;
            this.btnMi.UseVisualStyleBackColor = true;
            // 
            // btnFa
            // 
            this.btnFa.Location = new System.Drawing.Point(258, 128);
            this.btnFa.Name = "btnFa";
            this.btnFa.Size = new System.Drawing.Size(70, 70);
            this.btnFa.TabIndex = 5;
            this.btnFa.UseVisualStyleBackColor = true;
            // 
            // btnSol
            // 
            this.btnSol.Location = new System.Drawing.Point(334, 128);
            this.btnSol.Name = "btnSol";
            this.btnSol.Size = new System.Drawing.Size(70, 70);
            this.btnSol.TabIndex = 6;
            this.btnSol.UseVisualStyleBackColor = true;
            // 
            // btnLa
            // 
            this.btnLa.Location = new System.Drawing.Point(410, 128);
            this.btnLa.Name = "btnLa";
            this.btnLa.Size = new System.Drawing.Size(70, 70);
            this.btnLa.TabIndex = 7;
            this.btnLa.UseVisualStyleBackColor = true;
            // 
            // btnSi
            // 
            this.btnSi.Location = new System.Drawing.Point(486, 128);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(70, 70);
            this.btnSi.TabIndex = 8;
            this.btnSi.UseVisualStyleBackColor = true;
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErr.Location = new System.Drawing.Point(24, 220);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(22, 31);
            this.lblErr.TabIndex = 9;
            this.lblErr.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Para iniciar un nuevo juego presiona el botón blanco en tu panel especial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Instrucciones:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(466, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Una vez que hayas iniciado, presiona en tu panel el mismo botón que se te muestra" +
    " en la pantalla";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "El sistema esperará hasta que presiones el botón correcto";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(24, 263);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(22, 31);
            this.lblTime.TabIndex = 14;
            this.lblTime.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(281, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "El último dato enviado por el puerto serial (en decimal) fue:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(528, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 347);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.btnSi);
            this.Controls.Add(this.btnLa);
            this.Controls.Add(this.btnSol);
            this.Controls.Add(this.btnFa);
            this.Controls.Add(this.btnMi);
            this.Controls.Add(this.btnRe);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.lblDato);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Examen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort sPuerto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDato;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Button btnRe;
        private System.Windows.Forms.Button btnMi;
        private System.Windows.Forms.Button btnFa;
        private System.Windows.Forms.Button btnSol;
        private System.Windows.Forms.Button btnLa;
        private System.Windows.Forms.Button btnSi;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

