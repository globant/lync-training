using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserFramework
{
    public static class ControlsHelper
    {
        public static void Invoke(this Control control, Action action)
        {
            if (action == null) return;

            Action invoker = (control.InvokeRequired)
                          ? () => control.Invoke(action as Delegate)
                          : action;

            invoker.Invoke();
        }
    }
}
