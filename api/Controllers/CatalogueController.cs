using Catalogue.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
            //string[] name = { "Paroi de douche à l'italienne", "Paroi de douche fixe", "Paroi de douche latérale", "Paroi de douche avec LED", "Verre de bureau", "Verre pivotant", "Verrière d'intérieur" };
            //string[] Caract = { "Associé au bois de chêne 400mx600m", "Verre d'intérieur 600mx600m", "Type atelier en aluminium" };
            //string[] detail = { "Parfait pour l'intérieur, solide et épais", "Verre trempé", "Verre de cristal" };
            //Random random = new Random();

            for (int i = 0; i <= 100; i++)
            {
                //_context.Article.Add(new Article
                //{
                //    IdCategory = random.Next(1, 4),
                //    IdTag = random.Next(1, 5),
                //    PhotoUrl = "Images/Photo" + i,
                //    Status = random.Next(1, 4).ToString(),
                //    Price = random.Next(15, 400),
                //    Characteristic = Caract[random.Next(0, Caract.Length)],
                //    Detail = detail[random.Next(0, detail.Length)],
                //    Name = name[random.Next(0, name.Length)],
                //});
                //_context.SaveChanges();
            }
            return _context.Article.ToList();
        }

        [HttpGet("{id}", Name = "GetArticleById")]
        public Article GetById(int id)
        {
            return _context.Article.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpGet("RandomArticle", Name = "GetFourRandomArticle")]
        public List<Article> GetFourRandomArticle()
        {
            Random rnd = new Random();
            List<Article> fourRandomArticle = new List<Article>();
            for (int i = 1; i <= 4; i++)
            {
                fourRandomArticle.Add(_context.Article.ToList()[rnd.Next(_context.Article.ToList().Count)]);
            }
            return fourRandomArticle;
        }

        [HttpPost]
        public void CreateArticle([FromBody]Article article)
        {
            _context.Article.Add(article);
            _context.SaveChanges();
        }

        [HttpPut]
        public void EditArticle([FromBody]Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            _context.SaveChanges();
        }

        [HttpDelete]
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
