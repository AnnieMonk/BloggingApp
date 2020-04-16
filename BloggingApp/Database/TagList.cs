using System;
using System.Collections.Generic;

namespace BloggingApp.Database
{
    public partial class TagList
    {
        public TagList()
        {
            BlogsTags = new HashSet<BlogsTags>();
        }

        public int TagListId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<BlogsTags> BlogsTags { get; set; }
    }
}
