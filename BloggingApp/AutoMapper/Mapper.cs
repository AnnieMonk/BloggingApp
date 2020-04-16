using AutoMapper;
using BloggingApp.Database;
using BloggingApp_Model;
using BloggingApp_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApp.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<BlogPost, MBlogPost>().ReverseMap();
            CreateMap<BlogPost, BlogPostInsertRequest>().ReverseMap();
            CreateMap<BlogPost, BlogPostUpdateRequest>().ReverseMap();
            CreateMap<BlogsTags, MBlogsTags>().ReverseMap();
            CreateMap<TagList, MTagList>().ReverseMap();
           

        }
    }
}
