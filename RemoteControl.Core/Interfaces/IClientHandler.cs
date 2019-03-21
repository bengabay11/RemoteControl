namespace RemoteControl.Core.Interfaces
{
    public interface IClientHandler
    {
        void Start();

        void Stop();

        void Send(string message);

        byte[] Receive(int bufferSize);
    }
}
