using LSI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LSI.Domain.Storage
{
    public class ReportContext: DbContext
    {
        public DbSet<Report> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=reports.db", _ => _.MigrationsAssembly("LSI"));
    }
}