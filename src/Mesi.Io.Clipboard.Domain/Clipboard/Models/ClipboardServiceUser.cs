namespace Mesi.Io.Clipboard.Domain.Clipboard.Models
{
    /// <summary>
    /// A user that consumes clipboard services
    /// </summary>
    public class ClipboardServiceUser
    {
        protected ClipboardServiceUser(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
        
        public static ClipboardServiceUser Create(string id) => new ClipboardServiceUser(id);
    }
}