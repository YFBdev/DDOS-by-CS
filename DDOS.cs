using System;
using System.Net;
using System.Net.Sockets;

class Program {
    public static void Main() {
        string serverIP;
        int serverPort;
        int count = 0;
        Console.Write("服务器    |  Server: ");//要求输入服务寄地址
        serverIP = Console.ReadLine();
        while (true) {//要求输入端口,并检测
            Console.Write("端口      |  Port  : ");
            if (int.TryParse(Console.ReadLine(), out serverPort)) {
                break;
            } else {//处理端口输入是否正确
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("端口不正确|  Invalid input");
                Console.ResetColor();
            }
        }
        reclient:
        TcpClient client = new TcpClient();//定义tpc连接
        try {
            client.Connect(serverIP, serverPort);//连接服务器
            Console.WriteLine("服务器连接成功  |  Connect success.");
        } catch (Exception e) {//还是处理连接错误
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("服务器连接失败  |  Unable to connect to server.");
            Console.ResetColor();
        }
        NetworkStream stream = client.GetStream();//获取流
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes("DataDataDataDataDataData");
        while (true) {//开始发包
            count++;
            try {
                stream.Write(buffer, 0, buffer.Length);
                Console.Write("发了第" + count + "次包");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("成功");
                Console.ResetColor();
            } catch (Exception e) {//处理错误
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("在发送第" + count + "时发送问题" + e.Message);
                Console.ResetColor();
                goto reclient;
            }
        }
    }
}
//综上所述,祝你生活愉快,再见～
