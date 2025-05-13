using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentMaster.Domain.Entities;

namespace TournamentMaster.Infrastructure.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName("Id");

            builder.Property(x => x.FirstName)
                   .HasColumnName("FirstName")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.MiddleName)
                   .HasColumnName("MiddleName")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasColumnName("Email")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.PasswordHash)
                   .HasColumnName("PasswordHash")
                   .HasMaxLength(255)
                   .IsRequired();
        }
    }
}
