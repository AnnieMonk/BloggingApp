using System;
using System.Collections.Generic;

namespace BloggingApp.Database
{
    public partial class BlogPost
    {
        public BlogPost()
        {
            BlogsTags = new HashSet<BlogsTags>();
        }

        public int BlogPostId { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<BlogsTags> BlogsTags { get; set; }
    }
}
