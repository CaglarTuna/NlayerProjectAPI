using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IPersonService _personService;
        public OrderController(IProductService productService, IPersonService personService)
        {
            _productService = productService;
            _personService = personService;
        }
        public async Task<IActionResult> Buy([FromBody] BasketDto basketDto)
        {
            try
            {
                var products = await _productService.GetByIdAsync(basketDto.pId);
                OrderDto order = new OrderDto
                {
                    ProductName = _productService.GetByIdAsync(basketDto.pId).Result.Name,
                    CategoryName = _productService.GetByIdAsync(basketDto.pId).Result.Category.Name,
                    Number = basketDto.number,
                    PersonName = _personService.GetByIdAsync(basketDto.uId).Result.Name,
                    TotalPrice = basketDto.number * _productService.GetByIdAsync(basketDto.pId).Result.Price
                };

                products.Stock -= basketDto.number;
                _productService.Update(products);
                return Ok(order);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
