using Microsoft.EntityFrameworkCore;
using Start_Bootstrap.Back_End.Models;

namespace Start_Bootstrap.Back_End.DAL
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Card> Cards  { get; set; }
        public DbSet<MainPart> MainParts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    } 
}
