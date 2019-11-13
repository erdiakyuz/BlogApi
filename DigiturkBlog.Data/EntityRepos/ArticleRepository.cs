using DigiturkBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Data.EntityRepos
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(EfCoreContext context) : base(context)
        {
        }

        public void Add(Article item)
        {
            throw new NotImplementedException();
        }
    }
}
