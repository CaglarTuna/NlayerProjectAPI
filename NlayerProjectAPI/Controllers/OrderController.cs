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
        private readonly IOrderService _orderService;
        private readonly IPersonService _personService;
        public OrderController(IProductService productService, IPersonService personService, IOrderService orderService)
        {
            _orderService = orderService;
            _productService = productService;
            _personService = personService;
        }
        [HttpPost]
        public async Task<IActionResult> Buy(BasketDtoSpecific basketDtoSpecific)
        {
            try
            {
                var products = await _productService.GetByIdAsync(basketDtoSpecific.pId);
                OrderDto order = new OrderDto
                {
                    ProductName = basketDtoSpecific.ProductName,
                    Quantity = basketDtoSpecific.Quantity,
                    PersonName = basketDtoSpecific.Name,
                    TotalPrice = basketDtoSpecific.TotalPrice
                };

                products.Stock -= basketDtoSpecific.Quantity;
                _productService.Update(products);
                await _orderService.AddAsync(new Order {BasketId=basketDtoSpecific.Id, TotalPrice=basketDtoSpecific.TotalPrice });
                return Ok(order);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
