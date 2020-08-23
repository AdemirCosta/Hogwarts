using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class HogwartsContext : DbContext
    {
        public HogwartsContext(DbContextOptions<HogwartsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}
