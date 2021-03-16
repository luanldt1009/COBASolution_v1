using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COBAShop.Service.Catalog.Catelogies;
using COBAShop.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COBAShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var products = await _categoryService.GetAll(languageId);
            return Ok(products);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPagings([FromQuery] GetCategoryPagingRequest request)
        {
            var categories = await _categoryService.GetAllPaging(request);
            return Ok(categories);
        }

        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(string languageId, int id)
        {
            var category = await _categoryService.GetById(languageId, id);
            return Ok(category);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var categoyId = await _categoryService.Create(request);
            if (string.IsNullOrEmpty(request.LanguageId))
            {
                request.LanguageId = "vi";
            }
            if (categoyId == 0)
                return BadRequest();
            var category = await _categoryService.GetById(request.LanguageId, categoyId);
            return Ok(category);
        }

        [HttpPut("{categoryId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] int categoryId, [FromForm] CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            request.Id = categoryId;
            var result = await _categoryService.Update(request);
            if (result < 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var result = await _categoryService.Delete(categoryId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}