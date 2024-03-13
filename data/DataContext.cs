using mainWEB.Entities;
using Microsoft.EntityFrameworkCore;

namespace mainWEB.data
{
    



    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Superhero> Superheroes { get; set; }
    }
}
