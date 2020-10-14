using Mesi.Io.Clipboard.Domain.Clipboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Mesi.Io.Clipboard.Infrastructure.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ClipboardEntry> ClipboardEntries { get; set; }
        
        /// <inheritdoc />
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClipboardEntry>(b =>
            {
                b.HasKey(c => c.Id);
                b.ToTable("clipboardEntries");

                // b.Property(c => c.User)
                //     .IsRequired()
                //     .HasMaxLength(40)
                //     .HasConversion(
                //         u => u.UserId,
                //         v => ClipboardServiceUser.Create(v));

                b.Property(c => c.UserId)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("User");
            
                b.Property(c => c.Content)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasConversion(
                        c => c.Content,
                        v => ClipboardContent.Create(v));

                b.Property(c => c.ContentMaxLength)
                    .IsRequired();

                b.Property(c => c.CreatedAt).IsRequired();
            });
        }
    }
}