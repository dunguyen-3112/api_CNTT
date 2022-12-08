using SpendingManagement.Data.Entities;
using SpendingManagement.Share.TypeOfCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Repository.Categories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategory();
    }
}
