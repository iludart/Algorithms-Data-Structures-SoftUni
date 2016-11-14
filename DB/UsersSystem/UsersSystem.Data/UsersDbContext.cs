namespace UsersSystem.Data
{
    using Models;
    using System.Data.Entity;

    public class UsersDbContext : DbContext
    {
        public UsersDbContext()
            : base("name=UsersDb")
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}