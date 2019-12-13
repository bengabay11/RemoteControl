using RemoteControl.Core.Interfaces;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RemoteControl.Server
{
    public class ServerManager : ISocketManager
    {
        private IServer _server;
        private readonly IFormatter _formatter;
        private readonly IDictionary<ClientActionType, IClientAction> _clientActions;
        private bool _stop;

        public ServerManager(IServer server, IDictionary<ClientActionType, IClientAction> clientActions, IFormatter formatter)
        {
            _server = server;
            _clientActions = clientActions;
            _formatter = formatter;
            _stop = false;
        }

        private void HandleClients()
        {
            while (!_stop)
            {
                Socket client = _server.Accept();
                ClientHandler clientHandler = new ClientHandler(client, _formatter, _clientActions);
                Task clientHandlerTask = new Task(clientHandler.Start);
                clientHandlerTask.Start();
            }
        }

        public void Start(string ip, int port, int maxConnections)
        {
            _server.Bind(ip, port);
            _server.Listen(maxConnections);
            Task.Factory.StartNew(HandleClients);
        }

        public void Stop()
        {
            _stop = true;
        }
    }
}
