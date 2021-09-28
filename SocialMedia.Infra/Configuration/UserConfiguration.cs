using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infra.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tbUser");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("ID").HasColumnType("int").IsRequired();
            builder.Property(u => u.CreatedDate).HasColumnName("CREATED_DATE").HasColumnType("datetime2").IsRequired();
            builder.Property(u => u.Id).HasColumnName("ID").HasColumnType("int").IsRequired();
            builder.Property(u => u.Name).HasColumnName("NAME").HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(u => u.UserName).HasColumnName("USERNAME").HasColumnType("nvarchar(30)").IsRequired();
            builder.Property(u => u.Password).HasColumnName("PASSWORD").HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(u => u.Bio).HasColumnName("BIO").HasColumnType("nvarchar(150)");            
            builder.Property(u => u.IsPrivate).HasColumnName("ISPRIVATE").HasColumnType("bit").IsRequired();
            builder.Property(u => u.ProfileImage).HasColumnName("PROFILE_IMAGE").HasColumnType("nvarchar(300)");
            builder.Property(u => u.CoverImage).HasColumnName("COVER_IMAGE").HasColumnType("nvarchar(300)");
            builder.HasMany(u => u.Hobbies).WithOne(b => b.User).HasForeignKey(c => c.UserId);
            builder.HasMany(u => u.Links).WithOne(b => b.User).HasForeignKey(c => c.UserId);
            builder.HasOne(u => u.UserDetails).WithOne(b => b.User);
            
        }
    }
}