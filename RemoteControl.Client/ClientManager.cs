using RemoteControl.Core.Interfaces;
using System;

namespace RemoteControl.Client
{
    public class ClientManager : ISocketManager
    {
        private IClient _client;
        private bool _stop;

        public ClientManager(IClient client)
        {
            _client = client;
            _stop = false;
        }

        public void Start()
        {
            while (!_stop)
            {
                Console.WriteLine("What do you want to do?");
                string option = Console.ReadLine();
            }
        }

        public void Stop()
        {
            _stop = true;
        }
    }
}
