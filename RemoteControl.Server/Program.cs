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
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            ServerManager serverManager = new ServerManager(server, null, binaryFormatter);
            serverManager.Start();
        }
    }
}
