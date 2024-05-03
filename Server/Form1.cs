using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Reflection;
using System.Diagnostics.Eventing.Reader;
//server
namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        private List<string> usedUsernames = new List<string>();
        private List<string> IF100sub = new List<string>();
        private List<string> SPS101sub = new List<string>();
        private List<User> users = new List<User>();

        string IF = "IF100";
        string SPS = "SPS101";

        const string DISCONNECT = "DISCONNECT";
        const string MESSAGE = "MESSAGE";
        const string SUBS = "SUBS";
        const string UNSUBS = "UNSUBS";

        bool connected = false;

        bool listen = false;
        bool terminate = false;

        Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte[] data = Encoding.Default.GetBytes(DISCONNECT + "#");
            connected = false;
            terminate = true;
            Environment.Exit(0);
        }
        public struct User
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

            public void addtoUserSubbed (string channel)
            {
                userSubbedChannels.Add(channel);
            }
            public void rmmUserSubbed (string channel)
            {
                userSubbedChannels.Remove(channel);
            }

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


        private void HandleSub(string channelName, User user)
        {
            string username = user.Username;

            if (channelName == IF)
            {
                if (!IF100sub.Contains(username))
                {
                    IF100sub.Add(username);//Add username to IF100 List
                    user.addtoUserSubbed(channelName);
 
                    richTextBox_if100.AppendText(username + Environment.NewLine);
                    richTextBox_activities.AppendText(username + " has connected to channel " + channelName + Environment.NewLine);
                }
            }
            else if (channelName == SPS )
            {
                if (!SPS101sub.Contains(username))
                {
                    SPS101sub.Add(username);//Add username to SPS101 List
                    user.addtoUserSubbed(channelName);

                    richTextBox_sps101.AppendText(username + Environment.NewLine);
                    richTextBox_activities.AppendText(username + " has connected to channel " + channelName + Environment.NewLine);

                }
            }
        }

        private void HandleUnsub(string channelName, User user)
        {
   
           
            if (channelName == IF)
            {
                if (IF100sub.Contains(user.Username))
                {
                   
                    richTextBox_if100.Text = richTextBox_if100.Text.Replace(user.Username, "");
                    IF100sub.Remove(user.Username);//Remove user from the IF100 subscribe list
                    user.rmmUserSubbed(channelName);

                    richTextBox_activities.AppendText(user.Username + " has disconnected from channel " + channelName + Environment.NewLine);

                }
            }
            else if (channelName == SPS)
            {
                if (SPS101sub.Contains(user.Username))
                {
                    richTextBox_sps101.Text = richTextBox_sps101.Text.Replace(user.Username, "");
                    SPS101sub.Remove(user.Username);//Remove user from the SPS101 subscribe list
                    user.rmmUserSubbed(channelName);
                    richTextBox_activities.AppendText(user.Username + " has disconnected from channel " + channelName + Environment.NewLine);
                }
            }
        }

        
      
        private void button1_Click(object sender, EventArgs e)
        {


            int serverPort;
            if (Int32.TryParse(textBox_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                Socket.Bind(endPoint);
                Socket.Listen(10);
                listen = true;
                button1.Enabled = false; //Disable the Listen button and Port textbox
                textBox_port.Enabled = false;

                Thread listeningThread = new Thread(HandleUser);
                listeningThread.Start();

                richTextBox_activities.AppendText("Started listening on port: " + serverPort + "\n");
            }

            else
            {
                richTextBox_activities.AppendText("Please check port number \n");
            }

        }

        private void HandleUser()
        {
            while (listen)
            {
                try
                {
                    Socket newClient = Socket.Accept();

                    Byte[] buffer = new Byte[200];
                    newClient.Receive(buffer);
                    string username = Encoding.Default.GetString(buffer);
                    username = username.Substring(0, username.IndexOf('\0')); //Remove the extra (empty) characters from the username


                    if (IsUsernameAvailable(username))
                    {
                        User user = new User(newClient);
                        users.Add(user);
                        user.setName(username);
                        richTextBox_clients.AppendText(username + "\n");

                        usedUsernames.Add(username);

                        Thread userThread = new Thread(() => Listen(user));
                        userThread.Start();

                        richTextBox_activities.AppendText(username + " has connected to the server\n");
                    }
                    else
                    {
                        // Inform the client that the username is already taken
                        richTextBox_activities.AppendText("A user has tried to connect with a name that is already in use.\n");
                        byte[] message = Encoding.Default.GetBytes("Username already in use. Please choose another username.\n");
                        newClient.Send(message);
                        newClient.Close();
                    }
                }
                catch
                {
                    
                    if (terminate)
                    {
                        listen = false;
                    }
                    else
                    {
                        richTextBox_activities.AppendText("The socket stopped working.\n");
                    }
                }
            }

        }
        // Check if the username is available
        private bool IsUsernameAvailable(string username)
        {
            return !usedUsernames.Contains(username);
        }



        private void Listen(User user)
        {
            bool connected = true;
            while (connected && !terminate) 
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int bytes = user.Socket.Receive(buffer);
                    string message = Encoding.Default.GetString(buffer, 0, bytes);
                    string[] MessageToSend = message.Split('#');
                    if (MessageToSend.Length > 1) 
                    {
                        //Split and differentiate the parts of the message

                        string parts = MessageToSend[0];
                        if (parts == SUBS)
                        {
                            HandleSub(MessageToSend[1], user);
                        }
                        else if (parts == UNSUBS)
                        {
                            HandleUnsub(MessageToSend[1], user);
                        }
                        else if (parts == MESSAGE)
                        {
                            HandleChannelActions(MessageToSend[1], MessageToSend[2], user);

                        }
                        else if (parts == DISCONNECT)
                        {
                            if (connected)
                            {
                                disconnection(user);
                                connected = false;
                            }
                        }
                    }
                }
                
                catch
                {
                    if (connected)
                    {
                        disconnection(user);
                        connected = false;
                    }
                }
            }
        }

        private void HandleChannelActions(string channel, string msg, User sender) //Send Message to the channels the user subscribed to 
        {
            var usersToSend = users
                .Where(user => user.GetSubscribedChannels().Contains(channel) && user.Username != sender.Username)
                .ToList();
            List<String> userSubbedChannels = new List<String>(sender.GetSubscribedChannels());
            foreach (User user in usersToSend)
            {
                string a = $"{channel}#{msg}#{sender.Username}";
                byte[] buffer = Encoding.Default.GetBytes(a);
                user.Socket.Send(buffer);
                richTextBox_activities.AppendText(sender.Username + " has sent a message to channel " + channel + "\n");
            }
        }

        private void disconnection(User user) //Disconnect the user from the server
        {
            if (ReferenceEquals(user, null))
                return;

            richTextBox_activities.AppendText(user.Username + " has disconnected from the server " + "\n"); //Notify that the user has been disconnected
            // Remove the disconnected user from usedUsernames list                             

            users.Remove(user);

            List<string> newuser = new List<string>(user.GetSubscribedChannels());
            newuser.ForEach(channel => HandleUnsub(channel, user)); //Unsub the user from the already subscribed channels 

            richTextBox_clients.Text = richTextBox_clients.Text.Replace(user.Username, ""); //Remove the name of the user from the channels
            richTextBox_sps101.Text = richTextBox_sps101.Text.Replace(user.Username, "");
       
            
            user.Socket.Close();
           
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox_port
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //richTextBox_clients
        }


        private void richTextBox_sps101_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox_if100_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox_activities_TextChanged(object sender, EventArgs e)
        {

        }

    }
}