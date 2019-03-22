using RemoteControl.Core.DTOs;
using RemoteControl.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RemoteControl.Server
{
    public class ServerManager
    {
        private IServer _server;
        private readonly IFormatter _formatter;
        private readonly IDictionary<ClientActionType, IClientAction> _clientActions;
        private bool _stop;

        public ServerManager(IServer server, IDictionary<ClientActionType, IClientAction> clientActions, IFormatter formatter)
        {
            _server = server;
            _formatter = formatter;
            _clientActions = clientActions;
            _stop = false;
        }

        public void Start()
        {
            while (!_stop)
            {
                Socket client = _server.Accept();
                ClientHandler clientHandler = new ClientHandler(client, _formatter, _clientActions);
                Task clientHandlerTask = new Task(clientHandler.Start);
                clientHandlerTask.Start();
            }
        }

        public void Stop()
        {
            _stop = true;
        }
    }
}
