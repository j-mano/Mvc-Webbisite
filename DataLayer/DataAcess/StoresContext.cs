using DataLayer.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer.DataAcess
{
    public class StoresContext : DbContext
    {
        public StoresContext() : base("DefaultConnection")
        {

        }

        public DbSet<StoreModel> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreModel>().ToTable("Stores");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
