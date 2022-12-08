using SpendingManagement.Share.UnitTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Data.Entities
{
    public class Budget
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public long LimitMoney { get; set; }
        public UnitTime UnitTime { get; set; }
    }
}
