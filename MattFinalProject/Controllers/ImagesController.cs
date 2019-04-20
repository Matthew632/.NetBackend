﻿using System;
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