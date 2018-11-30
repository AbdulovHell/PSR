namespace MainModule
{
    partial class Oscilloscope
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DecrMaxXBtn = new System.Windows.Forms.Button();
            this.IncrMaxXBtn = new System.Windows.Forms.Button();
            this.DecrMinXBtn = new System.Windows.Forms.Button();
            this.IncrMinXBtn = new System.Windows.Forms.Button();
            this.DecrMinYBtn = new System.Windows.Forms.Button();
            this.IncrMaxYBtn = new System.Windows.Forms.Button();
            this.DecrMaxYBtn = new System.Windows.Forms.Button();
            this.IncrMinYBtn = new System.Windows.Forms.Button();
            this.SaveChartBtn = new System.Windows.Forms.Button();
            this.LessPeriodsBtn = new System.Windows.Forms.Button();
            this.MorePeriodsBtn = new System.Windows.Forms.Button();
            this.PeriodsText = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(842, 421);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(834, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Сигнал";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(834, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Амплитудный спектр";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(834, 395);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Фазовый спектр";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DecrMaxXBtn);
            this.splitContainer1.Panel1.Controls.Add(this.IncrMaxXBtn);
            this.splitContainer1.Panel1.Controls.Add(this.DecrMinXBtn);
            this.splitContainer1.Panel1.Controls.Add(this.IncrMinXBtn);
            this.splitContainer1.Panel1.Controls.Add(this.DecrMinYBtn);
            this.splitContainer1.Panel1.Controls.Add(this.IncrMaxYBtn);
            this.splitContainer1.Panel1.Controls.Add(this.DecrMaxYBtn);
            this.splitContainer1.Panel1.Controls.Add(this.IncrMinYBtn);
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Panel2.Controls.Add(this.SaveChartBtn);
            this.splitContainer1.Panel2.Controls.Add(this.LessPeriodsBtn);
            this.splitContainer1.Panel2.Controls.Add(this.MorePeriodsBtn);
            this.splitContainer1.Panel2.Controls.Add(this.PeriodsText);
            this.splitContainer1.Size = new System.Drawing.Size(842, 456);
            this.splitContainer1.SplitterDistance = 421;
            this.splitContainer1.TabIndex = 0;
            // 
            // DecrMaxXBtn
            // 
            this.DecrMaxXBtn.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecrMaxXBtn.Location = new System.Drawing.Point(790, 372);
            this.DecrMaxXBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DecrMaxXBtn.Name = "DecrMaxXBtn";
            this.DecrMaxXBtn.Size = new System.Drawing.Size(20, 20);
            this.DecrMaxXBtn.TabIndex = 0;
            this.DecrMaxXBtn.Text = "◄";
            this.DecrMaxXBtn.UseVisualStyleBackColor = true;
            this.DecrMaxXBtn.Click += new System.EventHandler(this.DecrMaxXBtn_Click);
            // 
            // IncrMaxXBtn
            // 
            this.IncrMaxXBtn.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IncrMaxXBtn.Location = new System.Drawing.Point(810, 372);
            this.IncrMaxXBtn.Margin = new System.Windows.Forms.Padding(0);
            this.IncrMaxXBtn.Name = "IncrMaxXBtn";
            this.IncrMaxXBtn.Size = new System.Drawing.Size(20, 20);
            this.IncrMaxXBtn.TabIndex = 0;
            this.IncrMaxXBtn.Text = "►";
            this.IncrMaxXBtn.UseVisualStyleBackColor = true;
            this.IncrMaxXBtn.Click += new System.EventHandler(this.IncrMaxXBtn_Click);
            // 
            // DecrMinXBtn
            // 
            this.DecrMinXBtn.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecrMinXBtn.Location = new System.Drawing.Point(47, 372);
            this.DecrMinXBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DecrMinXBtn.Name = "DecrMinXBtn";
            this.DecrMinXBtn.Size = new System.Drawing.Size(20, 20);
            this.DecrMinXBtn.TabIndex = 0;
            this.DecrMinXBtn.Text = "◄";
            this.DecrMinXBtn.UseVisualStyleBackColor = true;
            this.DecrMinXBtn.Click += new System.EventHandler(this.DecrMinXBtn_Click);
            // 
            // IncrMinXBtn
            // 
            this.IncrMinXBtn.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IncrMinXBtn.Location = new System.Drawing.Point(67, 372);
            this.IncrMinXBtn.Margin = new System.Windows.Forms.Padding(0);
            this.IncrMinXBtn.Name = "IncrMinXBtn";
            this.IncrMinXBtn.Size = new System.Drawing.Size(20, 20);
            this.IncrMinXBtn.TabIndex = 0;
            this.IncrMinXBtn.Text = "►";
            this.IncrMinXBtn.UseVisualStyleBackColor = true;
            this.IncrMinXBtn.Click += new System.EventHandler(this.IncrMinXBtn_Click);
            // 
            // DecrMinYBtn
            // 
            this.DecrMinYBtn.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecrMinYBtn.Location = new System.Drawing.Point(5, 349);
            this.DecrMinYBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DecrMinYBtn.Name = "DecrMinYBtn";
            this.DecrMinYBtn.Size = new System.Drawing.Size(20, 20);
            this.DecrMinYBtn.TabIndex = 0;
            this.DecrMinYBtn.Text = "▼";
            this.DecrMinYBtn.UseVisualStyleBackColor = true;
            this.DecrMinYBtn.Click += new System.EventHandler(this.DecrMinYBtn_Click);
            // 
            // IncrMaxYBtn
            // 
            this.IncrMaxYBtn.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IncrMaxYBtn.Location = new System.Drawing.Point(5, 25);
            this.IncrMaxYBtn.Margin = new System.Windows.Forms.Padding(0);
            this.IncrMaxYBtn.Name = "IncrMaxYBtn";
            this.IncrMaxYBtn.Size = new System.Drawing.Size(20, 20);
            this.IncrMaxYBtn.TabIndex = 0;
            this.IncrMaxYBtn.Text = "▲";
            this.IncrMaxYBtn.UseVisualStyleBackColor = true;
            this.IncrMaxYBtn.Click += new System.EventHandler(this.IncrMaxYBtn_Click);
            // 
            // DecrMaxYBtn
            // 
            this.DecrMaxYBtn.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecrMaxYBtn.Location = new System.Drawing.Point(5, 45);
            this.DecrMaxYBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DecrMaxYBtn.Name = "DecrMaxYBtn";
            this.DecrMaxYBtn.Size = new System.Drawing.Size(20, 20);
            this.DecrMaxYBtn.TabIndex = 0;
            this.DecrMaxYBtn.Text = "▼";
            this.DecrMaxYBtn.UseVisualStyleBackColor = true;
            this.DecrMaxYBtn.Click += new System.EventHandler(this.DecrMaxYBtn_Click);
            // 
            // IncrMinYBtn
            // 
            this.IncrMinYBtn.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IncrMinYBtn.Location = new System.Drawing.Point(5, 329);
            this.IncrMinYBtn.Margin = new System.Windows.Forms.Padding(0);
            this.IncrMinYBtn.Name = "IncrMinYBtn";
            this.IncrMinYBtn.Size = new System.Drawing.Size(20, 20);
            this.IncrMinYBtn.TabIndex = 0;
            this.IncrMinYBtn.Text = "▲";
            this.IncrMinYBtn.UseVisualStyleBackColor = true;
            this.IncrMinYBtn.Click += new System.EventHandler(this.IncrMinYBtn_Click);
            // 
            // SaveChartBtn
            // 
            this.SaveChartBtn.BackColor = System.Drawing.Color.White;
            this.SaveChartBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.SaveChartBtn.Location = new System.Drawing.Point(726, 0);
            this.SaveChartBtn.Name = "SaveChartBtn";
            this.SaveChartBtn.Size = new System.Drawing.Size(116, 31);
            this.SaveChartBtn.TabIndex = 2;
            this.SaveChartBtn.Text = "Сохранить в файл";
            this.SaveChartBtn.UseVisualStyleBackColor = false;
            this.SaveChartBtn.Click += new System.EventHandler(this.SaveChartBtn_Click);
            // 
            // LessPeriodsBtn
            // 
            this.LessPeriodsBtn.BackColor = System.Drawing.Color.Gainsboro;
            this.LessPeriodsBtn.Font = new System.Drawing.Font("Arial", 7F);
            this.LessPeriodsBtn.Location = new System.Drawing.Point(4, 5);
            this.LessPeriodsBtn.Name = "LessPeriodsBtn";
            this.LessPeriodsBtn.Size = new System.Drawing.Size(20, 20);
            this.LessPeriodsBtn.TabIndex = 1;
            this.LessPeriodsBtn.Text = "◄";
            this.LessPeriodsBtn.UseVisualStyleBackColor = false;
            this.LessPeriodsBtn.Click += new System.EventHandler(this.LessPeriodsBtn_Click);
            // 
            // MorePeriodsBtn
            // 
            this.MorePeriodsBtn.BackColor = System.Drawing.Color.Gainsboro;
            this.MorePeriodsBtn.Font = new System.Drawing.Font("Arial", 7F);
            this.MorePeriodsBtn.Location = new System.Drawing.Point(75, 5);
            this.MorePeriodsBtn.Name = "MorePeriodsBtn";
            this.MorePeriodsBtn.Size = new System.Drawing.Size(20, 20);
            this.MorePeriodsBtn.TabIndex = 1;
            this.MorePeriodsBtn.Text = "►";
            this.MorePeriodsBtn.UseVisualStyleBackColor = false;
            this.MorePeriodsBtn.Click += new System.EventHandler(this.MorePeriodsBtn_Click);
            // 
            // PeriodsText
            // 
            this.PeriodsText.BackColor = System.Drawing.Color.White;
            this.PeriodsText.Location = new System.Drawing.Point(30, 5);
            this.PeriodsText.Name = "PeriodsText";
            this.PeriodsText.ReadOnly = true;
            this.PeriodsText.ShortcutsEnabled = false;
            this.PeriodsText.Size = new System.Drawing.Size(39, 20);
            this.PeriodsText.TabIndex = 0;
            this.PeriodsText.Text = "1";
            this.PeriodsText.WordWrap = false;
            // 
            // Oscilloscope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 456);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Oscilloscope";
            this.Text = "Oscilloscope";
            this.Resize += new System.EventHandler(this.Oscilloscope_ResizeEnd);
            this.tabControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button LessPeriodsBtn;
        private System.Windows.Forms.Button MorePeriodsBtn;
        private System.Windows.Forms.TextBox PeriodsText;
        private System.Windows.Forms.Button SaveChartBtn;
        private System.Windows.Forms.Button DecrMaxXBtn;
        private System.Windows.Forms.Button IncrMaxXBtn;
        private System.Windows.Forms.Button DecrMinXBtn;
        private System.Windows.Forms.Button IncrMaxYBtn;
        private System.Windows.Forms.Button IncrMinYBtn;
        private System.Windows.Forms.Button IncrMinXBtn;
        private System.Windows.Forms.Button DecrMaxYBtn;
        private System.Windows.Forms.Button DecrMinYBtn;
    }
}