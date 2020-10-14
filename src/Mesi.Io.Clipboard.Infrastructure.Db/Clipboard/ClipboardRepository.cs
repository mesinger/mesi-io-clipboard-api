using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mesi.Io.Clipboard.Domain.Clipboard.Models;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mesi.Io.Clipboard.Infrastructure.Db.Clipboard
{
    public class ClipboardRepository : IClipboardRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ClipboardRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <inheritdoc />
        public async Task AddEntry(ClipboardEntry entry)
        {
            await _dbContext.ClipboardEntries.AddAsync(entry);
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ClipboardEntry>> GetAllByUser(string id)
        {
            var entries = _dbContext.ClipboardEntries
                .OrderByDescending(e => e.CreatedAt)
                .Where(e => e.UserId == id);
            return await entries.ToListAsync();
        }
    }
}