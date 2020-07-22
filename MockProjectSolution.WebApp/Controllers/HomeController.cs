using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Data.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MockProjectSolution.Application.Catalog.Products.Dtos;
using MockProjectSolution.Data.EF;
using MockProjectSolution.Data.Entities;
using MockProjectSolution.WebApp.Models;

namespace MockProjectSolution.WebApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly MockProjectDbContext _mockProjectDbContext ;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController( MockProjectDbContext mockProjectDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _mockProjectDbContext = mockProjectDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var product = await _mockProjectDbContext.Products.ToListAsync();
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                string uniqueImageName = UploadedImage(request);
                Product product = new Product
                {
                    Name = request.Name,
                    Account = request.Account,
                    Password = request.Password,
                    Price = request.Price,
                    Description = request.Description,
                    Image = uniqueImageName,
                    CategoryId = request.CategoryId
                };
                _mockProjectDbContext.Add(product);
                await _mockProjectDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public string UploadedImage (ProductCreateRequest request)
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
    }
}
