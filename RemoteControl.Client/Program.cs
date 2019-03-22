using System.Runtime.Serialization.Formatters.Binary;

namespace RemoteControl.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Client client = new Client(binaryFormatter);
            client.Connect("127.0.0.1", 8820);
            ClientManager clientManager = new ClientManager(client);
            clientManager.Start();
        }
    }
}
