using CoreDataFirstApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreDataFirstApp.DB_context
{
    public class Db_Class : DbContext
    {
        public Db_Class(DbContextOptions<Db_Class> options) : base(options)
        {

        }
        public DbSet<EmpModel> EmpModels { get; set; }
        public DbSet<userlogin> userlogins { get; set; }
    }
}
