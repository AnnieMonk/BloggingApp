using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingApp.Services;
using BloggingApp_Model;
using BloggingApp_Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingApp.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class BlogTagsController
    {
        private readonly IService<MBlogsTags, BlogPostSearchRequest> _service;
        public BlogTagsController(IService<MBlogsTags, BlogPostSearchRequest> service)
        {
            _service = service;
        }


        [HttpGet]
        [Produces("application/json")]
        public MBlogsTags GetOne([FromQuery]BlogPostSearchRequest search)
        {

            return _service.GetOne(search);
        }
    }
}