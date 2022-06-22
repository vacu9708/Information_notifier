using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Socket modules
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Information_notifier
{
    public partial class Form1 : Form
    {
        Socket client;
        Form2 form2;
        int obtained_information_location;
        bool monitoring;
        bool alarm_turned_on;
        public Form1()
        {
            InitializeComponent();
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            for (int port = 9000; port < 9999; port++)
            {
                try
                {
                    client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
                    MessageBox.Show("Bound to port: " + port);
                    break;
                }
                catch
                {
                    continue;
                }
            }
            this.form2 = new Form2();
            form2.Show();
            this.monitoring = false;
        }
        private void response_parser(string message, List<string> parsed_params)
        {
            int beginning_of_string = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ',')
                {// First distinguisher found
                    parsed_params.Add(message.Substring(beginning_of_string, i - beginning_of_string));
                    beginning_of_string = i + 1;
                }
                if (message[i] == '@') // Last index
                {
                    parsed_params.Add(message.Substring(beginning_of_string, i - beginning_of_string));
                    return;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Parse database
            client.Send(Encoding.UTF8.GetBytes("parse_database"));
            byte[] message = new byte[9999999];
            while (true) // If not the end of list
            {
                client.Receive(message, message.Length, SocketFlags.None);
                if (Encoding.UTF8.GetString(message)[0] == '$')
                    return;
                for (int i = 0; i < message.Length; i++) // Find the end of a line
                    if (Encoding.UTF8.GetString(message)[i] == '$')
                    {
                        webpage_list.Items.Add(Encoding.UTF8.GetString(message).Substring(0, i));
                        break;
                    }
                client.Send(new byte[1]); // Notify finishing the response
            }
        }
        private void start_monitoring_Click(object sender, EventArgs e)
        {
            if (monitoring)
            {
                MessageBox.Show("Already monitoring");
                return;
            }
            monitoring = true;
            start_monitoring.Text = "Monitoring ON";
            start_monitoring.BackColor = Color.Red;
            void thread()
            {
                string hide = hide_webbrowser.Checked ? "hide_webbrowser" : "0";
                client.Send(Encoding.UTF8.GetBytes("start_monitoring," + hide));
                while (monitoring)
                {
                    // Receive image from server socket
                    byte[] message = new byte[9999999];
                    client.Receive(message, message.Length, SocketFlags.None);
                    List<string> parsed_params = new List<string>();
                    response_parser(Encoding.UTF8.GetString(message), parsed_params);
                    byte[] image_bytes;
                    image_bytes = Convert.FromBase64String(parsed_params[1]);

                    while (!form2.obtained_information_list.InvokeRequired) ;// Prevent cross-thread error
                    form2.obtained_information_list.Invoke(new MethodInvoker(delegate
                    {
                        // Insert received image into list            
                        PictureBox picture_box = new PictureBox();
                        Image obtained_information = System.Drawing.Image.FromStream(new System.IO.MemoryStream(image_bytes, 0, image_bytes.Length));
                        picture_box.Size = new System.Drawing.Size(obtained_information.Width, obtained_information.Height);
                        picture_box.Image = obtained_information;
                        picture_box.Location = new System.Drawing.Point(0, obtained_information_location);
                        form2.obtained_information_list.Controls.Add(picture_box);
                        obtained_information_location += picture_box.Height;

                        // Insert webpage name and current time
                        Label label = new Label();
                        label.Text = "New information arrived (" + parsed_params[0] + ") " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + ")\n" +
                        "------------------------------------------";
                        label.Size = new System.Drawing.Size(form2.obtained_information_list.Width, 20);
                        label.Location = new System.Drawing.Point(0, obtained_information_location);
                        form2.obtained_information_list.Controls.Add(label);
                        obtained_information_location += label.Height;
                    }));

                    if (alarm_turned_on)
                    {
                        Thread beep = new Thread(new ThreadStart(() => Console.Beep(1000, 1500)));
                        beep.Start();
                    }
                }
            }
            Thread _thread = new Thread(new ThreadStart(thread));
            _thread.Start();
        }
        private void stop_monitoring_Click(object sender, EventArgs e)
        {
            monitoring = false;
            start_monitoring.BackColor = Color.Gold;
            start_monitoring.Text = "Start Monitoring";
            client.Send(Encoding.UTF8.GetBytes("stop_monitoring"));
        }
        private void append_webpage_Click(object sender, EventArgs e)
        {
            if (monitoring)
            {
                MessageBox.Show("Please turn off monitoring first");
                return;
            }
            webpage_list.Items.Add("Webpage name: " + webpage_name_box.Text + ", X path: " + X_path_box.Text);
            client.Send(Encoding.UTF8.GetBytes(
                "append_webpage," + webpage_name_box.Text + "," + URL_box.Text + "," + X_path_box.Text));
            webpage_name_box.Clear();
            URL_box.Clear();
            X_path_box.Clear();
        }
        private void delete_webpage_Click(object sender, EventArgs e)
        {
            if (monitoring)
            {
                MessageBox.Show("Please turn off monitoring first");
                return;
            }
            client.Send(Encoding.UTF8.GetBytes("delete_from_database," + webpage_list.SelectedIndex.ToString()));
            if (webpage_list.SelectedIndex == -1)
                return;
            webpage_list.Items.RemoveAt(webpage_list.SelectedIndex);
        }

        private void open_page_Click(object sender, EventArgs e)
        {
            client.Send(Encoding.UTF8.GetBytes("get_URL," + webpage_list.SelectedIndex.ToString()));
            byte[] message = new byte[9999999];
            client.Receive(message, message.Length, SocketFlags.None);
            string URL = Encoding.UTF8.GetString(message);
            System.Diagnostics.Process.Start(URL);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            alarm_turned_on = !alarm_turned_on;
        }
        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            client.Close();
            client.Send(Encoding.UTF8.GetBytes("exit"));
        }
    }
}
