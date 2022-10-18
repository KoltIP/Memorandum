using AutoMapper;
using Memorandum.CategoryServices.Models;
using Memorandum.CategoryServices.Services;
using Memorandum.UI.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace Memorandum.UI.Controllers
{
    [Route("/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, IMapper mapper, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> IndexAsync()
        {
            var categories = await _categoryService.GetCategories();
            var response = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return View("Category", response);
        }

        [HttpGet("{id}")]
        public async Task<CategoryResponse> GetCategory([FromRoute]int id)
        {
            var category = await _categoryService.GetCategory(id);
            var response = _mapper.Map<CategoryResponse>(category);
            return response;
        }

        [HttpGet("/OpenAddCategoryPage")]
        public IActionResult OpenAddCategoryPage()
        {
            return View("AddCategory");
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> Add(AddCategoryRequest request)
        {
            var model = _mapper.Map<AddCategoryModel>(request);
            var category = await _categoryService.AddCategory(model);
            var response = _mapper.Map<CategoryResponse>(category);
            return Redirect("Category");
        }

        [HttpGet("/OpenUpdateCategoryPage")]
        public async Task<IActionResult> OpenUpdateCategoryPageAsync(int id)
        {
            var category = await _categoryService.GetCategory(id);
            var response = _mapper.Map<CategoryResponse>(category);
            return View("UpdateCategory",response);
        }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> Update(int id, UpdateCategoryRequest request)
        {
            UpdateCategoryModel model = _mapper.Map<UpdateCategoryModel>(request);
            await _categoryService.UpdateCategory(id,model);
            return Redirect("Category");
        }


        [HttpPut("{id}")]
        public async Task<OkResult> UpdateCategory([FromRoute]int id,[FromBody] UpdateCategoryRequest request)
        {
            var model = _mapper.Map<UpdateCategoryModel>(request);
            await _categoryService.UpdateCategory(id,model);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            await _categoryService.DeleteCategory(id);
            var categories = await _categoryService.GetCategories();
            var response = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return View("Category", response);
        }
    }
}
