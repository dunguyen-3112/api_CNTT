using SpendingManagement.Share.UnitTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Share.NameUnitTimeGenerator
{
    public static class UnitTimeGenerator
    {
        public static string GenerateName(UnitTime unitTime)
        {
            switch (unitTime)
            {
                case UnitTime.Year:
                    return "Năm";
                case UnitTime.Month:
                    return "Tháng";
                case UnitTime.Day:
                    return "Ngày";
                default:
                    return "Ngày";
            }
        }
    }
}
