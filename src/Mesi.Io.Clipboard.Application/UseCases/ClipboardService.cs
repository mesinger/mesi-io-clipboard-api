using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard.Factories;
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
        private readonly IClipboardEntryFactory _clipboardEntryFactory;
        private readonly ILogger<ClipboardService> _logger;

        public ClipboardService(IClipboardRepository clipboardRepository, IClipboardEntryFactory clipboardEntryFactory, ILogger<ClipboardService> logger)
        {
            _clipboardRepository = clipboardRepository;
            _clipboardEntryFactory = clipboardEntryFactory;
            _logger = logger;
        }
        
        /// <inheritdoc />
        public async Task<CreateNewClipboardEntryResponse> Create(CreateNewClipboardEntryRequest request)
        {
            var entry = _clipboardEntryFactory.New(request.UserId, request.Content, DateTime.UtcNow);

            if (entry.HasNoValue)
            {
                _logger.LogWarning("Failed to create new clipboard entry.");
                return new CreateNewClipboardEntryResponse(Maybe<IClipboardEntry>.None);
            }
            
            await _clipboardRepository.Add(entry.Value);
            return new CreateNewClipboardEntryResponse(Maybe<IClipboardEntry>.From(entry.Value));
        }

        /// <inheritdoc />
        public async Task<FindAllClipboardEntriesByUserResponse> FindAll(FindAllClipboardEntriesByUserRequest request)
        {
            var entries = await _clipboardRepository.FindAllByUser(request.UserId);
            return new FindAllClipboardEntriesByUserResponse(entries);
        }
    }
}