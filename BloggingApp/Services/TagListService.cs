using AutoMapper;
using BloggingApp.Database;
using BloggingApp_Model;
using BloggingApp_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApp.Services
{
    public class TagListService : BaseService<MTagList, object, Database.TagList>
    {
        public TagListService(BloggingAppContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override MTagList GetOne(object search)
        {
            var query = _context.Set<TagList>().AsQueryable();

            var result = new MTagList
            {
                tags = _context.TagList.Select(tl=>tl.TagName).ToList()
            };

            return _mapper.Map<MTagList>(result);
        }
    }
}
