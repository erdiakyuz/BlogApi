using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Data.Entities
{
    public class Article 
    {
        //public Article()
        //{
        //    Author = new Author();
        //}
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Author Author { get; set; }
    }
}
