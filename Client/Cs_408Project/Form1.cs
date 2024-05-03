using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
//client
namespace Cs_408Project
{
    public partial class Form1 : Form
    {
        const string DISCONNECT = "DISCONNECT";
        const string MESSAGE = "MESSAGE";
        const string SUBS = "SUBS";
        const string UNSUBS = "UNSUBS";
        string username = "";
        bool terminated = false;
        bool connected = false;
        Socket clientSocket;
        string channel = "";
        string message = "";


        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_WhenClosed);
            InitializeComponent();
        }

        private void Form1_WhenClosed(object sender, FormClosingEventArgs e)
        {
            byte[] data = Encoding.Default.GetBytes(DISCONNECT + "#");

            connected = false;
            terminated = true;
            Environment.Exit(0);
        }

        public struct User //User Struct
        {
            public Socket Socket;
            public Socket returnSocket()
            {
                return Socket;
            }
            public string Username;
            public string ReturnUsername()
            {
                return Username;
            }
            private List<string> userSubbedChannels;

            public List<string> GetSubscribedChannels()
            {
                return userSubbedChannels;
            }

            public User(Socket socket)
            {
                this.Socket = socket;
                this.Username = null; // Default value for string (null) since structs cannot have parameterless constructors
                this.userSubbedChannels = new List<string>();
            }

            public void setName(string username)
            {
                this.Username = username;
            }
        }

        private void textBox_ip_TextChanged(object sender, EventArgs e)
        {

        }



        private void textBox_port_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {
            string input = textBox_username.Text; //Take the username as input
            username = input;
            if (connected)
            {
                textBox_username.Enabled = true;
            }
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                string IP = textBox_ip.Text;
                int portNum;

                if (Int32.TryParse(textBox_port.Text, out portNum))
                {
                    try
                    {
                        clientSocket.Connect(IP, portNum);
                        byte[] data = Encoding.Default.GetBytes(username); //Sed the username as bytes to the server
                        clientSocket.Send(data);
                        if (!terminated)
                        {
                            button_connect.Enabled = true;
                        }
                        connected = true;
                        button_connect.Text = "Disconnect"; //Change the name of the button to Disconnect when connection is made
                        
                        richTextBox_userconnection.AppendText("Connected to the server" + Environment.NewLine); //Show user connection status on the richTextBox
                        Thread receiveThread = new Thread(Receive);
                        receiveThread.Start();

                    }
                    catch
                    {
                        logs.AppendText("Could not connect to the server!\n"); //Notify when connection could not be made

                    }
                }
                else
                {
                    logs.AppendText("Please check the port number!\n"); //Notify when the port number is wrong
                }

            }
            else
            {
                byte[] data = Encoding.Default.GetBytes(DISCONNECT + "#"); //If the user is connected, disconnect the user
                clientSocket.Send(data);
                connected = false;
                richTextBox_userconnection.AppendText("Disconnected from the server!\n");
                button_connect.Text = "Connect"; //Change the name of the button to connect when the user is disconnected
            }

        }

        private void button_send_Click(object sender, EventArgs e)
        {

            byte[] data = Encoding.Default.GetBytes(MESSAGE + "#" + channel + "#" + message + "#" + username);//Send data to the server as bytes
            clientSocket.Send(data);

        }

        private void logs_TextChanged(object sender, EventArgs e)
        {
            //message textbox
        }

        private void richTextBox_userconnection_TextChanged(object sender, EventArgs e)
        {
            //user connection status textbox
            if (connected)
            {
                richTextBox_userconnection.Enabled = true;
            }
        }

        private void textBox_message_TextChanged(object sender, EventArgs e)
        {
            string input = textBox_message.Text;
            message = input;

        }

        private void button_substoIF101_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                if (button_substoIF101.Text == "Sub") // Add the user to channel IF100
                {
                    byte[] data = Encoding.Default.GetBytes(SUBS + "#" + "IF100");
                    clientSocket.Send(data);
                    button_substoIF101.Text = "Unsubs"; //Change the name of the button after connection
                    richTextBox_userconnection.AppendText("Connected to channel IF100" + Environment.NewLine);
                    radioButton1.Enabled = true; //Enable the radio button after subscription
                }
                else if (button_substoIF101.Text == "Unsubs") // Add the user to channel IF100
                {
                    byte[] data = Encoding.Default.GetBytes(UNSUBS + "#" + "IF100");
                    clientSocket.Send(data);
                    button_substoIF101.Text = "Sub"; //Change the name back to Sub
                    richTextBox_userconnection.AppendText("Disconnected from channel IF100" + Environment.NewLine);
                    radioButton1.Enabled = false; //Disable the radio button
                }

            }
        }



        private void button_substoSPS101_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                if (button_substoSPS101.Text == "Sub") // Add the user to channel SPS101
                {
                    byte[] data = Encoding.Default.GetBytes(SUBS + "#" + "SPS101");
                    clientSocket.Send(data);
                    button_substoSPS101.Text = "Unsubs"; //Change the name of the button after connection
                    richTextBox_userconnection.AppendText("Connected to channel SPS101" + Environment.NewLine);
                    radioButton2.Enabled = true; //Enable the radio button after subscription
                }
                else if (button_substoSPS101.Text == "Unsubs")// Add the user to channel SPS101
                {
                    byte[] data = Encoding.Default.GetBytes(UNSUBS + "#" + "SPS101");
                    clientSocket.Send(data);
                    button_substoSPS101.Text = "Sub"; //Change the name back to Sub
                    richTextBox_userconnection.AppendText("Disconnected from channel SPS101" + Environment.NewLine);
                    radioButton2.Enabled = false; //Disable the radio button
                }
            }

        }

        //Handling the messages from the server
        private void Receive()
        {
            while (connected)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int read = clientSocket.Receive(buffer);
                    if (read > 0)
                    {
                        // Evaluate the message sent from the client side by its parts
                        string UserMSgGet = Encoding.Default.GetString(buffer, 0, read);
                        string[] msgs = UserMSgGet.Split('#');
                        if (UserMSgGet.StartsWith("Username already in use"))
                        {
                            // Handle the case where the username is already in use
                            logs.AppendText("Username is already in use. Please choose another username.\n");
                            // You might want to take some action here, like allowing the user to input a new username
                            byte[] data = Encoding.Default.GetBytes(DISCONNECT + "#"); //If the user is connected, disconnect the user
                            clientSocket.Send(data);
                            connected = false;
                            richTextBox_userconnection.AppendText("Disconnected from the server!\n");
                            button_connect.Text = "Connect";
                        }
                        else 
                        {
                            string ChosenChannel = msgs[0];
                            string MsgPart = msgs[1];
                            string username = msgs[2];
                            string showStauts = "(" + ChosenChannel + ") " + username + ": " + MsgPart + "\n";
                            logs.AppendText(showStauts);
              
                        }
                    }

                }
                catch (Exception e)
                {
                    if (!terminated)
                    {
                        logs.AppendText("Error receiving message: " + e.Message + "\n");
                        logs.AppendText("The server has disconnected\n");
                        
                        button_connect.Text = "Connect"; //Change the name of the button to connect when the user is disconnected
                    }

                    clientSocket.Close();
                    connected = false;
                }
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e) 
        {
            if (!connected)
            {
                radioButton1.Enabled = false;
            }
            if (radioButton1.Checked)
            {
                channel = "IF100"; //Determine the channel to send the message

            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!connected)
            {
                radioButton2.Enabled = false;
                return;
            }

            if (radioButton2.Checked)
            {
                channel = "SPS101"; //Determine the channel to send the message

            }
            

        }



    }
}