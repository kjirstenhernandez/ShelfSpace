
namespace ShelfSpace.Data
{
    public class ShelfSpaceContext : DbContext
    {
        public ShelfSpaceContext(DbContextOptions<ShelfSpaceContext> options)
            : base(options){}

            public DbSet<MediaItem> Media { get; set; } = default!;
            public DbSet<User> User { get; set; } = default!;

   
    }

}