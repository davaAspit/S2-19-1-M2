using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CourtBooking.Data.Models
{
    public partial class valsby_dk_dbContext : DbContext
    {
        public valsby_dk_dbContext()
        {
        }

        public valsby_dk_dbContext(DbContextOptions<valsby_dk_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Court> Courts { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.HasIndex(e => new { e.BookingTime, e.CourtNumber })
                    .HasName("UC_Booking")
                    .IsUnique();

                entity.Property(e => e.Booker)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BookingTime).HasColumnType("datetime2(0)");

                entity.HasOne(d => d.CourtNumberNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CourtNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookings__CourtN__5FB337D6");
            });

            modelBuilder.Entity<Court>(entity =>
            {
                entity.HasKey(e => e.CourtNumber);

                entity.Property(e => e.CourtNumber).ValueGeneratedNever();
            });
        }
    }
}
