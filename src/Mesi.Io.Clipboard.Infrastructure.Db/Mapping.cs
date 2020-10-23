using CSharpFunctionalExtensions;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard;
using Mesi.Io.Clipboard.Domain.Contract.Clipboard.Factories;
using Mesi.Io.Clipboard.Infrastructure.Db.Clipboard;

namespace Mesi.Io.Clipboard.Infrastructure.Db
{
    internal static class Mapping
    {
        public static ClipboardEntryDataModel FromDomain(this IClipboardEntry entry)
        {
            return new ClipboardEntryDataModel
            {
                Id = entry.Id,
                UserId = entry.Creator.UserId,
                Content = entry.Content.Text,
                TimeStamp = entry.TimeStamp,
                ContentMaxLength = entry.ContentMaxLength
            };
        }

        public static IClipboardEntry ToDomain(this ClipboardEntryDataModel dataModel, IClipboardEntryFactory factory)
        {
            return factory.Create(dataModel.Id, dataModel.UserId, dataModel.Content, dataModel.TimeStamp, dataModel.ContentMaxLength);
        }
    }
}