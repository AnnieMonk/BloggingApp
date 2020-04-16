using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp_Model.Requests
{
    public class BlogPostUpdateRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }
    
    }
}