using System.IO;
namespace HttpExecutor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.ShowDialog();
            try
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
            catch (Exception)
            {
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestParser rp = new RequestParser(richTextBox1.Text);
            rp.parse();
        }
    }
}