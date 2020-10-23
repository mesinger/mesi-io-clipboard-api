using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard.Factories;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mesi.Io.Clipboard.Infrastructure.Db.Clipboard.Repositories
{
    public class ClipboardRepository : IClipboardRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IClipboardEntryFactory _clipboardEntryFactory;

        public ClipboardRepository(ApplicationDbContext dbContext, IClipboardEntryFactory clipboardEntryFactory)
        {
            _dbContext = dbContext;
            _clipboardEntryFactory = clipboardEntryFactory;
        }

        /// <inheritdoc />
        public async Task Add(IClipboardEntry entry)
        {
            await _dbContext.ClipboardEntries.AddAsync(entry.FromDomain());
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<IClipboardEntry>> FindAllByUser(string id)
        {
            var entries = _dbContext.ClipboardEntries
                .OrderByDescending(e => e.TimeStamp)
                .Where(e => e.UserId == id);

            return from entry in await entries.ToListAsync() select entry.ToDomain(_clipboardEntryFactory);
        }
    }
}