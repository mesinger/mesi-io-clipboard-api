using System;

namespace Mesi.Io.Clipboard.Infrastructure.Db.Clipboard
{
    internal class ClipboardEntryDataModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ContentMaxLength { get; set; }
    }
}