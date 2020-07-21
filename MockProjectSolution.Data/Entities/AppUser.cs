
using Microsoft.AspNetCore.Identity;
using MockProjectSolution.Data.Entities;
using System;
using System.Collections.Generic;

namespace eShopSolution.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public List<Order> Orders { set; get; }

    }
}
