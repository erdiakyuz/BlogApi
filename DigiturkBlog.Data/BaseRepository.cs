using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DigiturkBlog.Data
{
    public abstract class BaseRepository<TEntity> : IRepostory<TEntity> where TEntity : class
    {
        private EfCoreContext _context;
        public BaseRepository(EfCoreContext context)
        {
            _context = context;
        }

        public void Add(TEntity item)
        {
            _context.Entry<TEntity>(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity item)
        {
            _context.Entry<TEntity>(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Update(TEntity item)
        {
            _context.Entry<TEntity>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
