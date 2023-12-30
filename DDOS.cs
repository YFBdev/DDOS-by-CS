using System;
using System.Net;
using System.Net.Sockets;

class Program {
    static void Main() {
        string serverIP = "IP";
        int serverPort = 443;
        TcpClient client = new TcpClient();
        client.Connect(serverIP, serverPort);
        NetworkStream stream = client.GetStream();
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes("DataDataDataDataDataData");
        int count = 0;
        while(true) {
            count++;
            stream.Write(buffer, 0, 0);
            Console.WriteLine("发了第" + count + "次包");
        }
    }
}