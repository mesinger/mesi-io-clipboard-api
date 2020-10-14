using System;

namespace Mesi.Io.Clipboard.Web.Models
{
    public class ClipboardEntryResponse
    {
        public ClipboardEntryResponse(string content, DateTime createdAt)
        {
            Content = content;
            CreatedAt = createdAt;
        }

        public string Content { get; }
        public DateTime CreatedAt { get; }
    }
}