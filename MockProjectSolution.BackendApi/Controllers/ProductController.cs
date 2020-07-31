using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProjectSolution.Application.Catalog.Products;
using MockProjectSolution.Application.Catalog.Products.Dtos;

namespace MockProjectSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController (IProductService productService)
        {
            _productService = productService;
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var affectedResult = await _productService.Delete(Id);
            if (!affectedResult.IsSuccessed)
                return BadRequest();
            return Ok(affectedResult);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productService.Create(request);
            if (!product.IsSuccessed)
                return BadRequest(product);


            return Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affected = await _productService.Update(id, request);
            if (!affected.IsSuccessed)
            {
                return BadRequest();
            }
            return Ok(affected);

        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetProductsPaging ([FromQuery] GetProductPagingRequest request)
        {
            var users = await _productService.GetProductsPaging(request);
            return Ok(users);
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById (int productId)
        {
            var affected = await _productService.GetById(productId);
            return Ok(affected);
        }

    }
}
