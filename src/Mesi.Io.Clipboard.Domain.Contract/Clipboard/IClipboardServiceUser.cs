namespace Mesi.Io.Clipboard.Domain.Contract.Clipboard
{
    /// <summary>
    /// A user that consumes clipboard services
    /// </summary>
    public interface IClipboardServiceUser
    {
        /// <summary>
        /// The id of the service user
        /// </summary>
        public string UserId { get; }
    }
}