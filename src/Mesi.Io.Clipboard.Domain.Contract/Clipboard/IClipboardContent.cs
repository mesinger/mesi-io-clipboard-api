namespace Mesi.Io.Clipboard.Domain.Contract.Clipboard
{
    /// <summary>
    /// Representation of content that was stored in a clipboard
    /// </summary>
    public interface IClipboardContent
    {
        /// <summary>
        /// Holds the text value of a clipboard entry
        /// </summary>
        public string Text { get; }
    }
}