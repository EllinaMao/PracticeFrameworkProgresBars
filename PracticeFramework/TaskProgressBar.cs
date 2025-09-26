using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeFramework
{
    public class TaskProgressBar
    {
        private static Random rnd = new Random();
        public static void StartProgressBar(SynchronizationContext ctx, ProgressBar pb1, ProgressBar pb2, ProgressBar pb3)
        {
            Action<SynchronizationContext, ProgressBar, int> action = SetProgressBar;
            var arr1 = action.BeginInvoke(ctx, pb1, 10000, null, null);
            var arr2 = action.BeginInvoke(ctx, pb2, 10000, null, null);
            var arr3 = action.BeginInvoke(ctx, pb3, 10000, null, null);


            //action.EndInvoke(arr1);
            //action.EndInvoke(arr2);
            //action.EndInvoke(arr3);
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
