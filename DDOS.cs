using System;
using System.Net;
using System.Net.Sockets;

class Program {
    static void Main() {
        Console.Write("服务器: ");
        string serverIP = Console.ReadLine();
        Console.Write("端口: ");
        int serverPort = Int32.Parse(Console.ReadLine());
        Console.WriteLine("服务器地址读取成功...");
        TcpClient client = new TcpClient();
        client.Connect(serverIP, serverPort);
        Console.WriteLine("服务器连接成功...");
        NetworkStream stream = client.GetStream();
        Console.WriteLine("正在准备...");
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes("DataDataDataDataDataData");
        int count = 0;
        while(true) {
            count++;
            stream.Write(buffer, 0, 0);
            Console.WriteLine("发了第" + count + "次包");
        }
    }
}
