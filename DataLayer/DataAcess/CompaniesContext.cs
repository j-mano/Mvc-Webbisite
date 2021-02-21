using DataLayer.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer.DataAcess
{
    public class CompaniesContext : DbContext
    {
        public CompaniesContext() : base("DefaultConnection")
        {
        }

        public DbSet<CompanyModel> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyModel>().ToTable("Companies");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
