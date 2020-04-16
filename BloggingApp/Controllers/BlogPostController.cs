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
    [Route("api/post")]
    [ApiController]
    public class BlogPostController
    {
        private readonly ICRUDService<MBlogPost, BlogPostSearchRequest, BlogPostInsertRequest, BlogPostUpdateRequest> _service = null;

        public BlogPostController(ICRUDService<MBlogPost, BlogPostSearchRequest, BlogPostInsertRequest, BlogPostUpdateRequest> service) 
        {
            _service = service;
        }

        [HttpGet("{slug}")]
        [Produces("application/json")]
        public MBlogPost GetBySlug(string slug)
        {
            return _service.GetBySlug(slug);
        }

        [HttpPost]
        [Consumes("application/json")]
        public MBlogPost Insert(BlogPostInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{slug}")]
        [Consumes("application/json")]
        public MBlogPost Update(string slug, [FromBody]BlogPostUpdateRequest request)
        {
            return _service.Update(slug, request);
        }
        [HttpDelete("{slug}")]
        [Consumes("application/json")]
        public bool Delete(string slug)
        {
            return _service.Delete(slug);
        }
    }
}