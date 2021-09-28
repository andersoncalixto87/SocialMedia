using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infra.Configuration
{
    public class UserLinkConfiguration: IEntityTypeConfiguration<UserLink>
    {
        public void Configure(EntityTypeBuilder<UserLink> builder)
        {
            builder.ToTable("tbUserLink");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("ID").HasColumnType("int").IsRequired();
            builder.Property(u => u.CreatedDate).HasColumnName("CREATED_DATE").HasColumnType("datetime2").IsRequired();
            builder.Property(u => u.Description).HasColumnName("DESCRIPTION").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(u => u.LinkType).HasColumnName("LINK_TYPE").HasColumnType("int").IsRequired();
            builder.Property(u => u.UserId).HasColumnName("USER_ID").HasColumnType("int").IsRequired();
            
        }
        
    }
}