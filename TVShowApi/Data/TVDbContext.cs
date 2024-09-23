using Microsoft.EntityFrameworkCore;
using TVShowApi.Entities;

namespace TVShowApi.Data
{
    public class TVDbContext : DbContext
    {
        public TVDbContext(DbContextOptions<TVDbContext> options) : base(options)
        {

        }

        public DbSet<TVShow> TVShows { get; set; }

    }
}
