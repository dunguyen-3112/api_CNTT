using SpendingManagement.Data.Entities;
using SpendingManagement.Share.ApiResults;
using SpendingManagement.Share.TypeOfCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Application.Categories
{
    public interface ICategoryService
    {
        Task<ApiResultBase<List<CategoryResponse>>> GetAllCategory();
        Task<ApiResultBase<List<CategoryResponse>>> GetCategoriesByCategoryType(CategoryType categoryType);

    }
}
