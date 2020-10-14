using System;
using CSharpFunctionalExtensions;

namespace Mesi.Io.Clipboard.Domain.Contract.Clipboard.Factories
{
    /// <summary>
    /// Factory for <see cref="IClipboardEntry"/>
    /// </summary>
    public interface IClipboardEntryFactory
    {
        /// <summary>
        /// Creates a new clipboard entry entity
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="content"></param>
        /// <param name="timeStamp"></param>
        /// <returns>Returns a <see cref="IClipboardEntry"/> for valid arguments. Returns no value for invalid arguments.</returns>
        Maybe<IClipboardEntry> Create(string userId, string content, DateTime timeStamp);
    }
}