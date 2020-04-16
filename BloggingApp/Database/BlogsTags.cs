using System;
using System.Collections.Generic;

namespace BloggingApp.Database
{
    public partial class BlogsTags
    {
        public int BlogsTagsId { get; set; }
        public int BlogPostId { get; set; }
        public int TagListId { get; set; }

        public virtual BlogPost BlogPost { get; set; }
        public virtual TagList TagList { get; set; }
    }
}
