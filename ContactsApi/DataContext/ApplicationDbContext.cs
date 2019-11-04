using Microsoft.EntityFrameworkCore;
using ContactsApi.Models;

namespace ContactsApi.DataContext
{

    public class ApplicationDbContext : DbContext
    {

        //no need to reference all other types
        public DbSet<Collaboration> Collaboration { get; set; }
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Freelance>().HasBaseType<Contact>();
            modelBuilder.Entity<Employee>().HasBaseType<Contact>();

            modelBuilder.ApplyConfiguration(new CollaborationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyAddressEntityConfiguration());

        }
    }
}