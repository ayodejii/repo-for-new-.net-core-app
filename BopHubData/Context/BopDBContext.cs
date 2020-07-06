using BopHubData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BopHubData.Context
{
    public class BopDBContext : DbContext
    {
        public BopDBContext(DbContextOptions<BopDBContext> options)
            : base(options) {}

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bop> Bops { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasKey(a => new { a.BopId, a.AttendeeId });
        }
    }
}
