using System.Windows.Forms;

namespace ResourceManagement
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            button1.Visible = false;
            var c = new Controller(pictureBox1);
        }
    }
}
