using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl.Core.DTOs
{
    public class ClientData
    {
        public ClientAction Action { get; set; }
        public string Data { get; set; }

        public ClientData(ClientAction action, string data)
        {
            Action = action;
            Data = data;
        }
    }
}
