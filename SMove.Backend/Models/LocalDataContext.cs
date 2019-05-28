namespace SMove.Backend.Models
{
    using Domain;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<SMove.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<SMove.Domain.UserType> UserTypes { get; set; }
    }
}