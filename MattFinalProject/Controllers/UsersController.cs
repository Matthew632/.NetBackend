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
    public class UsersController : Controller
    {
        [HttpGet("")]
        public ActionResult<UsersList> Get()
        {
            var usersRepo = new UsersRepo();
            return usersRepo.GetUsers();
        }

        [HttpPost("")]
        public ActionResult<User> Post([FromBody]UserPost userPost)
        {
            var usersRepo = new UsersRepo();
            return usersRepo.PostUser(userPost);

        }

    }
}