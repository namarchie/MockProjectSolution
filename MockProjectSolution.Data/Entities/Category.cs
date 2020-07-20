using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Data.Entities
{
    public class Category
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int SortOrder { set; get; }
        public int? ParentId { set; get; }
        public List<Product> Products { get; set; }
    }
}
