using System.Collections.Generic;
using System.Threading.Tasks;
using Mesi.Io.Clipboard.Domain.Clipboard.Models;

namespace Mesi.Io.Clipboard.Application.UseCases
{
    /// <summary>
    /// Finds all <see cref="ClipboardEntry"/> for a given user
    /// </summary>
    public interface IFindAllClipboardEntriesByUser
    {
        /// <summary>
        /// Finds all <see cref="ClipboardEntry"/> for a given user
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
        public FindAllClipboardEntriesByUserResponse(IEnumerable<ClipboardEntry> entries)
        {
            Entries = entries;
        }

        public IEnumerable<ClipboardEntry> Entries { get; }
    }
}