
using DigiturkBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Utility.Interfaces
{
    public interface IArticleUtility : IUtility<Article>
    {
        List<AuthorArticleRequestModel> GetArticlesWithAuthors();
    }
}
