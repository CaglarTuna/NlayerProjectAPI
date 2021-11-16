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
        private readonly IBasketService _basketService;
        public OrderController(IProductService productService, IBasketService basketService, IOrderService orderService)
        {
            _orderService = orderService;
            _productService = productService;
            _basketService = basketService;
        }
        [HttpPost]
        public async Task<IActionResult> Buy(BasketDtoSpecific basketDtoSpecific)
        {
            try
            {
                var product = await _productService.GetByIdAsync(basketDtoSpecific.pId);
                var basket = await _basketService.GetByIdAsync(basketDtoSpecific.Id);
                OrderDto order = new OrderDto
                {
                    ProductName = basketDtoSpecific.ProductName,
                    Quantity = basketDtoSpecific.Quantity,
                    PersonName = basketDtoSpecific.Name,
                    TotalPrice = basketDtoSpecific.TotalPrice
                };
                basket.Status = "Bought";
                product.Stock -= basketDtoSpecific.Quantity;
                _productService.Update(product);
                _basketService.Update(basket);
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
