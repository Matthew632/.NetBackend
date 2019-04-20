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
    public class UserController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var userRepo = new UserRepo();
            return userRepo.GetUser(id);
        }
    }
}