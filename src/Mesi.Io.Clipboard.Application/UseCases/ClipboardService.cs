using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Mesi.Io.Clipboard.Domain.Clipboard.Models;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard.Repositories;
using Microsoft.Extensions.Logging;

namespace Mesi.Io.Clipboard.Application.UseCases
{
    /// <summary>
    /// Application layer for clipboard api
    /// </summary>
    public class ClipboardService : ICreateNewClipboardEntry, IFindAllClipboardEntriesByUser
    {
        private readonly IClipboardRepository _clipboardRepository;
        private readonly ILogger<ClipboardService> _logger;

        public ClipboardService(IClipboardRepository clipboardRepository, ILogger<ClipboardService> logger)
        {
            _clipboardRepository = clipboardRepository;
            _logger = logger;
        }
        
        /// <inheritdoc />
        public async Task<CreateNewClipboardEntryResponse> Create(CreateNewClipboardEntryRequest request)
        {
            try
            {
                var entry = ClipboardEntry.Create(request.UserId, request.Content, DateTime.UtcNow);
                await _clipboardRepository.AddEntry(entry);
                return new CreateNewClipboardEntryResponse(Maybe<ClipboardEntry>.From(entry));
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Failed to create new clipboard entry: '{msg}'", ex.Message);
                return new CreateNewClipboardEntryResponse(Maybe<ClipboardEntry>.None);
            }
        }

        /// <inheritdoc />
        public async Task<FindAllClipboardEntriesByUserResponse> FindAll(FindAllClipboardEntriesByUserRequest request)
        {
            var entries = await _clipboardRepository.GetAllByUser(request.UserId);
            return new FindAllClipboardEntriesByUserResponse(entries);
        }
    }
}