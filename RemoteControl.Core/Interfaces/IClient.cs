using RemoteControl.Core.DTOs;

namespace RemoteControl.Core.Interfaces
{
    public interface IClient
    {
        void Connect(string ip, int port);

        void Send(ClientData data);

        ServerData Receive();
    }
}
