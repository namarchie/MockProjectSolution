using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Categories.Dtos
{
    public class CategoryDeleteRequest
    {
        public int Id { set; get; }
        public string CategoryName { set; get; }
    }
}
