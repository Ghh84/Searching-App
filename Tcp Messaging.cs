using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Sample_Ex
{
    public partial class Tcp_Messaging : Form
    {
        public Tcp_Messaging()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // set the TcpListener on port 1336
                int port = int.Parse(textBox1.Text);
                TcpListener server = new TcpListener(IPAddress.Parse(textBox2.Text), port);
                // Start listening for client requests
                server.Start();
                // Buffer for reading data
                byte[] bytes = new byte[1024];
                string data;
                //Enter the listening loop
                while (true)
                {
                    label5.Text = "Waiting for a connection from client ... ";
                    MessageBox.Show("Please connect the TCP Client  ", "TCP Connection information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    label5.Text = "Connected!.....";
                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();
                    // Process the data sent by the client
                    if (textBox4.Text != "")
                    {
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(textBox4.Text);
                        // Send back a response.
                        textBox3.Text += "Sent:" + textBox4.Text + Environment.NewLine;
                        stream.Write(msg, 0, msg.Length);
                    }
                    else
                    {
                        MessageBox.Show("Insert message to be send...", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        client.Close(); break;
                    }
                    int i;
                    // Loop to receive all the data sent by the client.
                    i = stream.Read(bytes, 0, bytes.Length);
                    if (i != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        textBox3.Text += "Received:" + data + Environment.NewLine;
                        i = 0;
                    }
                    // Shutdown and end connection
                    textBox4.Text = " ";
                    client.Close();
                    server.Stop();
                    label5.Text = " ";
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm mf = new mainForm();
            mf.Show();
            this.Hide();
        }

    }
}
