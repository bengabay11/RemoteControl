using RemoteControl.Core.DTOs;
using RemoteControl.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace RemoteControl.Server
{
    public class ServerManager
    {
        private IServer _server;
        private readonly IFormatter _formatter;
        private readonly IDictionary<ClientAction, Action<ClientData, Action<ServerData>>> _clientActions;
        private bool _stop;

        public ServerManager(IServer server, IDictionary<ClientAction, Action<ClientData, Action<ServerData>>> clientActions, IFormatter formatter)
        {
            _server = server;
            _formatter = formatter;
            _clientActions = clientActions;
            _stop = false;
        }

        public void Start()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            while (!_stop)
            {
                Socket client = _server.Accept();
                ClientHandler clientHandler = new ClientHandler(client, binaryFormatter, _clientActions);
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
