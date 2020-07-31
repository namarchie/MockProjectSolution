using MockProjectSolution.Application.Categories.Dtos;
using MockProjectSolution.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockProjectSolution.AdminApp.Services
{
    public interface ICategoryApiClient
    {
        Task<ApiResult<PagedResult<CategoryViewModel>>> GetCategoriesPaging(GetCategoryPagingRequest request);
        Task<ApiResult<CategoryViewModel>> GetById(int Id);
        Task<ApiResult<bool>> Create(CategoryCreateRequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> Update(int Id, CategoryUpdateRequest request);
    }
}
