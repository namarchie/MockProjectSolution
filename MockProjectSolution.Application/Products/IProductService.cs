using MockProjectSolution.Application.Catalog.Products.Dtos;
using MockProjectSolution.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockProjectSolution.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<ApiResult<bool>> Create(ProductCreateRequest request);

        Task<ApiResult<bool>> Update(int id, ProductUpdateRequest request);

        Task<ApiResult<bool>> Delete(int Id);

        Task<ApiResult<PagedResult<ProductViewModel>>> GetProductsPaging(GetProductPagingRequest request);
        Task<ApiResult<ProductViewModel>> GetById(int Id);

        string NewImage(ProductCreateRequest request);
        string UpdateImage(ProductUpdateRequest request);
        Task<PagedResult<CategoryViewModel>> GetAllCategory();



    }
}
