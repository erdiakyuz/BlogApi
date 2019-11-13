using System;
using System.Collections.Generic;

namespace DigiturkBlog.Utility.Interfaces
{
   public interface IUtility<TEntity>
    {
        bool Add(TEntity item);
        bool Remove(TEntity item);
        bool Update(TEntity item);
        List<TEntity> GetAll();
        TEntity Get(int id);
        bool SoftRemove(int id);

    }
}
