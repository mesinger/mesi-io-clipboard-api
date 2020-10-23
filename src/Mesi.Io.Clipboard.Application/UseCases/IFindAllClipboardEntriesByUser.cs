using System.Collections.Generic;
using System.Threading.Tasks;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard;

namespace Mesi.Io.Clipboard.Application.UseCases
{
    /// <summary>
    /// Finds all <see cref="IClipboardEntry"/> for a given user
    /// </summary>
    public interface IFindAllClipboardEntriesByUser
    {
        /// <summary>
        /// Finds all <see cref="IClipboardEntry"/> for a given user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<FindAllClipboardEntriesByUserResponse> FindAll(FindAllClipboardEntriesByUserRequest request);
    }

    public class FindAllClipboardEntriesByUserRequest
    {
        public FindAllClipboardEntriesByUserRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }

    public class FindAllClipboardEntriesByUserResponse
    {
        public FindAllClipboardEntriesByUserResponse(IEnumerable<IClipboardEntry> entries)
        {
            Entries = entries;
        }

        public IEnumerable<IClipboardEntry> Entries { get; }
    }
}