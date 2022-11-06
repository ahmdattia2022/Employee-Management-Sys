
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL.Entities;

namespace WebApplication1.DAL.Database
{
    public class DbContainer:DbContext //context
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }

        public DbContainer(DbContextOptions<DbContainer> dbContextOptions): base(dbContextOptions)
        {

        }

        //first way : override th onconfiguring method from the DbContext
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server = DESKTOP-QKEI4UP\SQLEXPRESS ; database = COMPANY_DB ; integrated security = true"); //connection string
        //}
    }
}
