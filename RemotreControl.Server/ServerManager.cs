using RemoteControl.Core.DTOs;
using RemoteControl.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RemoteControl.Server
{
    public class ServerManager : ISocketManager
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

        private void HandleClients(IServer server)
        {
            while (!_stop)
            {
                Socket client = server.Accept();
                ClientHandler clientHandler = new ClientHandler(client, _formatter, _clientActions);
                Task clientHandlerTask = new Task(clientHandler.Start);
                clientHandlerTask.Start();
            }
        }

        public void Start(string ip, int port, int maxConnections)
        {
            IServer server = new Server();
            server.Bind(ip, port);
            server.Listen(maxConnections);
            Task.Factory.StartNew(() => HandleClients(server));
        }

        public void Stop()
        {
            _stop = true;
        }
    }
}
