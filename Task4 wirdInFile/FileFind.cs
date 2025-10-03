using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4_wirdInFile
{
    public static class FileFind
    {
        public static void FindCountWord(SynchronizationContext ctx, string word, string path, Label label)
        {

            Action<SynchronizationContext, int, Label> action = UiUpdate;
            Action<SynchronizationContext, Label, string> action2 = UiUpdate;
            ThreadPool.QueueUserWorkItem(th =>
            {
                try
                {
                    int bytesRead = 0;
                    var buffer = ReadFile(path, out bytesRead);

                    int count = CountWord(word, buffer, bytesRead);

                    action.BeginInvoke(ctx, count, label, null, null);
                }

                catch (Exception ex)
                {
                    action2.BeginInvoke(ctx, label, ex.Message, null, null);
                }
            });
        }

        private static int CountWord(string word, byte[] buffer, int readedBytes/*, Regex pattern*/)
        {
            Regex pattern = new Regex(@"\b" + Regex.Escape(word) + @"\b", RegexOptions.IgnoreCase);
            string content = System.Text.Encoding.UTF8.GetString(buffer, 0, readedBytes);

            int count = pattern.Matches(content).Count;
            return count;
        }

        private static byte[] ReadFile(string path, out int bytesRead)
        {
            /*Для виправлення цієї ситуації необхідно прочитати вміст файлу асинхронно. Для цього створюємо об'єкт System.IO.FileStream, використовуючи перевантаження конструктора, в якому є параметр System.IO.FileOptions. У цьому параметрі потрібно вказати прапор FileOptions.Asynchronous, який повідомляє об'єкту FileStream, що потрібно виконати асинхронну операцію читання та запису у файлі.*/
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous))
            {

                byte[] buffer = new byte[fs.Length];
                // Початок асинхронної операції читання з файлу FileStream. 
                //IAsyncResult 
                var readedBytes = fs.BeginRead(buffer, 0, buffer.Length, null, null);
                // Summary:
                //     Gets a System.Threading.WaitHandle that is used to wait for an asynchronous operation
                //     to complete.
                // Returns:
                //     A System.Threading.WaitHandle that is used to wait for an asynchronous operation
                //     to complete.
                readedBytes.AsyncWaitHandle.WaitOne();
                bytesRead = fs.EndRead(readedBytes);
                return buffer;

            }
        }
        public static void CountWordInDirectory(SynchronizationContext ctx, string directoryPath, string word, DataGridView dataGrid)
        {
            Action<SynchronizationContext, string, string, int, DataGridView> action = UiUpdate;
            Action<SynchronizationContext, string> error = UiUpdate;

            var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                try
                {
                    int bytecount;
                    var buffer = ReadFile(file, out bytecount);
                    int count = CountWord(word, buffer, bytecount);
                    if (count > 0)
                    {
                        action.BeginInvoke(ctx, Path.GetFileName(file), Path.GetFullPath(file), count, dataGrid, null, null);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    //ignore
                }
                catch (Exception ex)
                {
                    error.BeginInvoke(ctx, ex.Message, null, null);
                }
            }

        }
        private static void UiUpdate(SynchronizationContext ctx, int count, Label label)
        {
            ctx.Post(l =>
            {
                label.Text = $"{count}";
            }, null);

        }
        private static void UiUpdate(SynchronizationContext ctx, Label label, string message)
        {
            ctx.Post(_ =>
            {
                label.Text = message;
            }, null);
        }
        private static void UiUpdate(SynchronizationContext ctx, string fileName, string filePath, int count, DataGridView DG)
        {
            ctx.Post(dg =>
            {
                DG.Rows.Add(fileName, filePath, count);
            }, null);

        }
        private static void UiUpdate(SynchronizationContext ctx, string message)
        {
            ctx.Post(_ =>
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
            }, null);
        }
















    }
}