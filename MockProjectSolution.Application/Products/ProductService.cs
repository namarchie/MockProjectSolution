using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Xrm.Sdk.Workflow;
using MockProjectSolution.Application.Catalog.Products.Dtos;
using MockProjectSolution.Application.Common;
using MockProjectSolution.Common.Exceptions;
using MockProjectSolution.Data.EF;
using MockProjectSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MockProjectSolution.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly MockProjectDbContext _mockProjectDbContext;
        //private readonly IStorageService _storageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductService(MockProjectDbContext mockProjectDbContext,IWebHostEnvironment webHostEnvironment)
        {
            _mockProjectDbContext = mockProjectDbContext;
            //_storageService = storageService;
            _webHostEnvironment = webHostEnvironment;
        }



        public async Task<int> Delete(int productId)
        {
            var product = await _mockProjectDbContext.Products.FindAsync(productId);

            _mockProjectDbContext.Products.Remove(product);

            return await _mockProjectDbContext.SaveChangesAsync();
     
        }

        public async Task<ApiResult<PagedResult<ProductViewModel>>> GetProductsPaging(GetProductPagingRequest request)
        {
            
            var query = _mockProjectDbContext.Products.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Account = x.Account,
                Password = x.Password,
                Price = x.Price,
                DateCreated = x.DateCreated,
                Image = x.Image,
                CategoryId = x.CategoryId,
                Category = _mockProjectDbContext.Categories.First( o => o.Id == x.CategoryId).Name

            }) ;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }
            int totalRow = await query.CountAsync();
            var data =  query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = await data.ToListAsync()
            };
            return new ApiSuccessResult<PagedResult<ProductViewModel>>(pagedResult);
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            string uniqueImageName = UpdateImage(request);
            var product = await _mockProjectDbContext.Products.FindAsync(request.Id);

            if (product == null) throw new MockProjectException("Khong tim thay");
            product.Name = request.Name;
            product.Price = request.Price;
            product.Account = request.Account;
            product.Password = request.Password;
            product.Description = request.Description;
            product.CategoryId = request.CategoryId;
            product.Image = uniqueImageName;


            return await _mockProjectDbContext.SaveChangesAsync();
        }

        public string NewImage(ProductCreateRequest request)
        {
            string uniqueImageName = null;
            if (request.Image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueImageName = Guid.NewGuid().ToString() + "_" + request.Image.FileName;
                string imagePath = Path.Combine(uploadsFolder, uniqueImageName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    request.Image.CopyTo(fileStream);
                }
            }
            return uniqueImageName;
        }
        public string UpdateImage(ProductUpdateRequest request)
        {
            string uniqueImageName = null;
            if (request.Image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueImageName = Guid.NewGuid().ToString() + "_" + request.Image.FileName;
                string imagePath = Path.Combine(uploadsFolder, uniqueImageName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    request.Image.CopyTo(fileStream);
                }
            }
            return uniqueImageName;
        }

        public async Task<ApiResult<ProductViewModel>> GetById(int productId)
        {
            var product = await _mockProjectDbContext.Products.FindAsync(productId);
            var product1 = _mockProjectDbContext.Categories.First(x => x.Id == productId);
            if (product == null)
            {
                throw new MockProjectException("Khong tim thay");
            }
            var productViewModel = new ProductViewModel()
            {
                Account = product.Account,
                Password = product.Password,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                DateCreated = product.DateCreated,
                CategoryId = product.CategoryId,
                Image = product.Image,
                Id = product.Id,
                Category = product1.Name
            };
            return new ApiSuccessResult<ProductViewModel> (productViewModel);
        }

        async Task<ApiResult<bool>> IProductService.Create(ProductCreateRequest request)
        {
            var category = _mockProjectDbContext.Categories.First(x => x.Name == request.CategoryName);
            string uniqueImageName = NewImage(request);
            Product product = new Product
            {
                Name = request.Name,
                Account = request.Account,
                Password = request.Password,
                Price = request.Price,
                Description = request.Description,
                Image = uniqueImageName,
                CategoryId = category.Id,
                DateCreated = DateTime.Now
            };
            _mockProjectDbContext.Add(product);
            await _mockProjectDbContext.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<PagedResult<CategoryViewModel>> GetAllCategory()
        {
            var category = _mockProjectDbContext.Categories.Select(x => new CategoryViewModel()
            {
                CategoryId= x.Id,
                CategoryName = x.Name,
            });
            int totalRow = await category.CountAsync();
            var pageResult = new PagedResult<CategoryViewModel>()
            {
                Items = await category.ToListAsync()
            };
            return pageResult;
        }
    }
}
