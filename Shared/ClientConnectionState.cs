namespace Shared
{
    public enum ClientConnectionState
    {
        Unauthenticated, //dump any chat messages
        Authenticating, //buffer messages
        Authenticated //deliver
    }
}
