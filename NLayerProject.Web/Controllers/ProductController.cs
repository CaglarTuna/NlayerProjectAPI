using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using NLayerProject.Web.ApiServices;
using NLayerProject.Web.DTOs;
using NLayerProject.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, ProductApiService productApiService)
        {
            _productApiService = productApiService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [HttpPost]
        [Route("{id}/{quantity}")]
        public IActionResult Index(int id, int quantity)
        {
            return View();//RedirectToAction("Add","Basket", productDto);
        }
        [Authorize(Roles ="admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _productApiService.AddAsync(productDto);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);

            return View(_mapper.Map<ProductDto>(product));
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _productApiService.Update(productDto);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _productApiService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
