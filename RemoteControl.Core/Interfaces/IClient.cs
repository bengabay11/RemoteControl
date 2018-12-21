namespace RemoteControl.Core.Interfaces
{
    public interface IClient
    {
        void Connect(string ip, int port);

        void Send(string message);

        byte[] Receive(int bufferSize);
    }
}
