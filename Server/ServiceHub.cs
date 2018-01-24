using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace Server
{
    [HubName(Shared.Hub.Name)]
    public class ServiceHub : Hub, Shared.IHub
    {
        public void HandleMessageFromCaller(string message)
        {
            Console.WriteLine(message);
            Clients.Caller.HandleMessageFromServer($@"<<{message}>> has a length of: {message.Length}");
        }
    }
}
