namespace Shared
{
    public interface IClient
    {
        void HandleMessageFromServer(string message);
    }
}
