using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace Server
{
    [HubName(Shared.Hub.Name)]
    public class ServiceHub : Hub, IHub
    {
        public void DetermineLength(string message)
        {
            Console.WriteLine(message);
            Clients.Caller.ReceiveLength($@"<<{message}>> has a length of: {message.Length}");
        }
    }
}
