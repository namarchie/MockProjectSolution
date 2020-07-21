using MockProjectSolution.Application.Catalog.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly MockProjectDbContext _context;
        public ProductService(MockProjectDbContext context)
        {
            _context = context;
        }
        public int Create(ProductCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public int Delete(int ProductId)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
