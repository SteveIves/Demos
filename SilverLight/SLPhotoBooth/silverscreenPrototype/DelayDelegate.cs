using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace silverscreenPrototype
{
    public class DelayDelegate
    {
        static public void Queue(TimeSpan delay, Action action)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = delay;
            timer.Tick += new EventHandler(delegate(object sender, EventArgs e)
                {
                    (sender as DispatcherTimer).Stop();
                    action.Invoke();
                });
            timer.Start();
        }
    }
}
