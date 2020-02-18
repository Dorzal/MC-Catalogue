using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogue.Model
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int IdCategory { get; set; }
        public string PhotoUrl { get; set; }

        [ForeignKey("Tag")]
        public int IdTag { get; set; }
        public string Status { get; set; }
        public float Price { get; set; }
        public string Characteristic { get; set; }
        public string Detail { get; set; }
        public string Name { get; set; }
    }
}
