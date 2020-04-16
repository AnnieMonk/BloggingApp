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
    [Route("api/tags")]
    [ApiController]
    public class TagListController 
    {
        private readonly IService<MTagList, object> _service;
        public TagListController(IService<MTagList, object> service)
        {
            _service = service;
        }


        [HttpGet]
        [Produces("application/json")]
        public MTagList GetOne([FromQuery]object search)
        {

            return _service.GetOne(search);
        }
    }
}