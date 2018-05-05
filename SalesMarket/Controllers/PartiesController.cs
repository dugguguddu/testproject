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
    [Authorize("Member")]
    public class PartiesController : Controller
    {
        private IPartiesService partiesService;
        public PartiesController(IPartiesService service)
        {
            partiesService = service;
        }

        [Route("party")]
        [HttpGet]
        public IActionResult Get()
        {
            var parties =  partiesService.GetAll();
            return Ok(parties);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Parties parties)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }
            partiesService.Insert(parties);
            return Ok(parties);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Parties parties)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }
            partiesService.Update(parties);
            return Ok(parties);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}