using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Task2;

namespace PracticeFramework
{
    public static class TaskProgressBar
    {
        private static CancellationTokenSource cts;
        private static List<string> finishOrder = new List<string>();
        public static event EventHandler<EventEventArgs> finish;
        private static readonly Random rnd = new Random(); // один общий Random

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

            while (number < max && !cts.Token.IsCancellationRequested)
            {
                number += rnd.Next(1, 20);
                if (number > max) number = max;

                ctx.Send(_ => pb.Value = number, null);
                Thread.Sleep(1000);

                if (number >= max)
                {
                    WinCheck(ctx, pb);
                }
            }
        }

        private static void WinCheck(SynchronizationContext ctx, ProgressBar pb)
        {
            lock (finishOrder)
            {
                string horseName = pb.Tag?.ToString() ?? pb.Name;

                if (!finishOrder.Contains(horseName)) // чтобы не было дублей
                {
                    finishOrder.Add(horseName);
                    int place = finishOrder.Count;

                    // Отправляем событие наружу (для DataGridView)
                    finish?.Invoke(null, new EventEventArgs(horseName, place));

                    // Если все добежали — показываем победителя
                    if (finishOrder.Count == 5)
                    {
                        ctx.Send(_ => MessageBox.Show($"{finishOrder[0]} победил!"), null);
                        StopRace();
                    }
                }
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

