using System;
using System.Threading;

namespace BugEnterKey01
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var t1 = new Thread(Reader);
            t1.IsBackground = false;
            t1.Start();
            t1.Join();
        }

        private static void Reader()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    Console.WriteLine($"Key info: char={(int)key.KeyChar}; recognized key={key.Key}");
                    
                    if(key.Key == ConsoleKey.Escape)
                        break;
                }
                
                Thread.Sleep(100);
            }
        }
    }
}