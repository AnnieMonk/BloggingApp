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
    public class BlogsTagsService : BaseCRUDService<MBlogsTags, BlogPostSearchRequest, Database.BlogsTags, object, object>
    {
        public BlogsTagsService(BloggingAppContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override MBlogsTags GetOne(BlogPostSearchRequest search)
        {
            var query = _context.Set<BlogPost>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Tag))
            {
                var tagId = _context.TagList.Where(i => i.TagName == search.Tag).Select(i => i.TagListId).FirstOrDefault();
                var blogTags = _context.BlogsTags.Where(i => i.TagListId == tagId).Select(i => i.BlogPostId).ToList();

                query = query.Where(i => blogTags.Contains(i.BlogPostId));

            }

            var result = new MBlogsTags
            {
                blogPosts = query
                    .Select(bp => new MBlogPost
                    {
                        Slug = bp.Slug,
                        Title = bp.Title,
                        Description = bp.Description,
                        Body = bp.Body,
                        CreatedAt = bp.CreatedAt,
                        UpdatedAt = bp.UpdatedAt,
                        tagsList = _context.BlogsTags.Where(j => j.BlogPostId == bp.BlogPostId).Select(j => j.TagList.TagName).ToList()
                    }).OrderBy(bp=>bp.CreatedAt).ToList(),
                PostCount = query.Count()
            };

            return _mapper.Map<MBlogsTags>(result);
        }

    }
}
