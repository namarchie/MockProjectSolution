using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using MockProjectSolution.AdminApp.Services;
using MockProjectSolution.Application.Catalog.Products;
using MockProjectSolution.Application.Catalog.Products.Dtos;
using MockProjectSolution.Application.Common;
using MockProjectSolution.Application.Users.Dtos;

namespace MockProjectSolution.AdminApp.Controllers
{

    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        private readonly IProductService _productService;
        public ProductController(IProductApiClient productApiClient, IConfiguration configuration, IProductService productService)
        {
            _configuration = configuration;
            _productApiClient = productApiClient;
            _productService = productService;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 19)
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
    }
}
