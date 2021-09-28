using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Infra.Configuration;

namespace SocialMedia.Infra.Data
{
    public class SocialMediaContext : DbContext
    {
        public SocialMediaContext()
        {
            
        }
        public SocialMediaContext(DbContextOptions<SocialMediaContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<UserHobby> UserHobby { get; set; }
        public DbSet<UserLink> UserLink { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostLike> PostLike { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<CommentLike> CommentLike { get; set; }
        public DbSet<Hobby> Hobby { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new UserConfiguration().Configure(modelBuilder.Entity<User>);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDetailsConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserHobbyConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserLinkConfiguration).Assembly);
        }
        
    }
}