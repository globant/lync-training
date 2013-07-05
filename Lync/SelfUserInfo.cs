using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Lync;
using Microsoft.Lync.Utilities;
using Microsoft.Lync.Utilities.Logging;
using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Conversation;
using Microsoft.Lync.Model.Device;
using Microsoft.Lync.Model.Group;
using Microsoft.Lync.Model.Room;
using UserFramework;

namespace Lync
{
    class SelfUserInfo : UserInfo, ISelfUserInfo
    {
        Self _Self;

        internal SelfUserInfo(Self self)
            : base(self.Contact)
        {
            _Self = self;
        }

        public new UserStatus Status
        {
            get { return base.Status; }
            set
            {
                if (_Self == null)
                    return;

                ContactAvailability avai = ContactAvailability.None;

                switch (value)
                {
                    case UserStatus.Away:
                        avai = ContactAvailability.Away;
                        break;
                    case UserStatus.Busy:
                        avai = ContactAvailability.Busy;
                        break;
                    case UserStatus.Available:
                        avai = ContactAvailability.Free;
                        break;
                    default:
                        return; //not valid
                }

                var newstatus = new[] { new KeyValuePair<PublishableContactInformationType, object>(PublishableContactInformationType.Availability, avai) };

                _Self.BeginPublishContactInformation(newstatus, UserStatusCallback, null);
            }
        }

        private void UserStatusCallback(IAsyncResult ar)
        {
            if (!ar.IsCompleted) return;

            //do something
        }
    }
}
