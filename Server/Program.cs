using Microsoft.Owin.Hosting;
using System;

namespace Server
{
    public class Program
    {
        static void Main()
        {
            using (WebApp.Start<Startup>(Shared.Hub.Url))
            {
                Console.WriteLine($"Server is running at {Shared.Hub.Url}");
                Console.ReadLine();
            }
        }
    }
}
