using DigiturkBlog.Data;
using DigiturkBlog.Data.Entities;
using DigiturkBlog.Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Utility.Utilities
{
    public class TagUtility : IUtility<Tag>
    {
        UnitOfWork _uof;
        public TagUtility()
        {
            _uof = new UnitOfWork();
        }
        public bool Add(Tag item)
        {
            if (!string.IsNullOrEmpty(item.Name))
            {
                _uof.TagRepository.Add(item);
            }
            return _uof.ApplyChanges();
        }

        public Tag Get(int id)
        {
            return _uof.TagRepository.Get(id);
        }

        public List<Tag> GetAll()
        {
            return _uof.TagRepository.GetAll();

        }

        public bool Remove(Tag item)
        {
            _uof.TagRepository.Remove(item);
            return _uof.ApplyChanges();
        }

        public bool SoftRemove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Tag item)
        {
            _uof.TagRepository.Update(item);
            return _uof.ApplyChanges();
        }
    }
}
