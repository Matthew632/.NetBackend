using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MattFinalProject.Models;
using MattFinalProject.Repos;
using Microsoft.AspNetCore.Mvc;

namespace MattFinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : Controller
    {
        [HttpGet("restaurant/{id}")]
        public ActionResult<Image> Get(int id)
        {
            var imageRepo = new ImageRepo();
            return new Image { Id = 1, UrlPath = "vf"};
                
        }
    }
}