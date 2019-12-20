using RemoteControl.Core.DTOs;
using RemoteControl.Core.Interfaces;
using System;

namespace RemoteControl.Server.ClientActions
{
    public class TerminalAction : IClientAction
    {
        public void Handle(ClientData clientData, Action<ServerData> send)
        {
            Console.WriteLine("Terminal control...");
        }
    }
}
