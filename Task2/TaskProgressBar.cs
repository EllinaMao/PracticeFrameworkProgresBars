using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace PracticeFramework
{
    public static class TaskProgressBar
    {
        private static CancellationTokenSource cts;
        private static List<string> finishOrder = new List<string>();

        public static void StartProgressBar(SynchronizationContext ctx, TableLayoutPanel tb)
        {
            finishOrder.Clear();
            Action<SynchronizationContext, ProgressBar, int> action = SetProgressBar;
            cts = new CancellationTokenSource();

            foreach (Control control in tb.Controls)
            {
                if (control is ProgressBar pb)
                {
                    pb.Value = 0; 
                    action.BeginInvoke(ctx, pb, 100, null, null); //100 это максимум для прогрессбаров
      
                }
                
            }
            
        }
        private static void SetProgressBar(SynchronizationContext ctx, ProgressBar pb, int max)
        {
            int number = 0;

            while (number < max && cts.Token.IsCancellationRequested != true)
            {
                lock(cts){

                    Random rnd = new Random();
                    number += rnd.Next(1, 20);
                    if (number > max)
                    {
                        number = max;
                    }
                    ctx.Send(s => pb.Value = number, null);
                    Thread.Sleep(100);
                }

                WinCheck(ctx, pb, number, max);
                

            }

        }

        private static void WinCheck(SynchronizationContext ctx, ProgressBar pb, int number, int max)
        {
            if (number >= max && cts.Token.IsCancellationRequested != true)
            {
                lock (cts)
                {
                    finishOrder.Add(pb.Name);
                    cts.Cancel();
                    ctx.Send(message => MessageBox.Show($"{pb.Name} победил!"), null);
                }
                    StopRace();
            }
        }

        private static void StopRace()
        {
            if (cts != null)
            {
                cts.Cancel();
                cts.Dispose(); 
                cts = null;    
            }
        }



    }
}

