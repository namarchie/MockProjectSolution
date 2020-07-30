using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MockProjectSolution.Application.Users.Dtos
{
    public class UserViewModel
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string UserName { set; get; }
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public IList<string> Roles { get; set; }
    }
}