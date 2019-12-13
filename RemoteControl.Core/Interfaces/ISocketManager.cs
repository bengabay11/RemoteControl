using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl.Core.Interfaces
{
    public interface ISocketManager
    {
        void Start(string ip, int port, int maxConnections);

        void Stop();
    }
}
