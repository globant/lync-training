using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UserFramework;
using CommunicatorFactory;

namespace TestForm
{
    public partial class Form1 : Form, INotification
    {
        public Form1()
        {
            InitializeComponent();
            CommFactory.Notifier = this;
        }

        private void mnuConnect_Click(object sender, EventArgs e)
        {
            ICommunicator client = CommFactory.GetCommunicator();
            if (client == null) return;

            client.SignIn += new EventHandler(client_SignIn);
            client.SignOut += new EventHandler(client_SignOut);
            client.UserAdded += new EventHandler<UserAddedEventArgs>(client_UserAdded);
            client.Login(textBox1.Text, textBox2.Text);
        }

        void client_UserAdded(object sender, UserAddedEventArgs e)
        {
            AddContactToList(e.UserInfo);
        }

        private void mnuDisconnect_Click(object sender, EventArgs e)
        {
            ICommunicator client = CommFactory.GetCommunicator();
            if (client == null) return;

            client.Disconnect();
        }

        private void mnuAvailable_Click(object sender, EventArgs e)
        {
            SetStatus(UserStatus.Available);
        }

        private void mnuBusy_Click(object sender, EventArgs e)
        {
            SetStatus(UserStatus.Busy);
        }

        private void mnuAway_Click(object sender, EventArgs e)
        {
            SetStatus(UserStatus.Away);
        }

        void client_SignIn(object sender, EventArgs e)
        {
            ICommunicator client = CommFactory.GetCommunicator();
            client.Self.PropertyChanged += new EventHandler<UserInfoPropertyChangeEventArgs>(Self_PropertyChanged);

            this.Invoke(() =>
                        {
                            SetStatusTripButton(client.Self.Status);
                            SetStatusButtons(true);
                        });

            client.LoadUsers();
        }

        void Self_PropertyChanged(object sender, UserInfoPropertyChangeEventArgs e)
        {
            if (e.Properties.Contains(UserPorpertyInfo.UserStatus))
            {
                ICommunicator client = CommFactory.GetCommunicator();
                this.Invoke(() => { SetStatusTripButton(client.Self.Status); });
            }
        }

        void client_SignOut(object sender, EventArgs e)
        {
            this.Invoke(() =>
                        {
                            SetStatusButtons(false);
                            tsbStatus.Image = Properties.Resources.SignIn;
                            lstUsers.Clear();
                        });
        }

        private void SetStatusTripButton(UserStatus status)
        {
            Image img = null;

            switch (status)
            {
                case UserStatus.Away:
                    img = Properties.Resources.StatusAway;
                    break;
                case UserStatus.Busy:
                    img = Properties.Resources.StatusBusy;
                    break;
                case UserStatus.Available:
                    img = Properties.Resources.StatusOnline;
                    break;
                default:
                    return;
            }

            tsbStatus.Image = img;
        }

        private void SetStatusButtons(bool isSignedIn)
        {
            mnuAvailable.Visible = mnuAway.Visible = mnuBusy.Visible = mnuDisconnect.Visible = !(mnuConnect.Visible = !isSignedIn);
        }

        private void SetStatus(UserStatus status)
        {
            ICommunicator client = CommFactory.GetCommunicator();
            if (client == null) return;

            client.Self.Status = status;
        }

        private void AddContactToList(IUserInfo user)
        {
            if (!lstUsers.Users.Any(u => u.Id == user.Id))
                lstUsers.AddUser(user);
        }

        public void Notify(string title, string msg, Severity severity)
        {
            Action action = null;

            switch (severity)
            {
                case Severity.Info:
                    action = () => { lblMsg.Text = msg; };
                    break;
                case Severity.Warning:
                    action = () => { MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning); };
                    break;
                case Severity.Error:
                    action = () => { MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error); };
                    break;
                case Severity.None:
                default:
                    return;
            }

            this.Invoke(action);
        }
    }
}
