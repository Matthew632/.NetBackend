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
    public class CommunicationController : Controller
    {
        private IUsersRepo usersRepo;
        public CommunicationController(IUsersRepo usersRepo)
        {
            this.usersRepo = usersRepo;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
                var user = usersRepo.GetUser(id);
                return user;
            }

        [HttpGet("")]
        public ActionResult<UsersList> Get()
        {
            var users = usersRepo.GetUsers();
            return users;
        }

        [HttpPost("")]
        public ActionResult<User> Post([FromBody]UserPost userPost)
        {
            var user = usersRepo.PostUser(userPost);
            return user;

        }

    }
}