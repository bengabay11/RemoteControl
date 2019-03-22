using System;

namespace RemoteControl.Core.DTOs
{
    [Serializable]
    public class ClientData
    {
        public ClientActionType Action { get; set; }
        public string Data { get; set; }

        public ClientData(ClientActionType action, string data)
        {
            Action = action;
            Data = data;
        }
    }
}
