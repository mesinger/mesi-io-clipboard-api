using System;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard;

namespace Mesi.Io.Clipboard.Domain.Clipboard.Models
{
    /// <inheritdoc />
    public class ClipboardEntry : IClipboardEntry
    {
        protected ClipboardEntry(string id, IClipboardServiceUser creator, IClipboardContent content, DateTime timeStamp, int contentMaxLength)
        {
            Id = id;
            Creator = creator;
            Content = content;
            TimeStamp = timeStamp;
            ContentMaxLength = contentMaxLength;
        }

        public static ClipboardEntry New(string userId, string content, DateTime timeStamp)
        {
            const int contentMaxLength = 500;
            ThrowOnInvalidArguments(userId, content, contentMaxLength);
            return new ClipboardEntry(Guid.NewGuid().ToString(), ClipboardServiceUser.Create(userId), ClipboardContent.Create(content), timeStamp, contentMaxLength);
        }

        public static ClipboardEntry Create(string id, string userId, string content, DateTime timeStamp, int contentMaxLength)
        {
            ThrowOnInvalidArguments(userId, content, contentMaxLength);

            if (!Guid.TryParse(id, out var guid))
            {
                throw new ArgumentException("Id '{id}' for clipboard entry is not a valid guid", id);
            }
            
            return new ClipboardEntry(id, ClipboardServiceUser.Create(userId), ClipboardContent.Create(content), timeStamp, contentMaxLength);
        }

        /// <inheritdoc />
        public string Id { get; }

        /// <inheritdoc />
        public IClipboardServiceUser Creator { get; }

        /// <inheritdoc />
        public IClipboardContent Content { get; }

        /// <inheritdoc />
        public DateTime TimeStamp { get; }
        
        /// <inheritdoc />
        public int ContentMaxLength { get; }

        private static void ThrowOnInvalidArguments(string userId, string content, int contentMaxLength)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException($"UserId cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException($"Clipboard content cannot be empty.");
            }

            if (content.Length > contentMaxLength)
            {
                throw new ArgumentException($"Clipboard content exceeds limit of '{contentMaxLength}' characters.");
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Clipboard Entry '{Id}': User '{Creator.UserId}' on '{TimeStamp}': '{Content.Text}'";
        }
    }
}