using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infra.Configuration
{
    public class PostConfiguration: IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("tbPost");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("ID").HasColumnType("int").IsRequired();
            builder.Property(u => u.CreatedDate).HasColumnName("CREATED_DATE").HasColumnType("datetime2").IsRequired();
            builder.Property(u => u.Description).HasColumnName("DESCRIPTION").HasColumnType("NVARCHAR(200)");
            builder.Property(u => u.Image).HasColumnName("IMAGE").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(u => u.Location).HasColumnName("LOCATION").HasColumnType("NVARCHAR(200)");
            builder.Property(u => u.Privacy).HasColumnName("PRIVACY").HasColumnType("int").IsRequired();
            builder.Property(u => u.UserId).HasColumnName("USER_ID").HasColumnType("int").IsRequired();
            builder.HasMany(u => u.Likes).WithOne(b => b.Post).HasForeignKey(c => c.PostId);
            builder.HasMany(u => u.Comments).WithOne(b => b.Post).HasForeignKey(c => c.PostId);
        }
        
    }
}