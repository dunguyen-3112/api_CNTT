using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpendingManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Data.Configurations
{
    public class ExpenditureConfiguration : IEntityTypeConfiguration<Expenditure>
    {
        public void Configure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.ToTable("Expenditures");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AppUserId).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.Cost).IsRequired();
            builder.Property(x => x.DateCreate).IsRequired();
            builder.Property(x => x.Note).IsRequired(false).HasDefaultValue(String.Empty);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Expenditures).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Category).WithMany(x => x.Expenditures).HasForeignKey(x => x.CategoryId);
        }
    }
}
