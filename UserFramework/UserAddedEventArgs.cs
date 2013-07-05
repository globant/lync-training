using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserFramework
{
    public class UserAddedEventArgs : EventArgs
    {
        public UserAddedEventArgs(IUserInfo userinfo)
        {
            _UserInfo = userinfo;
        }

        private IUserInfo _UserInfo;
        public IUserInfo UserInfo { get { return _UserInfo; } }
    }
}
