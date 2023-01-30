namespace Clients.Core.Interfaces
{
    public interface IEmail
    {
        Task SendEmail(string from, List<string?> to, string fileName, string path);
    }
}
