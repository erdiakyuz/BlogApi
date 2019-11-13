using DigiturkBlog.Data.EntityRepos;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Data
{
    public class UnitOfWork
    {
        EfCoreContext _dbContext;
        IDbContextTransaction _transaction;
        public UnitOfWork()
        {
            _dbContext = new EfCoreContext();
        }
        private AuthorRepository _authorRepository;
        public AuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(this._dbContext);
                }
                return _authorRepository;
            }
        }

        private TagRepository _tagRepository;
        public TagRepository TagRepository
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new TagRepository(this._dbContext);
                }
                return _tagRepository;
            }

        }

        private ArticleRepository _articleRepository;
        public ArticleRepository ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new ArticleRepository(this._dbContext);
                }
                return _articleRepository;
            }
        }

        public bool ApplyChanges()
        {
            bool isSuccess = false;

            _transaction = _dbContext.Database.BeginTransaction();

            try
            {
                _dbContext.SaveChanges();
                _transaction.Commit();
                isSuccess = true;
            }
            catch (Exception)
            {
                _transaction.Rollback();
                isSuccess = false;
            }
            finally
            {
                _transaction.Dispose();
            }

            return isSuccess;
        }

    }

}
