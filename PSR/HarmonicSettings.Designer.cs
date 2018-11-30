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
            this.ResetBtn = new System.Windows.Forms.Button();
            this.TriangleTemplateBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SquareTemplateBtn = new System.Windows.Forms.Button();
            this.SawTemplateBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(504, 372);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ResetBtn);
            this.splitContainer1.Panel2.Controls.Add(this.TriangleTemplateBtn);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.SquareTemplateBtn);
            this.splitContainer1.Panel2.Controls.Add(this.SawTemplateBtn);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(504, 484);
            this.splitContainer1.SplitterDistance = 372;
            this.splitContainer1.TabIndex = 1;
            // 
            // ResetBtn
            // 
            this.ResetBtn.Location = new System.Drawing.Point(403, 75);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(98, 30);
            this.ResetBtn.TabIndex = 5;
            this.ResetBtn.Text = "Сброс";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // TriangleTemplateBtn
            // 
            this.TriangleTemplateBtn.Location = new System.Drawing.Point(3, 75);
            this.TriangleTemplateBtn.Name = "TriangleTemplateBtn";
            this.TriangleTemplateBtn.Size = new System.Drawing.Size(98, 30);
            this.TriangleTemplateBtn.TabIndex = 4;
            this.TriangleTemplateBtn.Text = "Треугольный";
            this.TriangleTemplateBtn.UseVisualStyleBackColor = true;
            this.TriangleTemplateBtn.Click += new System.EventHandler(this.TriangleTemplateBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(403, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 30);
            this.button3.TabIndex = 3;
            this.button3.Text = "Случайный";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SquareTemplateBtn
            // 
            this.SquareTemplateBtn.Location = new System.Drawing.Point(3, 39);
            this.SquareTemplateBtn.Name = "SquareTemplateBtn";
            this.SquareTemplateBtn.Size = new System.Drawing.Size(98, 30);
            this.SquareTemplateBtn.TabIndex = 2;
            this.SquareTemplateBtn.Text = "Прямоугольный";
            this.SquareTemplateBtn.UseVisualStyleBackColor = true;
            this.SquareTemplateBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // SawTemplateBtn
            // 
            this.SawTemplateBtn.Location = new System.Drawing.Point(3, 3);
            this.SawTemplateBtn.Name = "SawTemplateBtn";
            this.SawTemplateBtn.Size = new System.Drawing.Size(98, 30);
            this.SawTemplateBtn.TabIndex = 1;
            this.SawTemplateBtn.Text = "Пилообразный";
            this.SawTemplateBtn.UseVisualStyleBackColor = true;
            this.SawTemplateBtn.Click += new System.EventHandler(this.SinTemplateBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HarmonicSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 484);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HarmonicSettings";
            this.Text = "Параметры ГНЧ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HarmonicSettings_FormClosing);
            this.Load += new System.EventHandler(this.HarmonicSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button SawTemplateBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HarmonicNum;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amplitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freq;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaPhase;
        private System.Windows.Forms.Button SquareTemplateBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button TriangleTemplateBtn;
        private System.Windows.Forms.Button ResetBtn;
    }
}