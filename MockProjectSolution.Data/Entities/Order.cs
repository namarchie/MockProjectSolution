using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Data.Entities
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public List<OrderDetail> OrderDetails { set; get; }
        public AppUser AppUser { set; get; }

    }
}
