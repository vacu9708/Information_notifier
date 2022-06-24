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
            this.X_path_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.delete_webpage = new System.Windows.Forms.Button();
            this.open_page = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.webpage_list = new System.Windows.Forms.ListBox();
            this.hide_webbrowser = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stop_monitoring
            // 
            this.stop_monitoring.BackColor = System.Drawing.Color.Gold;
            this.stop_monitoring.Location = new System.Drawing.Point(65, 308);
            this.stop_monitoring.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stop_monitoring.Name = "stop_monitoring";
            this.stop_monitoring.Size = new System.Drawing.Size(152, 62);
            this.stop_monitoring.TabIndex = 2;
            this.stop_monitoring.Text = "Stop monitoring";
            this.stop_monitoring.UseVisualStyleBackColor = false;
            this.stop_monitoring.Click += new System.EventHandler(this.stop_monitoring_Click);
            // 
            // start_monitoring
            // 
            this.start_monitoring.BackColor = System.Drawing.Color.Gold;
            this.start_monitoring.Location = new System.Drawing.Point(65, 238);
            this.start_monitoring.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.start_monitoring.Name = "start_monitoring";
            this.start_monitoring.Size = new System.Drawing.Size(152, 62);
            this.start_monitoring.TabIndex = 3;
            this.start_monitoring.Text = "Start monitoring";
            this.start_monitoring.UseVisualStyleBackColor = false;
            this.start_monitoring.Click += new System.EventHandler(this.start_monitoring_Click);
            // 
            // append_webpage
            // 
            this.append_webpage.BackColor = System.Drawing.Color.Gold;
            this.append_webpage.Location = new System.Drawing.Point(323, 448);
            this.append_webpage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.append_webpage.Name = "append_webpage";
            this.append_webpage.Size = new System.Drawing.Size(152, 63);
            this.append_webpage.TabIndex = 4;
            this.append_webpage.Text = "Append a webpage";
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
            // X_path_box
            // 
            this.X_path_box.Location = new System.Drawing.Point(9, 159);
            this.X_path_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.X_path_box.Name = "X_path_box";
            this.X_path_box.Size = new System.Drawing.Size(308, 27);
            this.X_path_box.TabIndex = 7;
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
            this.delete_webpage.Size = new System.Drawing.Size(152, 63);
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
            this.open_page.Size = new System.Drawing.Size(152, 63);
            this.open_page.TabIndex = 13;
            this.open_page.Text = "Open a webpage";
            this.open_page.UseVisualStyleBackColor = false;
            this.open_page.Click += new System.EventHandler(this.open_page_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 194);
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
            // 
            // hide_webbrowser
            // 
            this.hide_webbrowser.AutoSize = true;
            this.hide_webbrowser.Location = new System.Drawing.Point(138, 194);
            this.hide_webbrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hide_webbrowser.Name = "hide_webbrowser";
            this.hide_webbrowser.Size = new System.Drawing.Size(148, 24);
            this.hide_webbrowser.TabIndex = 16;
            this.hide_webbrowser.Text = "Hide webbrowser";
            this.hide_webbrowser.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 527);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hide_webbrowser);
            this.Controls.Add(this.webpage_list);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.open_page);
            this.Controls.Add(this.delete_webpage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.X_path_box);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button stop_monitoring;
        private System.Windows.Forms.Button start_monitoring;
        private System.Windows.Forms.Button append_webpage;
        private System.Windows.Forms.TextBox webpage_name_box;
        private System.Windows.Forms.TextBox URL_box;
        private System.Windows.Forms.TextBox X_path_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button delete_webpage;
        private System.Windows.Forms.Button open_page;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox webpage_list;
        private CheckBox hide_webbrowser;
        private Label label4;
    }
}

