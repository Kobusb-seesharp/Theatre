using System.Data.Entity;
using Theatre.Web.Models;

namespace Theatre.Web.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("ConnString")
        {
            Database.SetInitializer<DataContext>(new CreateDatabaseIfNotExists<DataContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BookingItem> BookingItems { get; set; }
        public DbSet<BookingDay> BookingDays { get; set; }
    }
}