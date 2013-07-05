using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Lync.Model;
using UserFramework;

namespace Lync
{
    public partial class frmUserCard : Form
    {
        public frmUserCard(IUserInfo user)
        {
            InitializeComponent();

            LyncUser card = elementHost1.Child as LyncUser;

            card.SizeChanged += new System.Windows.SizeChangedEventHandler(frmUser_SizeChanged);
            card.contactCard1.Source = user.Id;
            card.LayoutUpdated += new EventHandler(card_LayoutUpdated);
        }

        void card_LayoutUpdated(object sender, EventArgs e)
        {
            LyncUser card = elementHost1.Child as LyncUser;
            this.Size = elementHost1.Size = new System.Drawing.Size((int)card.DesiredSize.Width, (int)card.DesiredSize.Height);
        }

        void frmUser_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            this.Size = elementHost1.Size = new Size((int)e.NewSize.Width, (int)e.NewSize.Height);
        }
    }
}
