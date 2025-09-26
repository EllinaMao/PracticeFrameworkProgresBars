using System;
using System.Threading;
using System.Windows.Forms;

namespace PracticeFramework
{
    public class TaskProgressBar
    {
        private static Random rnd = new Random();
        public static void StartProgressBar(SynchronizationContext ctx, FlowLayoutPanel flow)
        {
            Action<SynchronizationContext, ProgressBar, int> action = SetProgressBar;

            foreach (Control ctrl in flow.Controls)
            {
                if (ctrl is ProgressBar pb)
                {
                    action.BeginInvoke(ctx, pb, 10000, null, null);
                }

            }
        }
        private static void SetProgressBar(SynchronizationContext ctx, ProgressBar pb, int count)
        {
            int number = 0;

            for (int i = 0; i < count; i++)
            {
                lock (ctx)
                {
                    number = rnd.Next(0, 100);
                    ctx.Send(s => pb.Value = number, null);
                    Thread.Sleep(100);
                }

            }
        }
    }
}
