namespace Information_notifier
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stop_monitoring = new System.Windows.Forms.Button();
            this.start_monitoring = new System.Windows.Forms.Button();
            this.append_webpage = new System.Windows.Forms.Button();
            this.webpage_name_box = new System.Windows.Forms.TextBox();
            this.URL_box = new System.Windows.Forms.TextBox();
            this.XPath_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.delete_webpage = new System.Windows.Forms.Button();
            this.open_page = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.webpage_list = new System.Windows.Forms.ListBox();
            this.show_webbrowser = new System.Windows.Forms.CheckBox();
            this.edit_webpage = new System.Windows.Forms.Button();
            this.reset_text_boxes = new System.Windows.Forms.Button();
            this.debugger = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.n_of_browsers = new System.Windows.Forms.Label();
            this.n_of_browsers_bar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.n_of_browsers_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // stop_monitoring
            // 
            this.stop_monitoring.BackColor = System.Drawing.Color.Gold;
            this.stop_monitoring.Location = new System.Drawing.Point(9, 332);
            this.stop_monitoring.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stop_monitoring.Name = "stop_monitoring";
            this.stop_monitoring.Size = new System.Drawing.Size(152, 45);
            this.stop_monitoring.TabIndex = 2;
            this.stop_monitoring.Text = "Stop monitoring";
            this.stop_monitoring.UseVisualStyleBackColor = false;
            this.stop_monitoring.Click += new System.EventHandler(this.stop_monitoring_Click);
            // 
            // start_monitoring
            // 
            this.start_monitoring.BackColor = System.Drawing.Color.Gold;
            this.start_monitoring.Location = new System.Drawing.Point(9, 279);
            this.start_monitoring.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.start_monitoring.Name = "start_monitoring";
            this.start_monitoring.Size = new System.Drawing.Size(152, 45);
            this.start_monitoring.TabIndex = 3;
            this.start_monitoring.Text = "Start monitoring";
            this.start_monitoring.UseVisualStyleBackColor = false;
            this.start_monitoring.Click += new System.EventHandler(this.start_monitoring_Click);
            // 
            // append_webpage
            // 
            this.append_webpage.BackColor = System.Drawing.Color.Gold;
            this.append_webpage.Location = new System.Drawing.Point(9, 194);
            this.append_webpage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.append_webpage.Name = "append_webpage";
            this.append_webpage.Size = new System.Drawing.Size(65, 45);
            this.append_webpage.TabIndex = 4;
            this.append_webpage.Text = "Add";
            this.append_webpage.UseVisualStyleBackColor = false;
            this.append_webpage.Click += new System.EventHandler(this.append_webpage_Click);
            // 
            // webpage_name_box
            // 
            this.webpage_name_box.Location = new System.Drawing.Point(9, 36);
            this.webpage_name_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.webpage_name_box.Name = "webpage_name_box";
            this.webpage_name_box.Size = new System.Drawing.Size(308, 27);
            this.webpage_name_box.TabIndex = 8;
            // 
            // URL_box
            // 
            this.URL_box.Location = new System.Drawing.Point(9, 97);
            this.URL_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.URL_box.Name = "URL_box";
            this.URL_box.Size = new System.Drawing.Size(308, 27);
            this.URL_box.TabIndex = 6;
            // 
            // XPath_box
            // 
            this.XPath_box.Location = new System.Drawing.Point(9, 159);
            this.XPath_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.XPath_box.Name = "XPath_box";
            this.XPath_box.Size = new System.Drawing.Size(308, 27);
            this.XPath_box.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Webpage name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "URL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Full XPath";
            // 
            // delete_webpage
            // 
            this.delete_webpage.BackColor = System.Drawing.Color.Gold;
            this.delete_webpage.Location = new System.Drawing.Point(481, 448);
            this.delete_webpage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.delete_webpage.Name = "delete_webpage";
            this.delete_webpage.Size = new System.Drawing.Size(152, 45);
            this.delete_webpage.TabIndex = 12;
            this.delete_webpage.Text = "Delete a webpage";
            this.delete_webpage.UseVisualStyleBackColor = false;
            this.delete_webpage.Click += new System.EventHandler(this.delete_webpage_Click);
            // 
            // open_page
            // 
            this.open_page.BackColor = System.Drawing.Color.Gold;
            this.open_page.Location = new System.Drawing.Point(639, 448);
            this.open_page.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.open_page.Name = "open_page";
            this.open_page.Size = new System.Drawing.Size(152, 45);
            this.open_page.TabIndex = 13;
            this.open_page.Text = "Open a webpage";
            this.open_page.UseVisualStyleBackColor = false;
            this.open_page.Click += new System.EventHandler(this.open_page_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 247);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 24);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Turn on alarm";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // webpage_list
            // 
            this.webpage_list.FormattingEnabled = true;
            this.webpage_list.ItemHeight = 20;
            this.webpage_list.Location = new System.Drawing.Point(323, 36);
            this.webpage_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.webpage_list.Name = "webpage_list";
            this.webpage_list.Size = new System.Drawing.Size(464, 404);
            this.webpage_list.TabIndex = 15;
            this.webpage_list.SelectedIndexChanged += new System.EventHandler(this.webpage_list_SelectedIndexChanged);
            // 
            // show_webbrowser
            // 
            this.show_webbrowser.AutoSize = true;
            this.show_webbrowser.Location = new System.Drawing.Point(138, 247);
            this.show_webbrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.show_webbrowser.Name = "show_webbrowser";
            this.show_webbrowser.Size = new System.Drawing.Size(106, 24);
            this.show_webbrowser.TabIndex = 16;
            this.show_webbrowser.Text = "TEST mode";
            this.show_webbrowser.UseVisualStyleBackColor = true;
            // 
            // edit_webpage
            // 
            this.edit_webpage.BackColor = System.Drawing.Color.Gold;
            this.edit_webpage.Location = new System.Drawing.Point(323, 448);
            this.edit_webpage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.edit_webpage.Name = "edit_webpage";
            this.edit_webpage.Size = new System.Drawing.Size(152, 45);
            this.edit_webpage.TabIndex = 21;
            this.edit_webpage.Text = "Edit a webpage";
            this.edit_webpage.UseVisualStyleBackColor = false;
            this.edit_webpage.Click += new System.EventHandler(this.edit_webpage_Click);
            // 
            // reset_text_boxes
            // 
            this.reset_text_boxes.BackColor = System.Drawing.Color.Gold;
            this.reset_text_boxes.Location = new System.Drawing.Point(80, 194);
            this.reset_text_boxes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reset_text_boxes.Name = "reset_text_boxes";
            this.reset_text_boxes.Size = new System.Drawing.Size(137, 45);
            this.reset_text_boxes.TabIndex = 20;
            this.reset_text_boxes.Text = "Reset text boxes";
            this.reset_text_boxes.UseVisualStyleBackColor = false;
            this.reset_text_boxes.Click += new System.EventHandler(this.reset_text_boxes_Click);
            // 
            // debugger
            // 
            this.debugger.AutoSize = true;
            this.debugger.Location = new System.Drawing.Point(493, 9);
            this.debugger.Name = "debugger";
            this.debugger.Size = new System.Drawing.Size(140, 20);
            this.debugger.TabIndex = 22;
            this.debugger.Text = "New information : 0";
            this.debugger.Click += new System.EventHandler(this.debugger_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Webpage list";
            // 
            // n_of_browsers
            // 
            this.n_of_browsers.AutoSize = true;
            this.n_of_browsers.Location = new System.Drawing.Point(148, 394);
            this.n_of_browsers.Name = "n_of_browsers";
            this.n_of_browsers.Size = new System.Drawing.Size(163, 20);
            this.n_of_browsers.TabIndex = 24;
            this.n_of_browsers.Text = "Number of browsers : 1";
            // 
            // n_of_browsers_bar
            // 
            this.n_of_browsers_bar.LargeChange = 2;
            this.n_of_browsers_bar.Location = new System.Drawing.Point(12, 384);
            this.n_of_browsers_bar.Minimum = 1;
            this.n_of_browsers_bar.Name = "n_of_browsers_bar";
            this.n_of_browsers_bar.Size = new System.Drawing.Size(130, 56);
            this.n_of_browsers_bar.TabIndex = 25;
            this.n_of_browsers_bar.Value = 1;
            this.n_of_browsers_bar.Scroll += new System.EventHandler(this.n_of_browsers_bar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 500);
            this.Controls.Add(this.n_of_browsers_bar);
            this.Controls.Add(this.n_of_browsers);
            this.Controls.Add(this.debugger);
            this.Controls.Add(this.edit_webpage);
            this.Controls.Add(this.reset_text_boxes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.show_webbrowser);
            this.Controls.Add(this.webpage_list);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.open_page);
            this.Controls.Add(this.delete_webpage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.XPath_box);
            this.Controls.Add(this.URL_box);
            this.Controls.Add(this.webpage_name_box);
            this.Controls.Add(this.append_webpage);
            this.Controls.Add(this.start_monitoring);
            this.Controls.Add(this.stop_monitoring);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Information notifier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.n_of_browsers_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button stop_monitoring;
        private System.Windows.Forms.Button start_monitoring;
        private System.Windows.Forms.Button append_webpage;
        private System.Windows.Forms.TextBox webpage_name_box;
        private System.Windows.Forms.TextBox URL_box;
        private System.Windows.Forms.TextBox XPath_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button delete_webpage;
        private System.Windows.Forms.Button open_page;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox webpage_list;
        private CheckBox show_webbrowser;
        private Button edit_webpage;
        private Button reset_text_boxes;
        private Label debugger;
        private Label label4;
        private Label n_of_browsers;
        private TrackBar n_of_browsers_bar;
    }
}

