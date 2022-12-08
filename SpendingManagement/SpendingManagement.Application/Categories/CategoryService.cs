using Microsoft.EntityFrameworkCore;
using SpendingManagement.Repository.Categories;
using SpendingManagement.Share.ApiResults;
using SpendingManagement.Share.NameTypeOfCategoryGenerator;
using SpendingManagement.Share.TypeOfCategory;

namespace SpendingManagement.Application.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResultBase<List<CategoryResponse>>> GetAllCategory()
        {
            var result = await _categoryRepository.GetAllCategory().Select(x => new CategoryResponse()
            {
                Id = x.Id,
                CategoryType = x.TypeOfCategory,
                Description = x.Description,
                Name = x.Name,
                LinkIcon = x.LinkIcon,
                TypeOfCategoryName = TypeCategoryNameGenerator.GenerateName(x.TypeOfCategory)
            }).ToListAsync();
            return new ApiSuccessResult<List<CategoryResponse>>(resultObj: result);
        }

        public async Task<ApiResultBase<List<CategoryResponse>>> GetCategoriesByCategoryType(CategoryType categoryType)
        {
            var result = await _categoryRepository.GetAllCategory().Where(x => x.TypeOfCategory == categoryType)
                .Select(x => new CategoryResponse()
                {
                    Id = x.Id,
                    CategoryType = x.TypeOfCategory,
                    Description = x.Description,
                    Name = x.Name,
                    LinkIcon = x.LinkIcon,
                    TypeOfCategoryName = TypeCategoryNameGenerator.GenerateName(x.TypeOfCategory)
                }).ToListAsync();
            return new ApiSuccessResult<List<CategoryResponse>>(resultObj: result);

        }
    }
}