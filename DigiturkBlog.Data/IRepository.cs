using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Data
{
    interface IRepostory<TEntity>
    {
        void Add(TEntity item);
        void Remove(TEntity item);
        void Update(TEntity item);
        List<TEntity> GetAll();
        TEntity Get(int id);
    }
}
