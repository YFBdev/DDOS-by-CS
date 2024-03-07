using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.Write("Address: ");
        string serverIP = Console.ReadLine();

        int serverPort;
        while (true)
        {
            Console.Write("Port: ");
            if (int.TryParse(Console.ReadLine(), out serverPort) && serverPort >= 0 && serverPort <= 65536) break;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ResetColor();
            }
        }

        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        await socket.ConnectAsync(serverIP, serverPort);

        while (true)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes("DataDataDataDataDataDataDataDataDataDataDataDataDataDataDataData");
                await socket.SendAsync(data, SocketFlags.None);
                Console.WriteLine("OK");
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                await socket.ConnectAsync(serverIP, serverPort);
            }
        }
    }
}
