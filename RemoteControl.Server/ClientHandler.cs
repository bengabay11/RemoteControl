using RemoteControl.Core.DTOs;
using RemoteControl.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace RemoteControl.Server
{
    public class ClientHandler : IClientHandler
    {
        private readonly NetworkStream _networkStream;
        private IFormatter _formatter;
        private readonly IDictionary<ClientActionType, Action<ClientData, Action<ServerData>>> _clientActions;
        private bool _stop;

        public ClientHandler(Socket socket, IFormatter formatter, IDictionary<ClientActionType, Action<ClientData, Action<ServerData>>> clientActions)
        {
            _networkStream = new NetworkStream(socket);
            _formatter = formatter;
            _clientActions = clientActions;
            _stop = false;
        }

        public void Start()
        {
            while (!_stop)
            {
                ClientData clientData = Receive();
                foreach (KeyValuePair<ClientActionType, Action<ClientData, Action<ServerData>>> clientAction in _clientActions)
                {
                    if (clientData.Action == clientAction.Key)
                    {
                        clientAction.Value(clientData, Send);
                    }
                }
            }
        }

        public void Stop()
        {
            _stop = true;
        }

        public ClientData Receive()
        {
            return (ClientData)_formatter.Deserialize(_networkStream);
        }

        public void Send(ServerData data)
        {
            _formatter.Serialize(_networkStream, data);
        }
    }
}
