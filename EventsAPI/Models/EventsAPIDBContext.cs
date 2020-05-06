using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventsAPI.Models
{
    public partial class EventsAPIDBContext : DbContext
    {
        public EventsAPIDBContext()
        {
        }

        public EventsAPIDBContext(DbContextOptions<EventsAPIDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Favorites> Favorites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AODEQ1G\\SQLEXPRESS;Database=EventsAPIDB;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=LAPTOP-2QC4EM5C\\SQLEXPRESS;Database=EventsAPIDB;Trusted_Connection=True;");
                    
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorites>(entity =>
            {
                entity.Property(e => e.EventName).HasMaxLength(1);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Venue).HasMaxLength(1);

                entity.Property(e => e.EventId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
