using Catalogue.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Catalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CatalogueContext _context;

        public CategoryController(CatalogueContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Category> Get()
        {
            return _context.Category.ToList();
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public Category GetCategoryById(int id)
        {
            return _context.Category.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public void CreateCategory([FromBody]Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
        }

        [HttpPut]
        public void EditCategory([FromBody]Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCategory(int id)
        {
            Category categoryToDelete = _context.Category
                .Where(x => x.Id == id)
                .FirstOrDefault();

            _context.Category.Remove(categoryToDelete);
            _context.SaveChanges();
        }
    }
}