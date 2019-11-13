using DigiturkBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Data.EntityRepos
{
    public class TagRepository : BaseRepository<Tag>
    {
        public TagRepository(EfCoreContext context) : base(context)
        {
        }
    }
}
