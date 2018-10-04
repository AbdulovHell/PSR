namespace MainModule
{
    partial class HarmonicSettings
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.HarmonicNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Amplitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaPhase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SinTemplateBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MeasUnitsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HzMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HarmonicNum,
            this.Status,
            this.Amplitude,
            this.Freq,
            this.StaPhase});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(504, 302);
            this.dataGridView1.TabIndex = 0;
            // 
            // HarmonicNum
            // 
            this.HarmonicNum.Frozen = true;
            this.HarmonicNum.HeaderText = "Номер гармоники";
            this.HarmonicNum.Name = "HarmonicNum";
            this.HarmonicNum.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.Frozen = true;
            this.Status.HeaderText = "Статус";
            this.Status.Name = "Status";
            // 
            // Amplitude
            // 
            this.Amplitude.Frozen = true;
            this.Amplitude.HeaderText = "Амплитуда, В";
            this.Amplitude.Name = "Amplitude";
            // 
            // Freq
            // 
            this.Freq.Frozen = true;
            this.Freq.HeaderText = "Частота, Гц";
            this.Freq.Name = "Freq";
            // 
            // StaPhase
            // 
            this.StaPhase.Frozen = true;
            this.StaPhase.HeaderText = "Начальная фаза, град";
            this.StaPhase.Name = "StaPhase";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.SinTemplateBtn);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(504, 367);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.TabIndex = 1;
            // 
            // SinTemplateBtn
            // 
            this.SinTemplateBtn.Location = new System.Drawing.Point(3, 3);
            this.SinTemplateBtn.Name = "SinTemplateBtn";
            this.SinTemplateBtn.Size = new System.Drawing.Size(98, 30);
            this.SinTemplateBtn.TabIndex = 1;
            this.SinTemplateBtn.Text = "Пилообразный";
            this.SinTemplateBtn.UseVisualStyleBackColor = true;
            this.SinTemplateBtn.Click += new System.EventHandler(this.SinTemplateBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MeasUnitsMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(504, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MeasUnitsMenu
            // 
            this.MeasUnitsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RadMenuItem,
            this.HzMenuItem});
            this.MeasUnitsMenu.Name = "MeasUnitsMenu";
            this.MeasUnitsMenu.Size = new System.Drawing.Size(130, 20);
            this.MeasUnitsMenu.Text = "Еденицы измерения";
            // 
            // RadMenuItem
            // 
            this.RadMenuItem.Checked = true;
            this.RadMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RadMenuItem.Name = "RadMenuItem";
            this.RadMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RadMenuItem.Text = "рад/с ; радианы";
            this.RadMenuItem.Click += new System.EventHandler(this.RadMenuItem_Click);
            // 
            // HzMenuItem
            // 
            this.HzMenuItem.Name = "HzMenuItem";
            this.HzMenuItem.Size = new System.Drawing.Size(180, 22);
            this.HzMenuItem.Text = "Гц ; градусы";
            this.HzMenuItem.Click += new System.EventHandler(this.HzMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(107, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Прямоугольный";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(341, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 30);
            this.button3.TabIndex = 3;
            this.button3.Text = "Случайный";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // HarmonicSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 367);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HarmonicSettings";
            this.Text = "HarmonicSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HarmonicSettings_FormClosing);
            this.Load += new System.EventHandler(this.HarmonicSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button SinTemplateBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HarmonicNum;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amplitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freq;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaPhase;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MeasUnitsMenu;
        private System.Windows.Forms.ToolStripMenuItem RadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HzMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}