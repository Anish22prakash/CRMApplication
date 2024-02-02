using CustomerRelationshipManagementBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelationshipManagementBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<ClientRequirements> ClientRequirements { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<CompanyClient> CompanyClients { get; set; }
        public DbSet<CompanyEmployee> CompanyEmployees { get; set;}
        public DbSet<CompanyUltity> CompanyUltities { get; set; }
        public DbSet<CustomerComplaintQuery> CustomerComplaintQuery { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<TasksScheduler> TasksScheduler { get; set; }


    }
}
