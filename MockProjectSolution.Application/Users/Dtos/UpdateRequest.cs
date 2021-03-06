﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MockProjectSolution.Application.Users.Dtos
{
    public class UpdateRequest
    {
        public Guid Id { set; get; }
        [Display(Name = "Họ")]
        public string FirstName { get; set; }
        [Display(Name = "Tên")]
        public string LastName { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}
