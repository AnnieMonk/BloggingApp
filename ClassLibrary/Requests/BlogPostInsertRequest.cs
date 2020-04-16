using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloggingApp_Model.Requests
{
    public class BlogPostInsertRequest
    {
        
        [Required]
        
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Body { get; set; }
        public List<string> Tags { get; set; } = new List<string>();

    }
}
