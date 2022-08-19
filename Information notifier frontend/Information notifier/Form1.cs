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
        Form2 displayer_form;
        int obtained_information_location, new_information_counter, information_notifier_counter;
        bool monitoring, alarm_turned_on;
        List<string> webpage_names;
        List<string> URLs;
        List<string> XPaths;
        public Form1(int port)
        {
            InitializeComponent();

            this.monitoring = false;
            webpage_names = new List<string>();
            URLs = new List<string>();
            XPaths = new List<string>();

            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));

            this.displayer_form = new Form2();
            displayer_form.Show();

            information_notifier_counter = 1;
        }
        private List<string> response_parser(string message)
        {
            List<string> parsed_params = new List<string>();
            int beginning_of_string = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ',')
                {// First distinguisher found
                    parsed_params.Add(message.Substring(beginning_of_string, i - beginning_of_string));
                    beginning_of_string = i + 1;
                }
                if (message[i] == '$') // End of response
                {
                    parsed_params.Add(message.Substring(beginning_of_string, i - beginning_of_string));
                    break;
                }
            }
            return parsed_params;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Parse database
            client.Send(Encoding.UTF8.GetBytes("parse_database"));
            byte[] message = new byte[9999999];
            while (true) // If not the end of list
            {
                client.Receive(message, message.Length, SocketFlags.None);
                if (Encoding.UTF8.GetString(message)[0] == '$') // End of parsing database
                    return;

                List<string> parsed_params = response_parser(Encoding.UTF8.GetString(message));
                webpage_names.Add(parsed_params[0]);
                URLs.Add(parsed_params[1]);
                XPaths.Add(parsed_params[2]);

                webpage_list.Items.Add(parsed_params[0]);
                client.Send(new byte[1]); // Notify finishing a row
            }
        }
        private void append_webpage_Click(object sender, EventArgs e)
        {
            if (monitoring)
            {
                MessageBox.Show("Please turn off monitoring first");
                return;
            }
            if (webpage_name_box.Text == "" || URL_box.Text == "" || XPath_box.Text == "")
                return;

            client.Send(Encoding.UTF8.GetBytes("append_webpage," + webpage_name_box.Text + "," + URL_box.Text + "," + XPath_box.Text));

            // Add to lists
            webpage_names.Add(webpage_name_box.Text);
            URLs.Add(URL_box.Text);
            XPaths.Add(XPath_box.Text);
            // Add to webpage list
            webpage_list.Items.Add(webpage_name_box.Text);
            // Reset text boxes
            webpage_name_box.Clear();
            URL_box.Clear();
            XPath_box.Clear();
        }
        private void delete_webpage_Click(object sender, EventArgs e)
        {
            if (webpage_list.SelectedIndex < 0)
            {
                MessageBox.Show("Nothing selected");
                return;
            }


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
        private void start_monitoring_Click(object sender, EventArgs e)
        {
            if (monitoring)
            {
                MessageBox.Show("Already monitoring");
                return;
            }
            string hide = show_webbrowser.Checked ? "show_webbrowser" : "0";
            client.Send(Encoding.UTF8.GetBytes("start_monitoring," + hide + ", " + trackBar1.Value));

            monitoring = true;
            start_monitoring.Text = "Monitoring ON";
            start_monitoring.BackColor = Color.Red;
            void thread()
            {
                while (monitoring)
                {
                    // Receive image, webpage index, and URL from server socket
                    byte[] message = new byte[9999999];
                    client.Receive(message, message.Length, SocketFlags.None);
                    List<string> parsed_params = response_parser(Encoding.UTF8.GetString(message));
                    byte[] image_bytes;
                    image_bytes = Convert.FromBase64String(parsed_params[1]);

                    while (!displayer_form.obtained_information_list.InvokeRequired) ;// Prevent cross-thread error
                    displayer_form.obtained_information_list.Invoke(new MethodInvoker(delegate
                    {
                        // Full displayer
                        if (displayer_form.obtained_information_list.VerticalScroll.Maximum > 30000)
                        {
                            displayer_form = new Form2();
                            information_notifier_counter++;
                            displayer_form.Text = "Information notifier " + information_notifier_counter;
                            displayer_form.Show();
                            obtained_information_location = 0;
                        }

                        // Scroll to the top
                        displayer_form.obtained_information_list.VerticalScroll.Value = displayer_form.obtained_information_list.VerticalScroll.Minimum;
                        displayer_form.obtained_information_list.PerformLayout();

                        // Insert received image into list            
                        PictureBox picture_box = new PictureBox();
                        picture_box.Cursor = Cursors.Hand;
                        // Add a hyperlink
                        picture_box.Click += new EventHandler((sender, e) =>
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = parsed_params[2], UseShellExecute = true }));
                        //-----end Add a hyperlink

                        Image obtained_information = System.Drawing.Image.FromStream(new System.IO.MemoryStream(image_bytes, 0, image_bytes.Length));
                        picture_box.Size = new System.Drawing.Size(obtained_information.Width, obtained_information.Height);
                        picture_box.Image = obtained_information;
                        picture_box.Location = new System.Drawing.Point(0, obtained_information_location);
                        displayer_form.obtained_information_list.Controls.Add(picture_box);
                        obtained_information_location += picture_box.Height;
                        //-----end insert received image into list   

                        // Insert obtained information
                        Label label = new Label();
                        label.Text = "New information arrived from (" + parsed_params[0] + ") at (" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + ")\n" +
                        "------------------------------------------";
                        label.Size = new System.Drawing.Size(displayer_form.obtained_information_list.Width, 30);
                        label.Font = new Font("Arial", 15);
                        label.Location = new System.Drawing.Point(0, obtained_information_location);
                        displayer_form.obtained_information_list.Controls.Add(label);
                        obtained_information_location += label.Height;

                        // Scroll to the bottom
                        displayer_form.obtained_information_list.VerticalScroll.Value = displayer_form.obtained_information_list.VerticalScroll.Maximum;
                        displayer_form.obtained_information_list.PerformLayout();
                        new_information_counter++;
                        new_information_displayer.Text = "New information : " + new_information_counter.ToString();

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
            client.Send(Encoding.UTF8.GetBytes("stop_monitoring"));
            monitoring = false;
            start_monitoring.BackColor = Color.Gold;
            start_monitoring.Text = "Start Monitoring";
        }
        private void open_page_Click(object sender, EventArgs e)
        {
            if (webpage_list.SelectedIndex < 0)
            {
                MessageBox.Show("Nothing selected");
                return;
            }
            System.Diagnostics.Process.Start(URLs[webpage_list.SelectedIndex]);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            alarm_turned_on = !alarm_turned_on;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            client.Send(Encoding.UTF8.GetBytes("exit"));
            client.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            webpage_n.Text=trackBar1.Value.ToString();
        }

        private void reset_text_boxes_Click(object sender, EventArgs e)
        {
            webpage_name_box.Clear();
            URL_box.Clear();
            XPath_box.Clear();
            webpage_list.ClearSelected();
        }

        private void webpage_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webpage_list.SelectedIndex < 0)
                return;

            webpage_name_box.Text = webpage_names[webpage_list.SelectedIndex];
            URL_box.Text = URLs[webpage_list.SelectedIndex];
            XPath_box.Text = XPaths[webpage_list.SelectedIndex];

        }

        private void edit_webpage_Click(object sender, EventArgs e)
        {
            if (webpage_list.SelectedIndex < 0)
            {
                MessageBox.Show("Nothing selected");
                return;
            }

            client.Send(Encoding.UTF8.GetBytes("edit_webpage," + webpage_list.SelectedIndex + "," + webpage_name_box.Text + "," + URL_box.Text + "," + XPath_box.Text));

            // Edit lists
            int selected_index = webpage_list.SelectedIndex;
            webpage_names.RemoveAt(selected_index);
            URLs.RemoveAt(selected_index);
            XPaths.RemoveAt(selected_index);

            webpage_names.Add(webpage_name_box.Text);
            URLs.Add(URL_box.Text);
            XPaths.Add(XPath_box.Text);
            //-----end Edit lists
            // Add the new webpage
            webpage_list.Items.RemoveAt(selected_index);
            webpage_list.Items.Add(webpage_name_box.Text);
            // Reset text boxes
            webpage_name_box.Clear();
            URL_box.Clear();
            XPath_box.Clear();
        }
    }
}
