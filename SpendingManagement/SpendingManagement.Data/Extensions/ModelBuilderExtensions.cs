using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpendingManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var userId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                    new AppUser()
                    {
                        Id = userId,
                        UserName = "leminhloi",
                        NormalizedUserName = "LEMINHLOI",
                        NormalizedEmail = "LEMINHLOI@GMAIL.COM",
                        Email = "leminhloi@gmail.com",
                        EmailConfirmed = true,
                        DateOfBirth = DateTime.Now,
                        Gender = Share.Gender.GenderType.Undefined,
                        Name = "Lee Minh Loij",
                        PhoneNumber = "0948123432",
                        PhoneNumberConfirmed = true,
                        PhotoUrl = "",
                        PasswordHash = hasher.HashPassword(null, "Loi@1234"),
                        SecurityStamp = "",
                    }
                );
            var roleId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
            {
                Id = roleId,
                Name = "user",
                NormalizedName = "USER",
                ConcurrencyStamp = "",
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = userId
            });
            var idCategory = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<Category>().HasData(
                    new Category()
                    { 
                        Id = idCategory,
                        Name = "Tiền ăn",
                        Description = "Tiền mua đồ ăn này nọ",
                        TypeOfCategory = Share.TypeOfCategory.CategoryType.Out
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tiền nhà",
                        Description = "Tiền để thuê nhà này nọ",
                        TypeOfCategory = Share.TypeOfCategory.CategoryType.Out
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tiền xăng",
                        Description = "Tiền để đi đổ xăng",
                        TypeOfCategory = Share.TypeOfCategory.CategoryType.Out
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tiền mua sắm",
                        Description = "Tiền mua sắm cho sinh hoạt",
                        TypeOfCategory = Share.TypeOfCategory.CategoryType.Out
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Khác",
                        Description = "Khác với những cái ở trên",
                        TypeOfCategory = Share.TypeOfCategory.CategoryType.Out
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tiền lương",
                        Description = "Tiền lương",
                        TypeOfCategory = Share.TypeOfCategory.CategoryType.In
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tiền cho thuê",
                        Description = "Tiền cho thuê",
                        TypeOfCategory = Share.TypeOfCategory.CategoryType.In
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kinh doanh",
                        Description = "",
                        TypeOfCategory = Share.TypeOfCategory.CategoryType.In
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Quà tặng",
                        Description = "",
                        TypeOfCategory = Share.TypeOfCategory.CategoryType.In
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Khác",
                        Description = "Khác với những cái ở trên",
                        TypeOfCategory = Share.TypeOfCategory.CategoryType.In
                    }
                );
            modelBuilder.Entity<Expenditure>().HasData(
                    new Expenditure()
                    {
                        Id = Guid.NewGuid(),
                        AppUserId = userId,
                        CategoryId = idCategory,
                        Cost = 100000,
                        DateCreate = new DateTime(2022, 11, 20),
                        Note = ""
                    },
                    new Expenditure()
                    {
                        Id = Guid.NewGuid(),
                        AppUserId = userId,
                        CategoryId = idCategory,
                        Cost = 20000,
                        DateCreate = new DateTime(2022, 11, 21),
                        Note = ""
                    },
                    new Expenditure()
                    {
                        Id = Guid.NewGuid(),
                        AppUserId = userId,
                        CategoryId = idCategory,
                        Cost = 10000,
                        DateCreate = new DateTime(2022, 11, 22),
                        Note = ""
                    }                                                                
                ); 
        }
    }
}
