using DbFactory;
using SpendingManagement.Data.EF;
using SpendingManagement.Data.Entities;
using SpendingManagement.Share.TypeOfCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Repository.Categories
{
    public class CategoryRepository : GenericRepository<Category, Guid, ApplicationDbContext>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Category> GetAllCategory()
        {
            return FindAll();
        }
    }
}
