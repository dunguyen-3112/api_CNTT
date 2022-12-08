using SpendingManagement.Share.TypeOfCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Share.NameTypeOfCategoryGenerator
{
    public static class TypeCategoryNameGenerator
    {
        public static string GenerateName(CategoryType categoryType)
        {
            switch(categoryType)
            {
                case CategoryType.In:
                    return "Thu nhập";
                case CategoryType.Out:
                    return "Chi tiêu";
                default:
                    return "Thu nhập";
            }    
        }
    }
}
