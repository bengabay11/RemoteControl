using System.Net.Sockets;

namespace RemoteControl.Core.Interfaces
{
    public interface IServer
    {
        void Bind(string ip, int port);

        void Listen(int maxConnections);

        Socket Accept();
    }
}
