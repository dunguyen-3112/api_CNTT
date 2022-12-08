using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpendingManagement.Data.Entities;
using SpendingManagement.Share.Gender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.Gender).IsRequired(true).HasDefaultValue(GenderType.Undefined);
            builder.Property(x => x.PhotoUrl).IsRequired(false);
        }
    }
}
