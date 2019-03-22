using RemoteControl.Core.DTOs;
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
                Console.WriteLine("1) Terminal");
                string option = Console.ReadLine();
                try
                {
                    if (int.Parse(option) == 1)
                    {
                        _client.Send(new ClientData(ClientActionType.executeCommand, string.Empty));
                    }
                }
                catch (FormatException)
                {

                }
            }
        }

        public void Stop()
        {
            _stop = true;
        }
    }
}
