using MockProjectSolution.Application.Categories.Dtos;
using MockProjectSolution.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockProjectSolution.Application.Categories
{
    public interface ICategoryService
    {
        Task<PagedResult<CategoryViewModel>> GetAllCategory();
        Task<ApiResult<bool>> Create(CategoryCreateRequest request);

        Task<ApiResult<bool>> Update(int id, CategoryUpdateRequest request);

        Task<ApiResult<bool>> Delete(int Id);

        Task<ApiResult<PagedResult<CategoryViewModel>>> GetCategoriesPaging(GetCategoryPagingRequest request);
        Task<ApiResult<CategoryViewModel>> GetById(int Id);
    }
}
