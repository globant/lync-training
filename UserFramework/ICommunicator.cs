using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserFramework
{
    public interface ICommunicator
    {
        event EventHandler<UserAddedEventArgs> UserAdded;
        event EventHandler SignIn;
        event EventHandler SignOut;
        void Login(string userUri, string password);
        void Disconnect();
        void LoadUsers();
        ISelfUserInfo Self { get; }
    }
}
