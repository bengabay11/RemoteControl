using RemoteControl.Core.Interfaces;
using System.Net;
using System.Net.Sockets;

namespace RemoteControl.Server
{
    public class Server : IServer
    {
        private Socket _socket;

        public void Bind(string ip, int port)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
            _socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(localEndPoint);
        }

        public void Listen(int maxConnections)
        {
            _socket.Listen(maxConnections);
        }

        public Socket Accept()
        {
            return _socket.Accept();
        }
    }
}
