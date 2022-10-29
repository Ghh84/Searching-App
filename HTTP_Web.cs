using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample_Ex
{
    public partial class HTTP_Web : Form
    {
        public HTTP_Web()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string httpAdress = textBox2.Text;
            System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpAdress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content. 
            string[] name = Regex.Matches(responseFromServer, @"\<a href=""/ur.*?&amp").Cast<Match>().Select(m => m.Value.Replace("<a href=\"/url?q=", "").Replace("&amp", "")).ToArray();
            for (int i = 0; i < name.Length; i++)
            {
                textBox3.Text += name[i];
            }
            response.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm mf = new mainForm();
            mf.Show();
            this.Hide();
        }

        private void HTTP_Web_Load(object sender, EventArgs e)
        {

        }
    }
}
