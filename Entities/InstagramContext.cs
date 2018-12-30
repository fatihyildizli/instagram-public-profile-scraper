using Microsoft.EntityFrameworkCore;


namespace Stalker
{
    public class InstagramContext : BaseContext
    {
        public DbSet<Instagram> InstagramSet { get; set; }
    }
}
