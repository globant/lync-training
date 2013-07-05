using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserFramework;
using Lync;

namespace CommunicatorFactory
{
    public static class CommFactory
    {
        public static INotification Notifier { get; set; }

        public static ICommunicator GetCommunicator()
        {
            GlobantLyncClient.Notifier = Notifier;
            return GlobantLyncClient.GetInstance();
        }
    }
}
