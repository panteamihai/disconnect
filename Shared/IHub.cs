namespace Shared
{
    public interface IHub
    {
        void HandleMessageFromCaller(string input);
    }
}
