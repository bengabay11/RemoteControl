using System.Runtime.Serialization.Formatters.Binary;

namespace RemoteControl.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Client client = new Client(binaryFormatter);
            client.Connect(Properties.Settings.Default.ServerIp, Properties.Settings.Default.ServerPort);
            ClientManager clientManager = new ClientManager(client);
            clientManager.Start();
        }
    }
}
