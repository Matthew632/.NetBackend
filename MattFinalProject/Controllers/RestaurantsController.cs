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
        private readonly IRestaurantsRepo restaurantsRepo;

        public RestaurantsController(IRestaurantsRepo restaurantsRepo)
        {
            this.restaurantsRepo = restaurantsRepo;
        }

        [HttpGet("")]
        public ActionResult<ResList> Get()
        {
            return restaurantsRepo.GetRestaurants();
        }

        [HttpGet("{id}")]
        public ActionResult<ResSummary> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return restaurantsRepo.GetRestaurant(id);
        }

        [HttpPost("")]
        public ActionResult<ResSummary> Post([FromBody]ResPost resPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return restaurantsRepo.PostRestaurant(resPost);

        }

        [HttpPatch("{id}")]
        public ActionResult<ResSummary> Patch([FromRoute] int id, [FromBody]ResPatch resPatch)
        { return Ok(); }



    }
}