using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserFramework
{
    public class UserInfoPropertyChangeEventArgs : EventArgs
    {
        public UserInfoPropertyChangeEventArgs(IEnumerable<UserPorpertyInfo> props)
        {
            _Properties = props;
        }

        private IEnumerable<UserPorpertyInfo> _Properties;
        public IEnumerable<UserPorpertyInfo> Properties { get { return _Properties; } }
    }
}
