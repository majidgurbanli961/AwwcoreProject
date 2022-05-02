using Awwcor.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Awwcor.Data.Context
{
    public class AwwDbContext : DbContext
    {
        public AwwDbContext( DbContextOptions<AwwDbContext> options )
            : base( options )
        {

        }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Photo> Photos { get; set; }


    }
}
