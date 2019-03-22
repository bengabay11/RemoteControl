using RemoteControl.Core.DTOs;
using RemoteControl.Core.Interfaces;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace RemoteControl.Client
{
    public class Client : IClient
    {
        private NetworkStream _networkStream;
        private IFormatter _formatter;

        public Client(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public void Connect(string ip, int port)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);
            _networkStream = new NetworkStream(socket);
        }

        public ServerData Receive()
        {
            return (ServerData)_formatter.Deserialize(_networkStream);
        }

        public void Send(ClientData data)
        {
            _formatter.Serialize(_networkStream, data);
        }
    }
}
