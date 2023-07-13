using Microsoft.EntityFrameworkCore;

namespace Web.UI.Entities.ContextDb
{
    public class DataContextDb:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Users;Integrated Security=true;TrustServerCertificate=True");
        }

        public virtual DbSet<Users> Users { get; set; }
    }
}
