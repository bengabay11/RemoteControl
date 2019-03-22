using RemoteControl.Core.DTOs;

namespace RemoteControl.Core.Interfaces
{
    public interface IClientHandler
    {
        void Start();

        void Stop();

        void Send(ServerData data);

        ClientData Receive();
    }
}
