using Catalogue.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Catalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private readonly CatalogueContext _context;

        public CatalogueController(CatalogueContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Article> Get()
        {
            return _context.Article.ToList();
        }

        [HttpPost("{article}", Name = "CreateArticle")]
        public void CreateArticle([FromBody]Article article)
        {
            _context.Article.Add(article);
            _context.SaveChanges();
        }

        [HttpPut("{article}", Name = "UpdateArticle")]
        public void EditArticle([FromBody]Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            _context.SaveChanges();
        }

        [HttpDelete("{id}", Name = "DeleteArticle")]
        public void DeleteArticle(int id)
        {
            Article articleToDelete = _context.Article
                .Where(x => x.Id == id)
                .FirstOrDefault();

            _context.Article.Remove(articleToDelete);
            _context.SaveChanges();
        }
    }
}
