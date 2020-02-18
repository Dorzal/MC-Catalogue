using Catalogue.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Catalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly CatalogueContext _context;

        public TagController(CatalogueContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Tag> Get()
        {
            return _context.Tag.ToList();
        }

        [HttpGet("{id}", Name = "GetTagById")]
        public Tag GetTagById(int id)
        {
            return _context.Tag.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public void CreateTag([FromBody]Tag tag)
        {
            _context.Tag.Add(tag);
            _context.SaveChanges();
        }

        [HttpPut]
        public void EditTag([FromBody]Tag tag)
        {
            _context.Entry(tag).State = EntityState.Modified;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteTag(int id)
        {
            Tag tagToDelete = _context.Tag
                .Where(x => x.Id == id)
                .FirstOrDefault();

            _context.Tag.Remove(tagToDelete);
            _context.SaveChanges();
        }
    }
}