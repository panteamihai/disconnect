namespace Shared
{
    public interface IHub
    {
        void HandleMessageFromCaller(string input);

        void HandleLoginFromCaller(string username, string password);
    }
}
