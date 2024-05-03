namespace Cs_408Project
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
            label2 = new Label();
            label3 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            button_connect = new Button();
            logs = new RichTextBox();
            textBox_ip = new TextBox();
            textBox_port = new TextBox();
            textBox_username = new TextBox();
            textBox_message = new TextBox();
            button_send = new Button();
            button_substoIF101 = new Button();
            button_substoSPS101 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            richTextBox_userconnection = new RichTextBox();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 49);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 0;
            label1.Text = "IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 97);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 1;
            label2.Text = "Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 425);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 7;
            label3.Text = "Message:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 295);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(57, 20);
            label8.TabIndex = 14;
            label8.Text = "SPS101";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 253);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(44, 20);
            label7.TabIndex = 11;
            label7.Text = "IF100";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 141);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 9;
            label6.Text = "Username";
            // 
            // button_connect
            // 
            button_connect.Location = new Point(21, 173);
            button_connect.Margin = new Padding(2, 3, 2, 3);
            button_connect.Name = "button_connect";
            button_connect.Size = new Size(93, 35);
            button_connect.TabIndex = 4;
            button_connect.Text = "connect";
            button_connect.UseVisualStyleBackColor = true;
            button_connect.Click += button_connect_Click;
            // 
            // logs
            // 
            logs.Location = new Point(342, 35);
            logs.Margin = new Padding(2, 3, 2, 3);
            logs.Name = "logs";
            logs.Size = new Size(391, 341);
            logs.TabIndex = 5;
            logs.Text = "";
            logs.TextChanged += logs_TextChanged;
            // 
            // textBox_ip
            // 
            textBox_ip.Location = new Point(85, 45);
            textBox_ip.Margin = new Padding(2, 3, 2, 3);
            textBox_ip.Name = "textBox_ip";
            textBox_ip.Size = new Size(116, 27);
            textBox_ip.TabIndex = 2;
            textBox_ip.TextChanged += textBox_ip_TextChanged;
            // 
            // textBox_port
            // 
            textBox_port.Location = new Point(85, 91);
            textBox_port.Margin = new Padding(2, 3, 2, 3);
            textBox_port.Name = "textBox_port";
            textBox_port.Size = new Size(116, 27);
            textBox_port.TabIndex = 10;
            textBox_port.TextChanged += textBox_port_TextChanged;
            // 
            // textBox_username
            // 
            textBox_username.Location = new Point(89, 141);
            textBox_username.Margin = new Padding(2, 3, 2, 3);
            textBox_username.Name = "textBox_username";
            textBox_username.Size = new Size(111, 27);
            textBox_username.TabIndex = 17;
            textBox_username.TextChanged += textBox_username_TextChanged;
            // 
            // textBox_message
            // 
            textBox_message.Location = new Point(89, 423);
            textBox_message.Margin = new Padding(2, 3, 2, 3);
            textBox_message.Name = "textBox_message";
            textBox_message.Size = new Size(130, 27);
            textBox_message.TabIndex = 6;
            textBox_message.TextChanged += textBox_message_TextChanged;
            // 
            // button_send
            // 
            button_send.Location = new Point(224, 416);
            button_send.Margin = new Padding(2, 3, 2, 3);
            button_send.Name = "button_send";
            button_send.Size = new Size(87, 40);
            button_send.TabIndex = 8;
            button_send.Text = "send";
            button_send.UseVisualStyleBackColor = true;
            button_send.Click += button_send_Click;
            // 
            // button_substoIF101
            // 
            button_substoIF101.Location = new Point(70, 247);
            button_substoIF101.Margin = new Padding(2, 3, 2, 3);
            button_substoIF101.Name = "button_substoIF101";
            button_substoIF101.Size = new Size(93, 35);
            button_substoIF101.TabIndex = 12;
            button_substoIF101.Text = "Sub";
            button_substoIF101.UseVisualStyleBackColor = true;
            button_substoIF101.Click += button_substoIF101_Click;
            // 
            // button_substoSPS101
            // 
            button_substoSPS101.Location = new Point(70, 288);
            button_substoSPS101.Margin = new Padding(2, 3, 2, 3);
            button_substoSPS101.Name = "button_substoSPS101";
            button_substoSPS101.Size = new Size(93, 35);
            button_substoSPS101.TabIndex = 15;
            button_substoSPS101.Text = "Sub";
            button_substoSPS101.Click += button_substoSPS101_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Enabled = false;
            radioButton1.Location = new Point(62, 352);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(65, 24);
            radioButton1.TabIndex = 19;
            radioButton1.TabStop = true;
            radioButton1.Text = "IF100";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Enabled = false;
            radioButton2.Location = new Point(62, 381);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(78, 24);
            radioButton2.TabIndex = 20;
            radioButton2.TabStop = true;
            radioButton2.Text = "SPS101";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // richTextBox_userconnection
            // 
            richTextBox_userconnection.Location = new Point(342, 439);
            richTextBox_userconnection.Name = "richTextBox_userconnection";
            richTextBox_userconnection.Size = new Size(391, 120);
            richTextBox_userconnection.TabIndex = 21;
            richTextBox_userconnection.Text = "";
            richTextBox_userconnection.TextChanged += richTextBox_userconnection_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(333, 9);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 22;
            label4.Text = "Messages:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(342, 416);
            label5.Name = "label5";
            label5.Size = new Size(164, 20);
            label5.TabIndex = 23;
            label5.Text = "User Connection Status:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 600);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(richTextBox_userconnection);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(button_substoSPS101);
            Controls.Add(label8);
            Controls.Add(button_substoIF101);
            Controls.Add(label6);
            Controls.Add(button_send);
            Controls.Add(label3);
            Controls.Add(textBox_message);
            Controls.Add(logs);
            Controls.Add(button_connect);
            Controls.Add(textBox_port);
            Controls.Add(textBox_ip);
            Controls.Add(textBox_username);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label6;
        private Label label7;
        private TextBox textBox_ip;
        private TextBox textBox_port;
        private Button button_connect;
        private RichTextBox logs;
        private TextBox textBox_message;
        private TextBox textBox_username;
        private Label label3;
        private Button button_send;
        private Button button_substoIF101;
        private Label label8;
        private Button button_substoSPS101;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RichTextBox richTextBox_userconnection;
        private Label label4;
        private Label label5;
    }
}