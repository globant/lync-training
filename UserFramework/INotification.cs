using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserFramework
{
    public interface INotification
    {
        void Notify(string title, string msg, Severity severity);
    }

    public enum Severity
    {
        None,
        Info,
        Warning,
        Error
    }

    public class NotificationHelper
    {
        public static void Notify(INotification notifier, string title, string msg, Severity severity)
        {
            if (notifier != null)
                notifier.Notify(title, msg, severity);
        }
    }
}
