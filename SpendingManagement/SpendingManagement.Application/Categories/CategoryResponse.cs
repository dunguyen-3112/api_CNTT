using SpendingManagement.Share.TypeOfCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Application.Categories
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkIcon { get; set; }
        public CategoryType CategoryType{ get; set; }
        public string TypeOfCategoryName { get; set; }
    }
}
