using Microsoft.EntityFrameworkCore;

namespace PegasusHealthWebAPI.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<Models.SupplyRequest> SupplyRequests { get; set; }
        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Models.MedicalSupply> MedicalSupplies { get; set; }
        public DbSet<Models.Vendor> Vendors { get; set; }
    }
}