using MockProjectSolution.Application.Catalog.Products.Dtos;
using MockProjectSolution.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockProjectSolution.AdminApp.Services
{
    public interface IProductApiClient
    {
        Task<ApiResult<PagedResult<ProductViewModel>>> GetProductsPaging(GetProductPagingRequest request);
        Task<ApiResult<ProductViewModel>> GetById(int  Id);
        Task<ApiResult<bool>> Create(ProductCreateRequest request);
    }
}
