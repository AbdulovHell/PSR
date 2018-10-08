namespace MainModule
{
    partial class SourceSet
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
            this.OkBtn = new System.Windows.Forms.Button();
            this.FreqEd = new System.Windows.Forms.TextBox();
            this.AmpEd = new System.Windows.Forms.TextBox();
            this.PhaseEd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.isRadChk = new System.Windows.Forms.RadioButton();
            this.isHzChk = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(125, 116);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(100, 23);
            this.OkBtn.TabIndex = 0;
            this.OkBtn.Text = "Сохранить";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // FreqEd
            // 
            this.FreqEd.Location = new System.Drawing.Point(125, 38);
            this.FreqEd.Name = "FreqEd";
            this.FreqEd.Size = new System.Drawing.Size(100, 20);
            this.FreqEd.TabIndex = 1;
            this.FreqEd.Text = "0";
            // 
            // AmpEd
            // 
            this.AmpEd.Location = new System.Drawing.Point(125, 64);
            this.AmpEd.Name = "AmpEd";
            this.AmpEd.Size = new System.Drawing.Size(100, 20);
            this.AmpEd.TabIndex = 2;
            this.AmpEd.Text = "1";
            // 
            // PhaseEd
            // 
            this.PhaseEd.Location = new System.Drawing.Point(125, 90);
            this.PhaseEd.Name = "PhaseEd";
            this.PhaseEd.Size = new System.Drawing.Size(100, 20);
            this.PhaseEd.TabIndex = 3;
            this.PhaseEd.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Частота, Гц";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Амплитуда, В";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(18, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Начальная";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(18, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "фаза, град";
            // 
            // isRadChk
            // 
            this.isRadChk.AutoSize = true;
            this.isRadChk.Checked = true;
            this.isRadChk.Location = new System.Drawing.Point(12, 12);
            this.isRadChk.Name = "isRadChk";
            this.isRadChk.Size = new System.Drawing.Size(108, 17);
            this.isRadChk.TabIndex = 8;
            this.isRadChk.TabStop = true;
            this.isRadChk.Text = "Рад/с ; радианы";
            this.isRadChk.UseVisualStyleBackColor = true;
            this.isRadChk.CheckedChanged += new System.EventHandler(this.isRadChk_CheckedChanged);
            // 
            // isHzChk
            // 
            this.isHzChk.AutoSize = true;
            this.isHzChk.Location = new System.Drawing.Point(132, 12);
            this.isHzChk.Name = "isHzChk";
            this.isHzChk.Size = new System.Drawing.Size(88, 17);
            this.isHzChk.TabIndex = 8;
            this.isHzChk.Text = "Гц ; градусы";
            this.isHzChk.UseVisualStyleBackColor = true;
            // 
            // SourceSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 145);
            this.Controls.Add(this.isHzChk);
            this.Controls.Add(this.isRadChk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PhaseEd);
            this.Controls.Add(this.AmpEd);
            this.Controls.Add(this.FreqEd);
            this.Controls.Add(this.OkBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SourceSet";
            this.Text = "Параметры ГВЧ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SourceSet_FormClosing);
            this.Load += new System.EventHandler(this.SourceSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.TextBox FreqEd;
        private System.Windows.Forms.TextBox AmpEd;
        private System.Windows.Forms.TextBox PhaseEd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton isRadChk;
        private System.Windows.Forms.RadioButton isHzChk;
    }
}