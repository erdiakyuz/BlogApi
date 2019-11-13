using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigiturkBlog.Data.Entities;
using DigiturkBlog.Utility.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiturkBlog.API.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        IArticleUtility _articleUtility;
        public ArticleController(IArticleUtility articleUtility)
        {
            _articleUtility = articleUtility;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var articles = _articleUtility.GetAll();
            return Ok(articles);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var article = _articleUtility.Get(id);
                if (article == null)
                {
                    return NotFound($"Invalid article Id = {id}");

                }
                return Ok(article);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPut]
        public IActionResult Put(Article article)
        {
            try
            {
                if (_articleUtility.Update(article))
                    return Ok(article);
                else
                    return NotFound("Unable the update requested article");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public IActionResult Post(Article article) {
            try
            {
                if (_articleUtility.Add(article))
                    return new StatusCodeResult(201);
                else
                    return NotFound("Invalid article");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_articleUtility.SoftRemove(id))
                    return Ok();
                else
                    return NotFound("Unable the delete requested article");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetArticlesWithAuthors")]
        public IActionResult GetArticlesWithAuthors()
        {
            try
            {
                var result =_articleUtility.GetArticlesWithAuthors();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}