using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpendingManagement.Data.Entities;
using SpendingManagement.Share.UnitTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Data.Configurations
{
    public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.ToTable("Budgets");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LimitMoney).IsRequired().HasDefaultValue(10000000000);
            builder.Property(x => x.UnitTime).IsRequired().HasDefaultValue(UnitTime.Day);
            builder.Property(x => x.AppUserId).IsRequired();
        }
    }
}
