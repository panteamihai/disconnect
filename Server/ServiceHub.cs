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
            var identity = Context.User?.Identity;

            Console.WriteLine($"From {identity?.Name} (auth: {identity?.IsAuthenticated}): {message}");
            Clients.Caller.HandleMessageFromServer($"<<{message}>> has a length of: {message.Length}");
        }

        public void HandleLoginFromCaller(string username, string password)
        {
            Console.WriteLine($"Logging in user {username}");
            Clients.Caller.HandleMessageFromServer("Logged in");
        }

        [Authorize]
        public string AuthorizedString()
        {
            return "You are successfully Authorized";
        }
    }
}
