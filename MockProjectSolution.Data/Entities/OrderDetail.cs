using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Data.Entities
{
    public class OrderDetail
    {
        public int OrderId { set; get; }
        public decimal Price { set; get; }
        public Order Order { set; get; }
    }
}
