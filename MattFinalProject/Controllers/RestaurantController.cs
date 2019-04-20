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
    public class RestaurantController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<ResSummary> Get(int id)
        {
            var restaurantRepo = new RestaurantRepo();
            return restaurantRepo.GetRestaurant(id);
        }

    }
}