using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesMakert.Data.Model;
using SalesMarket.Serv;

namespace SalesMarket.Controllers
{
    [Authorize(Policy = "Member")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post(Products products)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }
            productService.Insert(products);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Products products)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }
            productService.Update(products);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }
            productService.Delete(id);
            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}