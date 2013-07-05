using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UserFramework;

namespace Lync
{
    public partial class ctlUserList : UserControl
    {
        public ctlUserList()
        {
            InitializeComponent();
        }

        public void AddUser(IUserInfo user)
        {
            Action action = () =>
                {
                    ctlUserItem ctl = new ctlUserItem(user);
                    ctl.Width = flowLayoutPanel1.ClientSize.Width;

                    flowLayoutPanel1.Controls.Add(ctl);
                };

            this.Invoke(action);
        }

        public void Clear()
        {
            this.Invoke(() => { flowLayoutPanel1.Controls.Clear(); });
        }

        public IEnumerable<IUserInfo> Users
        {
            get
            {
                return flowLayoutPanel1.Controls.OfType<ctlUserItem>().Select(ctl => ctl.User);
            }
        }
    }
}
