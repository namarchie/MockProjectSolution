using MockProjectSolution.Application.Catalog.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Catalog.Products
{
    public interface IProductService
    {
        public int Create(ProductCreateRequest request);
        public int Update(ProductUpdateRequest request);
        public int Delete(int ProductId);
        PagedViewModel<ProductViewModel> GetAllPaging();



    }
}
