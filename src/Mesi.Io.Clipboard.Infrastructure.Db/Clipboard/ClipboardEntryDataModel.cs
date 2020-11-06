using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mesi.Io.Clipboard.Infrastructure.Db.Clipboard
{
    internal class ClipboardEntryDataModel
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ContentMaxLength { get; set; }
    }
}