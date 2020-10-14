using System;
using CSharpFunctionalExtensions;

namespace Mesi.Io.Clipboard.Domain.Clipboard.Models
{
    /// <summary>
    /// A clipboard entry containing its user, content and timestamp
    /// </summary>
    public class ClipboardEntry
    {
        protected ClipboardEntry(string id, string userId, ClipboardContent content, DateTime createdAt, int contentMaxLength)
        {
            Id = id;
            UserId = UserId;
            Content = content;
            CreatedAt = createdAt;
            ContentMaxLength = contentMaxLength;
        }

        public static ClipboardEntry Create(string userId, string content, DateTime timeStamp)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException($"UserId cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException($"Clipboard content cannot be empty.");
            }
            
            const int contentMaxLength = 500;

            if (content.Length > contentMaxLength)
            {
                throw new ArgumentException($"Clipboard content exceeds limit of '{contentMaxLength}' characters.");
            }
            
            return new ClipboardEntry(Guid.NewGuid().ToString(), userId, ClipboardContent.Create(content), timeStamp, contentMaxLength);
        }

        public string Id { get; }
        // public ClipboardServiceUser User { get; }
        public string UserId { get; }
        public ClipboardContent Content { get; }
        public DateTime CreatedAt { get; }
        public int ContentMaxLength { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Clipboard Entry '{Id}': User '{UserId}' on '{CreatedAt}': '{Content.Content}'";
        }
    }
}