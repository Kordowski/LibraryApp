using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data
{
    public class LibraryAppDbContext : DbContext
    {
        public DbSet<Reader> Readers => Set<Reader>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<AuditEntry> Audits => Set<AuditEntry>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
