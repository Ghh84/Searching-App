using System;
using System.Windows.Forms;
namespace Sample_Ex
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Tcp_Messaging f2 = new Tcp_Messaging();
            f2.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            HTTP_Web hw = new HTTP_Web();
            hw.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.Show();
            this.Hide();
        }

    }
}
