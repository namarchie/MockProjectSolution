using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MockProjectSolution.Application.Categories.Dtos;
using MockProjectSolution.Application.Common;
using MockProjectSolution.Common.Exceptions;
using MockProjectSolution.Data.EF;
using MockProjectSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockProjectSolution.Application.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly MockProjectDbContext _mockProjectDbContext;
        //private readonly IStorageService _storageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryService(MockProjectDbContext mockProjectDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _mockProjectDbContext = mockProjectDbContext;
            //_storageService = storageService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ApiResult<bool>> Create(CategoryCreateRequest request)
        {
            var query =  _mockProjectDbContext.Categories.Any(x => x.Name == request.CategoryName);
            if (query)
            {
                //throw new MockProjectException("Danh mục này đã tồn tại");
                return new ApiErrorResult<bool>();
            }
            Category category = new Category
            {
                Name = request.CategoryName
            };
            _mockProjectDbContext.Add(category);
            await _mockProjectDbContext.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int Id)
        {
            var category = await _mockProjectDbContext.Categories.FindAsync(Id);

            _mockProjectDbContext.Categories.Remove(category);

            await _mockProjectDbContext.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<PagedResult<CategoryViewModel>> GetAllCategory()
        {
            var category = _mockProjectDbContext.Categories.Select(x => new CategoryViewModel()
            {
                CategoryId = x.Id,
                CategoryName = x.Name,
            });
            int totalRow = await category.CountAsync();
            var pageResult = new PagedResult<CategoryViewModel>()
            {
                Items = await category.ToListAsync()
            };
            return pageResult;
        }

        public async Task<ApiResult<CategoryViewModel>> GetById(int Id)
        {
            var category = await _mockProjectDbContext.Categories.FindAsync(Id);
            if (category == null)
            {
                throw new MockProjectException("Không tìm thấy danh mục này ");
            }
            var categoryViewModel = new CategoryViewModel()
            {
                CategoryId = Id,
                CategoryName = category.Name
            };
            return new ApiSuccessResult<CategoryViewModel>(categoryViewModel);
        }

        public async Task<ApiResult<PagedResult<CategoryViewModel>>> GetCategoriesPaging(GetCategoryPagingRequest request)
        {
            var query = _mockProjectDbContext.Categories.Select(x => new CategoryViewModel()
            {
                CategoryId = x.Id,
                CategoryName = x.Name

            });
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.CategoryName.Contains(request.Keyword));
            }
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);
            var pagedResult = new PagedResult<CategoryViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = await data.ToListAsync()
            };
            return new ApiSuccessResult<PagedResult<CategoryViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Update(int id, CategoryUpdateRequest request)
        {
            var category = await _mockProjectDbContext.Categories.FindAsync(id);

            if (category == null) throw new MockProjectException("Không tìm thấy danh mục này");
            category.Name = request.CategoryName;


            await _mockProjectDbContext.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
}
