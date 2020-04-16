using BloggingApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace BloggingApp.Services
{
    public class BaseService<TModel, TSearch, TDatabase> : IService<TModel, TSearch> where TDatabase : class
    {
        protected readonly BloggingAppContext _context;
        protected readonly IMapper _mapper;
        public BaseService(BloggingAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
           
        }
        public virtual TModel GetOne(TSearch search)
        {
            var list = _context.Set<TDatabase>().FirstOrDefault();

            return _mapper.Map<TModel>(list);
        }
        public virtual TModel GetBySlug(string slug)
        {
            //this needs to be overriden
            var entity = _context.Set<TDatabase>();

            return _mapper.Map<TModel>(entity);
        }
    }
}
