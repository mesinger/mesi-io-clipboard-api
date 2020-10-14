using System;

namespace Mesi.Io.Clipboard.Domain.Contract.Clipboard
{
    /// <summary>
    /// A clipboard entry
    /// </summary>
    public interface IClipboardEntry
    {
        /// <summary>
        /// Identifier of this clipboard entry
        /// </summary>
        public string Id { get; }
        
        /// <summary>
        /// Creator of this clipboard entry
        /// </summary>
        public IClipboardServiceUser Creator { get; }

        /// <summary>
        /// Content of this clipboard entry
        /// </summary>
        public IClipboardContent Content { get; }

        /// <summary>
        /// Timestamp of creation
        /// </summary>
        public DateTime TimeStamp { get; }
    }
}