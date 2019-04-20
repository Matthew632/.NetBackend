using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Repos;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : Controller
    {
        [HttpGet("")]
        public ActionResult<ResList> Get()
        {
            var resTwoRepo = new ResTwoRepo();
            return resTwoRepo.GetRestaurants();
        }
    }
}