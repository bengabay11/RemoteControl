using RemoteControl.Core.DTOs;
using System;

namespace RemoteControl.Core.Interfaces
{
    public interface IClientAction
    {
        void Handle(ClientData clientData, Action<ServerData> send);
    }
}
