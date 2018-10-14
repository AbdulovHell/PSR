using System;
using System.Drawing;
using System.Windows.Forms;

namespace MainModule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void CurSchemeToFileBtn_Click(object sender, EventArgs e)
        {
            var rect = tabControl1.TabPages[tabControl1.SelectedIndex].ClientRectangle;
            var pos = PointToScreen(rect.Location);
            //Text = $"x:{rect.X} y:{rect.Y} h:{rect.Height} w:{rect.Width}";
            Bitmap scr = new Bitmap(rect.Width, rect.Height);
            Graphics graphics = Graphics.FromImage(scr as Image);
            graphics.CopyFromScreen(pos.X+2, pos.Y+50, 0, 0, scr.Size);

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp";
            fileDialog.CheckPathExists = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                scr.Save(fileDialog.FileName);
            }
        }

    }
}
