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
        Maybe<IClipboardEntry> New(string userId, string content, DateTime timeStamp);

        /// <summary>
        /// Creates an existing clipboard entry entity
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="content"></param>
        /// <param name="timeStamp"></param>
        /// <param name="contentMaxLength"></param>
        /// <returns></returns>
        IClipboardEntry Create(string id, string userId, string content, DateTime timeStamp, int contentMaxLength);
    }
}