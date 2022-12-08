using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingManagement.Data.Entities
{
    public class Expenditure
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AppUserId { get; set; }
        public string Note { get; set; }
        public DateTime DateCreate { get; set; }
        public long Cost { get; set; }

        public AppUser AppUser { get; set; }
        public Category Category { get; set; }
    }
}
