using DigiturkBlog.Data;
using DigiturkBlog.Data.Entities;
using DigiturkBlog.Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Utility.Utilities
{
    public class AuthorUtility : IUtility<Author>
    {
        UnitOfWork _uof;
        public AuthorUtility()
        {
            _uof = new UnitOfWork();
        }
        public bool Add(Author item)
        {
            if (!string.IsNullOrEmpty(item.FirstName))
            {
                _uof.AuthorRepository.Add(item);
            }
            return _uof.ApplyChanges();
        }

        public Author Get(int id)
        {
            return _uof.AuthorRepository.Get(id);
        }

        public List<Author> GetAll()
        {
            return _uof.AuthorRepository.GetAll();

        }

        public bool Remove(Author item)
        {
            _uof.AuthorRepository.Remove(item);
            return _uof.ApplyChanges();
        }

        public bool SoftRemove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Author item)
        {
            _uof.AuthorRepository.Update(item);
            return _uof.ApplyChanges();
        }
    }
}
