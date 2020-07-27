using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Catalog.Products.Dtos
{
    public class ProductUpdateRequest
    {
        public int Id { set; get; }
        public string Account { set; get; }
        public string Password { set; get; }
        public decimal Price { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public IFormFile Image { set; get; }
        public int CategoryId { set; get; }
    }
}
