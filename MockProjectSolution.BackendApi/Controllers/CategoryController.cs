using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProjectSolution.Application.Categories;
using MockProjectSolution.Application.Categories.Dtos;

namespace MockProjectSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController (ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _categoryService.Delete(id);
            if (!affectedResult.IsSuccessed)
                return BadRequest();
            return Ok(affectedResult);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await _categoryService.Create(request);
            if (!category.IsSuccessed)
                return BadRequest(category);


            return Ok(category);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affected = await _categoryService.Update(id, request);
            if (!affected.IsSuccessed)
            {
                return BadRequest();
            }
            return Ok(affected);

        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetCategoriesPaging([FromQuery] GetCategoryPagingRequest request)
        {
            var users = await _categoryService.GetCategoriesPaging(request);
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var affected = await _categoryService.GetById(id);
            return Ok(affected);
        }
    }
    
}
