using RemoteControl.Core.Interfaces;
using System;
using System.Net.Sockets;

namespace RemoteControl.Server
{
    public class ClientHandler : IClientHandler
    {
        private Socket _socket;
        private bool _stop;

        public ClientHandler(Socket socket)
        {
            _socket = socket;
            _stop = false;
        }

        public void Start()
        {
            while (!_stop)
            {
                // TODO: Receive command to execute from the cliet and execute it.
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public byte[] Receive(int bufferSize)
        {
            throw new NotImplementedException();
        }

        public void Send(string message)
        {
            throw new NotImplementedException();
        }
    }
}
