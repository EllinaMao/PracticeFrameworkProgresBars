using System;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;

namespace FormMain
{
    /*
     * Завдання 1
Створіть віконний додаток, що генерує набір простих чисел у діапазоні, зазначеному користувачем. Якщо не вказано нижню межу, потік з стартує з 2. Якщо не вказано верхню межу, генерування відбувається до завершення програми. Використовуйте механізм потоків. Числа повинні відображатися у віконному інтерфейсі.
    */
    public static class ThreadNumberTask
    {


        public static void Generate(ListBox box, int start, int end)
        {
            /*QueueUserWorkItem<TState>(Action<TState>, TState, Boolean)	
             *Помещает метод, определенный делегатом Action<T>, в очередь на выполнение и указывает данные для этого метода. Метод выполняется, когда становится доступен поток из пула потоков.
            https://learn.microsoft.com/ru-ru/dotnet/api/system.threading.threadpool?view=net-8.0      
            господи как я замучалась
            */
            ThreadPool.QueueUserWorkItem(_ =>
            {
                int a = 0, b = 1;
                int lastAdded = -1;

                while (a <= end)
                {
                    if (a >= start && a != lastAdded)
                    {
                        int current = a;
                        box.BeginInvoke(new Action(() =>
                        {
                            box.Items.Add(current);
                        }));
                        lastAdded = a;
                    }

                    int temp = a + b;
                    a = b;
                    b = temp;

                    Thread.Sleep(100);
                }
            });
        }



    }
}




