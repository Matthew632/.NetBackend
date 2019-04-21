using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepo userRepo;
        private ILogger logger;
        public UserController(IUserRepo userRepo, ILogger<UserController> logger)
        { this.userRepo = userRepo;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {

                var user = userRepo.GetUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            catch (Exception e)
            {
                logger.LogError("this is an error", e.Message);
                return StatusCode(500, e);
            }
            
        }
    }
}