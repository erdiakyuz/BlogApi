using DigiturkBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Data.EntityRepos
{
    public class AuthorRepository : BaseRepository<Author>
    {
        public AuthorRepository(EfCoreContext context) : base(context)
        {
        }
    }
}
