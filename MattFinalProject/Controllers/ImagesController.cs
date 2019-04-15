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
        public ActionResult<ImageSummary> Get(int id)
        {
            var imageRepo = new ImageRepo();
            return imageRepo.GetImage(id);
                
        }

        [HttpPost("restaurant")]
        public ActionResult<Image> Post([FromBody]PostImage postImage)
        {
            var imageRepo = new ImageRepo();
            return imageRepo.PostImage(postImage);
                           
        }
    }
}