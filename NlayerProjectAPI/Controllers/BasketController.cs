using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly IPersonService _personService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public BasketController(IPersonService personService,ICategoryService categoryService, IMapper mapper, IProductService productService, IBasketService basketService)
        {
            _personService = personService;
            _categoryService = categoryService;
            _basketService = basketService;
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("{pid}")]
        public async Task<IActionResult> GetAll(int pid)
        {
            var myBasket = await _basketService.GetBypIdAsync(pid);
            List<BasketDtoSpecific> baskets = new List<BasketDtoSpecific>();
            foreach (var item in myBasket)
            {
                BasketDtoSpecific basket = new BasketDtoSpecific()
                {
                    Id=item.Id,
                    pId = item.ProductId,
                    uId= item.PersonId,
                    Name = _personService.GetByIdAsync(item.PersonId).Result.Name,
                    SurName = _personService.GetByIdAsync(item.PersonId).Result.Surname,
                    Quantity = item.Number,
                    ProductName = _productService.GetByIdAsync(item.ProductId).Result.Name,
                    TotalPrice = _productService.GetByIdAsync(item.ProductId).Result.Price * item.Number
                };
            baskets.Add(basket);
            }

            return Ok(baskets);
        }
        [HttpPost]
        [Route("{id}/{quantity}/{mail}")]
        public async Task<IActionResult> AddBasket(int id,int quantity,string mail)
        {
            try
            {
                var products = await _productService.GetByIdAsync(id);
                var currentUser = await _personService.GetByMailAsync(mail);
                Basket basket = new Basket
                {
                    ProductId=products.Id,
                    PersonId=currentUser.Id,
                    Number=quantity,
                    Status="Pending"
                };
                try
                {
                    var x = await _basketService.AddAsync(basket);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return Ok("Success");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var basket = _basketService.GetByIdAsync(id).Result;
            _basketService.Remove(basket);

            return Ok("Deleted");
        }
    }
}
