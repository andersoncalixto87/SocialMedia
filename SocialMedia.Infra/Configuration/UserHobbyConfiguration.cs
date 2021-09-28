using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infra.Configuration
{
    public class UserHobbyConfiguration : IEntityTypeConfiguration<UserHobby>
    {
        public void Configure(EntityTypeBuilder<UserHobby> builder)
        {
            builder.ToTable("tbUserHobby");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("ID").HasColumnType("int").IsRequired();
            builder.Property(u => u.CreatedDate).HasColumnName("CREATED_DATE").HasColumnType("datetime2").IsRequired();
            builder.Property(u => u.UserId).HasColumnName("USER_ID").HasColumnType("int");
            builder.Property(u => u.HobbyId).HasColumnName("HOBBY_ID").HasColumnType("int");
        }
        
        
    }
}