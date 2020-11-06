using Mesi.Io.Clipboard.Infrastructure.Db.Clipboard;
using Microsoft.EntityFrameworkCore;

namespace Mesi.Io.Clipboard.Infrastructure.Db
{
    public class ApplicationDbContext : DbContext
    {
        internal DbSet<ClipboardEntryDataModel> ClipboardEntries { get; set; }
        
        /// <inheritdoc />
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClipboardEntryDataModel>(b =>
            {
                b.HasKey(c => c.Id);
                b.ToTable("t_clipboard_entries");

                b.Property(c => c.UserId)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("user");

                b.Property(c => c.Content)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("content");

                b.Property(c => c.ContentMaxLength)
                    .IsRequired()
                    .HasColumnName("content_max_length");

                b.Property(c => c.TimeStamp)
                    .IsRequired()
                    .HasColumnName("time_stamp");
            });
        }
    }
}