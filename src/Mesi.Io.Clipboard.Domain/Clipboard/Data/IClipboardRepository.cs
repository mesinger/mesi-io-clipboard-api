using System.Collections.Generic;
using System.Threading.Tasks;
using Mesi.Io.Clipboard.Domain.Clipboard.Models;

namespace Mesi.Io.Clipboard.Domain.Clipboard.Data
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
        Task AddEntry(ClipboardEntry entry);

        /// <summary>
        /// Retrieves all clipboard entries by a given user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<ClipboardEntry>> GetAllByUser(string id);
    }
}