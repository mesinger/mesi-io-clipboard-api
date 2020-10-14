using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mesi.Io.Clipboard.Domain.Contract.Clipboard.Repositories
{
    /// <summary>
    /// Access to clipboard entries
    /// </summary>
    public interface IClipboardRepository
    {
        /// <summary>
        /// Adds a new clipboard entry
        /// </summary>
        /// <param name="entry"></param>
        Task Add(IClipboardEntry entry);

        /// <summary>
        /// Retrieves all clipboard entries by a given user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<IClipboardEntry>> FindAllByUser(string id);
    }
}