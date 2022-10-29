using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VDS.RDF.Query;

namespace Sample_Ex
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String URI = textBox2.Text;
            var request = (HttpWebRequest)WebRequest.Create(URI + " ?x ?y ?Concept" +
                " WHERE {?x ?y ?Concept}Limit 100");
            request.UserAgent = ".Net Client";
            var response = (HttpWebResponse)request.GetResponse();
            string responseString;
            textBox1.Text = " ";
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    responseString = reader.ReadToEnd();
                    textBox1.Text += responseString;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
            SparqlResultSet results = endpoint.QueryWithResultSet("SELECT DISTINCT ?Concept WHERE {[] a ?Concept}Limit 100");
            foreach (SparqlResult result in results)
            {
                textBox1.Text += result.ToString() + Environment.NewLine;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String URI = textBox2.Text;
            var request = (HttpWebRequest)WebRequest.Create(URI + "?x ?y ?Concept" +
               " WHERE {?x ?y ?Concept}Limit 100");
            request.UserAgent = ".Net Client";
            var response = (HttpWebResponse)request.GetResponse();
            string responseString;
            textBox1.Text = " ";
            int i = 0;
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    responseString = reader.ReadToEnd();
                    responseString = responseString.Replace("\t", "").Replace("\n", "");
                    string[] name = Regex.Matches(responseString, @"<res.*?</res").Cast<Match>().Select(m => m.Value).ToArray();
                    textBox1.Text += name[i];
                    i++;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainForm mf = new mainForm();
            mf.Show();
            this.Hide();
        }
    }
}
