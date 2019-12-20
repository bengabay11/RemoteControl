using RemoteControl.Core.Abstracts;
using RemoteControl.Core.Interfaces;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RemoteControl.Server
{
    public class ServerManager : ServerBase
    {
        private readonly IFormatter _formatter;
        private readonly IDictionary<ClientActionType, IClientAction> _clientActions;
        private bool _stop;

        public ServerManager(IDictionary<ClientActionType, IClientAction> clientActions, IFormatter formatter)
        {
            _clientActions = clientActions;
            _formatter = formatter;
            _stop = false;
        }

        private void HandleClients()
        {
            while (!_stop)
            {
                Socket clientSocket = Accept();
                ClientHandler clientHandler = new ClientHandler(clientSocket, _formatter, _clientActions);
                Task.Factory.StartNew(clientHandler.Start);
            }
        }

        public override void Start(string ip, int port, int maxConnections)
        {
            Bind(ip, port);
            Listen(maxConnections);
            HandleClients();
        }

        public override void Stop()
        {
            _stop = true;
        }
    }
}
