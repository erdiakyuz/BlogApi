using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Data.Entities
{
    public class ArticleTag
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        // ref
        public virtual Tag Tag { get; set; }
        public virtual Article Author { get; set; }
    }
}
