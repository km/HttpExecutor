using System.IO;
using System.Diagnostics;
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
            try
            {
                RequestParser rp = new RequestParser(richTextBox1.Text);
                rp.response(rp.parse());
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            catch (Exception x)
            {
                MessageBox.Show("Invalid Request");
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.Directory.CreateDirectory(@"Responses");
                var file = File.CreateText(@"Responses\" + DateTime.Now.ToFileTime() + ".txt");
                file.Write(RequestParser.sResponse);
                file.Flush();
                file.Close();
                MessageBox.Show("Successfully saved response!");
            }
            catch (Exception a)
            {

                MessageBox.Show(a.Message);
            }
            
         
        }
    }
}