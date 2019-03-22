using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl.Core.DTOs
{
    public class ServerData
    {
        public ServerActionType Action { get; set; }
        public string Data { get; set; }
            
        public ServerData(ServerActionType action, string data)
        {
            Action = action;
            Data = data;
        }
    }
}
