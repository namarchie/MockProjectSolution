using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MockProjectSolution.AdminApp.Services;
using MockProjectSolution.Application.Categories;
using MockProjectSolution.Application.Categories.Dtos;

namespace MockProjectSolution.AdminApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ICategoryApiClient _categoryApiClient;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvirentment;
        public CategoryController(ICategoryApiClient categoryApiClient, IConfiguration configuration, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _categoryApiClient = categoryApiClient;
            _categoryService = categoryService;
            _webHostEnvirentment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetCategoryPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _categoryApiClient.GetCategoriesPaging(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _categoryApiClient.GetById(id);
            return View(result.ResultObj);
        }
        [HttpGet]
        public  async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _categoryApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm mới danh mục sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);

            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryApiClient.GetById(id);
            return View(new CategoryDeleteRequest()
            {
                Id = id,
                CategoryName = result.ResultObj.CategoryName
            });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _categoryApiClient.Delete(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa danh mục sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);

            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            
            var result = await _categoryApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updateRequest = new CategoryUpdateRequest()
                {
                    CategoryName = user.CategoryName
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _categoryApiClient.Update(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật danh mục sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}
