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
        public List<Article> GetPost()
        {
            //string[] name = {
            //    "Panneau verre occultant",
            //    "Panneau verre occultant",
            //    "Panneau verre semi-vitré",
            //    "Panneau verre plein 2335",
            //    "Panneau anti-vent prémonté verre",
            //    "Panneau verre semi-vitré",
            //    "Panneau verre plein 2337",
            //    "Panneau verre occultant 2308",
            //    "Panneau verre semi-vitré",
            //    "Verre décoratif Diamanté 21 transparent",
            //};

            //string[] Caract = {
            //    "Pour se protéger du vent tout en profitant de la vue. Utilisable pour des vents de 76 Km/h à 105 km/h en utilisant le renfort approprié.",

            //    "Pour se protéger du vent tout en profitant de la vue.Utilisable pour des vents de 76 Km/h à 105 km/h en utilisant le renfort approprié.",

            //    "Verre sécurité 8 mm",

            //    "Brise vue et brise vent design contemporain",

            //    "Pour profiter de votre jardin ou de votre terrasse à l’abri du vent tout en gardant la vue intacte, rien ne vaut les panneaux en verre",

            //    "Verre sécurité 8 mm, PANNEAU VERRE TRANSPARENT",

            //    "Brise vue et brise vent design contemporain",

            //    "Brise vue et brise vent design contemporain",

            //    "Pour se protéger du vent tout en profitant de la vue.Utilisable pour des vents de 76 Km/h à 105 km/h en utilisant le renfort approprié.",

            //    "Verre clair et transparent pour tous types d'usage",

            //    "Verre imprimé classique, préserve l'intimité tout en laissant passer la lumière (fenêtre, cloison, mobilier ancien...)",
            //};

            //string[] detail = {
            //    "l.90 x H.180 cm",

            //    "l.90 x H.90 cm, transparent",

            //    "l.90 cm x h.180 cm",

            //    "l.120 x H.180 cm",

            //    "l.120 x H.180 cm",

            //    "l.90 x H.180 cm",

            //    "l.90 x H.90 cm",

            //    "l.120 x H.180 cm",

            //    "L.200 x l.98 cm 6 mm",

            //    "L.100 x l.100 cm 4 mm",
            //};



            //Random random = new Random();

            //for (int i = 0; i < 10; i++)
            //{
            //    int increment = i + 40;
            //    _context.Article.Add(new Article
            //    {
            //        IdCategory = 5,
            //        IdTag = 3,
            //        PhotoUrl = "images/photo" + increment + ".png",
            //        Status = random.Next(1, 4).ToString(),
            //        Price = random.Next(15, 600),
            //        Characteristic = Caract[i],
            //        Detail = detail[i],
            //        Name = name[i],
            //    });
            //    _context.SaveChanges();
            //}
            //return articles.Skip(index).Take(10).ToList();

            //if (string.IsNullOrEmpty(page))
            //{
            //    return await _context.Set<Article>().Skip(0).Take(10).ToListAsync();
            //}
            //else
            //{
            //    return await _context.Set<Article>().Skip(int.Parse(page) * 10).Take(10).ToListAsync();
            //}

            return _context.Article.ToList();
        }

        [HttpGet("NombrePage", Name = "GetNombrePage")]
        public int GetNombrePage()
        {
            return (int)Math.Ceiling((double)_context.Article.ToList().Count() / 10);
        }

        [HttpGet("category/{id}/article", Name = "GetArticleByCategory")]
        public List<Article> GetArticleByCategory(int id)
        {
            return _context.Article.Where(x => x.IdCategory == id).ToList();
        }

        [HttpGet("{id}", Name = "GetArticleById")]
        public Article GetById(int id)
        {
            return _context.Article.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpGet("Category", Name = "GetCategory")]
        public List<Category> GetCategory()
        {
            return _context.Category.ToList();
        }

        [HttpGet("Search", Name = "GetArticleFromSearchBar")]
        public List<Article> GetArticleFromSearchBar(string search)
        {
            return _context.Article
                .Where(
                x => x.Name.ToLower().Contains(search.ToLower())
                || x.Characteristic.ToLower().Contains(search.ToLower())
                || x.Detail.ToLower().Contains(search.ToLower()))
                .ToList();
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
