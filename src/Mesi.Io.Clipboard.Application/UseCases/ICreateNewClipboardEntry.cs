using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard;

namespace Mesi.Io.Clipboard.Application.UseCases
{
    /// <summary>
    /// Creates a new clipboard entry
    /// </summary>
    public interface ICreateNewClipboardEntry
    {
        /// <summary>
        /// Creates a new clipboard entry
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateNewClipboardEntryResponse> Create(CreateNewClipboardEntryRequest request);
    }

    public class CreateNewClipboardEntryRequest
    {
        public CreateNewClipboardEntryRequest(string userId, string content)
        {
            UserId = userId;
            Content = content;
        }

        public string UserId { get; }
        public string Content { get; }
    }

    public class CreateNewClipboardEntryResponse
    {
        public CreateNewClipboardEntryResponse(Maybe<IClipboardEntry> createdEntry)
        {
            CreatedEntry = createdEntry;
        }

        public Maybe<IClipboardEntry> CreatedEntry { get; }
    }
}