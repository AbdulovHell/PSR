using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule
{
    public partial class Form1 : Form
    {
        public static UnitsType unitsType = UnitsType.HzGrad;
        public static bool EnCursors=true;

        public Form1()
        {
            InitializeComponent();
        }

        public enum UnitsType
        {
            HzGrad,
            Radian
        }

        private void CurSchemeToFileBtn_Click(object sender, EventArgs e)
        {
            var rect = tabControl1.TabPages[tabControl1.SelectedIndex].ClientRectangle;
            var pos = PointToScreen(rect.Location);
            //Text = $"x:{rect.X} y:{rect.Y} h:{rect.Height} w:{rect.Width}";
            Bitmap scr = new Bitmap(rect.Width, rect.Height);
            Graphics graphics = Graphics.FromImage(scr as Image);
            graphics.CopyFromScreen(pos.X + 2, pos.Y + 50, 0, 0, scr.Size);

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp";
            fileDialog.CheckPathExists = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                scr.Save(fileDialog.FileName);
            }
        }

        private void SetRadianUnitsBtn_Click(object sender, EventArgs e)
        {
            if (SetRadianUnitsBtn.Checked) return;
            unitsType = UnitsType.Radian;
            SetRadianUnitsBtn.Checked = true;
            SetHzRadUnitsBtn.Checked = false;
        }

        private void SetHzRadUnitsBtn_Click(object sender, EventArgs e)
        {
            if (SetHzRadUnitsBtn.Checked) return;
            unitsType = UnitsType.HzGrad;
            SetHzRadUnitsBtn.Checked = true;
            SetRadianUnitsBtn.Checked = false;
        }

        private void EnableCursors_CheckedChanged(object sender, EventArgs e)
        {
            EnCursors = EnableCursors.Checked;
        }

        private void EnableCursors_Click(object sender, EventArgs e)
        {
            EnableCursors.Checked = !EnableCursors.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void сигналыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    mod11.BuildAll(0);
                    break;
                case 1:
                    mod_BM1.BuildAll(0);
                    break;
            }
        }

        private void амплитудныеСпектрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    mod11.BuildAll(1);
                    break;
                case 1:
                    mod_BM1.BuildAll(1);
                    break;
            }
        }

        private void фазовыеСпектрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    mod11.BuildAll(2);
                    break;
                case 1:
                    mod_BM1.BuildAll(2);
                    break;
            }
        }
    }
}
