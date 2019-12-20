using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl.Core.Abstracts
{
    public abstract class ServerBase
    {
        private Socket _socket;

        protected void Bind(string ip, int port)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
            _socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(localEndPoint);
        }

        protected void Listen(int maxConnections)
        {
            _socket.Listen(maxConnections);
        }

        protected Socket Accept()
        {
            return _socket.Accept();
        }

        public abstract void Start(string ip, int port, int maxConnections);

        public abstract void Stop();
    }
}
