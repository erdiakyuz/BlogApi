using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Data.Entities
{
    public class AuthorArticleRequestModel
    {
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }

    }
}
