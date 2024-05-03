namespace WinFormsApp5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox_port = new TextBox();
            richTextBox_clients = new RichTextBox();
            richTextBox_sps101 = new RichTextBox();
            richTextBox_if100 = new RichTextBox();
            richTextBox_activities = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "Port:";
            label1.Click += label1_Click;
            // 
            // textBox_port
            // 
            textBox_port.Location = new Point(56, 9);
            textBox_port.Name = "textBox_port";
            textBox_port.Size = new Size(158, 27);
            textBox_port.TabIndex = 1;
            textBox_port.TextChanged += textBox1_TextChanged;
            // 
            // richTextBox_clients
            // 
            richTextBox_clients.Location = new Point(12, 101);
            richTextBox_clients.Name = "richTextBox_clients";
            richTextBox_clients.Size = new Size(167, 295);
            richTextBox_clients.TabIndex = 3;
            richTextBox_clients.Text = "";
            richTextBox_clients.TextChanged += richTextBox1_TextChanged;
            // 
            // richTextBox_sps101
            // 
            richTextBox_sps101.Location = new Point(185, 101);
            richTextBox_sps101.Name = "richTextBox_sps101";
            richTextBox_sps101.Size = new Size(173, 295);
            richTextBox_sps101.TabIndex = 7;
            richTextBox_sps101.Text = "";
            richTextBox_sps101.TextChanged += richTextBox_sps101_TextChanged;
            // 
            // richTextBox_if100
            // 
            richTextBox_if100.Location = new Point(373, 101);
            richTextBox_if100.Name = "richTextBox_if100";
            richTextBox_if100.Size = new Size(172, 295);
            richTextBox_if100.TabIndex = 8;
            richTextBox_if100.Text = "";
            richTextBox_if100.TextChanged += richTextBox_if100_TextChanged;
            // 
            // richTextBox_activities
            // 
            richTextBox_activities.Location = new Point(560, 101);
            richTextBox_activities.Name = "richTextBox_activities";
            richTextBox_activities.Size = new Size(228, 235);
            richTextBox_activities.TabIndex = 9;
            richTextBox_activities.Text = "";
            richTextBox_activities.TextChanged += richTextBox_activities_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 73);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 10;
            label2.Text = "Clients:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(191, 71);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 11;
            label3.Text = "SPS101:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(375, 73);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 12;
            label4.Text = "IF100:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(564, 69);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 13;
            label5.Text = "Activities:";
            // 
            // button1
            // 
            button1.Location = new Point(256, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 14;
            button1.Text = "Listen ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(richTextBox_activities);
            Controls.Add(richTextBox_if100);
            Controls.Add(richTextBox_sps101);
            Controls.Add(richTextBox_clients);
            Controls.Add(textBox_port);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_port;

        private RichTextBox richTextBox_clients;
        private RichTextBox richTextBox_sps101;
        private RichTextBox richTextBox_if100;
        private RichTextBox richTextBox_activities;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
    }
}