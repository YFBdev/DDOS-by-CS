using System;
using System.Net;
using System.Net.Sockets;

class Program {
    static void Main() {
        int number;
        Console.Write("服务器    |  Server: ");
        string serverIP = Console.ReadLine();
        while (true) {
            Console.Write("端口      |  Port  : ");
            string InputPort = Console.ReadLine();
            if (int.TryParse(InputPort, out number)) {
                int serverPort = Int32.Parse(InputPort);
                try {
                    TcpClient client = new TcpClient();
                    client.Connect(serverIP, serverPort);
                    Console.WriteLine("服务器连接成功  |  Connect success.");
                    try {
                        NetworkStream stream = client.GetStream();
                        Console.WriteLine("正在连接服务器  |  Client server.");
                        byte[] buffer = System.Text.Encoding.ASCII.GetBytes("DataDataDataDataDataData");
                        int count = 0;
                        while(true) {
                            try {
                                count++;
                                stream.Write(buffer, 0, 0);
                                Console.WriteLine("发了第" + count + "次包");
                            } catch (Exception e) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("在发送第" + count + "时发送问题" + e.Message);
                                Console.ResetColor();
                                continue;
                            }
                        }
                    } catch(Exception e) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("连接失败.      |  Unable to client to server.");
                        Console.ResetColor();
                    }
                } catch (Exception e) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("服务器连接失败  |  Unable to connect to server.");
                    Console.ResetColor();
                }
                break;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("端口不正确|  Invalid input");
                Console.ResetColor();
            }
        }
        
    }
}
