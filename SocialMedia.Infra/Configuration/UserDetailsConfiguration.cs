using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infra.Configuration
{
    public class UserDetailsConfiguration : IEntityTypeConfiguration<UserDetails>
    {
        public void Configure(EntityTypeBuilder<UserDetails> builder)
        {
            builder.ToTable("tbUserDetails");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("ID").HasColumnType("int").IsRequired();
            builder.Property(u => u.CreatedDate).HasColumnName("CREATED_DATE").HasColumnType("datetime2").IsRequired();
            builder.Property(u => u.CurrentCity).HasColumnName("CURRENT_CITY").HasColumnType("NVARCHAR(200)");
            builder.Property(u => u.Hometown).HasColumnName("HOMETOWN").HasColumnType("NVARCHAR(200)");
            builder.Property(u => u.JobTitle).HasColumnName("JOB_TITLE").HasColumnType("NVARCHAR(200)");
            builder.Property(u => u.Relationship).HasColumnName("RELATIONSHIP").HasColumnType("int");
            builder.Property(u => u.WorkCompany).HasColumnName("WORK_COMPANY").HasColumnType("NVARCHAR(200)");
            builder.Property(u => u.UserId).HasColumnName("USER_ID").HasColumnType("int");

        }
        
    }
}