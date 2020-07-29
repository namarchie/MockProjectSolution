using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Users.Dtos
{
    public class DeleteRequest
    {
        public Guid Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string UserName { set; get; }
        public string PhoneNumber { set; get; }
        public DateTime Dob { set; get; }
        public string Email { set; get; }
    }
}
