using RemoteControl.Core.DTOs;
using System;

namespace RemoteControl.Core.Interfaces
{
    public interface IClientAction
    {
        void Act(ClientData clientData, Action<ServerData> send);
    }
}
