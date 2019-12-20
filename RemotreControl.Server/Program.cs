using RemoteControl.Core.Interfaces;
using RemoteControl.Server;
using RemoteControl.Server.ClientActions;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceProcess;

namespace RemotreControl.Server
{
    static class Program
    {
        public static void Main()
        {
            IDictionary<ClientActionType, IClientAction> clientActions = new Dictionary<ClientActionType, IClientAction>
            {
                { ClientActionType.executeCommand, new TerminalAction() }
            };
            IFormatter binaryFormatter = new BinaryFormatter();
            ServerManager serverManager = new ServerManager(clientActions, binaryFormatter);
            string listeningMessage = string.Format("Listening on port {0}...", Properties.Settings.Default.port);
            System.Console.WriteLine(listeningMessage);
            serverManager.Start(Properties.Settings.Default.ip, Properties.Settings.Default.port, Properties.Settings.Default.maxConnections);
        }
    }
}
