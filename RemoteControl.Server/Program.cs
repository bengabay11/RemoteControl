using RemoteControl.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace RemoteControl.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Init the server
            Server server = new Server();
            server.Bind(Properties.Settings.Default.ip, Properties.Settings.Default.port);
            server.Listen(Properties.Settings.Default.maxConnections);

            // Init the server Manager
            Dictionary<ClientActionType, IClientAction> clientActions = new Dictionary<ClientActionType, IClientAction>();
            // TODO: create client actions and add them to the dictionary.
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            ServerManager serverManager = new ServerManager(server, clientActions, binaryFormatter);

            Console.WriteLine(string.Format(Properties.Settings.Default.listeningMessage, Properties.Settings.Default.port));
            serverManager.Start();
        }
    }
}
