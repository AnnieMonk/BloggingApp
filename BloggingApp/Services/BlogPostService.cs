using AutoMapper;
using BloggingApp.Database;
using BloggingApp_Model;
using BloggingApp_Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingApp.Extensions;

namespace BloggingApp.Services
{
    public class BlogPostService : BaseCRUDService<MBlogPost, BlogPostSearchRequest, BlogPost, BlogPostInsertRequest, BlogPostUpdateRequest>
    {
        public BlogPostService(BloggingAppContext context, IMapper mapper) : base(context, mapper)
        {
        }
      
        public override MBlogPost GetBySlug(string slug)
        {
            var query = _context.Set<BlogPost>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(slug))
            {
                query = query.Where(i => i.Slug == slug);
            }

            var result = query
                .Select(i => new MBlogPost
                {
                    Slug = i.Slug,
                    Title = i.Title,
                    Description = i.Description,
                    Body = i.Body,
                    CreatedAt = i.CreatedAt,
                    UpdatedAt = i.UpdatedAt,
                    tagsList = _context.BlogsTags.Where(j => j.BlogPostId == i.BlogPostId).Select(j => j.TagList.TagName).ToList()

                }).FirstOrDefault();

            return _mapper.Map<MBlogPost>(result);

        }

        public override MBlogPost Insert(BlogPostInsertRequest request)
        {
            var entity = _mapper.Map<BlogPost>(request);

            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            var slug = SlugifyExtension.Slugify(request.Title);
            
            if(_context.BlogPost.Any(p => p.Slug == slug)){
                var i = 1;
                while (_context.BlogPost.Any(p => p.Slug == string.Concat(slug, "-", i.ToString())))
                {
                    i++;
                }
                slug = string.Concat(slug, "-", i.ToString());
            }
            entity.Slug = slug;
            _context.Set<BlogPost>().Add(entity);
            _context.SaveChanges();

            if (request.Tags != null)
            {
                foreach (var x in request.Tags)
                {

                    var tag = _context.TagList.Where(i => i.TagName == x).FirstOrDefault();
                    var blogsTags = new BlogsTags();

                    if (tag == null)
                    {
                        var newlyAdded = new TagList { TagName = x };
                        _context.Set<TagList>().Add(newlyAdded);
                        _context.SaveChanges();

                        blogsTags.TagListId = newlyAdded.TagListId;

                    }
                    else
                    {
                        blogsTags.TagListId = tag.TagListId;
                    }
                   
                    blogsTags.BlogPostId = entity.BlogPostId;
                   
                    _context.Set<BlogsTags>().Add(blogsTags);
                }
            }
            _context.SaveChanges();

            var model = new MBlogPost
            {
                Slug = entity.Slug,
                Title=entity.Title,
                Description=entity.Description,
                Body=entity.Body,
                CreatedAt=entity.CreatedAt,
                UpdatedAt=entity.UpdatedAt,
                tagsList = _context.BlogsTags.Where(i => i.BlogPostId == entity.BlogPostId).Select(i => i.TagList.TagName).ToList()
            };

            return _mapper.Map<MBlogPost>(model);
        }

        public override MBlogPost Update(string slug, BlogPostUpdateRequest request)
        {
            var entity = _context.BlogPost.Where(i => i.Slug == slug).FirstOrDefault();
            if (request.Title != null)
                entity.Slug = SlugifyExtension.Slugify(request.Title);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            var model = new MBlogPost
            {
                Slug = entity.Slug,
                Title = entity.Title,
                Description = entity.Description,
                Body = entity.Body,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = DateTime.Now,
                tagsList = _context.BlogsTags.Where(i => i.BlogPostId == entity.BlogPostId).Select(i => i.TagList.TagName).ToList()
            };
            return _mapper.Map<MBlogPost>(model);
        }

        public override bool Delete(string slug)
        {
            var entity = _context.BlogPost.Where(i => i.Slug == slug).FirstOrDefault();
            var blogTags = _context.BlogsTags.Where(i => i.BlogPostId == entity.BlogPostId).ToList();

            foreach(var bt in blogTags)
            {
                _context.Remove(bt);
            }
            _context.SaveChanges();

            _context.Remove(entity);

            _context.SaveChanges();

            return true;
        }

    }
}
