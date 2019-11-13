using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Data.Entities
{
    public class Author 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<Article> Articles { get; set; }
    }
}
