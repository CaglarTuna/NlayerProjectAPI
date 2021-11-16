using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Web.ApiServices;
using NLayerProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace NLayerProject.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly BasketApiService _basketApiService;
        private readonly PersonApiService _personApiService;
        private readonly IMapper _mapper;

        public BasketController(ProductApiService productApiService,PersonApiService personApiService,BasketApiService basketApiService,IMapper mapper)
        {
            _personApiService = personApiService;
            _basketApiService = basketApiService;
            _productApiService = productApiService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> MyBasket()
        {
            var currentUser = await _personApiService.Get(User.Identity.Name);
            var myBasket = await _basketApiService.GetAllByPidAsync(currentUser.Id);
            return View(_mapper.Map<IEnumerable<BasketDtoSpecific>>(myBasket));
        }
        [Route("{id}/{quantity}")]
        public async Task<IActionResult> Add(int id,int quantity)
        {
            var addedProduct = await  _productApiService.GetByIdAsync(id);
            var currentUserId = await _personApiService.Get(User.Identity.Name);
            BasketDto basketDto = new BasketDto
            {
                PersonId = currentUserId.Id,
                ProductId = addedProduct.Id,
                Number = quantity
            };
            return View();
        }
        [HttpPost]
        public IActionResult Add(int id,string a)
        {
            return View();
        }
        [HttpPut]
        public IActionResult Update()
        {
            return View();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            return RedirectToAction("MyBasket");
        }
    }
}
