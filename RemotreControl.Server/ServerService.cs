using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceProcess;
using RemoteControl.Core.Interfaces;
using RemoteControl.Server;
using RemoteControl.Server.ClientActions;

namespace RemotreControl.Server
{
    public partial class ServereService : ServiceBase
    {
        private readonly ServerManager _serverManager; 
        private readonly string _ip;
        private readonly int _port;
        private readonly int _maxConnections;

        public ServereService(string ip, int port, int maxConnections)
        {
            InitializeComponent();
            IDictionary<ClientActionType, IClientAction> clientActions = new Dictionary<ClientActionType, IClientAction>
            {
                { ClientActionType.executeCommand, new TerminalAction() }
            };
            IFormatter binaryFormatter = new BinaryFormatter();
            _serverManager = new ServerManager(clientActions, binaryFormatter);
            _ip = ip;
            _port = port;
            _maxConnections = maxConnections;
        }

        protected override void OnStart(string[] args)
        {
            _serverManager.Start(_ip, _port, _maxConnections);
        }

        protected override void OnStop()
        {
            _serverManager.Stop();
        }
    }
}
