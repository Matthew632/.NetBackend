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
        private ICommunicationRepo communicationRepo;
        public CommunicationController(ICommunicationRepo communicationRepo)
        {
            this.communicationRepo = communicationRepo;
        }

        [HttpGet("")]
        public ActionResult<Helper> Get()
        {
                return communicationRepo.GetHelper();
            }

        [HttpPatch("")]
        public ActionResult<Helper> Patch([FromBody]PatchHelper patchHelper)
        {
            return communicationRepo.HelperPatch(patchHelper);
        }
    }
}