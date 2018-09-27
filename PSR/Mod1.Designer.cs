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
            this.OscAtG2 = new System.Windows.Forms.Button();
            this.OscAtG1 = new System.Windows.Forms.Button();
            this.OscAtEnd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OscBtn
            // 
            this.OscBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.OscBtn.Location = new System.Drawing.Point(453, 184);
            this.OscBtn.Name = "OscBtn";
            this.OscBtn.Size = new System.Drawing.Size(130, 85);
            this.OscBtn.TabIndex = 1;
            this.OscBtn.Text = "Анализатор спектра";
            this.OscBtn.UseVisualStyleBackColor = true;
            this.OscBtn.Click += new System.EventHandler(this.OscBtn_Click);
            // 
            // G1SettingsBtn
            // 
            this.G1SettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.G1SettingsBtn.Location = new System.Drawing.Point(240, 61);
            this.G1SettingsBtn.Name = "G1SettingsBtn";
            this.G1SettingsBtn.Size = new System.Drawing.Size(135, 74);
            this.G1SettingsBtn.TabIndex = 5;
            this.G1SettingsBtn.Text = "Генератор несущего колебания";
            this.G1SettingsBtn.UseVisualStyleBackColor = true;
            // 
            // G2SettingsBtn
            // 
            this.G2SettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.G2SettingsBtn.Location = new System.Drawing.Point(240, 314);
            this.G2SettingsBtn.Name = "G2SettingsBtn";
            this.G2SettingsBtn.Size = new System.Drawing.Size(135, 74);
            this.G2SettingsBtn.TabIndex = 6;
            this.G2SettingsBtn.Text = "Генератор модулирующего колебания";
            this.G2SettingsBtn.UseVisualStyleBackColor = true;
            // 
            // OscAtG2
            // 
            this.OscAtG2.Image = global::MainModule.Resources.graph;
            this.OscAtG2.Location = new System.Drawing.Point(327, 273);
            this.OscAtG2.Name = "OscAtG2";
            this.OscAtG2.Size = new System.Drawing.Size(23, 23);
            this.OscAtG2.TabIndex = 4;
            this.OscAtG2.UseVisualStyleBackColor = true;
            this.OscAtG2.Click += new System.EventHandler(this.OscAtG2_Click);
            // 
            // OscAtG1
            // 
            this.OscAtG1.Image = global::MainModule.Resources.graph;
            this.OscAtG1.Location = new System.Drawing.Point(327, 150);
            this.OscAtG1.Name = "OscAtG1";
            this.OscAtG1.Size = new System.Drawing.Size(23, 23);
            this.OscAtG1.TabIndex = 3;
            this.OscAtG1.UseVisualStyleBackColor = true;
            this.OscAtG1.Click += new System.EventHandler(this.OscAtG1_Click);
            // 
            // OscAtEnd
            // 
            this.OscAtEnd.Image = global::MainModule.Resources.graph;
            this.OscAtEnd.Location = new System.Drawing.Point(383, 184);
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
            // Mod1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
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
    }
}
