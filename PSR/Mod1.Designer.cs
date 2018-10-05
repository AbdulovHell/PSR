namespace MainModule
{
    partial class Mod1
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OscBtn = new System.Windows.Forms.Button();
            this.G1SettingsBtn = new System.Windows.Forms.Button();
            this.G2SettingsBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.V0Edit = new System.Windows.Forms.TextBox();
            this.KEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OscAtG2 = new System.Windows.Forms.Button();
            this.OscAtG1 = new System.Windows.Forms.Button();
            this.OscAtEnd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HarmonicCountsLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OscBtn
            // 
            this.OscBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.OscBtn.Location = new System.Drawing.Point(453, 157);
            this.OscBtn.Name = "OscBtn";
            this.OscBtn.Size = new System.Drawing.Size(130, 85);
            this.OscBtn.TabIndex = 1;
            this.OscBtn.Text = "Анализатор спектра";
            this.OscBtn.UseVisualStyleBackColor = true;
            this.OscBtn.Click += new System.EventHandler(this.OscBtn_Click);
            // 
            // G1SettingsBtn
            // 
            this.G1SettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.G1SettingsBtn.Location = new System.Drawing.Point(240, 34);
            this.G1SettingsBtn.Name = "G1SettingsBtn";
            this.G1SettingsBtn.Size = new System.Drawing.Size(135, 74);
            this.G1SettingsBtn.TabIndex = 5;
            this.G1SettingsBtn.Text = "ГВЧ";
            this.G1SettingsBtn.UseVisualStyleBackColor = true;
            this.G1SettingsBtn.Click += new System.EventHandler(this.G1SettingsBtn_Click);
            // 
            // G2SettingsBtn
            // 
            this.G2SettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.G2SettingsBtn.Location = new System.Drawing.Point(240, 337);
            this.G2SettingsBtn.Name = "G2SettingsBtn";
            this.G2SettingsBtn.Size = new System.Drawing.Size(135, 74);
            this.G2SettingsBtn.TabIndex = 6;
            this.G2SettingsBtn.Text = "ГНЧ";
            this.G2SettingsBtn.UseVisualStyleBackColor = true;
            this.G2SettingsBtn.Click += new System.EventHandler(this.G2SettingsBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "V0, В";
            // 
            // V0Edit
            // 
            this.V0Edit.Location = new System.Drawing.Point(225, 192);
            this.V0Edit.Name = "V0Edit";
            this.V0Edit.Size = new System.Drawing.Size(44, 20);
            this.V0Edit.TabIndex = 8;
            this.V0Edit.Text = "1";
            // 
            // KEdit
            // 
            this.KEdit.Location = new System.Drawing.Point(225, 255);
            this.KEdit.Name = "KEdit";
            this.KEdit.Size = new System.Drawing.Size(44, 20);
            this.KEdit.TabIndex = 9;
            this.KEdit.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "K";
            // 
            // OscAtG2
            // 
            this.OscAtG2.Image = global::MainModule.Resources.graph;
            this.OscAtG2.Location = new System.Drawing.Point(327, 297);
            this.OscAtG2.Name = "OscAtG2";
            this.OscAtG2.Size = new System.Drawing.Size(23, 23);
            this.OscAtG2.TabIndex = 4;
            this.OscAtG2.UseVisualStyleBackColor = true;
            this.OscAtG2.Click += new System.EventHandler(this.OscAtG2_Click);
            // 
            // OscAtG1
            // 
            this.OscAtG1.Image = global::MainModule.Resources.graph;
            this.OscAtG1.Location = new System.Drawing.Point(327, 123);
            this.OscAtG1.Name = "OscAtG1";
            this.OscAtG1.Size = new System.Drawing.Size(23, 23);
            this.OscAtG1.TabIndex = 3;
            this.OscAtG1.UseVisualStyleBackColor = true;
            this.OscAtG1.Click += new System.EventHandler(this.OscAtG1_Click);
            // 
            // OscAtEnd
            // 
            this.OscAtEnd.Image = global::MainModule.Resources.graph;
            this.OscAtEnd.Location = new System.Drawing.Point(383, 157);
            this.OscAtEnd.Name = "OscAtEnd";
            this.OscAtEnd.Size = new System.Drawing.Size(23, 23);
            this.OscAtEnd.TabIndex = 2;
            this.OscAtEnd.UseVisualStyleBackColor = true;
            this.OscAtEnd.Click += new System.EventHandler(this.OscAtEnd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::MainModule.Resources.AM1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // HarmonicCountsLbl
            // 
            this.HarmonicCountsLbl.AutoSize = true;
            this.HarmonicCountsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.HarmonicCountsLbl.Location = new System.Drawing.Point(381, 363);
            this.HarmonicCountsLbl.Name = "HarmonicCountsLbl";
            this.HarmonicCountsLbl.Size = new System.Drawing.Size(55, 24);
            this.HarmonicCountsLbl.TabIndex = 11;
            this.HarmonicCountsLbl.Text = "N = 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(385, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Частота = 0 Рад/с";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(385, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Амплитуда = 0 V";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(385, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Начальная фаза = 0 Рад";
            // 
            // Mod1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HarmonicCountsLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KEdit);
            this.Controls.Add(this.V0Edit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.G2SettingsBtn);
            this.Controls.Add(this.G1SettingsBtn);
            this.Controls.Add(this.OscAtG2);
            this.Controls.Add(this.OscAtG1);
            this.Controls.Add(this.OscAtEnd);
            this.Controls.Add(this.OscBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Mod1";
            this.Size = new System.Drawing.Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button OscBtn;
        private System.Windows.Forms.Button OscAtEnd;
        private System.Windows.Forms.Button OscAtG1;
        private System.Windows.Forms.Button OscAtG2;
        private System.Windows.Forms.Button G1SettingsBtn;
        private System.Windows.Forms.Button G2SettingsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox V0Edit;
        private System.Windows.Forms.TextBox KEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label HarmonicCountsLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
