using Mesi.Io.Clipboard.Domain.Contract.Clipboard;

namespace Mesi.Io.Clipboard.Domain.Clipboard.Models
{
    /// <inheritdoc />
    public class ClipboardContent : IClipboardContent
    {
        protected ClipboardContent(string content)
        {
            Text = content;
        }

        public static ClipboardContent Create(string content) => new ClipboardContent(content);
        public static ClipboardContent Empty() => new ClipboardContent(string.Empty);

        /// <inheritdoc />
        public string Text { get; }
    }
}