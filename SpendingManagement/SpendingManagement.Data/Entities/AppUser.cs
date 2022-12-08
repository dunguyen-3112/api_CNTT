using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SpendingManagement.Share.Gender;

namespace SpendingManagement.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public string PhotoUrl { get; set; }

        public List<Expenditure> Expenditures { get; set; }
    }
}
