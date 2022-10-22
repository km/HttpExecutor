using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpExecutor
{
    public partial class Form2 : Form
    {
        private Response r = new Response();
        public Form2()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = RequestParser.sResponse;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var file = File.CreateText(@"Responses\" + DateTime.Now.ToFileTime() + ".txt");
            file.Write(richTextBox1.Text);
            file.Flush();
            file.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(r.content());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(r.headers());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(r.statusCode().ToString());
        }
    }
}
