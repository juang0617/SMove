using System.Data.Entity;

namespace SMove.Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<SMove.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<SMove.Domain.UserType> UserTypes { get; set; }
    }
}
