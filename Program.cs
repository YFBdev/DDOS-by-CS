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
    static async Task Main()
    {
        Console.Clear();
        Console.Write("服务器 |  Server: ");
        bool isDomainName = false;
        string DomainPattern = @"^(?:[a-zA-Z0-9](?:[a-zA-Z0-9]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z0-9]{0,}$";
        Regex ymregex = new Regex(DomainPattern);
        while (!isDomainName)
        {
            IP = Console.ReadLine();
            isDomainName = ymregex.IsMatch(IP);
            if (!isDomainName)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n非法地址 | Invalid input");
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
                Console.WriteLine("\n非法端口 | Invalid input");
                Console.ResetColor();
            }
        }
        for (int i = 0; i < 16; i++)
        {
            Console.WriteLine("Thread\u0020"+i+"\u0020starts.");
            Task.Run(() =>
            {
                socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(IP, Port);
                while (true)
                {
                    Thread.Sleep(10);
                    Task.Run(() =>
                    {
                        byte[] data = Encoding.UTF8.GetBytes("DataDataDataDataDataDataDataData");
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
            });
        }
        while(true) {
            Task.WaitAll();
        }
    }
}
