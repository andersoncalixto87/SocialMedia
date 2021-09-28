using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infra.Configuration
{
    public class CommentConfiguration: IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("tbComment");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("ID").HasColumnType("int").IsRequired();
            builder.Property(u => u.CreatedDate).HasColumnName("CREATED_DATE").HasColumnType("datetime2").IsRequired();
            builder.HasMany(u => u.Likes).WithOne(b => b.Comment).HasForeignKey(c => c.CommentId);
            builder.Property(u => u.PostId).HasColumnName("POST_ID").HasColumnType("int").IsRequired();
            builder.Property(u => u.UserId).HasColumnName("USER_ID").HasColumnType("int").IsRequired();
        }
        
    }
}