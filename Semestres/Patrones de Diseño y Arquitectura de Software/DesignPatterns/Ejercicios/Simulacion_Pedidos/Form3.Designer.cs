
namespace Simulacion_Pedidos
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datagridLabel = new System.Windows.Forms.Label();
            this.bunifuDataGridView1 = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.events = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datagrid = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.textfile = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.textbox = new Bunifu.UI.WinForms.BunifuCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(887, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label2.Location = new System.Drawing.Point(373, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 50);
            this.label2.TabIndex = 15;
            this.label2.Text = "Report";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(191)))), ((int)(((byte)(188)))));
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Location = new System.Drawing.Point(534, 277);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(264, 248);
            this.textBox1.TabIndex = 16;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.label1.Location = new System.Drawing.Point(601, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 30);
            this.label1.TabIndex = 17;
            this.label1.Text = "TextBox";
            // 
            // datagridLabel
            // 
            this.datagridLabel.AutoSize = true;
            this.datagridLabel.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagridLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.datagridLabel.Location = new System.Drawing.Point(152, 233);
            this.datagridLabel.Name = "datagridLabel";
            this.datagridLabel.Size = new System.Drawing.Size(124, 30);
            this.datagridLabel.TabIndex = 18;
            this.datagridLabel.Text = "DataGrid";
            this.datagridLabel.Click += new System.EventHandler(this.datagridLabel_Click);
            // 
            // bunifuDataGridView1
            // 
            this.bunifuDataGridView1.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bunifuDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(252)))), ((int)(((byte)(248)))));
            this.bunifuDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.bunifuDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuDataGridView1.ColumnHeadersHeight = 40;
            this.bunifuDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.events,
            this.time});
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.BackColor = System.Drawing.Color.Teal;
            this.bunifuDataGridView1.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Teal;
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.Name = null;
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.bunifuDataGridView1.EnableHeadersVisualStyles = false;
            this.bunifuDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.bunifuDataGridView1.HeaderBackColor = System.Drawing.Color.Teal;
            this.bunifuDataGridView1.HeaderBgColor = System.Drawing.Color.Empty;
            this.bunifuDataGridView1.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.Location = new System.Drawing.Point(88, 277);
            this.bunifuDataGridView1.Name = "bunifuDataGridView1";
            this.bunifuDataGridView1.RowHeadersVisible = false;
            this.bunifuDataGridView1.RowHeadersWidth = 51;
            this.bunifuDataGridView1.RowTemplate.Height = 40;
            this.bunifuDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuDataGridView1.Size = new System.Drawing.Size(264, 248);
            this.bunifuDataGridView1.TabIndex = 19;
            this.bunifuDataGridView1.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Teal;
            this.bunifuDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuDataGridView1_CellContentClick);
            // 
            // events
            // 
            this.events.HeaderText = "Events";
            this.events.MinimumWidth = 6;
            this.events.Name = "events";
            // 
            // time
            // 
            this.time.HeaderText = "Time";
            this.time.MinimumWidth = 6;
            this.time.Name = "time";
            // 
            // datagrid
            // 
            this.datagrid.AllowBindingControlAnimation = true;
            this.datagrid.AllowBindingControlColorChanges = false;
            this.datagrid.AllowBindingControlLocation = true;
            this.datagrid.AllowCheckBoxAnimation = false;
            this.datagrid.AllowCheckmarkAnimation = true;
            this.datagrid.AllowOnHoverStates = true;
            this.datagrid.AutoCheck = true;
            this.datagrid.BackColor = System.Drawing.Color.Transparent;
            this.datagrid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("datagrid.BackgroundImage")));
            this.datagrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.datagrid.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.datagrid.BorderRadius = 12;
            this.datagrid.Checked = true;
            this.datagrid.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
            this.datagrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.datagrid.CustomCheckmarkImage = null;
            this.datagrid.Location = new System.Drawing.Point(284, 140);
            this.datagrid.MinimumSize = new System.Drawing.Size(17, 17);
            this.datagrid.Name = "datagrid";
            this.datagrid.OnCheck.BorderColor = System.Drawing.Color.DodgerBlue;
            this.datagrid.OnCheck.BorderRadius = 12;
            this.datagrid.OnCheck.BorderThickness = 2;
            this.datagrid.OnCheck.CheckBoxColor = System.Drawing.Color.DodgerBlue;
            this.datagrid.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.datagrid.OnCheck.CheckmarkThickness = 2;
            this.datagrid.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.datagrid.OnDisable.BorderRadius = 12;
            this.datagrid.OnDisable.BorderThickness = 2;
            this.datagrid.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.datagrid.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.datagrid.OnDisable.CheckmarkThickness = 2;
            this.datagrid.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.datagrid.OnHoverChecked.BorderRadius = 12;
            this.datagrid.OnHoverChecked.BorderThickness = 2;
            this.datagrid.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.datagrid.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.datagrid.OnHoverChecked.CheckmarkThickness = 2;
            this.datagrid.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.datagrid.OnHoverUnchecked.BorderRadius = 12;
            this.datagrid.OnHoverUnchecked.BorderThickness = 1;
            this.datagrid.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.datagrid.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.datagrid.OnUncheck.BorderRadius = 12;
            this.datagrid.OnUncheck.BorderThickness = 1;
            this.datagrid.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.datagrid.Size = new System.Drawing.Size(21, 21);
            this.datagrid.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.datagrid.TabIndex = 20;
            this.datagrid.ThreeState = false;
            this.datagrid.ToolTipText = null;
            this.datagrid.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.bunifuCheckBox1_CheckedChanged);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.bunifuLabel1.Location = new System.Drawing.Point(195, 140);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(83, 21);
            this.bunifuLabel1.TabIndex = 21;
            this.bunifuLabel1.Text = "DataGrid";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AllowParentOverrides = false;
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.bunifuLabel2.Location = new System.Drawing.Point(398, 140);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(83, 21);
            this.bunifuLabel2.TabIndex = 23;
            this.bunifuLabel2.Text = "Text File";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // textfile
            // 
            this.textfile.AllowBindingControlAnimation = true;
            this.textfile.AllowBindingControlColorChanges = false;
            this.textfile.AllowBindingControlLocation = true;
            this.textfile.AllowCheckBoxAnimation = false;
            this.textfile.AllowCheckmarkAnimation = true;
            this.textfile.AllowOnHoverStates = true;
            this.textfile.AutoCheck = true;
            this.textfile.BackColor = System.Drawing.Color.Transparent;
            this.textfile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("textfile.BackgroundImage")));
            this.textfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.textfile.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.textfile.BorderRadius = 12;
            this.textfile.Checked = true;
            this.textfile.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
            this.textfile.Cursor = System.Windows.Forms.Cursors.Default;
            this.textfile.CustomCheckmarkImage = null;
            this.textfile.Location = new System.Drawing.Point(487, 140);
            this.textfile.MinimumSize = new System.Drawing.Size(17, 17);
            this.textfile.Name = "textfile";
            this.textfile.OnCheck.BorderColor = System.Drawing.Color.DodgerBlue;
            this.textfile.OnCheck.BorderRadius = 12;
            this.textfile.OnCheck.BorderThickness = 2;
            this.textfile.OnCheck.CheckBoxColor = System.Drawing.Color.DodgerBlue;
            this.textfile.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.textfile.OnCheck.CheckmarkThickness = 2;
            this.textfile.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.textfile.OnDisable.BorderRadius = 12;
            this.textfile.OnDisable.BorderThickness = 2;
            this.textfile.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.textfile.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.textfile.OnDisable.CheckmarkThickness = 2;
            this.textfile.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.textfile.OnHoverChecked.BorderRadius = 12;
            this.textfile.OnHoverChecked.BorderThickness = 2;
            this.textfile.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.textfile.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.textfile.OnHoverChecked.CheckmarkThickness = 2;
            this.textfile.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.textfile.OnHoverUnchecked.BorderRadius = 12;
            this.textfile.OnHoverUnchecked.BorderThickness = 1;
            this.textfile.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.textfile.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.textfile.OnUncheck.BorderRadius = 12;
            this.textfile.OnUncheck.BorderThickness = 1;
            this.textfile.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.textfile.Size = new System.Drawing.Size(21, 21);
            this.textfile.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.textfile.TabIndex = 22;
            this.textfile.ThreeState = false;
            this.textfile.ToolTipText = null;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.CursorType = null;
            this.bunifuLabel3.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(95)))), ((int)(((byte)(93)))));
            this.bunifuLabel3.Location = new System.Drawing.Point(590, 140);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(77, 21);
            this.bunifuLabel3.TabIndex = 25;
            this.bunifuLabel3.Text = "TextBox";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // textbox
            // 
            this.textbox.AllowBindingControlAnimation = true;
            this.textbox.AllowBindingControlColorChanges = false;
            this.textbox.AllowBindingControlLocation = true;
            this.textbox.AllowCheckBoxAnimation = false;
            this.textbox.AllowCheckmarkAnimation = true;
            this.textbox.AllowOnHoverStates = true;
            this.textbox.AutoCheck = true;
            this.textbox.BackColor = System.Drawing.Color.Transparent;
            this.textbox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("textbox.BackgroundImage")));
            this.textbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.textbox.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.textbox.BorderRadius = 12;
            this.textbox.Checked = true;
            this.textbox.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
            this.textbox.Cursor = System.Windows.Forms.Cursors.Default;
            this.textbox.CustomCheckmarkImage = null;
            this.textbox.Location = new System.Drawing.Point(679, 140);
            this.textbox.MinimumSize = new System.Drawing.Size(17, 17);
            this.textbox.Name = "textbox";
            this.textbox.OnCheck.BorderColor = System.Drawing.Color.DodgerBlue;
            this.textbox.OnCheck.BorderRadius = 12;
            this.textbox.OnCheck.BorderThickness = 2;
            this.textbox.OnCheck.CheckBoxColor = System.Drawing.Color.DodgerBlue;
            this.textbox.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.textbox.OnCheck.CheckmarkThickness = 2;
            this.textbox.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.textbox.OnDisable.BorderRadius = 12;
            this.textbox.OnDisable.BorderThickness = 2;
            this.textbox.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.textbox.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.textbox.OnDisable.CheckmarkThickness = 2;
            this.textbox.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.textbox.OnHoverChecked.BorderRadius = 12;
            this.textbox.OnHoverChecked.BorderThickness = 2;
            this.textbox.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.textbox.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.textbox.OnHoverChecked.CheckmarkThickness = 2;
            this.textbox.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.textbox.OnHoverUnchecked.BorderRadius = 12;
            this.textbox.OnHoverUnchecked.BorderThickness = 1;
            this.textbox.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.textbox.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.textbox.OnUncheck.BorderRadius = 12;
            this.textbox.OnUncheck.BorderThickness = 1;
            this.textbox.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.textbox.Size = new System.Drawing.Size(21, 21);
            this.textbox.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.textbox.TabIndex = 24;
            this.textbox.ThreeState = false;
            this.textbox.ToolTipText = null;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(252)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.bunifuLabel3);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.textfile);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.bunifuDataGridView1);
            this.Controls.Add(this.datagridLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label datagridLabel;
        public Bunifu.UI.WinForms.BunifuDataGridView bunifuDataGridView1;
        private Bunifu.UI.WinForms.BunifuCheckBox datagrid;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuCheckBox textfile;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuCheckBox textbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn events;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
    }
}