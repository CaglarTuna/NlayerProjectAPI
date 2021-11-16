using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NLayerProject.Web.CategoryApiService;
using NLayerProject.Web.DTOs;
using NLayerProject.Web.Filters;

namespace NLayerProject.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryApiServiceCs _categoryApiService;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper,CategoryApiServiceCs categoryApiService)
        {
            _categoryApiService = categoryApiService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryApiService.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);

            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryApiService.Update(categoryDto);

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Remove(int id)
        {
            await _categoryApiService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
