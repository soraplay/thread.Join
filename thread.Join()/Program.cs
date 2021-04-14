﻿using System;
using System.Threading;

namespace thread.Join__
{
    class Program
    {
        static void Function()
        {
            Console.WriteLine("ID Вторичного потока: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 160; i++)
            {
                Thread.Sleep(20);
                Console.Write('-');
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nВторичный поток завершился.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("ID Первичного потока: {0}", Thread.CurrentThread.GetHashCode());

            // Создание нового потока
            Thread thread = new Thread(new ThreadStart(Function));
            thread.Start();

            // Ожидание первичным потоком, завершения работы вторичного потока.
            thread.Join();

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 160; i++)
            {
                Thread.Sleep(20);
                Console.Write('=');
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nПервичный поток завершился.");

            // Delay
            Console.ReadKey();
        }
    }
}
