
using AutoMapper;
using BloggingApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApp.Services
{
    public class BaseCRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> :
        BaseService<TModel, TSearch, TDatabase>,
        ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase : class
    {
        public BaseCRUDService(BloggingAppContext context, IMapper mapper) : base(context, mapper) { }
        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);

            _context.Set<TDatabase>().Add(entity);
            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(string slug, TUpdate request)
        {
            var entity = _context.Set<TDatabase>().Find(slug);
            _context.Set<TDatabase>().Attach(entity);
            _context.Set<TDatabase>().Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }
        public virtual bool Delete(string slug)
        {
            if (slug != null)
            {
                var entity = _context.Set<TDatabase>().Find(slug);
                _context.Set<TDatabase>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
