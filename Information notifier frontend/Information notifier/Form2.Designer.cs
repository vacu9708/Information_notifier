namespace Information_notifier
{
    partial class Form2
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
            this.obtained_information_list = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // obtained_information_list
            // 
            this.obtained_information_list.AutoScroll = true;
            this.obtained_information_list.AutoSize = true;
            this.obtained_information_list.Location = new System.Drawing.Point(12, 12);
            this.obtained_information_list.Name = "obtained_information_list";
            this.obtained_information_list.Size = new System.Drawing.Size(1433, 753);
            this.obtained_information_list.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1457, 777);
            this.Controls.Add(this.obtained_information_list);
            this.Name = "Form2";
            this.Text = "Information displayer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Panel obtained_information_list;
    }
}