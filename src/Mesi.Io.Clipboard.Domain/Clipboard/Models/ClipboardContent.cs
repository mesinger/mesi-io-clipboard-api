namespace Mesi.Io.Clipboard.Domain.Clipboard.Models
{
    /// <summary>
    /// Representation of content that was stored in a clipboard
    /// </summary>
    public class ClipboardContent
    {
        protected ClipboardContent(string content)
        {
            Content = content;
        }

        public string Content { get; }
        
        public static ClipboardContent Create(string content) => new ClipboardContent(content);
        public static ClipboardContent Empty() => new ClipboardContent(string.Empty);
    }
}