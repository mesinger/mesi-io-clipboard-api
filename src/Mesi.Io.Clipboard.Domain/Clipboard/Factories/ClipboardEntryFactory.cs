using System;
using CSharpFunctionalExtensions;
using Mesi.Io.Clipboard.Domain.Clipboard.Models;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard.Factories;
using Microsoft.Extensions.Logging;

namespace Mesi.Io.Clipboard.Domain.Clipboard.Factories
{
    /// <inheritdoc />
    public class ClipboardEntryFactory : IClipboardEntryFactory
    {
        private readonly ILogger<ClipboardEntryFactory> _logger;

        public ClipboardEntryFactory(ILogger<ClipboardEntryFactory> logger)
        {
            _logger = logger;
        }
        
        /// <inheritdoc />
        public Maybe<IClipboardEntry> Create(string userId, string content, DateTime timeStamp)
        {
            try
            {
                var entry = ClipboardEntry.Create(userId, content, timeStamp);
                return Maybe<IClipboardEntry>.From(entry);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Unable to create clipboard entry. '{error}'", ex.Message);
                return Maybe<IClipboardEntry>.None;
            }
        }
    }
}