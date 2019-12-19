using Catalogue.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Catalogue.Controllers
{
    [Route("api/[controller]")]
    public class CatalogueController : ControllerBase
    {
        [HttpGet]
        public List<Article> GetCatalogue()
        {
            using (CatalogueContext db = new CatalogueContext())
            {
                return db.Article
                    .ToList();
            }
        }

        [HttpPost("{article}", Name = "CreateArticle")]
        public void CreateArticle([FromBody]Article article)
        {
            using (CatalogueContext db = new CatalogueContext())
            {
                if (ModelState.IsValid)
                {
                    db.Set<Article>().Add(article);
                    db.SaveChanges();
                }
            }
        }

        [HttpPut("{article}", Name = "UpdateArticle")]
        public void UpdateArticle([FromBody]Article article)
        {
            using (CatalogueContext db = new CatalogueContext())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        [HttpDelete("{id}", Name = "DeleteArticle")]
        public void DeleteArticle(string id)
        {
            using (CatalogueContext db = new CatalogueContext())
            {
                if (ModelState.IsValid)
                {
                    db.Remove(db
                        .Article
                        .First(c => c.Id == id));
                    db.SaveChanges();
                }
            }
        }
    }
}