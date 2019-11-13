using DigiturkBlog.Data;
using DigiturkBlog.Data.Entities;
using DigiturkBlog.Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiturkBlog.Utility.Utilities
{
    public class ArticleUtility : IArticleUtility
    {
        UnitOfWork _uof;
        public ArticleUtility()
        {
            _uof = new UnitOfWork();
        }
        public bool Add(Article item)
        {
            _uof.ArticleRepository.Add(item);
            return _uof.ApplyChanges();
        }

        public Article Get(int id)
        {
            return _uof.ArticleRepository.Get(id);
        }

        public List<Article> GetAll()
        {
            return _uof.ArticleRepository.GetAll().Where(x => x.IsActive == true).ToList();
        }

        public bool SoftRemove(int id)
        {
            var tobeDeleteItem = _uof.ArticleRepository.Get(id);
            tobeDeleteItem.IsActive = false;
            _uof.ArticleRepository.Update(tobeDeleteItem);
            return _uof.ApplyChanges();
        }
        public bool Remove(Article item)
        {
            _uof.ArticleRepository.Remove(item);
            return _uof.ApplyChanges();
        }
        public bool Update(Article item)
        {
            _uof.ArticleRepository.Update(item);
            return _uof.ApplyChanges();
        }

        public List<AuthorArticleRequestModel> GetArticlesWithAuthors()
        {
            var authors = _uof.AuthorRepository.GetAll().ToList();
            var articles = _uof.ArticleRepository.GetAll().ToList();

            var results = (from author in authors
                           join article in articles
                            on author.Id equals article.Id
                           select new AuthorArticleRequestModel
                           {
                               ArticleContent = article.Content,
                               ArticleTitle = article.Title,
                               AuthorFirstName = author.FirstName,
                               AuthorLastName = author.LastName,
                               AuthorId = author.Id
                           }).ToList();
            return results;
        }
    }
}
