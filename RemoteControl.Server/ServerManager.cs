using RemoteControl.Core.Interfaces;
using System.Net.Sockets;

namespace RemoteControl.Server
{
    public class ServerManager
    {
        private IServer _server;
        private bool _stop;

        public ServerManager(IServer server)
        {
            _server = server;
            _stop = false;
        }

        public void Start()
        {
            while (!_stop)
            {
                Socket client = _server.Accept();
            }
        }

        public void Stop()
        {
            _stop = true;
        }
    }
}
