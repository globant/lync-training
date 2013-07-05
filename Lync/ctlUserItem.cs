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
    public partial class ctlUserItem : UserControl
    {
        frmUserCard _UserCard;

        public ctlUserItem(IUserInfo user)
        {
            InitializeComponent();

            _User = user;

            this.Invoke(() =>
                        {
                            Image icon = _User.Photo;
                            picIcon.Image = (icon != null) ? icon : Properties.Resources.icon_user_32px;

                            lblDisplayName.Text = _User.DisplayName;
                            SetStatusIcon(_User.Status);
                        });

            _User.PropertyChanged += new EventHandler<UserInfoPropertyChangeEventArgs>(user_PropertyChanged);
        }

        private IUserInfo _User;
        public IUserInfo User { get { return _User; } }

        void user_PropertyChanged(object sender, UserInfoPropertyChangeEventArgs e)
        {
            Action action = null;

            foreach (var prop in e.Properties)
            {
                switch (prop)
                {
                    case UserPorpertyInfo.DisplayName:
                        action = () => { lblDisplayName.Text = _User.DisplayName; };
                        break;
                    case UserPorpertyInfo.Icon:
                        action = () => { picIcon.Image = _User.Icon; };
                        break;
                    case UserPorpertyInfo.UserStatus:
                        action = () => { SetStatusIcon(_User.Status); };
                        break;
                    default:
                        continue;
                }

                this.Invoke(action);
            }
        }

        private void SetStatusIcon(UserStatus status)
        {
            Image img = null;

            switch (status)
            {
                case UserStatus.Offline:
                    img = Properties.Resources.StatusOffline;
                    break;
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
                    break;
            }

            picStatus.Image = img;
        }

        private void picStatus_MouseHover(object sender, EventArgs e)
        {
            this.Invoke(() => { toolStatus.Show(_User.Status.ToString(), picStatus); });
        }

        private void picStatus_MouseLeave(object sender, EventArgs e)
        {
            toolStatus.Hide(picStatus);
        }

        private void picIcon_MouseHover(object sender, EventArgs e)
        {
            this.Invoke(() => { toolIcon.Show(_User.Id, picIcon); });
        }

        private void picIcon_MouseLeave(object sender, EventArgs e)
        {
            toolIcon.Hide(picIcon);
        }

        private void picShowContactCard_MouseUp(object sender, MouseEventArgs e)
        {
            if (_UserCard == null)
            {
                _UserCard = new frmUserCard(_User);
                _UserCard.Location = picShowContactCard.PointToScreen(Point.Add(Point.Empty, picShowContactCard.Size));
                _UserCard.Show();
            }
            else
            {
                _UserCard.Dispose();
                _UserCard = null;
            }
        }
    }
}
