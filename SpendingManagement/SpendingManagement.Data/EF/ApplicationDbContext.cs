using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpendingManagement.Data.Configurations;
using SpendingManagement.Data.Entities;
using SpendingManagement.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Data.EF
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Configure using Fluent API
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ExpenditureConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new BudgetConfiguration());

            //change name default of tables identity 
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            builder.Entity<IdentityRole<Guid>>().ToTable("AppRoles").HasKey(x => x.Id);

            //Data seeding
            builder.Seed();
        }
    }
}
