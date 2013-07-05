using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UserFramework
{
    public interface IUserInfo
    {
        event EventHandler<UserInfoPropertyChangeEventArgs> PropertyChanged;
        INotification Notifier { get; set; }

        string Id { get; }
        string DisplayName { get; }
        string FisrtName { get; }
        string LastName { get; }
        Image Icon { get; }
        Image Photo { get; }
        UserStatus Status { get; }
    }

    public interface ISelfUserInfo : IUserInfo
    {
        new UserStatus Status { get;  set; }
    }
}
