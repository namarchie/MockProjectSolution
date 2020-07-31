using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using MockProjectSolution.AdminApp.Services;
using MockProjectSolution.Application.Catalog.Products;
using MockProjectSolution.Application.Catalog.Products.Dtos;
using MockProjectSolution.Application.Common;
using MockProjectSolution.Application.Products.Dtos;
using MockProjectSolution.Application.Users.Dtos;

namespace MockProjectSolution.AdminApp.Controllers
{

    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvirentment;
        public ProductController(IProductApiClient productApiClient, IConfiguration configuration, IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _productApiClient = productApiClient;
            _productService = productService;
            _webHostEnvirentment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _productApiClient.GetProductsPaging(request);
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
            var result = await _productApiClient.GetById(id);
            return View(result.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.category = await _productService.GetAllCategory();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _productApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);

            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productApiClient.GetById(id);
            return View(new ProductDeleteRequest()
            {
                Id = result.ResultObj.Id,
                Name = result.ResultObj.Name,
                Account = result.ResultObj.Account,
                Password = result.ResultObj.Password,
                Price = result.ResultObj.Price,
                Description = result.ResultObj.Description,
                CategoryId = result.ResultObj.CategoryId,
                Image = result.ResultObj.Image,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _productApiClient.Delete(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);

            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.category = await _productService.GetAllCategory();
            var result = await _productApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updateRequest = new ProductUpdateRequest()
                {
                    Name = user.Name,
                    Account = user.Account,
                    Password = user.Password,
                    Price = user.Price,
                    Description = user.Description,
                    Id = id
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.Update(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}
