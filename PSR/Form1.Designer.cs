namespace MainModule
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mod11 = new MainModule.Mod_AM();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mod_BM1 = new MainModule.Mod_BM();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurSchemeToFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сигналыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.амплитудныеСпектрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фазовыеСпектрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.еденицыИзмеренияПоУмолчаниюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetHzRadUnitsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SetRadianUnitsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EnableCursors = new System.Windows.Forms.ToolStripMenuItem();
            this.mod_SM1 = new MainModule.Mod_SM();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(805, 455);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mod11);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(797, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Амплитудная модуляция";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mod11
            // 
            this.mod11.AutoSize = true;
            this.mod11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mod11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mod11.Location = new System.Drawing.Point(3, 3);
            this.mod11.Name = "mod11";
            this.mod11.Size = new System.Drawing.Size(791, 423);
            this.mod11.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mod_BM1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(797, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Балансная модуляция";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mod_BM1
            // 
            this.mod_BM1.AutoSize = true;
            this.mod_BM1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mod_BM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mod_BM1.Location = new System.Drawing.Point(3, 3);
            this.mod_BM1.Name = "mod_BM1";
            this.mod_BM1.Size = new System.Drawing.Size(791, 423);
            this.mod_BM1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.mod_SM1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(797, 429);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Однополосная модуляция";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(797, 429);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Частотная модуляция";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(797, 429);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Фазовая модуляция";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 481);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(805, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel1.Text = "Статус";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.построитьВсеToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(805, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurSchemeToFileBtn});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // CurSchemeToFileBtn
            // 
            this.CurSchemeToFileBtn.Name = "CurSchemeToFileBtn";
            this.CurSchemeToFileBtn.ShortcutKeyDisplayString = "Ctrl + S";
            this.CurSchemeToFileBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.CurSchemeToFileBtn.Size = new System.Drawing.Size(322, 22);
            this.CurSchemeToFileBtn.Text = "Сохранить схему установки в файл...";
            this.CurSchemeToFileBtn.Click += new System.EventHandler(this.CurSchemeToFileBtn_Click);
            // 
            // построитьВсеToolStripMenuItem
            // 
            this.построитьВсеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сигналыToolStripMenuItem,
            this.амплитудныеСпектрыToolStripMenuItem,
            this.фазовыеСпектрыToolStripMenuItem});
            this.построитьВсеToolStripMenuItem.Name = "построитьВсеToolStripMenuItem";
            this.построитьВсеToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.построитьВсеToolStripMenuItem.Text = "Построить все";
            // 
            // сигналыToolStripMenuItem
            // 
            this.сигналыToolStripMenuItem.Name = "сигналыToolStripMenuItem";
            this.сигналыToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.сигналыToolStripMenuItem.Text = "Сигналы...";
            this.сигналыToolStripMenuItem.Click += new System.EventHandler(this.сигналыToolStripMenuItem_Click);
            // 
            // амплитудныеСпектрыToolStripMenuItem
            // 
            this.амплитудныеСпектрыToolStripMenuItem.Name = "амплитудныеСпектрыToolStripMenuItem";
            this.амплитудныеСпектрыToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.амплитудныеСпектрыToolStripMenuItem.Text = "Амплитудные спектры...";
            this.амплитудныеСпектрыToolStripMenuItem.Click += new System.EventHandler(this.амплитудныеСпектрыToolStripMenuItem_Click);
            // 
            // фазовыеСпектрыToolStripMenuItem
            // 
            this.фазовыеСпектрыToolStripMenuItem.Name = "фазовыеСпектрыToolStripMenuItem";
            this.фазовыеСпектрыToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.фазовыеСпектрыToolStripMenuItem.Text = "Фазовые спектры...";
            this.фазовыеСпектрыToolStripMenuItem.Click += new System.EventHandler(this.фазовыеСпектрыToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.еденицыИзмеренияПоУмолчаниюToolStripMenuItem,
            this.toolStripSeparator1,
            this.EnableCursors});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // еденицыИзмеренияПоУмолчаниюToolStripMenuItem
            // 
            this.еденицыИзмеренияПоУмолчаниюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetHzRadUnitsBtn,
            this.SetRadianUnitsBtn});
            this.еденицыИзмеренияПоУмолчаниюToolStripMenuItem.Name = "еденицыИзмеренияПоУмолчаниюToolStripMenuItem";
            this.еденицыИзмеренияПоУмолчаниюToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.еденицыИзмеренияПоУмолчаниюToolStripMenuItem.Text = "Еденицы измерения по умолчанию";
            // 
            // SetHzRadUnitsBtn
            // 
            this.SetHzRadUnitsBtn.Checked = true;
            this.SetHzRadUnitsBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SetHzRadUnitsBtn.Name = "SetHzRadUnitsBtn";
            this.SetHzRadUnitsBtn.ShowShortcutKeys = false;
            this.SetHzRadUnitsBtn.Size = new System.Drawing.Size(154, 22);
            this.SetHzRadUnitsBtn.Text = "Герцы, Градусы";
            this.SetHzRadUnitsBtn.Click += new System.EventHandler(this.SetHzRadUnitsBtn_Click);
            // 
            // SetRadianUnitsBtn
            // 
            this.SetRadianUnitsBtn.Name = "SetRadianUnitsBtn";
            this.SetRadianUnitsBtn.ShowShortcutKeys = false;
            this.SetRadianUnitsBtn.Size = new System.Drawing.Size(154, 22);
            this.SetRadianUnitsBtn.Text = "Радианы";
            this.SetRadianUnitsBtn.Click += new System.EventHandler(this.SetRadianUnitsBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(268, 6);
            // 
            // EnableCursors
            // 
            this.EnableCursors.Checked = true;
            this.EnableCursors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableCursors.Name = "EnableCursors";
            this.EnableCursors.ShowShortcutKeys = false;
            this.EnableCursors.Size = new System.Drawing.Size(271, 22);
            this.EnableCursors.Text = "Курсоры на графиках";
            this.EnableCursors.CheckedChanged += new System.EventHandler(this.EnableCursors_CheckedChanged);
            this.EnableCursors.Click += new System.EventHandler(this.EnableCursors_Click);
            // 
            // mod_SM1
            // 
            this.mod_SM1.AutoSize = true;
            this.mod_SM1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mod_SM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mod_SM1.Location = new System.Drawing.Point(3, 3);
            this.mod_SM1.Name = "mod_SM1";
            this.mod_SM1.Size = new System.Drawing.Size(791, 423);
            this.mod_SM1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 503);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Модуляции";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private MainModule.Mod_AM mod11;
        private Mod_BM mod_BM1;
        private System.Windows.Forms.ToolStripMenuItem CurSchemeToFileBtn;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem еденицыИзмеренияПоУмолчаниюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetHzRadUnitsBtn;
        private System.Windows.Forms.ToolStripMenuItem SetRadianUnitsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem EnableCursors;
        private System.Windows.Forms.ToolStripMenuItem построитьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сигналыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem амплитудныеСпектрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фазовыеСпектрыToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage5;
        private Mod_SM mod_SM1;
    }
}

