using System.Windows.Forms;

namespace MainModule
{
    public partial class ErrorWindow : Form
    {
        int ErrorsCount = 0;

        public ErrorWindow()
        {
            InitializeComponent();
            label1.Text = "Возможные причины:";
        }

        public void AddError(string error)
        {
            label1.Text = label1.Text + $"\n{++ErrorsCount}. " + error;
        }
    }
}
